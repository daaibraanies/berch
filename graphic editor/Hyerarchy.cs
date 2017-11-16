using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphic_editor
{
    public static class Hyerarchy
    {

        public static System.Windows.Forms.TreeView source;

        static public  List<Line> _lines = new List<Line>();

        static public Dictionary<string, string> _nodesNames = new Dictionary<string, string>()
        {
            {"LN","Lines" }
        };

        public static void HyerarcyINIT()
        {
            source.Nodes.Add(_nodesNames["LN"]);
        }

        public static void AddLineToHierarchhy(Line line)
        {
            source.Nodes[0].Nodes.Add(line.ToString());
        }


    }
}
