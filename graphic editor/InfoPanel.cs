using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace graphic_editor
{
    public static class InfoPanel
    {
        public static Label lineLenghtInfo {get;set;}
        public static Label endPointInfo { get; set; }
        public static Label startPointInfo { get; set; }
        public static Label  currentActionInfo { get; set; }
        public static Label angleMouse { get; set; }
       


        public static void INFOPANEL_INIT()
        {
            lineLenghtInfo.Text = "0";
            endPointInfo.Text = "{0:0}";
            startPointInfo.Text = "{0:0}";  
        }



        public static void toDefault()
       {
            lineLenghtInfo.Text = "0";
            endPointInfo.Text = "{0:0}";
            startPointInfo.Text = "{0:0}";
       }
    }
}
