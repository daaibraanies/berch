using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace graphic_editor
{
    public class Line
    {
        #region Data
        private const int PEN_WIDTH = 3;
        private const int POIN_SIZE = 5;
        private const int BORDER_SIZE = 2;
        private const int LINE_SELECTION_ARRANGE = 7;
        static private int _horizontalDirection;    /*Направление выравнивания, нужна была в старой версиивроде*/
        static private int _verticalDirection;      /*Направление выравнивания, нужна была в старой версии вроде*/

        private bool _fixed = false;                /*Возможность осуществлять действия над линией*/
        private bool _complex = false;              /*Связанная ли линия с другими*/
        private int _lineId;                        /*Номер линии*/
        private int _pointSize;                     /*Размер начальной и конечной точек линии*/
        private int _penSize;                       /*Ширина линии*/
        private int _complexId;                     /*Номер комплекса линии в который всходит экземпляр*/
        private int _length = 0;                    /*Длина линии*/
        private Point _strartPoint;                 /*Начальная точка*/
        private Point _endPoint;                    /*Конечная точка*/
        private Point _deltaStart;                  /*Смещение начальной точки(нужно для перемещения линии) в момет dt*/
        private Point _lineCenter;                  /* центр линии */
        private Point _deltaEnd;                    /*Смещение конечной точки(нужно для перемещения линии) в момет dt*/
        private Color _penColor;                    /*Текущий цвет линии*/


        public enum Types
        {
            Single,         //Просто линия
            Complex        //если мы их объединили
        };                        /*Определение типов линии*/
        public Types LineType;                      /*тип линии*/

        public List<Line> commonLines;                                                      //не помню для чгео оставил
        static private List<Line> linesForOrthogonalization = new List<Line>();             //не помню для чгео оставил
        #endregion

        //цвета для разных режимов действий
        #region Colors arrange
        static public Color GENERAL_COLOR = Color.DarkSeaGreen;
        static public Color EDITORIAL_COLOR = Color.AliceBlue;
        static public Color FIXED_COLOR = Color.Pink;
        static public Color DELITABLE_COLOR = Color.PaleVioletRed;
        static public Color SELECTED_COLOR = Color.Gray;
        static public Color NEARBY_COLOR = Color.DarkBlue;
        static public Color LINE_TO_ORTHOGON = Color.Red;
        #endregion

        //Доступ к переменым
        #region Properties

        public int ComplexID
        {
            get { return _complexId; }
            set { _complexId = value; }
        }
        public bool Fixed
        {
            get { return _fixed; }
            set { _fixed = value; }
        }
        public bool Complex
        {
            get { return _complex; }
            set { _complex = value; }
        }
        public Color PenColor
        {
            get { return _penColor; }
            set { _penColor = value; }
        }
        public int PenWidth
        {
            get { return PEN_WIDTH; }
        }
        public Point StartPoint
        {
            set { _strartPoint = value; }
            get { return _strartPoint; }
        }
        public Point EndPoint
        {
            set { _endPoint = value; }
            get { return _endPoint; }
        }
        public Point DeltaStart
        {
            get { return _deltaStart; }
            set { _deltaStart = value; }
        }
        public Point DeltaEnd
        {
            get { return _deltaEnd; }
            set { _deltaEnd = value; }
        }
        public int Id
        {
            get { return _lineId; }
        }
        public int PenSize
        {
            get { return _penSize; }
            set { _penSize = value; }
        }

        /* public float Slope
        {
            get
            {
                return (((float)_endPoint.Y - (float)_strartPoint.Y) / ((float)_endPoint.X - (float)_strartPoint.X));
            }
        }*/         //использовалось для определения принадлежности точки линии [X]

        /*public float YIntercept
         {
             get { return _strartPoint.Y - Slope * _strartPoint.X; }
         }*/    //использовалось для определения принадлежности точки линии [X]

        public int Length
        {
            get
            {
                return _length = (int)Math.Sqrt(Math.Pow((_endPoint.X - _strartPoint.X), 2) + Math.Pow((_endPoint.Y - _strartPoint.Y), 2));
            }
            set { _length = value; }
        }
        public Point LineCenter
        {
            get { return new Point((_strartPoint.X + _endPoint.X) / 2, (_strartPoint.Y + _endPoint.Y) / 2); }
        }
        static public int HorizontalDirection
        {
            get { return _horizontalDirection; }
            set { _horizontalDirection = value; }
        }
        static public int VerticalDirection
        {
            get { return _verticalDirection; }
            set { _verticalDirection = value; }
        }




        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param razmer pen="penSize"></param>
        /// <param razmer tochki koncs="pointsize"></param>
        public Line(int id = 0, int penSize = PEN_WIDTH, int pointsize = POIN_SIZE)
        {
            _penSize = penSize;
            _pointSize = 1;
            _lineId = id;
            _pointSize = pointsize;
            _penColor = GENERAL_COLOR;
            LineType = Types.Single;
            _complexId = 0;
            _horizontalDirection = 1;
            _verticalDirection = -1;
            commonLines = new List<Line>();
        }

        #endregion

        #region Functions
        public void DrawStartPoints(PaintEventArgs g)
        {

            Rectangle startRect;
            Rectangle endRect;
            Rectangle centerRect;
            Size pointSize;

            if (_strartPoint != null)
            {

                pointSize = new Size(_pointSize, _pointSize);
                startRect = new Rectangle(_strartPoint, pointSize);
                endRect = new Rectangle(_endPoint, pointSize);
                centerRect = new Rectangle(LineCenter, pointSize);
                using (Pen pn = new Pen(Color.Aqua, BORDER_SIZE))
                {
                    g.Graphics.DrawRectangle(pn, startRect);
                    g.Graphics.DrawRectangle(pn, endRect);
                    g.Graphics.DrawRectangle(pn, centerRect);
                }
            }
            else
            {
                MyLogger.LogIt("Cant find start point! |" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + "|", MyLogger.Importance.Fatal);
            }

        }              
        public bool isEndPoint(Point p, int cusion = 5)
        {
            float rd = Math.Abs(_endPoint.X - p.X);
            float kd = Math.Abs(_endPoint.Y - p.Y);
            if (rd <= cusion && kd <= cusion)
                return true;
            else
                return false;
        }
        public bool isStartPoint(Point p, int cusion = 5)
        {
            float rd = Math.Abs(_strartPoint.X - p.X);
            float kd = Math.Abs(_strartPoint.Y - p.Y);
            if (rd <= cusion && kd <= cusion)
                return true;
            else
                return false;
        }
        public bool PointOnLineSegment(Point pt, double epsilon = 3)
        {
            Point pt1 = this.EndPoint;
            Point pt2 = this.StartPoint;

            if (pt.X - Math.Max(pt1.X, pt2.X) > epsilon ||
                Math.Min(pt1.X, pt2.X) - pt.X > epsilon ||
                pt.Y - Math.Max(pt1.Y, pt2.Y) > epsilon ||
                Math.Min(pt1.Y, pt2.Y) - pt.Y > epsilon)
                return false;

            if (Math.Abs(pt2.X - pt1.X) < epsilon)
                return Math.Abs(pt1.X - pt.X) < epsilon || Math.Abs(pt2.X - pt.X) < epsilon;
            if (Math.Abs(pt2.Y - pt1.Y) < epsilon)
                return Math.Abs(pt1.Y - pt.Y) < epsilon || Math.Abs(pt2.Y - pt.Y) < epsilon;

            double x = pt1.X + (pt.Y - pt1.Y) * (pt2.X - pt1.X) / (pt2.Y - pt1.Y);
            double y = pt1.Y + (pt.X - pt1.X) * (pt2.Y - pt1.Y) / (pt2.X - pt1.X);

            return Math.Abs(pt.X - x) < epsilon || Math.Abs(pt.Y - y) < epsilon;
        }
        public override string ToString()
        {
            string result = "Line";
            if (this.Fixed)
                result += " [FX]";
            if (this.Complex)
                result += " [CX]";


            return result;
        }
       
        #endregion

        #region StaticFunctions

        public static void StartDrawingLine(MouseEventArgs e)
        {

            int newLineId = Form1._allLines.Count + 1;
            Line newLine = new Line(newLineId);
            newLine.StartPoint = e.Location;
            newLine.EndPoint = e.Location;

            InfoPanel.startPointInfo.Text = newLine._strartPoint.ToString();

            foreach (Line currentLine in Form1._allLines)
            {
                if (currentLine.isEndPoint(e.Location, 10))
                {
                    newLine.StartPoint = currentLine.EndPoint;
                    break;
                }

                else if (currentLine.isStartPoint(e.Location, 10))
                {
                    newLine.StartPoint = currentLine.StartPoint;
                    break;
                }
            }
            Form1._allLines.Add(newLine);
        }
        public static void FinishDrawingLine(MouseEventArgs e, Line currentlyDrawingLine)
        {
            currentlyDrawingLine.EndPoint = e.Location;

            foreach (Line currentLine in Form1._allLines)
            {
                if (currentLine.isEndPoint(e.Location, 10))
                    currentlyDrawingLine.EndPoint = currentLine.EndPoint;
                else if (currentLine.isStartPoint(e.Location, 10))
                    currentlyDrawingLine.EndPoint = currentLine.StartPoint;
            }
            MyLogger.LogIt("LINE " + currentlyDrawingLine.Id + " " + currentlyDrawingLine.StartPoint + " " + currentlyDrawingLine.EndPoint, MyLogger.Importance.Fatal);
        }
        public static void TransferLine(MouseEventArgs e)
        {
            foreach (Line currentLine in Form1._allLines)
            {
                if (currentLine.PointOnLineSegment(e.Location))
                {
                    if (currentLine.LineType == Types.Complex)
                    {
                        TightUper.ComplexTransfer(e, currentLine);
                        break;
                    }
                    else if(currentLine.Fixed)
                    {

                        string message = "Элемент зафиксирован.";
                        string caption = "Действие невозможно.";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result;
                        result = MessageBox.Show(message, caption, buttons);
                    }
                    else
                    {
                        currentLine._deltaStart = new Point(currentLine.StartPoint.X - e.Location.X,
                                                        currentLine.StartPoint.Y - e.Location.Y);

                        currentLine._deltaEnd = new Point(currentLine.EndPoint.X - e.Location.X,
                                                currentLine.EndPoint.Y - e.Location.Y);

                        Form1.WrapperForSelectedLines = currentLine;
                        Form1.WrapperForSelectedLines.PenColor = Line.EDITORIAL_COLOR;
                        break;
                    }
                }
            }
        }
        public static void SelectLine(MouseEventArgs e)
        {
            foreach (Line currentLine in Form1._allLines)
            {

                if (currentLine.PointOnLineSegment(e.Location))
                {
                    if (currentLine.LineType == Types.Single)
                    {
                        Form1.WrapperForSelectedLines = currentLine;          

                        if (Form1.TreeSelectedLines.Contains(currentLine))
                        {
                            if(currentLine==Form1.WrapperForSelectedLines)
                            {
                                currentLine.PenColor = Line.GENERAL_COLOR;
                                Form1.TreeSelectedLines.Remove(currentLine);
                            }else
                            {
                                currentLine.PenColor = Line.GENERAL_COLOR;
                                Form1.TreeSelectedLines.Remove(currentLine);
                                break;
                            }

                        }
                        else
                        {
                            currentLine.PenColor = Line.SELECTED_COLOR;
                            Form1.TreeSelectedLines.Add(currentLine);

                            InfoPanel.lineLenghtInfo.Text = currentLine.Length.ToString();
                            InfoPanel.startPointInfo.Text = currentLine.StartPoint.ToString();
                            InfoPanel.endPointInfo.Text = currentLine.EndPoint.ToString();
                            break;
                        }
                    }
                    else if (currentLine.LineType == Types.Complex)
                    {
                        TightUper.SelectComplexes(currentLine);
                        break;
                    }
                }

            }
        }
        public static void FixLine(MouseEventArgs e)
        {
            foreach (Line currentLine in Form1.TreeSelectedLines)
            {
                if (currentLine.PointOnLineSegment(e.Location))
                {
                    if (!currentLine.Fixed)
                    {
                        currentLine.Fixed = true;
                        currentLine.PenColor = Line.FIXED_COLOR;
                        TreeListControl.RefreshTreeList(currentLine);

                        Form1.TreeSelectedLines.Clear();
                        break;
                    }
                    else if (currentLine.Fixed)
                    {
                        currentLine.Fixed = false;
                        currentLine.PenColor = Line.GENERAL_COLOR;
                        TreeListControl.RefreshTreeList(currentLine);

                        Form1.TreeSelectedLines.Clear();
                        break;
                    }
                }
            }

        }
        public static void DeleteLine(MouseEventArgs e)
        {
            try
            {
                foreach (Line currentLine in Form1._allLines)
                {
                    if (currentLine.PointOnLineSegment(e.Location))
                    {
                        if (currentLine.LineType == Types.Complex)
                        {
                            TightUper.DeleteComplex(currentLine);
                            break;
                        }
                        else if (!currentLine.Fixed && currentLine.LineType == Types.Single)
                        {
                            Form1._allLines.Remove(currentLine);
                            TreeListControl.RemoveInfoLine(currentLine);

                            MyLogger.LogIt("Trying to dele fixed line!", MyLogger.Importance.Warrning);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MyLogger.LogIt(ex.Message, MyLogger.Importance.Fatal);
            }
        }
     
        public static void AlignHorizontally(MouseEventArgs e)
        {
            foreach (Line currentLine in Form1._allLines)
            {
                if (currentLine.PointOnLineSegment(e.Location))
                {
                    if (
                        currentLine.LineType == Types.Single &&
                        !currentLine.Fixed
                        )
                    {
                        Line HORIZONTAL = new Line(-1, 0, 0);
                        HORIZONTAL.StartPoint = new Point(0, 250);
                        HORIZONTAL.EndPoint = new Point(930,250);

                        LineEquintaince modelLineEquainteince = new LineEquintaince(currentLine);                  
                        LineEquintaince selectedLineEquainteince = new LineEquintaince(HORIZONTAL);

                        double anglePHI;
                        anglePHI = LineEquintaince.AngleBetweenTwoLines(selectedLineEquainteince, modelLineEquainteince);
                        double angle = anglePHI * (180 / Math.PI);
                        double dA = 180 - angle;

                        if (dA > 0)
                            dA *= (-1);
                        if (currentLine.StartPoint.Y > currentLine.EndPoint.Y)
                            dA *= (-1);
                        double rotationAngle = -dA * Math.PI / 180;


                        Point modifiedStart = new Point(
                                   (int)(-Math.Sin(rotationAngle) * (currentLine.StartPoint.Y - currentLine.LineCenter.Y) + Math.Cos(rotationAngle) *
                                   (currentLine.StartPoint.X - currentLine.LineCenter.X) + currentLine.LineCenter.X),     //x1

                                   (int)(Math.Cos(rotationAngle) * (currentLine.StartPoint.Y - currentLine.LineCenter.Y) + Math.Sin(rotationAngle) *
                                   (currentLine.StartPoint.X - currentLine.LineCenter.X) + currentLine.LineCenter.Y)      //y1
                                   );

                        Point modifiedEnd = new Point(
                            (int)(-Math.Sin(rotationAngle) * (currentLine.EndPoint.Y - currentLine.LineCenter.Y) + Math.Cos(rotationAngle) *
                            (currentLine.EndPoint.X - currentLine.LineCenter.X) + currentLine.LineCenter.X),     //x2

                            (int)(Math.Cos(rotationAngle) * (currentLine.EndPoint.Y - currentLine.LineCenter.Y) + Math.Sin(rotationAngle) *
                            (currentLine.EndPoint.X - currentLine.LineCenter.X) + currentLine.LineCenter.Y)      //y2
                            );

                        currentLine.StartPoint = modifiedStart;
                        currentLine.EndPoint = modifiedEnd;
                        break;
                    }
                }
            }
        }
       
        
        /* public static void AlignHorizontally(MouseEventArgs e)
        {
            foreach (Line currentLine in Form1._allLines)
            {
                if (currentLine.PointOnLineSegment(e.Location))
                {
                    if (
                        currentLine.LineType == Types.Single &&
                        !currentLine.Fixed
                        )
                    {
                        Point tmp = Point.Empty;
                        Point tmp2 = Point.Empty;

                        tmp.Y = currentLine.LineCenter.Y;
                        tmp.X = currentLine.StartPoint.X;
                        tmp2.Y = tmp.Y;
                        tmp2.X = currentLine.EndPoint.X;



                        currentLine.StartPoint = tmp;
                        currentLine.EndPoint = tmp2;
                        break;
                    }

                }
            }
        }*/

        public static void AlignVertivally(MouseEventArgs e)
        {
            foreach (Line currentLine in Form1._allLines)
            {
                if (currentLine.PointOnLineSegment(e.Location))
                {
                    if (
                        currentLine.LineType == Types.Single &&
                        !currentLine.Fixed
                        )
                    {
                        Line VERTICAL = new Line(-2, 0, 0);
                        VERTICAL.StartPoint = new Point(420, 0);
                        VERTICAL.EndPoint = new Point(420, 545);

                        LineEquintaince modelLineEquainteince = new LineEquintaince(currentLine);
                        LineEquintaince selectedLineEquainteince = new LineEquintaince(VERTICAL);

                        double anglePHI;
                        anglePHI = LineEquintaince.AngleBetweenTwoLines(selectedLineEquainteince, modelLineEquainteince);
                        double angle = anglePHI * (180 / Math.PI);
                        double dA = 360-angle;

                        if ((currentLine.StartPoint.Y > currentLine.EndPoint.Y)||(currentLine.StartPoint.X > currentLine.EndPoint.X))
                            dA *= (-1);
                        double rotationAngle = -dA * Math.PI / 180;


                        Point modifiedStart = new Point(
                                   (int)(-Math.Sin(rotationAngle) * (currentLine.StartPoint.Y - currentLine.LineCenter.Y) + Math.Cos(rotationAngle) *
                                   (currentLine.StartPoint.X - currentLine.LineCenter.X) + currentLine.LineCenter.X),     //x1

                                   (int)(Math.Cos(rotationAngle) * (currentLine.StartPoint.Y - currentLine.LineCenter.Y) + Math.Sin(rotationAngle) *
                                   (currentLine.StartPoint.X - currentLine.LineCenter.X) + currentLine.LineCenter.Y)      //y1
                                   );

                        Point modifiedEnd = new Point(
                            (int)(-Math.Sin(rotationAngle) * (currentLine.EndPoint.Y - currentLine.LineCenter.Y) + Math.Cos(rotationAngle) *
                            (currentLine.EndPoint.X - currentLine.LineCenter.X) + currentLine.LineCenter.X),     //x2

                            (int)(Math.Cos(rotationAngle) * (currentLine.EndPoint.Y - currentLine.LineCenter.Y) + Math.Sin(rotationAngle) *
                            (currentLine.EndPoint.X - currentLine.LineCenter.X) + currentLine.LineCenter.Y)      //y2
                            );

                        currentLine.StartPoint = modifiedStart;
                        currentLine.EndPoint = modifiedEnd;
                        break;
                    }
                }
            }
        }
        public static void MakePerpendicularLine(Point pointOnLine)
        {
            Line lineToBeoRthogonal = Form1.WrapperForSelectedLines;

            if (lineToBeoRthogonal != null)         //линия которая будет становиться перпендикулярной
            {
                foreach (Line currentLine in Form1._allLines)
                {
                    if (currentLine != lineToBeoRthogonal)
                    {
                        if (currentLine.PointOnLineSegment(pointOnLine))
                        {

                            LineEquintaince modelLineEquainteince = new LineEquintaince(currentLine);                  //ОРИЕНТИР ОРТОГАНАЛИЗАЦИИИ. Уравненеия конечно
                            LineEquintaince selectedLineEquainteince = new LineEquintaince(lineToBeoRthogonal);        //ОБЪЕКТ ОРТОГАНАЛИЗАЦИИИ.   Уравненеия конечно

                            bool alreadyPerpendicullary = modelLineEquainteince.IsPerpendicularToLine(selectedLineEquainteince);       //Проверка, а вдруг уже перпенды

                            if (!alreadyPerpendicullary)
                            {
                                double anglePHI;
                                double rotationAngle;
                                anglePHI = LineEquintaince.AngleBetweenTwoLines(selectedLineEquainteince, modelLineEquainteince);
                                double angle = anglePHI * (180 / Math.PI);      //ttest
                                double dA = 90 - angle;
                                /*if (dA > 90)
                                    dA %= 90;*/
                                if (dA < 0)
                                    dA *= (-1);

                                rotationAngle = -dA * Math.PI / 180;

                                Point modifiedStart = new Point(
                                    (int)(-Math.Sin(rotationAngle) * (lineToBeoRthogonal.StartPoint.Y - lineToBeoRthogonal.LineCenter.Y) + Math.Cos(rotationAngle) *
                                    (lineToBeoRthogonal.StartPoint.X - lineToBeoRthogonal.LineCenter.X) + lineToBeoRthogonal.LineCenter.X),     //x1

                                    (int)(Math.Cos(rotationAngle) * (lineToBeoRthogonal.StartPoint.Y - lineToBeoRthogonal.LineCenter.Y) + Math.Sin(rotationAngle) *
                                    (lineToBeoRthogonal.StartPoint.X - lineToBeoRthogonal.LineCenter.X) + lineToBeoRthogonal.LineCenter.Y)      //y1
                                    );

                                Point modifiedEnd = new Point(
                                    (int)(-Math.Sin(rotationAngle) * (lineToBeoRthogonal.EndPoint.Y - lineToBeoRthogonal.LineCenter.Y) + Math.Cos(rotationAngle) *
                                    (lineToBeoRthogonal.EndPoint.X - lineToBeoRthogonal.LineCenter.X) + lineToBeoRthogonal.LineCenter.X),     //x2

                                    (int)(Math.Cos(rotationAngle) * (lineToBeoRthogonal.EndPoint.Y - lineToBeoRthogonal.LineCenter.Y) + Math.Sin(rotationAngle) *
                                    (lineToBeoRthogonal.EndPoint.X - lineToBeoRthogonal.LineCenter.X) + lineToBeoRthogonal.LineCenter.Y)      //y2
                                    );

                                lineToBeoRthogonal.StartPoint = modifiedStart;
                                lineToBeoRthogonal.EndPoint = modifiedEnd;
                                lineToBeoRthogonal.PenColor = Line.GENERAL_COLOR;
                                Form1.WrapperForSelectedLines = null;
                                break;
                            }
                        }
                    }

                }
            }
        }
        public static void MakeParallelLine(Point pointOnLine)
        {
            Line lineToParallel = Form1.WrapperForSelectedLines;

            if (lineToParallel != null)
            {
                foreach (Line currentLine in Form1._allLines)
                {
                    if (currentLine != lineToParallel)
                    {
                        if (currentLine.PointOnLineSegment(pointOnLine))
                        {
                            LineEquintaince modelLineEquainteince = new LineEquintaince(currentLine);                  //ОРИЕНТИР ОРТОГАНАЛИЗАЦИИИ. Уравненеия конечно
                            LineEquintaince selectedLineEquainteince = new LineEquintaince(lineToParallel);        //ОБЪЕКТ ОРТОГАНАЛИЗАЦИИИ.   Уравненеия конечно

                            bool alreadyParallel = (modelLineEquainteince.K == selectedLineEquainteince.K);
                            if (!alreadyParallel)
                            {
                                double anglePHI;
                                double rotationAngle;
                                anglePHI = LineEquintaince.AngleBetweenTwoLines(selectedLineEquainteince, modelLineEquainteince);
                                double angle = anglePHI * (180 / Math.PI);      //ttest
                                double dA = 180 - angle;

                                //if (dA < 0)
                                    //dA *= (-1);
                                 if (lineToParallel.EndPoint.Y<lineToParallel.StartPoint.Y)
                                    dA *= (-1);

                                rotationAngle = dA * Math.PI / 180;

                                Point modifiedStart = new Point(
                                    (int)(-Math.Sin(rotationAngle) * (lineToParallel.StartPoint.Y - lineToParallel.LineCenter.Y) + Math.Cos(rotationAngle) *
                                    (lineToParallel.StartPoint.X - lineToParallel.LineCenter.X) + lineToParallel.LineCenter.X),     //x1

                                    (int)(Math.Cos(rotationAngle) * (lineToParallel.StartPoint.Y - lineToParallel.LineCenter.Y) + Math.Sin(rotationAngle) *
                                    (lineToParallel.StartPoint.X - lineToParallel.LineCenter.X) + lineToParallel.LineCenter.Y)      //y1
                                    );

                                Point modifiedEnd = new Point(
                                    (int)(-Math.Sin(rotationAngle) * (lineToParallel.EndPoint.Y - lineToParallel.LineCenter.Y) + Math.Cos(rotationAngle) *
                                    (lineToParallel.EndPoint.X - lineToParallel.LineCenter.X) + lineToParallel.LineCenter.X),     //x2

                                    (int)(Math.Cos(rotationAngle) * (lineToParallel.EndPoint.Y - lineToParallel.LineCenter.Y) + Math.Sin(rotationAngle) *
                                    (lineToParallel.EndPoint.X - lineToParallel.LineCenter.X) + lineToParallel.LineCenter.Y)      //y2
                                    );

                                lineToParallel.StartPoint = modifiedStart;
                                lineToParallel.EndPoint = modifiedEnd;
                                Form1.WrapperForSelectedLines.PenColor = Line.GENERAL_COLOR;
                                Form1.WrapperForSelectedLines = null;
                                break;
                            }
                        }
                    }
                    else
                    {
                        string message = "Не удается определить точку на линии.";
                        string caption = "Ошибка.";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result;
                        result = MessageBox.Show(message, caption, buttons);
                    }
                }
            }

        }
        public static void ShowAngleBetween(Point pointOnline)
        {
            Line first = Form1.WrapperForSelectedLines;
            foreach (Line second in Form1._allLines)
            {
                if(second.PointOnLineSegment(pointOnline) && second!=first)
                {
                    LineEquintaince frstEQ = new LineEquintaince(first);
                    LineEquintaince scdEQ = new LineEquintaince(second);

                    double radAngle = LineEquintaince.AngleBetweenTwoLines(frstEQ, scdEQ);
                    double degAngle = radAngle * (180 / Math.PI);

                    string message = "Градусы: "+Math.Round(degAngle,1)+"\nРадианы: "+Math.Round(radAngle,3);
                    string caption = "Угол между линиями";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    Form1.WrapperForSelectedLines.PenColor = Line.GENERAL_COLOR;
                    Form1.WrapperForSelectedLines = null;
                    break;
                }
            }
        }



        #endregion
    }
}