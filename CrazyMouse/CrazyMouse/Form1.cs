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
        private int cycle = new int();
        #region Part 1 keyboard hook
        public delegate void LLKeyboardHook(int Code, int wParam, ref keyBoardHookStruct lParam);
        private int sum = new int();
        private IntPtr Hook = IntPtr.Zero;
        LLKeyboardHook llkh;
        #endregion

        public Form1()
        {
            InitializeComponent();
            timer1.Start();

            #region Part 2 keyboard hook
            llkh = new LLKeyboardHook(HookProc);
            IntPtr hInstance = LoadLibrary("User32");
            Hook = SetWindowsHookEx(WH_KEYBOARD_LL, llkh, hInstance, 0);
            #endregion
        }

        #region Part 3 keyboard hook
        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, LLKeyboardHook callback, IntPtr hInstance, uint theardID);
        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string lpFileName);

        public struct keyBoardHookStruct
        {
            public int vkCode;
        }
        private const int WH_KEYBOARD_LL = 13;

        private void HookProc(int Code, int wParam, ref keyBoardHookStruct lParam)
        {
            #region Coordinate Marking
            sum++;
            Keys key = (Keys)lParam.vkCode;
            var cursor = new Point();
            GetCursorPos(ref cursor);
            if ((key == Keys.Add || key == Keys.Oemplus) && sum % 2 != 0)
            {
                listBoxY.Items.Add("X" + cursor.X.ToString());
                listBoxX.Items.Add("Y" + cursor.Y.ToString());
                lsX.Add(Convert.ToInt32(cursor.X.ToString()));
                lsY.Add(Convert.ToInt32(cursor.Y.ToString()));
                label2.Text = "OFF";
                panel1.BackColor = Color.Red;
            }
            else
            if (key == Keys.End && listBoxX.Items.Count != 0 && label2.Text != "Finish")
            {
                timer2.Stop();
                timer1.Start();
                label2.Text = "OFF";
                panel1.BackColor = Color.Red;
            }
            else
            if (key == Keys.Home && listBoxX.Items.Count != 0)
            {
                if (textBox1.Text != "" )
                {
                    label1.Text = "0";
                    mousesteps = 0;
                    mousestepscount = 0;
                    timer2.Start();
                    timer1.Stop();
                    sum = 0;
                    label2.Text = "ON";
                    panel1.BackColor = Color.Green;
                }
                else
                {
                    MessageBox.Show("Please Enter Count Cycle");
                }
            }
            #endregion
        }
        #endregion

        #region Mouse Click
        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, IntPtr dwExtraInfo);

        [Flags]
        private enum MOUSEEVENTF
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004
        }
        #region Mouse Move

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(ref Point lpPoint);

        private void timer1_Tick(object sender, EventArgs e)
        {
            var cursor = new Point();
            GetCursorPos(ref cursor);
            labelX.Text = "X" + cursor.X.ToString();
            labelY.Text = "Y" + cursor.Y.ToString();
        }
        #endregion

        #region Mouse Click
        private void timerCursorClick_Tick(object sender, EventArgs e)
        {
            var cursor = new Point();
            GetCursorPos(ref cursor);
            int[] arrX = lsX.ToArray();
            int[] arrY = lsY.ToArray();
            if (!checkBox1.Checked)
            {
                cycle = Convert.ToInt32(textBox1.Text);
            }
            if (mousestepscount != cycle)
            {
                if (mousesteps < arrX.Length)
                {
                    labelX.Text = "X" + cursor.X.ToString();
                    labelY.Text = "Y" + cursor.Y.ToString();
                    Cursor.Position = new Point(arrX[mousesteps], arrY[mousesteps]);
                    timer2.Interval = Convert.ToInt32(domainUpDown2.Text);
                    mouse_event((uint)MOUSEEVENTF.LEFTDOWN, 0, 0, 0, IntPtr.Zero);
                    mouse_event((uint)MOUSEEVENTF.LEFTUP, 0, 0, 0, IntPtr.Zero);
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
                label2.Text = "Finish";
                panel1.BackColor = Color.YellowGreen;
            }
            sum = new int();
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\tInstruction \n\n1) Start = Home \n2) Stop = End \n3) Tag Coordinate " +
                "= Add(+) and Oemplus(=,+)\n\n\tInformation\n\nYear: 2017\nVersion: 1.0\nName: Carzy Mouse\nAuthor:" +
                " Suren Khachatryan\nE-mail: surench94@gmail.com\n\n\t Made in Armenia");
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
                sum = 0;
                label2.Text = "OFF";
                panel1.BackColor = Color.Red;
            }
            else
            {
                MessageBox.Show("There Is Nothing To Clean Up!!");
            }
        }
        #endregion

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8 || textBox1.Text == "" && chr == '0')
            {
                e.Handled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Enabled = false;
                cycle = Int32.MaxValue;
            }
            else
            {
                textBox1.Enabled = true;
            }
        }
    }
}
