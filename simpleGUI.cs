using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLANCHECK
{
    public partial class simpleGUI : Form
    {
        public simpleGUI()
        {
            InitializeComponent();

            progbar.Style = ProgressBarStyle.Marquee;
            progbar.Visible = true;
            progbar.MarqueeAnimationSpeed = 150;
            Show();

        }
    }
}
