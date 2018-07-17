using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PopupControl;

namespace FreeControls
{
    internal partial class MonthUC : UserControl
    {
        public event EventHandler MonthChanged; 
        public  MonthUC()
        {
            InitializeComponent();
        }

        private void radioButton_MouseEnter(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            radio.ForeColor = Color.White;
            radio.BackColor = SystemColors.HotTrack;
        }

        private void radioButton_MouseLeave(object sender, EventArgs e)
        {
            SetColors(sender as RadioButton);
        }

        private static void SetColors(RadioButton radioButton)
        {
            if (radioButton.Checked)
            {
                radioButton.ForeColor = SystemColors.HighlightText;
                radioButton.BackColor = SystemColors.Highlight;
            }
            else
            {
                radioButton.ForeColor = SystemColors.WindowText;
                radioButton.BackColor = SystemColors.Window;
            }
        }

        private void radioButton_Click(object sender, EventArgs e)
        {
            foreach (var ct in this.Controls )
            {
                if (ct is RadioButton)
                    SetColors((RadioButton)ct);
            }

            if (MonthChanged != null)
                MonthChanged(sender, EventArgs.Empty);
            (Parent as Popup).Close();
        }

        public void  ActiveRadioByTagID(int monthNo)
        {
            foreach (var ct in this.Controls)
            {
                if (ct is RadioButton)
                    if (int.Parse(((RadioButton)ct).Tag.ToString()) == monthNo)
                    {
                        ((RadioButton)ct).Checked = true; 
                        SetColors((RadioButton)ct);
                    }
            }
        }

    }
}
