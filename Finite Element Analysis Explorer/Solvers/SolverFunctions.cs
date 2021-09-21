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
        private static Stopwatch mainTimer = new Stopwatch();
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

        private static double[][] sdk;
        private static double[][] sdk11;
        private static double[][] sdk21;

        private static double[] dqk;
        private static double[] dqu;
        private static double[] ddu;

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

        #region Preparation

        /// <summary>
        /// Resets the display and shows the welcome message.
        /// </summary>
        internal static async void ResetDisplayAndShowWelcomeMessage()
        {
            mainTimer = new Stopwatch();
            mainTimer.Start();
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                CoreDispatcherPriority.High,
                () =>
                    {
                        SolverDisplay.Current.ClearMessages();
                    });

            AddMessage(mainTimer.ElapsedMilliseconds, -1, "Starting solver DoubleLUP.", 0);
            AddMessage(mainTimer.ElapsedMilliseconds, -1, "    Local matrices for elements and nodes have been created during construction stage.", 0);
        }

        /// <summary>
        /// Resets the properties for the solver.
        /// </summary>
        internal static void ResetPropertiesForSolver()
        {
            Stopwatch taskTimer = new Stopwatch();
            taskTimer.Start();
            AddMessage(mainTimer.ElapsedMilliseconds, -1, "Reset solver properties.", 0);

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

                sdk = null;
                sdk11 = null;
                sdk21 = null;
                dqk = null;
                dqu = null;
                ddu = null;

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
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
                WService.ReportException(ex);
            }

            AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        /// <summary>
        /// Displays the model properties.
        /// </summary>
        internal static void DisplayModelProperties()
        {
            AddMessage(-1, -1, "Model Properties.", 0);
            AddMessage(-1, -1, "    " + Model.Members.Count.ToString("#,###") + " Members.", 1);
            AddMessage(-1, -1, "    " + Model.Members.MembersWithLinearLoads.Count.ToString("#,###") + " Members with linear loads.", 1);
            AddMessage(-1, -1, "    " + Model.Nodes.Count.ToString("#,###") + " Nodes.", 1);
            AddMessage(-1, -1, "    " + Model.Nodes.NodesWithConstraints.Count.ToString("#,###") + " nodes with constraints.", 1);
            AddMessage(-1, -1, "    " + Model.Nodes.NodesWithNodalLoads.Count.ToString("#,###") + " nodes with nodal loads.", 1);
        }

        /// <summary>
        /// Shrinks the model.
        /// </summary>
        internal static void ShrinkModel()
        {
            stageStart = mainTimer.ElapsedMilliseconds;
            AddMessage(mainTimer.ElapsedMilliseconds, -1, "Shrinking Model. (searching for orphan nodes)", 0);

            int previousNodeCount = 0;
            int postNodeCount = 0;

            try
            {
                previousNodeCount = Model.Nodes.Count;
                Model.Shrink();
                postNodeCount = Model.Nodes.Count;
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(mainTimer.ElapsedMilliseconds, mainTimer.ElapsedMilliseconds - stageStart, "    ERROR!", 2);
                AddMessage(mainTimer.ElapsedMilliseconds, mainTimer.ElapsedMilliseconds - stageStart, "    " + ex.Message, 2);
                WService.ReportException(ex);
            }

            AddMessage(mainTimer.ElapsedMilliseconds, -1, "    Started with " + previousNodeCount + " nodes.", 1);
            AddMessage(mainTimer.ElapsedMilliseconds, -1, "    Ended with " + postNodeCount + " nodes.", 1);
            AddMessage(mainTimer.ElapsedMilliseconds, -1, "    Removed " + (previousNodeCount - postNodeCount) + " nodes.", 1);

            AddMessage(mainTimer.ElapsedMilliseconds, mainTimer.ElapsedMilliseconds - stageStart, "    Finished.", 1);
        }

        /// <summary>
        /// Saves to file.
        /// </summary>
        internal static async void SaveFile()
        {
            stageStart = mainTimer.ElapsedMilliseconds;
            AddMessage(mainTimer.ElapsedMilliseconds, -1, "Saving File.", 0);
            await FileManager.SaveFile();
            AddMessage(mainTimer.ElapsedMilliseconds, mainTimer.ElapsedMilliseconds - stageStart, "    Finished.", 1);
        }

        #endregion

        /// <summary>
        /// Assigns code numbers to degrees or freedoms on nodes.
        /// </summary>
        internal static bool AssignCodeNumbersToDegreesOfFreedom()
        {
            Stopwatch taskTimer = new Stopwatch();
            taskTimer.Start();
            AddMessage(mainTimer.ElapsedMilliseconds, -1, "Assigning code numbers to the degrees of freedom.", 0);
            AddMessage(-1, -1, "    Each node has three degrees of freedom.", 1);

            try
            {
                // Assign code numbers to the unrestrained first.
                foreach (var node in Model.Nodes)
                {
                    if (node.Value.Constraints.X == false)
                    {
                        node.Value.Codes = new Codes(unrestrainedDOF, node.Value.Codes.Y, node.Value.Codes.M);
                        unrestrainedDOF++;
                    }

                    if (node.Value.Constraints.Y == false)
                    {
                        node.Value.Codes = new Codes(node.Value.Codes.X, unrestrainedDOF, node.Value.Codes.M);
                        unrestrainedDOF++;
                    }

                    if (node.Value.Constraints.M == false)
                    {
                        node.Value.Codes = new Codes(node.Value.Codes.X, node.Value.Codes.Y, unrestrainedDOF);
                        unrestrainedDOF++;
                    }
                }

                // Then assign code number to the remaining.
                foreach (var node in Model.Nodes)
                {
                    if (node.Value.Constraints.X == true)
                    {
                        node.Value.Codes = new Codes(unrestrainedDOF + restrainedDOF, node.Value.Codes.Y, node.Value.Codes.M);
                        restrainedDOF++;
                    }

                    if (node.Value.Constraints.Y == true)
                    {
                        node.Value.Codes = new Codes(node.Value.Codes.X, unrestrainedDOF + restrainedDOF, node.Value.Codes.M);
                        restrainedDOF++;
                    }

                    if (node.Value.Constraints.M == true)
                    {
                        node.Value.Codes = new Codes(node.Value.Codes.X, node.Value.Codes.Y, unrestrainedDOF + restrainedDOF);
                        restrainedDOF++;
                    }
                }

                if(restrainedDOF <= 2)
                {
                    hasErrors = true;
                    AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                    AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    The Model requires at least three retrained degrees of freedom.", 2);
                    AddMessage(-1, -1, "    Total unrestrained degrees of freedom " + unrestrainedDOF + ".", 1);
                    AddMessage(-1, -1, "    Total restrained degrees of freedom " + restrainedDOF + ".", 1);
                    AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    Finished.", 1);
                    return false;
                }
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
                WService.ReportException(ex);
                return false;
            }

            AddMessage(-1, -1, "    Total unrestrained degrees of freedom " + unrestrainedDOF + ".", 1);
            AddMessage(-1, -1, "    Total restrained degrees of freedom " + restrainedDOF + ".", 1);
            AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    Finished.", 1);
            return true;
        }

        /// <summary>
        /// Create superposition values from segments to nodes.
        /// </summary>
        internal static void CreateSuperpositionValuesFromSegmentsToNodes()
        {
            Stopwatch taskTimer = new Stopwatch();
            taskTimer.Start();
            AddMessage(mainTimer.ElapsedMilliseconds, -1, "Superposition Stage One.", 0);

            try
            {
                foreach (var node in Model.Nodes)
                {
                    node.Value.SuperPosition = new NodalLoad(0, 0, 0);
                    node.Value.SuperPosition = new NodalLoad(0, 0, 0);
                }

                foreach (var member in Model.Members)
                {
                    foreach (var nextSegment in member.Value.Segments)
                    {
                        nextSegment.Value.NodeNear.SuperPosition = new NodalLoad(
                            nextSegment.Value.NodeNear.SuperPosition.X + nextSegment.Value.NearSuperGlobal.X,
                            nextSegment.Value.NodeNear.SuperPosition.Y + nextSegment.Value.NearSuperGlobal.Y,
                            nextSegment.Value.NodeNear.SuperPosition.M + nextSegment.Value.NearSuperGlobal.M);

                        nextSegment.Value.NodeFar.SuperPosition = new NodalLoad(
                            nextSegment.Value.NodeFar.SuperPosition.X + nextSegment.Value.FarSuperGlobal.X,
                            nextSegment.Value.NodeFar.SuperPosition.Y + nextSegment.Value.FarSuperGlobal.Y,
                            nextSegment.Value.NodeFar.SuperPosition.M + nextSegment.Value.FarSuperGlobal.M);
                    }
                }
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
                WService.ReportException(ex);
            }

            AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        #region Transfer from Nodes.

        /// <summary>
        /// Get the QK values from sub nodes.
        /// </summary>
        internal static void GetQkFromSubNodes()
        {
            Stopwatch taskTimer = new Stopwatch();
            taskTimer.Start();
            AddMessage(mainTimer.ElapsedMilliseconds, -1, "Get [Qk] vector from model data.", 0);

            try
            {
                dqk = DoubleMatrix.VectorCreate(unrestrainedDOF);

                // Get the Qk matrix.
                qk = Matrix<double>.Build.Dense(unrestrainedDOF, 1);
                for (int j = 0; j < unrestrainedDOF; j++)
                {
                    foreach (var node in Model.Nodes)
                    {
                        if (node.Value.Codes.X == j)
                        {
                            qk[j, 0] = (double)node.Value.Load.X + (double)node.Value.SuperPosition.X;

                            dqk[j] = (double)node.Value.Load.X + (double)node.Value.SuperPosition.X;
                        }

                        if (node.Value.Codes.Y == j)
                        {
                            qk[j, 0] = (double)node.Value.Load.Y + (double)node.Value.SuperPosition.Y;

                            dqk[j] = (double)node.Value.Load.Y + (double)node.Value.SuperPosition.Y;
                        }

                        if (node.Value.Codes.M == j)
                        {
                            qk[j, 0] = (double)node.Value.Load.M + (double)node.Value.SuperPosition.M;

                            dqk[j] = (double)node.Value.Load.M + (double)node.Value.SuperPosition.M;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
                WService.ReportException(ex);
            }

            try
            {
                AddMessage(-1, -1, "    [Qk] vector length " + qk.RowCount.ToString("#,###"), 1);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        /// <summary>
        /// Get the QU values from sub nodes.
        /// </summary>
        internal static void GetQuFromSubNodes()
        {
            Stopwatch taskTimer = new Stopwatch();
            taskTimer.Start();
            AddMessage(mainTimer.ElapsedMilliseconds, -1, "Get [Qu] vector from model data.", 0);

            try
            {
                dqu = DoubleMatrix.VectorCreate(restrainedDOF);

                // Get the Qu matrix.
                qu = Matrix<double>.Build.Dense(restrainedDOF, 1);
                for (int j = 0; j < restrainedDOF; j++)
                {
                    foreach (var node in Model.Nodes)
                    {
                        if (node.Value.Codes.X == j + unrestrainedDOF)
                        {
                            qu[j, 0] = (double)node.Value.Load.X;

                            dqu[j] = (double)node.Value.Load.X;
                        }

                        if (node.Value.Codes.Y == j + unrestrainedDOF)
                        {
                            qu[j, 0] = (double)node.Value.Load.Y;

                            dqu[j] = (double)node.Value.Load.Y;
                        }

                        if (node.Value.Codes.M == j + unrestrainedDOF)
                        {
                            qu[j, 0] = (double)node.Value.Load.M;

                            dqu[j] = (double)node.Value.Load.M;
                        }
                    }
                }

                AddMessage(-1, -1, "    [Qu] vector length " + qu.RowCount.ToString("#,###"), 1);
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
                WService.ReportException(ex);
            }

            AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        /// <summary>
        /// Gets the DK values from the sub nodes.
        /// </summary>
        internal static void GetDkFromSubNodes()
        {
            Stopwatch taskTimer = new Stopwatch();
            taskTimer.Start();
            AddMessage(mainTimer.ElapsedMilliseconds, -1, "Get [Dk] vector from model data.", 0);

            try
            {
                // Get the Qu matrix.
                dk = Matrix<double>.Build.Dense(restrainedDOF, 1);
                for (int j = 0; j < restrainedDOF; j++)
                {
                    foreach (var node in Model.Nodes)
                    {
                        if (node.Value.Codes.X == j + unrestrainedDOF)
                        {
                            dk[j, 0] = (double)node.Value.Displacement.X;
                        }

                        if (node.Value.Codes.Y == j + unrestrainedDOF)
                        {
                            dk[j, 0] = (double)node.Value.Displacement.Y;
                        }

                        if (node.Value.Codes.M == j + unrestrainedDOF)
                        {
                            dk[j, 0] = (double)node.Value.Displacement.M;
                        }
                    }
                }

                AddMessage(-1, -1, "    Dk " + dk.ColumnCount + " " + dk.RowCount, 1);
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
                WService.ReportException(ex);
            }

            AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        /// <summary>
        /// Gets the DU values from the sub nodes.
        /// </summary>
        internal static void GetDuFromSubNodes()
        {
            Stopwatch taskTimer = new Stopwatch();
            taskTimer.Start();
            AddMessage(mainTimer.ElapsedMilliseconds, -1, "Get [Du] vector from model data.", 0);

            try
            {
                ddu = DoubleMatrix.VectorCreate(unrestrainedDOF);

                // Get the Qk vector.
                du = Matrix<double>.Build.Dense(unrestrainedDOF, 1, 0);
                for (int j = 0; j < unrestrainedDOF; j++)
                {
                    foreach (var node in Model.Nodes)
                    {
                        if (node.Value.Codes.X == j)
                        {
                            du[j, 0] = (double)node.Value.Displacement.X;

                            ddu[j] = (double)node.Value.Displacement.X;
                        }

                        if (node.Value.Codes.Y == j)
                        {
                            du[j, 0] = (double)node.Value.Displacement.Y;

                            ddu[j] = (double)node.Value.Displacement.Y;
                        }

                        if (node.Value.Codes.M == j)
                        {
                            du[j, 0] = (double)node.Value.Displacement.M;

                            ddu[j] = (double)node.Value.Displacement.M;
                        }
                    }
                }

                AddMessage(-1, -1, "    Du " + du.ColumnCount + " " + du.RowCount, 1);
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
                WService.ReportException(ex);
            }
            
            AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        #endregion

        #region Assemble Matrices.

        /// <summary>
        /// Assembles the stiffness matrix.
        /// </summary>
        internal static bool AssembleStiffnessMatrix()
        {
            Stopwatch taskTimer = new Stopwatch();
            taskTimer.Start();
            AddMessage(mainTimer.ElapsedMilliseconds, -1, "Assembling global stiffness matrix. {K}", 0);

            // Check if model contains any nodes first.
            if (Model.Nodes.Count == 0)
            {
                hasErrors = true;
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    Model has no Nodes. Return to Construction phase and complete the Model before solving the Model.", 2);
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    Finished.", 1);
                return false;
            }

            try
            {
                // Assemble the stiffness matrix K.
                totalDOF = Model.Nodes.Count * 3;
                sdk = DoubleMatrix.MatrixCreate(totalDOF, totalDOF);
                k = Matrix<double>.Build.Dense(totalDOF, totalDOF);
                int x = 0;
                int y = 0;

                foreach (var member in Model.Members)
                {
                    foreach (var segment in member.Value.Segments)
                    {
                        int[] enf = { segment.Value.NodeNear.Codes.X, segment.Value.NodeNear.Codes.Y, segment.Value.NodeNear.Codes.M, segment.Value.NodeFar.Codes.X, segment.Value.NodeFar.Codes.Y, segment.Value.NodeFar.Codes.M };
                        for (int i = 0; i < 6; i++)
                        {
                            for (int j = 0; j < 6; j++)
                            {
                                x = enf[i];
                                y = enf[j];
                                k[y, x] = k[y, x] + (double)segment.Value.KMatrix[j, i];

                                sdk[y][x] = sdk[y][x] + (double)segment.Value.KMatrix[j, i];
                            }
                        }
                    }
                }

                AddMessage(-1, -1, "    Matrix size is " + totalDOF.ToString("#,###") + " x " + totalDOF.ToString("#,###") + ".", 1);
                AddMessage(-1, -1, "    Total number of elements within matrix is " + (totalDOF * totalDOF).ToString("#,###") + ".", 1);
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
                WService.ReportException(ex);
                return false;
            }
            
            AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    Finished.", 1);
            return true;
        }

        /// <summary>
        /// Assembles the K matrices.
        /// </summary>
        internal static void AssembleKMatrices()
        {
            Stopwatch taskTimer = new Stopwatch();
            taskTimer.Start();
            AddMessage(mainTimer.ElapsedMilliseconds, -1, "Divide K matrix into four matrices {K11}, {K12}, {K21}, {K22}.", 0);

            try
            {
                // Resize and fill the K** Matrices.
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

                sdk11 = DoubleMatrix.MatrixCreate(unrestrainedDOF, unrestrainedDOF);
                for (int j = 0; j < sdk11.Length; j++)
                {
                    for (int i = 0; i < sdk11[1].Length; i++)
                    {
                        sdk11[j][i] = (double)k[j, i];
                    }
                }

                sdk21 = DoubleMatrix.MatrixCreate(restrainedDOF, unrestrainedDOF);
                for (int j = 0; j < sdk21.Length; j++)
                {
                    for (int i = 0; i < sdk21[1].Length; i++)
                    {
                        sdk21[j][i] = (double)k[j, i];
                    }
                }

                // K is no longer necessary so remove from memory to improve performance.
                k = null;

                // Dimension Du to prevent errors.
                du = Matrix<double>.Build.Dense(unrestrainedDOF, 1, 0);
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
                WService.ReportException(ex);
            }

            AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        #endregion

        #region Solve

        /// <summary>
        /// Solve for DU.
        /// </summary>
        internal static void SolveForDu()
        {
            // Solve for the displacements.
            Stopwatch taskTimer = new Stopwatch();
            taskTimer.Start();
            AddMessage(mainTimer.ElapsedMilliseconds, -1, "Solve For Du", 0);

            try
            {
                du = k11.Inverse() * qk;
                ddu = DoubleMatrix.SystemSolve(sdk11, dqk);
                AddMessage(-1, -1, "    Du " + du.ColumnCount + " " + du.RowCount, 1);
                AddMessage(-1, -1, "    Qk " + qk.ColumnCount + " " + qk.RowCount, 1);
                AddMessage(-1, -1, "    K11 " + k11.ColumnCount + " " + k11.RowCount, 1);
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
                WService.ReportException(ex);
            }
            
            AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        /// <summary>
        /// Solve for QU.
        /// </summary>
        internal static void SolveForQu()
        {
            // Solve for the reactions.
            Stopwatch taskTimer = new Stopwatch();
            taskTimer.Start();
            AddMessage(mainTimer.ElapsedMilliseconds, -1, "Solve For Qu", 0);

            try
            {
                qu = k21 * du;
                dqu = DoubleMatrix.MatrixVectorProduct(sdk21, ddu);
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
                WService.ReportException(ex);
            }

            AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        #endregion

        #region Transfer to Nodes.

        /// <summary>
        /// Set QK values to sub nodes.
        /// </summary>
        internal static void SetQkToSubNodes()
        {
            Stopwatch taskTimer = new Stopwatch();
            taskTimer.Start();
            AddMessage(mainTimer.ElapsedMilliseconds, -1, "Set [Qk] vector from model data.", 0);

            try
            {
                // Set the Qk matrix.
                for (int j = 0; j < unrestrainedDOF; j++)
                {
                    foreach (var node in Model.Nodes)
                    {
                        if (node.Value.Codes.X == j)
                        {
                            node.Value.JointLoad = new NodalLoad((decimal)qk[j, 0], node.Value.JointLoad.Y, node.Value.JointLoad.M);
                        }

                        if (node.Value.Codes.Y == j)
                        {
                            node.Value.JointLoad = new NodalLoad(node.Value.JointLoad.X, (decimal)qk[j, 0], node.Value.JointLoad.M);
                        }

                        if (node.Value.Codes.M == j)
                        {
                            node.Value.JointLoad = new NodalLoad(node.Value.JointLoad.X, node.Value.JointLoad.Y, (decimal)qk[j, 0]);
                        }
                    }
                }

                AddMessage(-1, -1, "    [Qk] vector length " + qk.RowCount.ToString("#,###"), 1);
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
                WService.ReportException(ex);
            }
            
            AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        /// <summary>
        /// Set the QU values to sub nodes.
        /// </summary>
        internal static void SetQuToSubNodes()
        {
            Stopwatch taskTimer = new Stopwatch();
            taskTimer.Start();
            AddMessage(mainTimer.ElapsedMilliseconds, -1, "Set [Qu] vector from model data.", 0);

            try
            {
                // Set the Qu matrix.
                for (int j = 0; j < restrainedDOF; j++)
                {
                    foreach (var node in Model.Nodes)
                    {
                        if (node.Value.Codes.X == j + unrestrainedDOF)
                        {
                            node.Value.LoadReaction = new NodalLoad((decimal)qu[j, 0], node.Value.LoadReaction.Y, node.Value.LoadReaction.M);
                        }

                        if (node.Value.Codes.Y == j + unrestrainedDOF)
                        {
                            node.Value.LoadReaction = new NodalLoad(node.Value.LoadReaction.X, (decimal)qu[j, 0], node.Value.LoadReaction.M);
                        }

                        if (node.Value.Codes.M == j + unrestrainedDOF)
                        {
                            node.Value.LoadReaction = new NodalLoad(node.Value.LoadReaction.X, node.Value.LoadReaction.Y, (decimal)qu[j, 0]);
                        }
                    }
                }

                AddMessage(-1, -1, "    [Qu] vector length " + qu.RowCount.ToString("#,###"), 1);
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
                WService.ReportException(ex);
            }

            AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        /// <summary>
        /// Set the Dk values to sub nodes.
        /// </summary>
        internal static void SetDkToSubNodes()
        {
            Stopwatch taskTimer = new Stopwatch();
            taskTimer.Start();
            AddMessage(mainTimer.ElapsedMilliseconds, -1, "Set [Dk] vector from model data.", 0);

            try
            {
                // Set the Dk matrix. These should be zeros as the fixed dof's are fixed.
                for (int j = 0; j < restrainedDOF; j++)
                {
                    foreach (var node in Model.Nodes)
                    {
                        if (node.Value.Codes.X == j + unrestrainedDOF)
                        {
                            node.Value.Displacement = new Point((decimal)dk[j, 0], node.Value.Displacement.Y, node.Value.Displacement.M);
                        }

                        if (node.Value.Codes.Y == j + unrestrainedDOF)
                        {
                            node.Value.Displacement = new Point(node.Value.Displacement.X, (decimal)dk[j, 0], node.Value.Displacement.M);
                        }

                        if (node.Value.Codes.M == j + unrestrainedDOF)
                        {
                            node.Value.Displacement = new Point(node.Value.Displacement.X, node.Value.Displacement.Y, (decimal)dk[j, 0]);
                        }
                    }
                }

                AddMessage(-1, -1, "    [Dk] vector length " + dk.RowCount.ToString("#,###"), 1);
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
                WService.ReportException(ex);
            }
            
            AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        /// <summary>
        /// After Solver to Du the results are to be transfered back to the vector.
        /// </summary>
        internal static void SetDuToSubNodes()
        {
            Stopwatch taskTimer = new Stopwatch();
            taskTimer.Start();
            AddMessage(mainTimer.ElapsedMilliseconds, -1, "Set [Du] vector from model data.", 0);

            try
            {
                for (int j = 0; j < unrestrainedDOF; j++)
                {
                    foreach (var node in Model.Nodes)
                    {
                        if (node.Value.Codes.X == j)
                        {
                            node.Value.Displacement = new Point((decimal)du[j, 0], node.Value.Displacement.Y, node.Value.Displacement.M);
                        }

                        if (node.Value.Codes.Y == j)
                        {
                            node.Value.Displacement = new Point(node.Value.Displacement.X, (decimal)du[j, 0], node.Value.Displacement.M);
                        }

                        if (node.Value.Codes.M == j)
                        {
                            node.Value.Displacement = new Point(node.Value.Displacement.X, node.Value.Displacement.Y, (decimal)du[j, 0]);
                        }
                    }
                }

                AddMessage(-1, -1, "    [Du] vector length " + du.RowCount.ToString("#,###"), 1);
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
                WService.ReportException(ex);
            }

            AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        #endregion

        /// <summary>
        /// Updates member and segments from the matrix.
        /// </summary>
        internal static void UpdateMemberAndSegmentsFromMatrix()
        {
            Stopwatch taskTimer = new Stopwatch();
            taskTimer.Start();
            AddMessage(mainTimer.ElapsedMilliseconds, -1, "Update Members and Segments from Matrix.", 0);

            try
            {
                foreach (var segment in Model.Members)
                {
                    foreach (var nextSegment in segment.Value.Segments)
                    {
                        nextSegment.Value.UpdatePropertiesFromMatrix();
                    }

                    segment.Value.UpdatePropertiesFromMatrix();
                }
            }
            catch (Exception ex)
            {
                hasErrors = true;
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    ERROR!", 2);
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    " + ex.Message, 2);
                WService.ReportException(ex);
            }

            AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        /// <summary>
        /// Creates length ratio colors.
        /// </summary>
        internal static void CreateLengthRatioColors()
        {
            Stopwatch taskTimer = new Stopwatch();
            taskTimer.Start();
            AddMessage(mainTimer.ElapsedMilliseconds, -1, "Calculate Length Ratios.", 0);

            try
            {
                if (Camera.LargestLengthRatio == 0)
                {
                    foreach (var member in Model.Members)
                    {
                        foreach (var nextSegment in member.Value.Segments)
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
                    byte ratioByte;

                    foreach (var member in Model.Members)
                    {
                        foreach (var nextSegment in member.Value.Segments)
                        {
                            if (nextSegment.Value.LengthRatio > 0)
                            {
                                int tmpValue = (int)(Math.Abs(nextSegment.Value.LengthRatio) * tension_ratio);
                                if (tmpValue > 255)
                                {
                                    tmpValue = 255;
                                }

                                if (tmpValue < 0)
                                {
                                    tmpValue = 0;
                                }

                                ratioByte = (byte)(255 - tmpValue);
                                nextSegment.Value.LengthRatioColor = Color.FromArgb(255, ratioByte, ratioByte, 255);
                            }
                            else if (nextSegment.Value.LengthRatio < 0)
                            {
                                int tmpValue = (int)(Math.Abs(nextSegment.Value.LengthRatio) * compression_ratio);
                                if (tmpValue > 255)
                                {
                                    tmpValue = 255;
                                }

                                if (tmpValue < 0)
                                {
                                    tmpValue = 0;
                                }

                                ratioByte = (byte)(255 - tmpValue);
                                nextSegment.Value.LengthRatioColor = Color.FromArgb(255, 255, ratioByte, ratioByte);
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
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    ERROR!", 3);
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    " + ex.Message, 3);
                WService.ReportException(ex);
            }

            AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        /// <summary>
        /// Creates axial ratio colors.
        /// </summary>
        internal static void CreateAxialRatioColors()
        {
            Stopwatch taskTimer = new Stopwatch();
            taskTimer.Start();
            AddMessage(mainTimer.ElapsedMilliseconds, -1, "Calculate Axial Ratios.", 0);

            try
            {
                if (Camera.LargestAxialRatio == 0)
                {
                    foreach (var member in Model.Members)
                    {
                        foreach (var nextSegment in member.Value.Segments)
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
                    byte ratioByte;

                    foreach (var member in Model.Members)
                    {
                        foreach (var nextSegment in member.Value.Segments)
                        {
                            if (nextSegment.Value.InternalLoadNearLocal.X < 0)
                            {
                                int tmpValue = (int)(Math.Abs(nextSegment.Value.InternalLoadNearLocal.X) * tension_ratio);
                                if (tmpValue > 255)
                                {
                                    tmpValue = 255;
                                }

                                if (tmpValue < 0)
                                {
                                    tmpValue = 0;
                                }

                                ratioByte = (byte)(255 - tmpValue);
                                nextSegment.Value.AxialRatioColor = Color.FromArgb(255, ratioByte, ratioByte, 255);
                            }
                            else if (nextSegment.Value.InternalLoadNearLocal.X > 0)
                            {
                                int tmpValue = (int)(Math.Abs(nextSegment.Value.InternalLoadNearLocal.X) * compression_ratio);
                                if (tmpValue > 255)
                                {
                                    tmpValue = 255;
                                }

                                if (tmpValue < 0)
                                {
                                    tmpValue = 0;
                                }

                                ratioByte = (byte)(255 - tmpValue);
                                nextSegment.Value.AxialRatioColor = Color.FromArgb(255, 255, ratioByte, ratioByte);
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
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    ERROR!", 3);
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    " + ex.Message, 3);
                WService.ReportException(ex);
            }

            AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        /// <summary>
        /// Create normal stress colors.
        /// </summary>
        internal static void CreateNormalStressColors()
        {
            Stopwatch taskTimer = new Stopwatch();
            taskTimer.Start();
            AddMessage(mainTimer.ElapsedMilliseconds, -1, "Calculate Axial Ratios.", 0);

            try
            {
                if (Camera.LargestNormalStress == 0)
                {
                    foreach (var member in Model.Members)
                    {
                        foreach (var nextSegment in member.Value.Segments)
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

                    byte ratioByte;

                    foreach (var member in Model.Members)
                    {
                        foreach (var nextSegment in member.Value.Segments)
                        {
                            if (nextSegment.Value.NormalStress < 0)
                            {
                                int tmpValue = (int)(Math.Abs(nextSegment.Value.NormalStress) * tension_ratio);
                                if (tmpValue > 255)
                                {
                                    tmpValue = 255;
                                }

                                if (tmpValue < 0)
                                {
                                    tmpValue = 0;
                                }

                                ratioByte = (byte)(255 - tmpValue);

                                nextSegment.Value.NormalStressColor = Color.FromArgb(255, ratioByte, ratioByte, 255);
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

                                ratioByte = (byte)(255 - tmpValue);
                                nextSegment.Value.NormalStressColor = Color.FromArgb(255, 255, ratioByte, ratioByte);
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
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    ERROR!", 3);
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    " + ex.Message, 3);
                WService.ReportException(ex);
            }

            AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        /// <summary>
        /// Calculates equilibrium values.
        /// </summary>
        internal static void CalculateEqulibriumValues()
        {
            Stopwatch taskTimer = new Stopwatch();
            taskTimer.Start();
            AddMessage(mainTimer.ElapsedMilliseconds, -1, "Calculate Equilibrium Values.", 0);

            try
            {
                foreach (var nodalLoad in Model.Nodes.NodesWithNodalLoads)
                {
                    Model.ForceX += nodalLoad.Value.Load.X;
                    Model.ForceY += nodalLoad.Value.Load.Y;
                    Model.ForceM += nodalLoad.Value.Load.M;
                }

                foreach (var nodeWithReaction in Model.Nodes.NodesWithReactions)
                {
                    Model.ReactionX += nodeWithReaction.Value.LoadReaction.X;
                    Model.ReactionY += nodeWithReaction.Value.LoadReaction.Y;
                    Model.ReactionM += nodeWithReaction.Value.LoadReaction.M;
                }
            }
            catch (Exception ex)
            {
                hasWarning = true;
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    ERROR!", 3);
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    " + ex.Message, 3);
                WService.ReportException(ex);
            }

            AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        /// <summary>
        /// WIP.
        /// </summary>
        internal static void CalculateMaterials()
        {
        }

        /// <summary>
        /// WIP.
        /// </summary>
        internal static void CalculateLabour()
        {
        }

        /// <summary>
        /// Calculate the cost.
        /// </summary>
        internal static void CalculateCost()
        {
            Stopwatch taskTimer = new Stopwatch();
            taskTimer.Start();
            AddMessage(mainTimer.ElapsedMilliseconds, -1, "Calculate Equilibrium Values.", 0);

            try
            {
                foreach (var member in Model.Members)
                {
                    Model.TotalCost += member.Value.MemberCost;
                    Model.MaterialCost += member.Value.MaterialCost;
                    Model.NodeCost += member.Value.NodeCost;
                }
            }
            catch (Exception ex)
            {
                hasWarning = true;
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    ERROR!", 3);
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    " + ex.Message, 3);
                WService.ReportException(ex);
            }

            AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        /// <summary>
        /// Checks to see if the user wants a report generated.
        /// </summary>
        internal static async void CreateReportAsync()
        {
            Model.IsReportBasic = false;
            Stopwatch taskTimer = new Stopwatch();
            taskTimer.Start();
            AddMessage(mainTimer.ElapsedMilliseconds, -1, "Generate Report.", 0);

            try
            {
                if (Options.Solvers.GenerateReport)
                {
                    ReportBasic report = new ReportBasic();
                    await report.CreateReportAsync();
                }
                else
                {
                    ReportBasic report = new ReportBasic();
                    await report.CreateReportAsync();
                    AddMessage(mainTimer.ElapsedMilliseconds, -1, "Report not required.", 0);
                }
            }
            catch (Exception ex)
            {
                hasWarning = true;
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    ERROR!", 3);
                AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    " + ex.Message, 3);
                WService.ReportException(ex);
            }

            AddMessage(mainTimer.ElapsedMilliseconds, taskTimer.ElapsedMilliseconds, "    Finished.", 1);
        }

        /// <summary>
        /// Display the messages when the solver completes.
        /// </summary>
        internal static async void DisplayEndMessages()
        {
            AddMessage(-1, -1, "    ", 0);
            AddMessage(mainTimer.ElapsedMilliseconds, mainTimer.ElapsedMilliseconds, "    Finished.", 0);

            if (!hasErrors)
            {
                if (Options.Solvers.
                    AutoFinishSolver)
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