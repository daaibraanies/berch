using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace graphic_editor
{
    public static class TreeListControl
    {
        private static ListView _source;
        public static bool Enabled;
        public static ListView TreeSource
        {
            get { return _source; }
            set { _source = value; }
        }

        public static void AddNewInfoLine(Line lineToAdd)
        {
            if(Enabled)
            { 
            ListViewItem item = new ListViewItem(lineToAdd.Id.ToString());
            item.SubItems.Add(lineToAdd.ToString());
            _source.Items.Add(item);
            }
        }

        public static void AddNewInfoComplex(ComplexLines complex)
        {
            if (Enabled)
            {
                ListViewItem item = new ListViewItem(complex.Id.ToString());
                item.SubItems.Add(complex.ToString());
                _source.Items.Add(item);
            }
        }

        public static void RemoveInfoComplex(ComplexLines complex)
        {
            if (Enabled)
            {
                ListViewItem item = _source.FindItemWithText(complex.Id.ToString());
                _source.Items.Remove(item);
            }
        }

        public static void RefreshTreeList(Line line)
        {
            if(Enabled)
            { 
                ListViewItem item = _source.FindItemWithText(line.Id.ToString());
                item.SubItems.Clear();
                item.Text=line.Id.ToString();
                item.SubItems.Add(line.ToString());
            }
        }

        public static void RemoveInfoLine(Line lineToDelete)
        {
            if(Enabled)
            { 
                ListViewItem item = _source.FindItemWithText(lineToDelete.Id.ToString());
                _source.Items.Remove(item);
            }
        }


    }
}
