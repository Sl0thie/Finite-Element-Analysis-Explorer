using System;
using System.Diagnostics;
using System.Numerics;
using Windows.UI;

namespace Finite_Element_Analysis_Explorer
{
    internal class Segment
    {
        #region Constructor

        internal void Output()
        {
            Debug.WriteLine("\nSEGMENT index: " + index + "  parent:" + parent.Index + "  nodeNear X:" + nodeNear.Index + "  nodeFar:" + nodeFar.Index + "  section:" + section.Name);
            Debug.WriteLine("  length:" + length + "  angle:" + angle + "  LDLNear X:" + LDLNear + "  LDLFar:" + LDLFar);
            Debug.WriteLine("  nearVectorDisplaced:" + nearVectorDisplaced + "  farVectorDisplaced:" + farVectorDisplaced);
            Debug.WriteLine("  LDLUnit:" + LDLUnit + "  lDLUnitRight:" + lDLUnitRight + "  lDLUnitLeft:" + lDLUnitLeft);
            Debug.WriteLine("  shearNear:" + shearNear + "  shearFar:" + shearFar + "  momentNear:" + momentNear + "  momentFar:" + momentFar);
            Debug.WriteLine("  nearLDLLine:" + nearLDLLine + "  farLDLLine:" + farLDLLine);
        }

        internal Segment(int _index, Member _parent, Node _nodeNear, Node _nodeFar, Section _section, decimal _LDLNear, decimal _LDLFar, int _previousSegment)
        {
            try
            {
                if (_nodeNear == _nodeFar)
                {
                    Debug.WriteLine("Zero Length " + _index + " " + _nodeNear.Index + " " + _nodeFar.Index);
                }

                index = _index;
                parent = _parent;
                previousSegment = _previousSegment;
                nodeNear = _nodeNear;
                nearVector = new Vector2(_nodeNear.Position.Location.X, _nodeNear.Position.Location.Y);
                nodeFar = _nodeFar;
                farVector = new Vector2(_nodeFar.Position.Location.X, _nodeFar.Position.Location.Y);

                section = _section;
                LDLNear = _LDLNear;
                LDLFar = _LDLFar;
                ProcessProperties(nodeNear.Position.X, nodeNear.Position.Y, nodeFar.Position.X, nodeFar.Position.Y);

                currentColor = section.Color;

                // Output();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error Segment Construction " + ex.Message);
            }
        }

        #endregion

        #region Properties

        #region Objects

        private int index;

        internal int Index
        {
            get
            {
                return index;
            }
        }

        private Member parent;

        public Member Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        private int previousSegment;

        public int PreviousSegment
        {
            get { return previousSegment; }
            set { previousSegment = value; }
        }

        private Node nodeNear;

        internal Node NodeNear
        {
            get
            {
                return nodeNear;
            }
        }

        private Node nodeFar;

        internal Node NodeFar
        {
            get
            {
                return nodeFar;
            }
        }

        private Section section;

        internal Section Section
        {
            get
            {
                return section;
            }

            set
            {
                section = value;

                // ProcessProperties(nodeNear.Position.X, nodeNear.Position.Y, nodeFar.Position.X, nodeFar.Position.Y);
            }
        }

        private DecimalMatrix kMatrix = new DecimalMatrix(6, 6);

        internal DecimalMatrix KMatrix
        {
            get { return kMatrix; }
        }

        #endregion

        #region Construction

        private decimal length;

        internal decimal Length
        {
            get
            {
                return length;
            }
        }

        private decimal lengthXAxis;

        internal decimal LengthXAxis
        {
            get
            {
                return lengthXAxis;
            }
        }

        private decimal lengthYAxis;

        internal decimal LengthYAxis
        {
            get
            {
                return lengthYAxis;
            }
        }

        private int angleMultiplyer = 0;
        private decimal angle;

        internal decimal Angle
        {
            get
            {
                return angle;
            }
        }

        private decimal lDLNear;

        internal decimal LDLNear
        {
            get
            {
                return lDLNear;
            }

            set
            {
                lDLNear = value;
            }
        }

        private decimal lDLFar;

        internal decimal LDLFar
        {
            get
            {
                return lDLFar;
            }

            set
            {
                lDLFar = value;

                // ProcessProperties(nodeNear.Position.X, nodeNear.Position.Y, nodeFar.Position.X, nodeFar.Position.Y);
            }
        }

        #endregion

        #region Internal Forces

        private NodalLoad internalLoadNearLocal;

        internal NodalLoad InternalLoadNearLocal
        {
            get { return internalLoadNearLocal; }
            set { internalLoadNearLocal = value; }
        }

        private NodalLoad internalLoadFarLocal;

        internal NodalLoad InternalLoadFarLocal
        {
            get { return internalLoadFarLocal; }
            set { internalLoadFarLocal = value; }
        }

        private NodalLoad internalLoadNearGlobal;

        internal NodalLoad InternalLoadNearGlobal
        {
            get { return internalLoadNearGlobal; }
            set { internalLoadNearGlobal = value; }
        }

        private NodalLoad internalLoadFarGlobal;

        internal NodalLoad InternalLoadFarGlobal
        {
            get { return internalLoadFarGlobal; }
            set { internalLoadFarGlobal = value; }
        }

        #endregion

        #region Superposition

        private NodalLoad nearSuperGlobal;

        internal NodalLoad NearSuperGlobal
        {
            get { return nearSuperGlobal; }
            set { nearSuperGlobal = value; }
        }

        private NodalLoad farSuperGlobal;

        internal NodalLoad FarSuperGlobal
        {
            get { return farSuperGlobal; }
            set { farSuperGlobal = value; }
        }

        private NodalLoad nearSuperLocal;

        private NodalLoad farSuperLocal;

        #endregion

        #region Displaced Properties

        private Vector2 centerPointDisplaced;

        internal Vector2 CenterPointDisplaced
        {
            get
            {
                return centerPointDisplaced;
            }

            set
            {
                centerPointDisplaced = value;
            }
        }

        private decimal lengthDisplaced;

        internal decimal LengthDisplaced
        {
            get { return lengthDisplaced; }
        }

        private decimal lengthDisplacedXAxis;

        internal decimal LengthDisplacedXAxis
        {
            get
            {
                return lengthDisplacedXAxis;
            }
        }

        private decimal lengthDisplacedYAxis;

        internal decimal LengthDisplacedYAxis
        {
            get
            {
                return lengthDisplacedYAxis;
            }
        }

        private decimal angleDisplaced;

        public decimal AngleDisplaced
        {
            get { return angleDisplaced; }
        }

        private decimal lengthDifference;

        public decimal LengthDifference
        {
            get { return lengthDifference; }
        }

        private decimal lengthDifferenceXAxis;

        internal decimal LengthDifferenceXAxis
        {
            get
            {
                return lengthDifferenceXAxis;
            }
        }

        private decimal lengthDifferenceYAxis;

        internal decimal LengthDifferenceYAxis
        {
            get
            {
                return lengthDifferenceYAxis;
            }
        }

        private decimal angleDifference;

        public decimal AngleDifference
        {
            get { return angleDifference; }
        }

        private decimal lengthRatio;

        internal decimal LengthRatio
        {
            get { return lengthRatio; }
            set { lengthRatio = value; }
        }

        #endregion

        #region Colors

        private Color lengthRatioColor;

        internal Color LengthRatioColor
        {
            get { return lengthRatioColor; }
            set { lengthRatioColor = value; }
        }

        private Color axialRatioColor;

        public Color AxialRatioColor
        {
            get { return axialRatioColor; }
            set { axialRatioColor = value; }
        }

        private Color normalStressColor;

        public Color NormalStressColor
        {
            get { return normalStressColor; }
            set { normalStressColor = value; }
        }

        private Color currentColor;

        public Color CurrentColor
        {
            get { return currentColor; }
            set { currentColor = value; }
        }

        #endregion

        #region Graphics

        private Vector2 nearVector = new Vector2(0, 0);

        internal Vector2 NearVector
        {
            get { return nearVector; }
        }

        private Vector2 farVector = new Vector2(0, 0);

        internal Vector2 FarVector
        {
            get { return farVector; }
        }

        private Vector2 nearVectorDisplaced = new Vector2(0, 0);

        internal Vector2 NearVectorDisplaced
        {
            get { return nearVectorDisplaced; }
        }

        private Vector2 farVectorDisplaced = new Vector2(0, 0);

        internal Vector2 FarVectorDisplaced
        {
            get { return farVectorDisplaced; }
        }

        private Vector2 shearNear;

        public Vector2 ShearNear
        {
            get { return shearNear; }
            set { shearNear = value; }
        }

        private Vector2 shearFar;

        public Vector2 ShearFar
        {
            get { return shearFar; }
            set { shearFar = value; }
        }

        private Vector2 momentNear;

        public Vector2 MomentNear
        {
            get { return momentNear; }
            set { momentNear = value; }
        }

        private Vector2 momentFar;

        public Vector2 MomentFar
        {
            get { return momentFar; }
            set { momentFar = value; }
        }

        private Vector2 lDLUnit;

        internal Vector2 LDLUnit
        {
            get { return lDLUnit; }
            set { lDLUnit = value; }
        }

        private Vector2 lDLUnitRight;

        internal Vector2 LDLUnitRight
        {
            get { return lDLUnitRight; }
            set { lDLUnitRight = value; }
        }

        private Vector2 lDLUnitLeft;

        internal Vector2 LDLUnitLeft
        {
            get { return lDLUnitLeft; }
            set { lDLUnitLeft = value; }
        }

        private Vector2 nearLDLLine;

        public Vector2 NearLDLLine
        {
            get { return nearLDLLine; }
            set { nearLDLLine = value; }
        }

        private Vector2 farLDLLine;

        public Vector2 FarLDLLine
        {
            get { return farLDLLine; }
            set { farLDLLine = value; }
        }

        #endregion

        #region Stress/Strain

        private decimal normalStress;

        public decimal NormalStress
        {
            get { return normalStress; }
            set { normalStress = value; }
        }

        #endregion

        #endregion

        #region Methods

        private void ProcessProperties(decimal NearX, decimal NearY, decimal FarX, decimal FarY)
        {
            // Process Linear Load.
            lengthXAxis = Math.Abs(FarX - NearX);
            lengthYAxis = Math.Abs(FarY - NearY);

            length = DMath.Sqrt((lengthXAxis * lengthXAxis) + (lengthYAxis * lengthYAxis));

            if (length == 0)
            {
                Debug.WriteLine("Zero Length Segment " + this.index);
            }

            if (FarY > NearY)
            {
                angle = (decimal)Math.Atan2((double)lengthYAxis, (double)lengthXAxis);
                angleMultiplyer = 1;
            }
            else if (FarY < NearY)
            {
                angle = -(decimal)Math.Atan2((double)lengthYAxis, (double)lengthXAxis);
                angleMultiplyer = -1;
            }
            else
            {
                angle = 0;
                angleMultiplyer = 1;
            }

            DecimalMatrix k_prime = CreateFrameMemberStiffnessMatrix();
            DecimalMatrix t = CreateDisplacementTransformationMatrix();
            DecimalMatrix Tt = CreateForceTransformationMatrix();

            kMatrix = Tt * k_prime * t;

            if (lDLNear + lDLFar > 0)
            {
                Add_PositiveLoad();
            }
            else if (lDLNear + lDLFar < 0)
            {
                Add_NegativeLoad();
            }
            else
            {
                DecimalMatrix superposition_local = new DecimalMatrix(6, 1);
                superposition_local[0, 0] = 0;
                superposition_local[1, 0] = 0;
                superposition_local[2, 0] = 0;
                superposition_local[3, 0] = 0;
                superposition_local[4, 0] = 0;
                superposition_local[5, 0] = 0;
                CreateSuperpositionValues(superposition_local);
            }

            centerPointDisplaced = new Vector2((float)((NearX + FarX) / 2), (float)((NearY + FarY) / 2));

            UpdateGraphicsProperties();
        }

        private DecimalMatrix CreateFrameMemberStiffnessMatrix()
        {
            // Create k_prime matrix.
            decimal a = section.Area;
            decimal E = section.E;
            decimal I = section.I;

            decimal L = length;
            decimal L2 = length * length;
            decimal L3 = length * length * length;

            DecimalMatrix Rm = new DecimalMatrix(6, 6);

            Rm[0, 0] = a * E / L;
            Rm[0, 1] = 0;
            Rm[0, 2] = 0;
            Rm[0, 3] = -(a * E / L);
            Rm[0, 4] = 0;
            Rm[0, 5] = 0;

            Rm[1, 0] = 0;
            Rm[1, 1] = 12 * E * I / L3;
            Rm[1, 2] = 6 * E * I / L2;
            Rm[1, 3] = 0;
            Rm[1, 4] = -(12 * E * I / L3);
            Rm[1, 5] = 6 * E * I / L2;

            Rm[2, 0] = 0;
            Rm[2, 1] = 6 * E * I / L2;
            Rm[2, 2] = 4 * E * I / L;
            Rm[2, 3] = 0;
            Rm[2, 4] = 0 - (6 * E * I / L2);
            Rm[2, 5] = 2 * E * I / L;

            Rm[3, 0] = -(a * E / L);
            Rm[3, 1] = 0;
            Rm[3, 2] = 0;
            Rm[3, 3] = a * E / L;
            Rm[3, 4] = 0;
            Rm[3, 5] = 0;

            Rm[4, 0] = 0;
            Rm[4, 1] = -(12 * E * I / L3);
            Rm[4, 2] = 0 - (6 * E * I / L2);
            Rm[4, 3] = 0;
            Rm[4, 4] = 12 * E * I / L3;
            Rm[4, 5] = -(6 * E * I / L2);

            Rm[5, 0] = 0;
            Rm[5, 1] = 6 * E * I / L2;
            Rm[5, 2] = 2 * E * I / L;
            Rm[5, 3] = 0;
            Rm[5, 4] = -(6 * E * I / L2);
            Rm[5, 5] = 4 * E * I / L;

            return Rm;
        }

        private DecimalMatrix CreateDisplacementTransformationMatrix()
        {
            decimal lamba_X;// = lengthXAxis / length;
            decimal lamba_Y;// = lengthYAxis / length;

            lamba_X = lengthXAxis / length;
            lamba_Y = lengthYAxis / length * angleMultiplyer;

            // Debug.WriteLine("Segment " + index + " " + lamba_X + " " + lamba_Y);

            // decimal lamba_X = lengthXAxis / length * angleMultiplyer;
            // decimal lamba_Y = lengthYAxis / length * angleMultiplyer;
            DecimalMatrix t = new DecimalMatrix(6, 6);

            t[0, 0] = lamba_X;
            t[0, 1] = lamba_Y;
            t[0, 2] = 0;
            t[0, 3] = 0;
            t[0, 4] = 0;
            t[0, 5] = 0;

            t[1, 0] = -lamba_Y;
            t[1, 1] = lamba_X;
            t[1, 2] = 0;
            t[1, 3] = 0;
            t[1, 4] = 0;
            t[1, 5] = 0;

            t[2, 0] = 0;
            t[2, 1] = 0;
            t[2, 2] = 1;
            t[2, 3] = 0;
            t[2, 4] = 0;
            t[2, 5] = 0;

            t[3, 0] = 0;
            t[3, 1] = 0;
            t[3, 2] = 0;
            t[3, 3] = lamba_X;
            t[3, 4] = lamba_Y;
            t[3, 5] = 0;

            t[4, 0] = 0;
            t[4, 1] = 0;
            t[4, 2] = 0;
            t[4, 3] = -lamba_Y;
            t[4, 4] = lamba_X;
            t[4, 5] = 0;

            t[5, 0] = 0;
            t[5, 1] = 0;
            t[5, 2] = 0;
            t[5, 3] = 0;
            t[5, 4] = 0;
            t[5, 5] = 1;

            return t;
        }

        private DecimalMatrix CreateForceTransformationMatrix()
        {
            // decimal lamba_X = lengthXAxis / length;
            // decimal lamba_Y = lengthYAxis / length;
            decimal lamba_X;// = lengthXAxis / length;
            decimal lamba_Y;// = lengthYAxis / length;

            lamba_X = lengthXAxis / length;
            lamba_Y = lengthYAxis / length * angleMultiplyer;

            DecimalMatrix tt = new DecimalMatrix(6, 6);

            tt[0, 0] = lamba_X;
            tt[0, 1] = -lamba_Y;
            tt[0, 2] = 0;
            tt[0, 3] = 0;
            tt[0, 4] = 0;
            tt[0, 5] = 0;

            tt[1, 0] = lamba_Y;
            tt[1, 1] = lamba_X;
            tt[1, 2] = 0;
            tt[1, 3] = 0;
            tt[1, 4] = 0;
            tt[1, 5] = 0;

            tt[2, 0] = 0;
            tt[2, 1] = 0;
            tt[2, 2] = 1;
            tt[2, 3] = 0;
            tt[2, 4] = 0;
            tt[2, 5] = 0;

            tt[3, 0] = 0;
            tt[3, 1] = 0;
            tt[3, 2] = 0;
            tt[3, 3] = lamba_X;
            tt[3, 4] = -lamba_Y;
            tt[3, 5] = 0;

            tt[4, 0] = 0;
            tt[4, 1] = 0;
            tt[4, 2] = 0;
            tt[4, 3] = lamba_Y;
            tt[4, 4] = lamba_X;
            tt[4, 5] = 0;

            tt[5, 0] = 0;
            tt[5, 1] = 0;
            tt[5, 2] = 0;
            tt[5, 3] = 0;
            tt[5, 4] = 0;
            tt[5, 5] = 1;

            return tt;
        }

        internal void UpdateColor()
        {
            switch (Options.MemberDisplay)
            {
                case 0:
                    currentColor = section.Color;
                    break;
                case 1:
                    currentColor = lengthRatioColor;
                    break;
                case 2:
                    currentColor = axialRatioColor;
                    break;
                case 3:
                    currentColor = normalStressColor;
                    break;
            }
        }

        /// <summary>
        /// Calculate the Internal forces and update the displaced properties.
        /// </summary>
        internal void UpdatePropertiesFromMatrix()
        {

            DecimalMatrix q_Local = new DecimalMatrix(6, 6);
            DecimalMatrix q_Global = new DecimalMatrix(6, 6);
            DecimalMatrix di = new DecimalMatrix(6, 6);
            DecimalMatrix k_prime = CreateFrameMemberStiffnessMatrix();
            DecimalMatrix T = CreateDisplacementTransformationMatrix();

            // DecimalMatrix Tt = CreateForceTransformationMatrix();
            di[0, 0] = NodeNear.Displacement.X;
            di[1, 0] = NodeNear.Displacement.Y;
            di[2, 0] = NodeNear.Displacement.M;
            di[3, 0] = NodeFar.Displacement.X;
            di[4, 0] = NodeFar.Displacement.Y;
            di[5, 0] = NodeFar.Displacement.M;

            q_Local = k_prime * T * di;
            q_Global = k_prime * di;

            internalLoadNearLocal = new NodalLoad(q_Local[0, 0] - nearSuperLocal.X, q_Local[1, 0] - nearSuperLocal.Y, q_Local[2, 0] - nearSuperLocal.M);
            internalLoadFarLocal = new NodalLoad(q_Local[3, 0] - farSuperLocal.X, q_Local[4, 0] - farSuperLocal.Y, q_Local[5, 0] - farSuperLocal.M);
            internalLoadNearGlobal = new NodalLoad(q_Global[0, 0] - nearSuperGlobal.X, q_Global[1, 0] - nearSuperGlobal.Y, q_Global[2, 0] - nearSuperGlobal.M);
            internalLoadFarGlobal = new NodalLoad(q_Global[3, 0] - farSuperGlobal.X, q_Global[4, 0] - farSuperGlobal.Y, q_Global[5, 0] - farSuperGlobal.M);

            int superPositionProcess = 0;// Easy way to try multiple processes.
            switch (superPositionProcess)
            {
                case 0:// Process based on individual constraint type.
                    // Subtract superposition from constrained dofs.
                    if (nodeNear.Constraints.X)
                    {
                        nodeNear.LoadReaction = new Finite_Element_Analysis_Explorer.NodalLoad(nodeNear.LoadReaction.X - nodeNear.SuperPosition.X, nodeNear.LoadReaction.Y, nodeNear.LoadReaction.M);
                    }

                    if (nodeNear.Constraints.Y)
                    {
                        nodeNear.LoadReaction = new Finite_Element_Analysis_Explorer.NodalLoad(nodeNear.LoadReaction.X, nodeNear.LoadReaction.Y - nodeNear.SuperPosition.Y, nodeNear.LoadReaction.M);
                    }

                    if (nodeNear.Constraints.M)
                    {
                        nodeNear.LoadReaction = new Finite_Element_Analysis_Explorer.NodalLoad(nodeNear.LoadReaction.X, nodeNear.LoadReaction.Y, nodeNear.LoadReaction.M - nodeNear.SuperPosition.M);
                    }

                    if (nodeFar.Constraints.X)
                    {
                        nodeFar.LoadReaction = new Finite_Element_Analysis_Explorer.NodalLoad(nodeFar.LoadReaction.X - nodeFar.SuperPosition.X, nodeFar.LoadReaction.Y, nodeFar.LoadReaction.M);
                    }

                    if (nodeFar.Constraints.Y)
                    {
                        nodeFar.LoadReaction = new Finite_Element_Analysis_Explorer.NodalLoad(nodeFar.LoadReaction.X, nodeFar.LoadReaction.Y - nodeFar.SuperPosition.Y, nodeFar.LoadReaction.M);
                    }

                    if (nodeFar.Constraints.M)
                    {
                        nodeFar.LoadReaction = new Finite_Element_Analysis_Explorer.NodalLoad(nodeFar.LoadReaction.X, nodeFar.LoadReaction.Y, nodeFar.LoadReaction.M - nodeFar.SuperPosition.M);
                    }

                    break;

                case 1:// Process only Fully Fixed nodes.
                    if (nodeNear.Constraints.ConstraintType == ConstraintType.Fixed)
                    {
                        nodeNear.LoadReaction = new Finite_Element_Analysis_Explorer.NodalLoad(nodeNear.LoadReaction.X - nodeNear.SuperPosition.X, nodeNear.LoadReaction.Y, nodeNear.LoadReaction.M);
                        nodeNear.LoadReaction = new Finite_Element_Analysis_Explorer.NodalLoad(nodeNear.LoadReaction.X, nodeNear.LoadReaction.Y - nodeNear.SuperPosition.Y, nodeNear.LoadReaction.M);
                        nodeNear.LoadReaction = new Finite_Element_Analysis_Explorer.NodalLoad(nodeNear.LoadReaction.X, nodeNear.LoadReaction.Y, nodeNear.LoadReaction.M - nodeNear.SuperPosition.M);

                        nodeFar.LoadReaction = new Finite_Element_Analysis_Explorer.NodalLoad(nodeFar.LoadReaction.X - nodeFar.SuperPosition.X, nodeFar.LoadReaction.Y, nodeFar.LoadReaction.M);
                        nodeFar.LoadReaction = new Finite_Element_Analysis_Explorer.NodalLoad(nodeFar.LoadReaction.X, nodeFar.LoadReaction.Y - nodeFar.SuperPosition.Y, nodeFar.LoadReaction.M);
                        nodeFar.LoadReaction = new Finite_Element_Analysis_Explorer.NodalLoad(nodeFar.LoadReaction.X, nodeFar.LoadReaction.Y, nodeFar.LoadReaction.M - nodeFar.SuperPosition.M);
                    }
                    else
                    {
                    }

                    break;

                case 2:// Reverse of case 1.
                    if (nodeNear.Constraints.ConstraintType != ConstraintType.Fixed)
                    {
                        nodeNear.LoadReaction = new Finite_Element_Analysis_Explorer.NodalLoad(nodeNear.LoadReaction.X - nodeNear.SuperPosition.X, nodeNear.LoadReaction.Y, nodeNear.LoadReaction.M);
                        nodeNear.LoadReaction = new Finite_Element_Analysis_Explorer.NodalLoad(nodeNear.LoadReaction.X, nodeNear.LoadReaction.Y - nodeNear.SuperPosition.Y, nodeNear.LoadReaction.M);
                        nodeNear.LoadReaction = new Finite_Element_Analysis_Explorer.NodalLoad(nodeNear.LoadReaction.X, nodeNear.LoadReaction.Y, nodeNear.LoadReaction.M - nodeNear.SuperPosition.M);

                        nodeFar.LoadReaction = new Finite_Element_Analysis_Explorer.NodalLoad(nodeFar.LoadReaction.X - nodeFar.SuperPosition.X, nodeFar.LoadReaction.Y, nodeFar.LoadReaction.M);
                        nodeFar.LoadReaction = new Finite_Element_Analysis_Explorer.NodalLoad(nodeFar.LoadReaction.X, nodeFar.LoadReaction.Y - nodeFar.SuperPosition.Y, nodeFar.LoadReaction.M);
                        nodeFar.LoadReaction = new Finite_Element_Analysis_Explorer.NodalLoad(nodeFar.LoadReaction.X, nodeFar.LoadReaction.Y, nodeFar.LoadReaction.M - nodeFar.SuperPosition.M);
                    }
                    else
                    {
                    }

                    break;
            }

            nodeNear.PositionDisplaced = new Point(
                nodeNear.Position.X + nodeNear.Displacement.X,
                nodeNear.Position.Y + nodeNear.Displacement.Y,
                nodeNear.Position.M + nodeNear.Displacement.M);

            nodeFar.PositionDisplaced = new Point(
                nodeFar.Position.X + nodeFar.Displacement.X,
                nodeFar.Position.Y + nodeFar.Displacement.Y,
                nodeFar.Position.M + nodeFar.Displacement.M);

            lengthDisplacedXAxis = Math.Abs(nodeFar.PositionDisplaced.X - nodeNear.PositionDisplaced.X);
            lengthDisplacedYAxis = Math.Abs(nodeFar.PositionDisplaced.Y - nodeNear.PositionDisplaced.Y);

            lengthDifferenceXAxis = lengthDisplacedXAxis - lengthXAxis;
            lengthDifferenceYAxis = lengthDisplacedYAxis - lengthYAxis;

            lengthDisplaced = DMath.Sqrt((lengthDisplacedXAxis * lengthDisplacedXAxis) + (lengthDisplacedYAxis * lengthDisplacedYAxis));
            angleDisplaced = Convert.ToDecimal(Math.Atan2(
                nodeFar.PositionDisplaced.Location.Y - nodeNear.PositionDisplaced.Location.Y,
                nodeFar.PositionDisplaced.Location.X - nodeNear.PositionDisplaced.Location.X));

            lengthDifference = lengthDisplaced - length;
            angleDifference = AngleDisplaced - angle;
            lengthRatio = lengthDifference / length;

            if (Math.Abs(lengthRatio) > Camera.LargestLengthRatio)
            {
                Camera.LargestLengthRatio = Math.Abs(lengthRatio);
            }

            if (Math.Abs(internalLoadNearLocal.X) > Camera.LargestAxialRatio)
            {
                Camera.LargestAxialRatio = Math.Abs(internalLoadNearLocal.X);
            }

            normalStress = internalLoadNearLocal.X / this.section.Area;

            if (Math.Abs(normalStress) > Camera.LargestNormalStress)
            {
                Camera.LargestNormalStress = Math.Abs(normalStress);
            }

            UpdateGraphicsProperties();
        }

        internal void UpdateGraphicsProperties()
        {
            // Debug.WriteLine("UpdateGraphicsProperties " + parent.Index + " " + this.index);

            nearVectorDisplaced = new Vector2((float)(nodeNear.Position.X + (nodeNear.Displacement.X * (decimal)Options.DisplacementFactor)), (float)(nodeNear.Position.Y + (nodeNear.Displacement.Y * (decimal)Options.DisplacementFactor)));
            farVectorDisplaced = new Vector2((float)(nodeFar.Position.X + (nodeFar.Displacement.X * (decimal)Options.DisplacementFactor)), (float)(nodeFar.Position.Y + (nodeFar.Displacement.Y * (decimal)Options.DisplacementFactor)));

            // Unit Vectors.
            LDLUnit = Vector2.Normalize(new Vector2(farVectorDisplaced.X - nearVectorDisplaced.X, farVectorDisplaced.Y - nearVectorDisplaced.Y));
            LDLUnit = Vector2.TransformNormal(LDLUnit, Matrix3x2.CreateRotation((float)Math.PI / 2));

            if (lDLNear + lDLFar < 0)
            {
                lDLUnitRight = Vector2.TransformNormal(LDLUnit, Matrix3x2.CreateRotation((float)Math.PI / 4));
                lDLUnitLeft = Vector2.TransformNormal(LDLUnit, Matrix3x2.CreateRotation(-(float)Math.PI / 4));
            }
            else if (lDLNear + lDLFar > 0)
            {
                lDLUnitRight = Vector2.TransformNormal(-LDLUnit, Matrix3x2.CreateRotation((float)Math.PI / 4));
                lDLUnitLeft = Vector2.TransformNormal(-LDLUnit, Matrix3x2.CreateRotation(-(float)Math.PI / 4));
            }

            if (previousSegment != -1)
            {
                shearNear = NearVectorDisplaced + (LDLUnit * ((float)internalLoadNearLocal.Y * (float)Options.ShearFactor));
                shearFar = FarVectorDisplaced + (LDLUnit * (-(float)internalLoadFarLocal.Y * (float)Options.ShearFactor));
                Vector2 tmpVector = (shearNear + parent.Segments[previousSegment].ShearFar) / 2;
                shearNear = tmpVector;
                parent.Segments[previousSegment].ShearFar = tmpVector;

                momentNear = NearVectorDisplaced + (LDLUnit * ((float)internalLoadNearLocal.M * (float)Options.MomentFactor));
                momentFar = FarVectorDisplaced + (LDLUnit * (-(float)internalLoadFarLocal.M * (float)Options.MomentFactor));
                tmpVector = (momentNear + parent.Segments[previousSegment].MomentFar) / 2;
                momentNear = tmpVector;
                parent.Segments[previousSegment].MomentFar = tmpVector;

                nearLDLLine = NearVectorDisplaced + (LDLUnit * (-(float)lDLNear * (float)Options.LinearFactor));
                farLDLLine = FarVectorDisplaced + (LDLUnit * (-(float)lDLFar * (float)Options.LinearFactor));

                tmpVector = (nearLDLLine + parent.Segments[previousSegment].FarLDLLine) / 2;
                nearLDLLine = tmpVector;
                parent.Segments[previousSegment].FarLDLLine = tmpVector;
            }
            else
            {
                shearNear = NearVectorDisplaced + (LDLUnit * ((float)internalLoadNearLocal.Y * (float)Options.ShearFactor));
                shearFar = FarVectorDisplaced + (LDLUnit * (-(float)internalLoadFarLocal.Y * (float)Options.ShearFactor));

                momentNear = NearVectorDisplaced + (LDLUnit * ((float)internalLoadNearLocal.M * (float)Options.MomentFactor));
                momentFar = FarVectorDisplaced + (LDLUnit * (-(float)internalLoadFarLocal.M * (float)Options.MomentFactor));

                nearLDLLine = NearVectorDisplaced + (LDLUnit * (-(float)lDLNear * (float)Options.LinearFactor));
                farLDLLine = FarVectorDisplaced + (LDLUnit * (-(float)lDLFar * (float)Options.LinearFactor));
            }

            // centerPointDisplaced = new Vector2((float)((nearVectorDisplaced.X + farVectorDisplaced.X) /2), (float)((nearVectorDisplaced.Y + farVectorDisplaced.Y) /2));

            // Debug.WriteLine("CenterPoint " + parent.Index + " " + this.index + " " + centerPointDisplaced);
            // Output();
        }

        private void Add_PositiveLoad()
        {
            if (lDLNear > lDLFar)
            {
                // WNear
                decimal wN = lDLNear - lDLFar;

                decimal M = lDLFar * length * length / 12;
                decimal Nr = lDLFar * length / 2;

                DecimalMatrix superposition_local = new DecimalMatrix(6, 1);
                superposition_local[0, 0] = 0;
                superposition_local[1, 0] = Nr + (wN * length / 3 * 2);
                superposition_local[2, 0] = M + (wN * length * length / 20);
                superposition_local[3, 0] = 0;
                superposition_local[4, 0] = Nr + (wN * length / 3);
                superposition_local[5, 0] = -M + (-(wN * length * length) / 30);
                CreateSuperpositionValues(superposition_local);
            }
            else if (lDLNear < lDLFar)
            {
                // WFar
                decimal wF = lDLFar - lDLNear;

                // double WN = WNear - WFar;
                decimal M = lDLFar * length * length / 12;
                decimal Nr = lDLFar * length / 2;

                DecimalMatrix superposition_local = new DecimalMatrix(6, 1);
                superposition_local[0, 0] = 0;
                superposition_local[1, 0] = Nr + (wF * length / 3);
                superposition_local[2, 0] = M + (wF * length * length / 30);
                superposition_local[3, 0] = 0;
                superposition_local[4, 0] = Nr + (wF * length / 3 * 2);
                superposition_local[5, 0] = -M + (-(wF * length * length) / 20);

                CreateSuperpositionValues(superposition_local);
            }
            else
            {
                // pos UDL
                decimal m = lDLFar * length * length / 12;
                decimal Nr = lDLFar * length / 2;

                DecimalMatrix superposition_local = new DecimalMatrix(6, 1);
                superposition_local[0, 0] = 0;
                superposition_local[1, 0] = Nr;
                superposition_local[2, 0] = m;
                superposition_local[3, 0] = 0;
                superposition_local[4, 0] = Nr;
                superposition_local[5, 0] = -m;
                CreateSuperpositionValues(superposition_local);
            }
        }

        private void Add_NegativeLoad()
        {
            if (lDLNear > lDLFar)
            {
                decimal wF = lDLFar - lDLNear;
                decimal M = lDLNear * length * length / 12;
                decimal Nr = lDLNear * length / 2;
                DecimalMatrix superposition_local = new DecimalMatrix(6, 1);
                superposition_local[0, 0] = 0;
                superposition_local[1, 0] = Nr + (wF * length * 0.5m / 3);
                superposition_local[2, 0] = M + (wF * length * length / 30);
                superposition_local[3, 0] = 0;
                superposition_local[4, 0] = Nr + (wF * length * 0.5m / 3 * 2);
                superposition_local[5, 0] = -M + (-(wF * length * length) / 20);
                CreateSuperpositionValues(superposition_local);

                // Debug.WriteLine("LDL " + superposition_local[0, 0] + " " + superposition_local[1, 0] + " " + superposition_local[2, 0] + " " + superposition_local[3, 0] + " " + superposition_local[4, 0] + " " + superposition_local[5, 0]);
            }
            else if (lDLNear < lDLFar)
            {
                decimal wN = lDLNear - lDLFar;
                decimal M = lDLFar * length * length / 12;
                decimal Nr = lDLFar * length / 2;
                DecimalMatrix superposition_local = new DecimalMatrix(6, 1);
                superposition_local[0, 0] = 0;
                superposition_local[1, 0] = Nr + (wN * length * 0.5m / 3 * 2);
                superposition_local[2, 0] = M + (wN * length * length / 20);
                superposition_local[3, 0] = 0;
                superposition_local[4, 0] = Nr + (wN * length * 0.5m / 3);
                superposition_local[5, 0] = -M + (-(wN * length * length) / 30);
                CreateSuperpositionValues(superposition_local);

                // Debug.WriteLine("LDL " + superposition_local[0, 0] + " " + superposition_local[1, 0] + " " + superposition_local[2, 0] + " " + superposition_local[3, 0] + " " + superposition_local[4, 0] + " " + superposition_local[5, 0]);
            }
            else
            {
                // pos UDL
                decimal m = lDLFar * length * length / 12;
                decimal Nr = lDLFar * length / 2;
                DecimalMatrix superposition_local = new DecimalMatrix(6, 1);
                superposition_local[0, 0] = 0;
                superposition_local[1, 0] = Nr;
                superposition_local[2, 0] = m;
                superposition_local[3, 0] = 0;
                superposition_local[4, 0] = Nr;
                superposition_local[5, 0] = -m;
                CreateSuperpositionValues(superposition_local);
            }
        }

        private void CreateSuperpositionValues(DecimalMatrix superposition_local)
        {
            // Debug.WriteLine("Segment " + index + " L " + length + " N " + lDLNear + " F " + lDLFar);
            // Debug.WriteLine("LDL " + superposition_local[0, 0] + " " + superposition_local[1, 0] + " " + superposition_local[2, 0] + " " + superposition_local[3, 0] + " " + superposition_local[4, 0] + " " + superposition_local[5, 0]);

            // Create a matrix to hold the superposition with respect to the global co-ordinates.
            DecimalMatrix superposition_global = new DecimalMatrix(6, 1);
            DecimalMatrix tt = CreateForceTransformationMatrix();
            superposition_global = tt * superposition_local;

            nearSuperGlobal = new Finite_Element_Analysis_Explorer.NodalLoad(
                superposition_global[0, 0],
                superposition_global[1, 0],
                superposition_global[2, 0]);

            farSuperGlobal = new Finite_Element_Analysis_Explorer.NodalLoad(
                superposition_global[3, 0],
                superposition_global[4, 0],
                superposition_global[5, 0]);

            nearSuperLocal = new Finite_Element_Analysis_Explorer.NodalLoad(
                superposition_local[0, 0],
                superposition_local[1, 0],
                superposition_local[2, 0]);

            farSuperLocal = new Finite_Element_Analysis_Explorer.NodalLoad(
                superposition_local[3, 0],
                superposition_local[4, 0],
                superposition_local[5, 0]);
        }

        #endregion
    }
}
