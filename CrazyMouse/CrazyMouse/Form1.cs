using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;


namespace CrazyMouse
{
    public partial class Form1 : Form
    {
        private List<int> lsX = new List<int>();
        private List<int> lsY = new List<int>();
        private int mousesteps = new int();
        private int mousestepscount = new int();

        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

        [Flags]
        public enum MouseEventFlags : uint
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
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
        private void timerCursorClick_Tick(object sender, EventArgs e)
        {
            var cursor = new Point();
            GetCursorPos(ref cursor);
            int[] arrX = lsX.ToArray();
            int[] arrY = lsY.ToArray();
            if (mousestepscount != Convert.ToInt32(textBox1.Text))
            {
                if (mousesteps < arrX.Length)
                {
                    labelX.Text = "X" + cursor.X.ToString();
                    labelY.Text = "Y" + cursor.Y.ToString();
                    Cursor.Position = new Point(arrX[mousesteps], arrY[mousesteps]);
                    timer2.Interval = Convert.ToInt32(domainUpDown2.Text);
                    mouse_event((uint)(MouseEventFlags.LEFTDOWN | MouseEventFlags.LEFTUP), (uint)arrX[mousesteps], (uint)arrY[mousesteps], 0, UIntPtr.Zero);
                    mousesteps++;
                    if (mousesteps == arrX.Length)
                    {
                        mousesteps = 0;
                        mousestepscount++;
                        label1.Text = mousestepscount.ToString();
                    }
                }
            }
            else
            {
                timer2.Stop();
                timer1.Start();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            var cursor = new Point();
            GetCursorPos(ref cursor);
            if (e.KeyCode == Keys.ControlKey)
            {
                listBoxY.Items.Add("X" + cursor.X.ToString());
                listBoxX.Items.Add("Y" + cursor.Y.ToString());
                lsX.Add(Convert.ToInt32(cursor.X.ToString()));
                lsY.Add(Convert.ToInt32(cursor.Y.ToString()));
            }
            else
            if (e.KeyCode == Keys.End)
            {
                timer2.Stop();
                timer1.Start();
            }
            else
            if (e.KeyCode == Keys.Home)
            {
                if (textBox1.Text != "")
                {
                    label1.Text = "0";
                    mousesteps = 0;
                    mousestepscount = 0;
                    timer2.Start();
                    timer1.Stop();
                }
                else
                {
                    MessageBox.Show("Please Enter Count Cycle");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\tInstruction \n\n1) Start = Home \n2) Stop = End \n3) Tag Coordinate = Ctrl\n\n\tInformation\n\nAuthor of program Suren Khachatryan\nE-mail: surench94@gmail.com");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBoxX.Items.Count != 0 && listBoxY.Items.Count != 0)
            {
                listBoxX.Items.Clear();
                listBoxY.Items.Clear();
                lsX.Clear();
                lsY.Clear();
                label1.Text = "0";
            }
            else
            {
                MessageBox.Show("There Is Nothing To Clean Up!!");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8 || textBox1.Text == "" && chr == '0')
            {
                e.Handled = true;
            }
        }
    }
}
