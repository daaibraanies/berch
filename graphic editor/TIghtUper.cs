using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace graphic_editor
{
    /// <summary>
    /// Класс представляющий собой соединенные линии
    /// </summary>
    public class ComplexLines
    {
        private List<Line> _lines;
        private List<Point> _vertexes;
        private int _complexId;

        public static Color COMPLEX_COLOR = Color.YellowGreen;
        public List<Line> Lines
        {
            get { return _lines; }
            set { _lines = value; }
        }
        public List<Point> Vertexes
        {
            get { return _vertexes; }
            set { _vertexes = value; }
        }
        public int Id
        {
            get { return _complexId; }
        }
        public ComplexLines(int id)
        {
            _complexId = id;
            _lines = new List<Line>();
            _vertexes = new List<Point>();
        }
        public override string ToString()
        {
            string result = "Complex line #"+_complexId;

            return result;
        }

    }


    public static class TightUper
    {
        public static List<ComplexLines> complexes = new List<ComplexLines>();
        public static void TightUp(List<Line> lines)
        {
            int complexId = complexes.Count + 1;
            ComplexLines complexLine = new ComplexLines(complexId);

            foreach(Line itemToTight in lines)
            {
                itemToTight.Complex = true;
                itemToTight.LineType = Line.Types.Complex;
                itemToTight.ComplexID = complexId;
                itemToTight.PenColor = ComplexLines.COMPLEX_COLOR;

                complexLine.Lines.Add(itemToTight);
                if(!complexLine.Vertexes.Contains(itemToTight.StartPoint))
                     complexLine.Vertexes.Add(itemToTight.StartPoint);
                if (!complexLine.Vertexes.Contains(itemToTight.EndPoint))
                    complexLine.Vertexes.Add(itemToTight.EndPoint);

                TreeListControl.RemoveInfoLine(itemToTight);
                
            }
            complexes.Add(complexLine);
            TreeListControl.AddNewInfoComplex(complexLine);
            Form1.TreeSelectedLines.Clear();

        }
        
        public static void SelectComplexes(Line oneOfLines)
        {
            ComplexLines cmplx = complexes.Find(x => x.Id == oneOfLines.ComplexID);

            foreach(Line ln in cmplx.Lines)
            {
                if(!Form1.TreeSelectedLines.Contains(ln))
                {
                    Form1.TreeSelectedLines.Add(ln);
                    ln.PenColor = Line.SELECTED_COLOR;
                }
            }

        }

        public static void DeleteComplex(Line lineInComplex)
        {
            ComplexLines cmplx = complexes.Find(x => x.Id == lineInComplex.ComplexID);

            foreach(Line ln in cmplx.Lines)
            {
                Form1._allLines.Remove(ln);
            }
            TreeListControl.RemoveInfoComplex(cmplx);
        }

        public static void ComplexTransfer(MouseEventArgs e, Line oneOfLines)
        {
            ComplexLines cmplx = complexes.Find(x => x.Id == oneOfLines.ComplexID);

            foreach(Line line in cmplx.Lines)
            {
                line.DeltaStart = new Point(line.StartPoint.X - e.Location.X,
                                                        line.StartPoint.Y - e.Location.Y);

                line.DeltaEnd = new Point(line.EndPoint.X - e.Location.X,
                                        line.EndPoint.Y - e.Location.Y);
            }

            Form1.WrapperForComplexlines = cmplx;
           
        }

    }
}

