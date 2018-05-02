using Client.MirControls;
using Client.MirGraphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.MirScenes.Dialogs
{
    public sealed class AssistDialog : MirControl
    {
        public MirCheckBox auto;
        

        public AssistDialog()
        {
            Movable = true;
            Sort = true;
            Location = Center;


        //    auto = new MirCheckBox { Index = 1956, UnTickedIndex = 2086, TickedIndex = 2087, Parent = this, Location = new Point(16, 16), Library = Libraries.Prguse };

        }

        public void Hide()
        {
            if (!Visible) return;
            Visible = false;
        }

        public void Show()
        {
            if (Visible) return;
            Visible = true;
        }
    }
}
