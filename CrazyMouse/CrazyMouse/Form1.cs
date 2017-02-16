using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrazyMouse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);

        private void timer1_Tick(object sender, EventArgs e)
        {
            var cursor = new Point();
            GetCursorPos(ref cursor);

            labelX.Text = "X" + cursor.X.ToString();
            labelY.Text = "Y" + cursor.Y.ToString();

        }
    }
}
