using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace graphic_editor
{
    /// <summary>
    /// Преобразования ТОЧКА-ТОЧКА в уравнения линии для оперций вычисления угла , поворотов и тп
    /// </summary>
    class LineEquintaince
    {
        private Point p1;
        private Point p2;
        private int eqA=0;
        private int eqB=0;
        private int eqC=0;
        private double k=0;
        private Point normal;

        #region Properties
        public int A
        {
            get { return eqA==0 ? p1.Y - p2.Y : eqA; }
            set { eqA = value; }
        }
        public int B
        {
            get { return eqB == 0 ? p2.X - p1.X : eqB; }
            set { eqB = value; }
        }
        public int C
        {
            get { return eqC == 0 ? p1.X * p2.Y - p2.X * p1.Y : eqC; }
            set { eqC = value; }
        }

        public double K
        {
            get { return (-((double)A / (double)B)); }
            set { k = value; }
        }
        public LineEquintaince(int A,int B,int C=0)
        {
            eqA = A;
            eqB = B;
            eqC = C;
            normal = new Point(A, B);
        }
        #endregion

        public LineEquintaince(Point p1,Point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
            eqA = A;
            eqB = B;
            eqC = C;
            k = K;
            normal = new Point(A, B);
        }
        public LineEquintaince(Line line)
        {
            p1 = line.StartPoint;
            p2 = line.EndPoint;
            eqA = A;
            eqB = B;
            eqC = C;
            k = K;
            normal = new Point(A, B);
        }

        public LineEquintaince Perpendicularline(int A2,int B2)
        {
            //A1A2+B1B2=0

            if((A*A2+B*B2)==0) //parallelni
            {
                MyLogger.LogIt("fiejfef");
            }

                A2 = -(B * B2) / A;
                B2 = -(A * A2) / B;
            
  

            return new LineEquintaince(A2, B2);
        }

        public bool IsPerpendicularToLine(LineEquintaince lineEq)
        {
            if ((this.k * lineEq.k) >= -0.9 && (this.k * lineEq.k) <= -1.1)
                return true;
            else if (double.IsInfinity(this.k) || double.IsInfinity(lineEq.K))
                return true;
            else return false;
        }

        public static double AngleBetweenTwoLines(LineEquintaince eq1,LineEquintaince eq2)
        {
            double cosN1N2 = ((eq1.A * eq2.A) + (eq1.B * eq2.B)) / (Math.Sqrt(Math.Pow(eq1.A, 2) + Math.Pow(eq1.B, 2)) *
                Math.Sqrt(Math.Pow(eq2.A, 2) + Math.Pow(eq2.B, 2)));

            return Math.Acos(cosN1N2);
        }

        public override string ToString()
        {
            return A + "x+" + B + "y+" + C + "=0\n"+
                "y="+k+"x+b";
        }



    }
}
