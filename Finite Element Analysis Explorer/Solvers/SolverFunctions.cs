namespace Finite_Element_Analysis_Explorer
{
    using System;
    using System.Diagnostics;
    using MathNet.Numerics.LinearAlgebra;
    using Windows.UI;
    using Windows.UI.Core;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// Functions to solve the solution.
    /// </summary>
    internal static class SolverFunctions
    {
        private static readonly Stopwatch MainTimer = new Stopwatch();
        private static bool hasErrors = false;
        private static bool hasWarning = false;
        private static long stageStart;
        private static int unrestrainedDOF = 0;
        private static int restrainedDOF = 0;
        private static int totalDOF = 0;
        private static Matrix<double> k;
        private static Matrix<double> k11;
        private static Matrix<double> k12;
        private static Matrix<double> k21;
        private static Matrix<double> k22;

        private static Matrix<double> qk;
        private static Matrix<double> qu;
        private static Matrix<double> dk;
        private static Matrix<double> du;

        private static double[][] DK;
        private static double[][] DK11;
        private static double[][] DK21;

        private static double[] DQk;
        private static double[] DQu;
        private static double[] DDu;

        #region Thread Communications

        /// <summary>
        /// Adds a message to the solver display.
        /// </summary>
        /// <param name="total">Total time. The time between the start of the solve and now.</param>
        /// <param name="step">The time the step has taken.</param>
        /// <param name="message">The message to be displayed.</param>
        /// <param name="messageType">The type of message. The color that is displayed.</param>
        public static async void AddMessage(long total, long step, string message, int messageType)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                CoreDispatcherPriority.High,
                () =>
                    {
                        SolverDisplay.Current.AddMessage(total, step, message, messageType);
                    });
        }

        #endregion

        #region Preperation

        internal static async void ResetDisplayAndShowWelcomeMessage()
        {
            MainTimer.Start();
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.High,
                    () =>
                    {
                        SolverDisplay.Current.ClearMessages();
                    }
                    );

            AddMessage(MainTimer.ElapsedMilliseconds, -1, "Starting solver DoubleLUP.", 0);
            AddMessage(MainTimer.ElapsedMilliseconds, -1, "    Local matrices for elements and nodes have been created during construction stage.", 0);
        }

        internal static void ResetPropertiesForSolver()
        {
            Stopwatch TaskTimer = new Stopwatch();
            TaskTimer.Start();
            AddMessage(MainTimer.ElapsedMilliseconds, -1, "Reset solver properties.", 0);

            try
            {
                Model.Members.CurrentMember = null;
                Camera.LargestLengthRatio = 0;
                Camera.LargestAxialRatio = 0;
                hasErrors = false;


                unrestrainedDOF = 0;
                restrainedDOF = 0;
                totalDOF = 0;

                k = null;
                k11 = null;
                k12 = null;
                k21 = null;
                k22 = null;

                qk = null;
                qu = null;
                dk = null;
                du = null;

                DK = null;
                DK11 = null;
                DK21 = null;
                DQk = null;
                DQu = null;
                DDu = null;

                Model.ForceX = 0;
                Model.ForceY = 0;
                Model.ForceM = 0;
                Model.ReactionX = 0;
                Model.ReactionY = 0;
                Model.ReactionM = 0;

                Model.TotalCost = 0;
                Model.MaterialCost = 0;
                Model.NodeCost = 0;
                Model.TransportCost = 0;
                Model.ElevationCost = 0;
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
            }

            AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    Finished.", 1);

        }

        internal static void DisplayModelProperties()
        {
            AddMessage(-1, -1, "Model Properties.", 0);
            AddMessage(-1, -1, "    " + Model.Members.Count.ToString("#,###") + " Members.", 1);
            AddMessage(-1, -1, "    " + Model.Members.MembersWithLinearLoads.Count.ToString("#,###") + " Members with linear loads.", 1);
            AddMessage(-1, -1, "    " + Model.Nodes.Count.ToString("#,###") + " Nodes.", 1);
            AddMessage(-1, -1, "    " + Model.Nodes.NodesWithConstraints.Count.ToString("#,###") + " nodes with constraints.", 1);
            AddMessage(-1, -1, "    " + Model.Nodes.NodesWithNodalLoads.Count.ToString("#,###") + " nodes with nodal loads.", 1);

        }

        internal static void ShrinkModel()
        {
            stageStart = MainTimer.ElapsedMilliseconds;
            AddMessage(MainTimer.ElapsedMilliseconds, -1, "Shrinking Model. (searching for orphan nodes)", 0);

            int PreviousNodeCount = 0;
            int PostNodeCount = 0;

            try
            {
                PreviousNodeCount = Model.Nodes.Count;
                Model.Shrink();
                PostNodeCount = Model.Nodes.Count;
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(MainTimer.ElapsedMilliseconds, MainTimer.ElapsedMilliseconds - stageStart, "    ERROR!", 2);
                AddMessage(MainTimer.ElapsedMilliseconds, MainTimer.ElapsedMilliseconds - stageStart, "    " + ex.Message, 2);
            }

            AddMessage(MainTimer.ElapsedMilliseconds, -1, "    Started with " + PreviousNodeCount + " nodes.", 1);
            AddMessage(MainTimer.ElapsedMilliseconds, -1, "    Ended with " + PostNodeCount + " nodes.", 1);
            AddMessage(MainTimer.ElapsedMilliseconds, -1, "    Removed " + (PreviousNodeCount - PostNodeCount) + " nodes.", 1);

            AddMessage(MainTimer.ElapsedMilliseconds, MainTimer.ElapsedMilliseconds - stageStart, "    Finished.", 1);
        }

        internal static async void SaveFile()
        {
            stageStart = MainTimer.ElapsedMilliseconds;
            AddMessage(MainTimer.ElapsedMilliseconds, -1, "Saving File.", 0);
            await FileManager.SaveFile();
            AddMessage(MainTimer.ElapsedMilliseconds, MainTimer.ElapsedMilliseconds - stageStart, "    Finished.", 1);
        }

        #endregion

        internal static void AssignCodeNumbersToDegreesOfFreedom()
        {
            Stopwatch taskTimer = new Stopwatch();
            taskTimer.Start();
            AddMessage(MainTimer.ElapsedMilliseconds, -1, "Assigning code numbers to the degrees of freedom.", 0);
            AddMessage(-1, -1, "    Each node has three degrees of freedom.", 1);

            try
            {
                //Assign code numbers to the unrestrained first.
                foreach (var Item in Model.Nodes)
                {
                    if (Item.Value.Constraints.X == false)
                    {
                        Item.Value.Codes = new Codes(unrestrainedDOF, Item.Value.Codes.Y, Item.Value.Codes.M);
                        unrestrainedDOF++;
                    }
                    if (Item.Value.Constraints.Y == false)
                    {
                        Item.Value.Codes = new Codes(Item.Value.Codes.X, unrestrainedDOF, Item.Value.Codes.M);
                        unrestrainedDOF++;
                    }
                    if (Item.Value.Constraints.M == false)
                    {
                        Item.Value.Codes = new Codes(Item.Value.Codes.X, Item.Value.Codes.Y, unrestrainedDOF);
                        unrestrainedDOF++;
                    }
                }

                //Then assign code number to the remaining.
                foreach (var Item in Model.Nodes)
                {
                    if (Item.Value.Constraints.X == true)
                    {
                        Item.Value.Codes = new Codes(unrestrainedDOF + restrainedDOF, Item.Value.Codes.Y, Item.Value.Codes.M);
                        restrainedDOF++;
                    }
                    if (Item.Value.Constraints.Y == true)
                    {
                        Item.Value.Codes = new Codes(Item.Value.Codes.X, unrestrainedDOF + restrainedDOF, Item.Value.Codes.M);
                        restrainedDOF++;
                    }
                    if (Item.Value.Constraints.M == true)
                    {
                        Item.Value.Codes = new Codes(Item.Value.Codes.X, Item.Value.Codes.Y, unrestrainedDOF + restrainedDOF);
                        restrainedDOF++;
                    }
                }
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(MainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(MainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
            }

            AddMessage(-1, -1, "    Total unrestrained degrees of freedom " + unrestrainedDOF + ".", 1);
            AddMessage(-1, -1, "    Total restrained degrees of freedom " + restrainedDOF + ".", 1);
            AddMessage(MainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        internal static void CreateSuperpositionValuesFromSegmentsToNodes()
        {
            Stopwatch TaskTimer = new Stopwatch();
            TaskTimer.Start();
            AddMessage(MainTimer.ElapsedMilliseconds, -1, "Superposition Stage One.", 0);

            try
            {
                foreach (var NodeItem in Model.Nodes)
                {
                    NodeItem.Value.SuperPosition = new Finite_Element_Analysis_Explorer.NodalLoad(0, 0, 0);
                    NodeItem.Value.SuperPosition = new Finite_Element_Analysis_Explorer.NodalLoad(0, 0, 0);
                }
                foreach (var Item in Model.Members)
                {
                    foreach (var nextSegment in Item.Value.Segments)
                    {
                        nextSegment.Value.NodeNear.SuperPosition = new NodalLoad(
                            nextSegment.Value.NodeNear.SuperPosition.X + nextSegment.Value.NearSuperGlobal.X,
                            nextSegment.Value.NodeNear.SuperPosition.Y + nextSegment.Value.NearSuperGlobal.Y,
                            nextSegment.Value.NodeNear.SuperPosition.M + nextSegment.Value.NearSuperGlobal.M
                            );

                        nextSegment.Value.NodeFar.SuperPosition = new NodalLoad(
                            nextSegment.Value.NodeFar.SuperPosition.X + nextSegment.Value.FarSuperGlobal.X,
                            nextSegment.Value.NodeFar.SuperPosition.Y + nextSegment.Value.FarSuperGlobal.Y,
                            nextSegment.Value.NodeFar.SuperPosition.M + nextSegment.Value.FarSuperGlobal.M
                            );
                    }
                }
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
            }

            AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        #region Transfer from Nodes.

        internal static void GetQkFromSubNodes()
        {
            Stopwatch TaskTimer = new Stopwatch();
            TaskTimer.Start();
            AddMessage(MainTimer.ElapsedMilliseconds, -1, "Get [Qk] vector from model data.", 0);

            try
            {
                DQk = DoubleMatrix.VectorCreate(unrestrainedDOF);
                //Get the Qk matrix.
                qk = Matrix<double>.Build.Dense(unrestrainedDOF, 1);
                for (int j = 0; j < unrestrainedDOF; j++)
                {
                    foreach (var Item in Model.Nodes)
                    {

                        if (Item.Value.Codes.X == j)
                        {
                            qk[j, 0] = (double)Item.Value.Load.X + (double)Item.Value.SuperPosition.X;

                            DQk[j] = (double)Item.Value.Load.X + (double)Item.Value.SuperPosition.X;
                        }
                        if (Item.Value.Codes.Y == j)
                        {
                            qk[j, 0] = (double)Item.Value.Load.Y + (double)Item.Value.SuperPosition.Y;

                            DQk[j] = (double)Item.Value.Load.Y + (double)Item.Value.SuperPosition.Y;
                        }
                        if (Item.Value.Codes.M == j)
                        {
                            qk[j, 0] = (double)Item.Value.Load.M + (double)Item.Value.SuperPosition.M;

                            DQk[j] = (double)Item.Value.Load.M + (double)Item.Value.SuperPosition.M;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
            }
            AddMessage(-1, -1, "    [Qk] vector length " + qk.RowCount.ToString("#,###"), 1);
            AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        internal static void GetQuFromSubNodes()
        {
            Stopwatch TaskTimer = new Stopwatch();
            TaskTimer.Start();
            AddMessage(MainTimer.ElapsedMilliseconds, -1, "Get [Qu] vector from model data.", 0);

            try
            {
                DQu = DoubleMatrix.VectorCreate(restrainedDOF);
                //Get the Qu matrix.
                qu = Matrix<double>.Build.Dense(restrainedDOF, 1);
                for (int j = 0; j < restrainedDOF; j++)
                {
                    foreach (var Item in Model.Nodes)
                    {
                        if (Item.Value.Codes.X == j + unrestrainedDOF)
                        {
                            qu[j, 0] = (double)Item.Value.Load.X;

                            DQu[j] = (double)Item.Value.Load.X;
                        }
                        if (Item.Value.Codes.Y == j + unrestrainedDOF)
                        {
                            qu[j, 0] = (double)Item.Value.Load.Y;

                            DQu[j] = (double)Item.Value.Load.Y;
                        }
                        if (Item.Value.Codes.M == j + unrestrainedDOF)
                        {
                            qu[j, 0] = (double)Item.Value.Load.M;

                            DQu[j] = (double)Item.Value.Load.M;
                        }
                    }
                }
                AddMessage(-1, -1, "    [Qu] vector length " + qu.RowCount.ToString("#,###"), 1);
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
            }
            AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        internal static void GetDkFromSubNodes()
        {
            Stopwatch TaskTimer = new Stopwatch();
            TaskTimer.Start();
            AddMessage(MainTimer.ElapsedMilliseconds, -1, "Get [Dk] vector from model data.", 0);

            try
            {
                //Get the Qu matrix.
                dk = Matrix<double>.Build.Dense(restrainedDOF, 1);
                for (int j = 0; j < restrainedDOF; j++)
                {
                    foreach (var Item in Model.Nodes)
                    {
                        if (Item.Value.Codes.X == j + unrestrainedDOF)
                        {
                            dk[j, 0] = (double)Item.Value.Displacement.X;
                        }
                        if (Item.Value.Codes.Y == j + unrestrainedDOF)
                        {
                            dk[j, 0] = (double)Item.Value.Displacement.Y;
                        }
                        if (Item.Value.Codes.M == j + unrestrainedDOF)
                        {
                            dk[j, 0] = (double)Item.Value.Displacement.M;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
            }

            AddMessage(-1, -1, "    Dk " + dk.ColumnCount + " " + dk.RowCount, 1);
            AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        internal static void GetDuFromSubNodes()
        {
            Stopwatch TaskTimer = new Stopwatch();
            TaskTimer.Start();
            AddMessage(MainTimer.ElapsedMilliseconds, -1, "Get [Du] vector from model data.", 0);

            try
            {
                DDu = DoubleMatrix.VectorCreate(unrestrainedDOF);
                //Get the Qk vector.
                du = Matrix<double>.Build.Dense(unrestrainedDOF, 1, 0);
                for (int j = 0; j < unrestrainedDOF; j++)
                {
                    foreach (var Item in Model.Nodes)
                    {
                        if (Item.Value.Codes.X == j)
                        {
                            du[j, 0] = (double)Item.Value.Displacement.X;

                            DDu[j] = (double)Item.Value.Displacement.X;
                        }
                        if (Item.Value.Codes.Y == j)
                        {
                            du[j, 0] = (double)Item.Value.Displacement.Y;

                            DDu[j] = (double)Item.Value.Displacement.Y;
                        }
                        if (Item.Value.Codes.M == j)
                        {
                            du[j, 0] = (double)Item.Value.Displacement.M;

                            DDu[j] = (double)Item.Value.Displacement.M;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
            }
            AddMessage(-1, -1, "    Du " + du.ColumnCount + " " + du.RowCount, 1);
            AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        #endregion

        #region Assemble Matrices.

        internal static void AssembleStiffnessMatrix()
        {
            Stopwatch TaskTimer = new Stopwatch();
            TaskTimer.Start();
            AddMessage(MainTimer.ElapsedMilliseconds, -1, "Assembling global stiffness matrix. {K}", 0);

            try
            {
                //Assemble the stiffness matrix K.
                totalDOF = Model.Nodes.Count * 3;
                DK = DoubleMatrix.MatrixCreate(totalDOF, totalDOF);
                k = Matrix<double>.Build.Dense(totalDOF, totalDOF);
                int X = 0;
                int Y = 0;

                foreach (var Item in Model.Members)
                {
                    foreach (var nextItem in Item.Value.Segments)
                    {
                        int[] enf = { nextItem.Value.NodeNear.Codes.X, nextItem.Value.NodeNear.Codes.Y, nextItem.Value.NodeNear.Codes.M, nextItem.Value.NodeFar.Codes.X, nextItem.Value.NodeFar.Codes.Y, nextItem.Value.NodeFar.Codes.M };
                        for (int i = 0; i < 6; i++)
                        {
                            for (int j = 0; j < 6; j++)
                            {
                                X = enf[i];
                                Y = enf[j];
                                k[Y, X] = k[Y, X] + (double)nextItem.Value.KMatrix[j, i];

                                DK[Y][X] = DK[Y][X] + (double)nextItem.Value.KMatrix[j, i];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
            }
            AddMessage(-1, -1, "    Matrix size is " + totalDOF.ToString("#,###") + " x " + totalDOF.ToString("#,###") + ".", 1);
            AddMessage(-1, -1, "    Total number of elements within matrix is " + (totalDOF * totalDOF).ToString("#,###") + ".", 1);
            AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        internal static void AssembleKMatrices()
        {
            Stopwatch TaskTimer = new Stopwatch();
            TaskTimer.Start();
            AddMessage(MainTimer.ElapsedMilliseconds, -1, "Divide K matrix into four matries {K11}, {K12}, {K21}, {K22}.", 0);

            try
            {
                //Resize and fill the K** Matrices.
                k11 = Matrix<double>.Build.Dense(unrestrainedDOF, unrestrainedDOF);
                for (int j = 0; j < k11.RowCount; j++)
                {
                    for (int i = 0; i < k11.ColumnCount; i++)
                    {
                        k11[j, i] = k[j, i];
                    }
                }
                AddMessage(-1, -1, "    {K11} " + k11.ColumnCount.ToString("#,###") + " x " + k11.RowCount.ToString("#,###") + " = " + (k11.ColumnCount * k11.RowCount).ToString("#,###") + " elements.", 1);


                k12 = Matrix<double>.Build.Dense(unrestrainedDOF, restrainedDOF);
                for (int j = 0; j < k12.RowCount; j++)
                {
                    for (int i = 0; i < k12.ColumnCount; i++)
                    {
                        k12[j, i] = k[j, i + unrestrainedDOF];
                    }
                }
                AddMessage(-1, -1, "    {K12} " + k12.ColumnCount.ToString("#,###") + " x " + k12.RowCount.ToString("#,###") + " = " + (k12.ColumnCount * k12.RowCount).ToString("#,###") + " elements.", 1);

                k21 = Matrix<double>.Build.Dense(restrainedDOF, unrestrainedDOF);
                for (int j = 0; j < k21.RowCount; j++)
                {
                    for (int i = 0; i < k21.ColumnCount; i++)
                    {
                        k21[j, i] = k[j + unrestrainedDOF, i];
                    }
                }
                AddMessage(-1, -1, "    {K21} " + k21.ColumnCount.ToString("#,###") + " x " + k21.RowCount.ToString("#,###") + " = " + (k21.ColumnCount * k21.RowCount).ToString("#,###") + " elements.", 1);



                k22 = Matrix<double>.Build.Dense(restrainedDOF, restrainedDOF);
                for (int j = 0; j < k22.RowCount; j++)
                {
                    for (int i = 0; i < k22.ColumnCount; i++)
                    {
                        k22[j, i] = k[j + unrestrainedDOF, i + unrestrainedDOF];
                    }
                }
                AddMessage(-1, -1, "    {K22} " + k22.ColumnCount.ToString("#,###") + " x " + k22.RowCount.ToString("#,###") + " = " + (k22.ColumnCount * k22.RowCount).ToString("#,###") + " elements.", 1);



                DK11 = DoubleMatrix.MatrixCreate(unrestrainedDOF, unrestrainedDOF);
                for (int j = 0; j < DK11.Length; j++)
                {
                    for (int i = 0; i < DK11[1].Length; i++)
                    {
                        DK11[j][i] = (double)k[j, i];
                    }
                }

                DK21 = DoubleMatrix.MatrixCreate(restrainedDOF, unrestrainedDOF);
                for (int j = 0; j < DK21.Length; j++)
                {
                    for (int i = 0; i < DK21[1].Length; i++)
                    {
                        DK21[j][i] = (double)k[j, i];
                    }
                }

                //K is no longer nessacary so remove from memory to improve performance.
                k = null;

                // Dimension Du to prevent errors.
                du = Matrix<double>.Build.Dense(unrestrainedDOF, 1, 0);


            }

            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
            }
            AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        #endregion

        #region Solve

        internal static void SolveForDu()
        {
            //Solve for the displacements.
            Stopwatch TaskTimer = new Stopwatch();
            TaskTimer.Start();
            AddMessage(MainTimer.ElapsedMilliseconds, -1, "Solve For Du", 0);
            //AddMessage(-1, -1, "    Du " + Du.ColumnCount + " " + Du.RowCount,1);
            //AddMessage(-1, -1, "    Qk " + Qk.ColumnCount + " " + Qk.RowCount,1);
            //AddMessage(-1, -1, "    K11 " + K11.ColumnCount + " " + K11.RowCount,1);

            try
            {
                du = k11.Inverse() * qk;
                DDu = DoubleMatrix.SystemSolve(DK11, DQk);
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
            }

            AddMessage(-1, -1, "    Du " + du.ColumnCount + " " + du.RowCount, 1);
            AddMessage(-1, -1, "    Qk " + qk.ColumnCount + " " + qk.RowCount, 1);
            AddMessage(-1, -1, "    K11 " + k11.ColumnCount + " " + k11.RowCount, 1);
            AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        internal static void SolveForQu()
        {
            //Solve for the reactions.
            Stopwatch TaskTimer = new Stopwatch();
            TaskTimer.Start();
            AddMessage(MainTimer.ElapsedMilliseconds, -1, "Solve For Qu", 0);

            try
            {
                qu = k21 * du;
                DQu = DoubleMatrix.MatrixVectorProduct(DK21, DDu);
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
            }
            AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        #endregion

        #region Transfer to Nodes.

        internal static void SetQkToSubNodes()
        {
            Stopwatch TaskTimer = new Stopwatch();
            TaskTimer.Start();
            AddMessage(MainTimer.ElapsedMilliseconds, -1, "Set [Qk] vector from model data.", 0);

            try
            {
                //Set the Qk matrix.
                for (int j = 0; j < unrestrainedDOF; j++)
                {
                    foreach (var Item in Model.Nodes)
                    {
                        if (Item.Value.Codes.X == j)
                        {
                            Item.Value.JointLoad = new NodalLoad((decimal)qk[j, 0], Item.Value.JointLoad.Y, Item.Value.JointLoad.M);
                        }
                        if (Item.Value.Codes.Y == j)
                        {
                            Item.Value.JointLoad = new NodalLoad(Item.Value.JointLoad.X, (decimal)qk[j, 0], Item.Value.JointLoad.M);
                        }
                        if (Item.Value.Codes.M == j)
                        {
                            Item.Value.JointLoad = new NodalLoad(Item.Value.JointLoad.X, Item.Value.JointLoad.Y, (decimal)qk[j, 0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
            }
            AddMessage(-1, -1, "    [Qk] vector length " + qk.RowCount.ToString("#,###"), 1);
            AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        internal static void SetQuToSubNodes()
        {
            Stopwatch TaskTimer = new Stopwatch();
            TaskTimer.Start();
            AddMessage(MainTimer.ElapsedMilliseconds, -1, "Set [Qu] vector from model data.", 0);

            try
            {
                //Set the Qu matrix.
                for (int j = 0; j < restrainedDOF; j++)
                {
                    foreach (var Item in Model.Nodes)
                    {
                        if (Item.Value.Codes.X == j + unrestrainedDOF)
                        {
                            Item.Value.LoadReaction = new NodalLoad((decimal)qu[j, 0], Item.Value.LoadReaction.Y, Item.Value.LoadReaction.M);
                        }
                        if (Item.Value.Codes.Y == j + unrestrainedDOF)
                        {
                            Item.Value.LoadReaction = new NodalLoad(Item.Value.LoadReaction.X, (decimal)qu[j, 0], Item.Value.LoadReaction.M);
                        }
                        if (Item.Value.Codes.M == j + unrestrainedDOF)
                        {
                            Item.Value.LoadReaction = new NodalLoad(Item.Value.LoadReaction.X, Item.Value.LoadReaction.Y, (decimal)qu[j, 0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
            }
            AddMessage(-1, -1, "    [Qu] vector length " + qu.RowCount.ToString("#,###"), 1);
            AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        internal static void SetDkToSubNodes()
        {
            Stopwatch TaskTimer = new Stopwatch();
            TaskTimer.Start();
            AddMessage(MainTimer.ElapsedMilliseconds, -1, "Set [Dk] vector from model data.", 0);

            try
            {
                //Set the Dk matrix. These should be zeros as the fixed dof's are fixed.
                for (int j = 0; j < restrainedDOF; j++)
                {
                    foreach (var Item in Model.Nodes)
                    {
                        if (Item.Value.Codes.X == j + unrestrainedDOF)
                        {
                            Item.Value.Displacement = new Point((decimal)dk[j, 0], Item.Value.Displacement.Y, Item.Value.Displacement.M);
                        }
                        if (Item.Value.Codes.Y == j + unrestrainedDOF)
                        {
                            Item.Value.Displacement = new Point(Item.Value.Displacement.X, (decimal)dk[j, 0], Item.Value.Displacement.M);
                        }
                        if (Item.Value.Codes.M == j + unrestrainedDOF)
                        {
                            Item.Value.Displacement = new Point(Item.Value.Displacement.X, Item.Value.Displacement.Y, (decimal)dk[j, 0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
            }
            AddMessage(-1, -1, "    [Dk] vector length " + dk.RowCount.ToString("#,###"), 1);
            AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        /// <summary>
        /// After Solver to Du the results are to be transfered back to the vector.
        /// </summary>
        internal static void SetDuToSubNodes()
        {
            Stopwatch TaskTimer = new Stopwatch();
            TaskTimer.Start();
            AddMessage(MainTimer.ElapsedMilliseconds, -1, "Set [Du] vector from model data.", 0);

            try
            {
                for (int j = 0; j < unrestrainedDOF; j++)
                {
                    foreach (var Item in Model.Nodes)
                    {
                        if (Item.Value.Codes.X == j)
                        {
                            Item.Value.Displacement = new Point((decimal)du[j, 0], Item.Value.Displacement.Y, Item.Value.Displacement.M);
                        }
                        if (Item.Value.Codes.Y == j)
                        {
                            Item.Value.Displacement = new Point(Item.Value.Displacement.X, (decimal)du[j, 0], Item.Value.Displacement.M);
                        }
                        if (Item.Value.Codes.M == j)
                        {
                            Item.Value.Displacement = new Point(Item.Value.Displacement.X, Item.Value.Displacement.Y, (decimal)du[j, 0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
            }
            AddMessage(-1, -1, "    [Du] vector length " + du.RowCount.ToString("#,###"), 1);
            AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        #endregion

        internal static void UpdateMemberAndSegmentsFromMatrix()
        {
            Stopwatch TaskTimer = new Stopwatch();
            TaskTimer.Start();
            AddMessage(MainTimer.ElapsedMilliseconds, -1, "Update Members and Segments from Matrix.", 0);

            try
            {
                foreach (var Item in Model.Members)
                {
                    foreach (var nextSegment in Item.Value.Segments)
                    {
                        nextSegment.Value.UpdatePropertiesFromMatrix();
                    }
                    Item.Value.UpdatePropertiesFromMatrix();
                }
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
            }

            AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        internal static void CreateLengthRatioColors()
        {
            Stopwatch TaskTimer = new Stopwatch();
            TaskTimer.Start();
            AddMessage(MainTimer.ElapsedMilliseconds, -1, "Calculate Length Ratios.", 0);

            try
            {
                if (Camera.LargestLengthRatio == 0)
                {
                    foreach (var Item in Model.Members)
                    {
                        foreach (var nextSegment in Item.Value.Segments)
                        {
                            nextSegment.Value.LengthRatioColor = Color.FromArgb(255, 255, 255, 255);
                            nextSegment.Value.UpdateColor();
                        }
                    }
                }
                else
                {
                    decimal compression_ratio = 255 / Camera.LargestLengthRatio;
                    decimal tension_ratio = 255 / Camera.LargestLengthRatio;
                    byte RatioByte;

                    foreach (var Item in Model.Members)
                    {
                        foreach (var nextSegment in Item.Value.Segments)
                        {
                            if (nextSegment.Value.LengthRatio > 0)
                            {
                                int tmpValue = (int)(Math.Abs(nextSegment.Value.LengthRatio) * tension_ratio);
                                if (tmpValue > 255) { tmpValue = 255; }
                                if (tmpValue < 0) { tmpValue = 0; }
                                RatioByte = (byte)(255 - tmpValue);
                                nextSegment.Value.LengthRatioColor = Color.FromArgb(255, RatioByte, RatioByte, 255);
                            }
                            else if (nextSegment.Value.LengthRatio < 0)
                            {
                                int tmpValue = (int)(Math.Abs(nextSegment.Value.LengthRatio) * compression_ratio);
                                if (tmpValue > 255) { tmpValue = 255; }
                                if (tmpValue < 0) { tmpValue = 0; }
                                RatioByte = (byte)(255 - tmpValue);
                                nextSegment.Value.LengthRatioColor = Color.FromArgb(255, 255, RatioByte, RatioByte);
                            }
                            else
                            {
                                nextSegment.Value.LengthRatioColor = Color.FromArgb(255, 255, 255, 255);
                            }
                            nextSegment.Value.UpdateColor();
                        }
                    }
                }

                Camera.UpdateSegmentColor(1);
            }
            catch (Exception ex)
            {
                hasWarning = true;
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    ERROR!", 3);
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    " + ex.Message, 3);
            }

            AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }


        internal static void CreateAxialRatioColors()
        {
            Stopwatch TaskTimer = new Stopwatch();
            TaskTimer.Start();
            AddMessage(MainTimer.ElapsedMilliseconds, -1, "Calculate Axial Ratios.", 0);

            try
            {
                if (Camera.LargestAxialRatio == 0)
                {
                    foreach (var Item in Model.Members)
                    {
                        foreach (var nextSegment in Item.Value.Segments)
                        {
                            nextSegment.Value.AxialRatioColor = Color.FromArgb(255, 255, 255, 255);
                            nextSegment.Value.UpdateColor();
                        }
                    }
                }
                else
                {
                    decimal compression_ratio = 255 / Camera.LargestAxialRatio;
                    decimal tension_ratio = 255 / Camera.LargestAxialRatio;
                    byte RatioByte;

                    foreach (var Item in Model.Members)
                    {
                        foreach (var nextSegment in Item.Value.Segments)
                        {
                            if (nextSegment.Value.InternalLoadNearLocal.X < 0)
                            {
                                int tmpValue = (int)(Math.Abs(nextSegment.Value.InternalLoadNearLocal.X) * tension_ratio);
                                if (tmpValue > 255) { tmpValue = 255; }
                                if (tmpValue < 0) { tmpValue = 0; }
                                RatioByte = (byte)(255 - tmpValue);
                                nextSegment.Value.AxialRatioColor = Color.FromArgb(255, RatioByte, RatioByte, 255);
                            }
                            else if (nextSegment.Value.InternalLoadNearLocal.X > 0)
                            {
                                int tmpValue = (int)(Math.Abs(nextSegment.Value.InternalLoadNearLocal.X) * compression_ratio);
                                if (tmpValue > 255) { tmpValue = 255; }
                                if (tmpValue < 0) { tmpValue = 0; }
                                RatioByte = (byte)(255 - tmpValue);
                                nextSegment.Value.AxialRatioColor = Color.FromArgb(255, 255, RatioByte, RatioByte);
                            }
                            else
                            {
                                nextSegment.Value.AxialRatioColor = Color.FromArgb(255, 255, 255, 255);
                            }
                            nextSegment.Value.UpdateColor();
                        }
                    }
                }

                Camera.UpdateSegmentColor(1);
            }
            catch (Exception ex)
            {
                hasWarning = true;
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    ERROR!", 3);
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    " + ex.Message, 3);
            }
            AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        internal static void CreateNormalStressColors()
        {
            Stopwatch TaskTimer = new Stopwatch();
            TaskTimer.Start();
            AddMessage(MainTimer.ElapsedMilliseconds, -1, "Calculate Axial Ratios.", 0);

            try
            {
                if (Camera.LargestNormalStress == 0)
                {
                    foreach (var Item in Model.Members)
                    {
                        foreach (var nextSegment in Item.Value.Segments)
                        {
                            nextSegment.Value.NormalStressColor = Color.FromArgb(255, 255, 255, 255);
                            nextSegment.Value.UpdateColor();
                        }
                    }
                }
                else
                {
                    decimal compression_ratio = 255 / Camera.LargestNormalStress;
                    decimal tension_ratio = 255 / Camera.LargestNormalStress;

                    byte RatioByte;

                    foreach (var Item in Model.Members)
                    {
                        foreach (var nextSegment in Item.Value.Segments)
                        {
                            if (nextSegment.Value.NormalStress < 0)
                            {
                                int tmpValue = (int)(Math.Abs(nextSegment.Value.NormalStress) * tension_ratio);
                                if (tmpValue > 255) { tmpValue = 255; }
                                if (tmpValue < 0) { tmpValue = 0; }

                                RatioByte = (byte)(255 - tmpValue);

                                nextSegment.Value.NormalStressColor = Color.FromArgb(255, RatioByte, RatioByte, 255);
                            }
                            else if (nextSegment.Value.NormalStress > 0)
                            {
                                int tmpValue = (int)(Math.Abs(nextSegment.Value.NormalStress) * compression_ratio);
                                if (tmpValue > 255)
                                {
                                    tmpValue = 255;
                                }

                                if (tmpValue < 0)
                                {
                                    tmpValue = 0;
                                }

                                RatioByte = (byte)(255 - tmpValue);
                                nextSegment.Value.NormalStressColor = Color.FromArgb(255, 255, RatioByte, RatioByte);
                            }
                            else
                            {
                                nextSegment.Value.NormalStressColor = Color.FromArgb(255, 255, 255, 255);
                            }

                        }
                    }
                }

                Camera.UpdateSegmentColor(1);
            }
            catch (Exception ex)
            {
                hasWarning = true;
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    ERROR!", 3);
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    " + ex.Message, 3);
            }

            AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        internal static void CalculateEqulibriumValues()
        {
            Stopwatch taskTimer = new Stopwatch();
            taskTimer.Start();
            AddMessage(MainTimer.ElapsedMilliseconds, -1, "Calculate Equilibrium Values.", 0);

            try
            {
                foreach (var item in Model.Nodes.NodesWithNodalLoads)
                {
                    Model.ForceX += item.Value.Load.X;
                    Model.ForceY += item.Value.Load.Y;
                    Model.ForceM += item.Value.Load.M;
                }

                foreach (var item1 in Model.Nodes.NodesWithReactions)
                {
                    Model.ReactionX += item1.Value.LoadReaction.X;
                    Model.ReactionY += item1.Value.LoadReaction.Y;
                    Model.ReactionM += item1.Value.LoadReaction.M;
                }
            }
            catch (Exception ex)
            {
                hasWarning = true;
                AddMessage(MainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    ERROR!", 3);
                AddMessage(MainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    " + ex.Message, 3);
            }

            AddMessage(MainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        internal static void CalculateMaterials()
        {

        }

        internal static void CalculateLabour()
        {

        }

        internal static void CalculateCost()
        {
            Stopwatch TaskTimer = new Stopwatch();
            TaskTimer.Start();
            AddMessage(MainTimer.ElapsedMilliseconds, -1, "Calculate Equlibrium Values.", 0);

            try
            {
                foreach (var Item in Model.Members)
                {
                    Model.TotalCost += Item.Value.MemberCost;
                    Model.MaterialCost += Item.Value.MaterialCost;
                    Model.NodeCost += Item.Value.NodeCost;
                }
            }

            catch (Exception ex)
            {
                hasWarning = true;
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    ERROR!", 3);
                AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    " + ex.Message, 3);
            }

            AddMessage(MainTimer.ElapsedMilliseconds, TaskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        internal static async void DisplayEndMessages()
        {
            AddMessage(-1, -1, "    ", 0);
            AddMessage(MainTimer.ElapsedMilliseconds, MainTimer.ElapsedMilliseconds, "    Finished.", 0);

            if (!hasErrors)
            {
                if (Options.AutoFinishSolver)
                {

                    if (!hasWarning)
                    {
                        await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                            CoreDispatcherPriority.High,
                            () =>
                       {
                           Frame rootFrame = Window.Current.Content as Frame;
                           rootFrame.Navigate(typeof(Results));
                       });
                    }
                    else
                    {
                        await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                            CoreDispatcherPriority.High,
                            () =>
                       {
                           PanelSolver.Current.ShowResultsButton();
                       });
                    }
                }
                else
                {
                    await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                        CoreDispatcherPriority.High,
                        () =>
                       {
                           PanelSolver.Current.ShowResultsButton();
                       });
                }
            }
        }

    }
}
