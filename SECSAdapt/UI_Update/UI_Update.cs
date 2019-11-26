using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SECSAdapt.UI_Update
{
    public class UI_Update
    {
        delegate void UpdateUI(string id,string state);
        delegate void UpdateLog( string text);
        public static void ShowLog(string text)
        {
            try
            {
                Form form = Application.OpenForms["Form1"];

                if (form == null)
                    return;

                RichTextBox W = form.Controls.Find("log_rt", true).FirstOrDefault() as RichTextBox;

                if (W == null)
                    return;

                if (W.InvokeRequired)
                {
                    UpdateLog ph = new UpdateLog(ShowLog);
                    W.Invoke(ph, text);
                }
                else
                {
                    if (W.Text.Length > 13000)
                    {
                        W.Text = W.Text.Substring(W.Text.Length - 7000);
                    }
                    W.SelectionStart = W.TextLength;
                    W.SelectionLength = 0;


                    if (text.ToUpper().Contains("ACK"))
                    {
                        W.SelectionColor = Color.Blue;
                    }
                    else if (text.ToUpper().Contains("INF"))
                    {
                        W.SelectionColor = Color.Green;
                    }
                    else if (text.ToUpper().Contains("ABS"))
                    {
                        W.SelectionColor = Color.Red;
                    }
                    else if (text.ToUpper().Contains("CAN"))
                    {
                        W.SelectionColor = Color.Orange;
                    }
                    else
                    {
                        W.SelectionColor = Color.Black;
                    }
                    W.AppendText(text + "\n");
                    W.ScrollToCaret();
                }


            }
            catch (Exception e)
            {

            }
        }
        public static void ChangeState(string id, string state)
        {
            try
            {
                Form form = Application.OpenForms["Form1"];

                if (form == null)
                    return;

                Label ctrl = form.Controls.Find(id, true).FirstOrDefault() as Label;

                if (ctrl == null)
                    return;

                if (ctrl.InvokeRequired)
                {
                    UpdateUI ph = new UpdateUI(ChangeState);
                    ctrl.BeginInvoke(ph, id, state);
                }
                else
                {
                    ctrl.Text = state;
                }


            }
            catch (Exception e)
            {
                
            }
        }
    }
}
