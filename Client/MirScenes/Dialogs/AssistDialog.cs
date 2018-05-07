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
    public sealed class AssistDialog : MirImageControl
    {
        public MirCheckBox checkBoxSmartAttack, checkBoxSmartFire, checkBoxAutoEat, checkBoxSmartSheild;
        public MirTextBox textBoxPercentHpProtect, textBoxPercentMpProtect;
        public MirTextBox textBoxEatItemName, textBoxEatMpName;

        public AssistDialog()
        {
            Index = 710;
            Library = Libraries.Prguse;

            Movable = true;
            Sort = true;
            Location = Center;

            checkBoxSmartAttack = new MirCheckBox { Index = 2086, UnTickedIndex = 2086, TickedIndex = 2087, Parent = this, Location = new Point(16, 16), Library = Libraries.Prguse };
            checkBoxSmartAttack.LabelText = "刀刀刺杀";
            checkBoxSmartAttack.Click += CheckBoxClick;

            checkBoxSmartFire = new MirCheckBox { Index = 2086, UnTickedIndex = 2086, TickedIndex = 2087, Parent = this, Location = new Point(16, 32), Library = Libraries.Prguse };
            checkBoxSmartFire.LabelText = "自动烈火";
            checkBoxSmartFire.Checked = Settings.smartFireHit;
            checkBoxSmartFire.Click += CheckBoxFireClick;

            checkBoxAutoEat = new MirCheckBox { Index = 2086, UnTickedIndex = 2086, TickedIndex = 2087, Parent = this, Location = new Point(16, 48), Library = Libraries.Prguse };
            checkBoxAutoEat.LabelText = "自动吃药";
            checkBoxAutoEat.Checked = Settings.smartFireHit;
            checkBoxAutoEat.Click += CheckBoxAutoEatClick;

            checkBoxSmartSheild = new MirCheckBox { Index = 2086, UnTickedIndex = 2086, TickedIndex = 2087, Parent = this, Location = new Point(206, 16), Library = Libraries.Prguse };
            checkBoxSmartSheild.LabelText = "自动开盾";
            checkBoxSmartSheild.Checked = Settings.smartSheild;
            checkBoxSmartSheild.Click += CheckBoxSheildClick;

            textBoxPercentHpProtect = new MirTextBox {
                Location = new Point(16, 64),
                Parent = this,
                Size = new Size(136, 15),
                MaxLength = Globals.MaxPasswordLength,
                OnlyNumber = true,
                CanLoseFocus = true,
                FocusWhenVisible = false
            };
            textBoxPercentHpProtect.TextBox.TextChanged += percentHpTextBox_changed;
            textBoxPercentHpProtect.Text = String.Format("{0}", Settings.percentHpProtect);

            textBoxEatItemName = new MirTextBox {
                Location = new Point(16, 90),
                Parent = this,
                Size = new Size(136, 15),
                MaxLength = Globals.MaxPasswordLength,
                CanLoseFocus = true,
                FocusWhenVisible = false
            };
            textBoxEatItemName.TextBox.TextChanged += eatHpItemTextBox_changed;
            textBoxEatItemName.Text = Settings.hpItemName;

            textBoxPercentMpProtect = new MirTextBox { Location = new Point(16, 120),
                Parent = this, Size = new Size(136, 15),
                MaxLength = Globals.MaxPasswordLength, OnlyNumber = true,
                CanLoseFocus = true, FocusWhenVisible= false };
            textBoxPercentMpProtect.TextBox.TextChanged += percentMpTextBox_changed;
            textBoxPercentMpProtect.Text = String.Format("{0}", Settings.percentHpProtect);

            textBoxEatMpName = new MirTextBox {
                Location = new Point(16, 150), Parent = this,
                Size = new Size(136, 15), MaxLength = Globals.MaxPasswordLength,
                CanLoseFocus = true, FocusWhenVisible = false };
            textBoxEatMpName.TextBox.TextChanged += eatMpItemTextBox_changed;
            textBoxEatMpName.Text = Settings.mpItemName;


            checkBoxSmartSheild = new MirCheckBox
            {
                Index = 2086, UnTickedIndex = 2086, TickedIndex = 2087,
                Parent = this, Location = new Point(206, 16), Library = Libraries.Prguse
            };
            checkBoxSmartSheild.LabelText = "自动换毒";
            checkBoxSmartSheild.Checked = Settings.smartSheild;
            checkBoxSmartSheild.Click += CheckBoxSheildClick;
        }

        private void eatMpItemTextBox_changed(object sender, EventArgs e)
        {
            Settings.mpItemName = textBoxEatMpName.Text;
        }

        private void percentMpTextBox_changed(object sender, EventArgs e)
        {
              int.TryParse(textBoxPercentMpProtect.Text, out Settings.percentMpProtect);
        }

        private void CheckBoxSheildClick(object sender, EventArgs e)
        {
            Settings.smartSheild = checkBoxSmartSheild.Checked;
        }

        private void eatHpItemTextBox_changed(object sender, EventArgs e)
        {
            Settings.hpItemName = textBoxEatItemName.Text;
        }

        private void percentHpTextBox_changed(object sender, EventArgs e)
        {
            int.TryParse(textBoxPercentHpProtect.Text, out Settings.percentHpProtect); 
        }

        private void CheckBoxAutoEatClick(object sender, EventArgs e)
        {
            Settings.autoEatItem = checkBoxAutoEat.Checked;
        }

        private void CheckBoxFireClick(object sender, EventArgs e)
        {
            Settings.smartFireHit = checkBoxSmartFire.Checked;
        }

        private void CheckBoxClick(object sender, EventArgs e)
        {
            Settings.smartSheild = checkBoxSmartSheild.Checked;
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
