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
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_SYSKEYUP = 0x0105;

        private List<Keys> HookedKeys = new List<Keys>();

        private void HookProc(int Code, int wParam, ref keyBoardHookStruct lParam)
        {
            #region Coordinate Marking
            sum++;
            if (sum % 2 != 0)
            {
                Keys key = (Keys)lParam.vkCode;
                var cursor = new Point();
                GetCursorPos(ref cursor);
                if (key == Keys.LControlKey || key == Keys.RControlKey)
                {
                    listBoxY.Items.Add("X" + cursor.X.ToString());
                    listBoxX.Items.Add("Y" + cursor.Y.ToString());
                    lsX.Add(Convert.ToInt32(cursor.X.ToString()));
                    lsY.Add(Convert.ToInt32(cursor.Y.ToString()));
                }
                else
                if (key == Keys.End)
                {
                    timer2.Stop();
                    timer1.Start();
                }
                else
                if (key == Keys.Home)
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
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010
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
            if (mousestepscount != Convert.ToInt32(textBox1.Text))
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
            }
            sum = new int();
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\tInstruction \n\n1) Start = Home \n2) Stop = End \n3) Tag Coordinate " +
                "= Ctrl\n\n\tInformation\n\nYear: 2017\nVersion: 1.0\nName: Carzy Mouse\nAuthor: Suren Khachatryan\nE-mail: surench94@gmail.com");
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
        #endregion

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
