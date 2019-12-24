using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferControl.CommandConvert;
using TransferControl.Engine;
using TransferControl.Management;

namespace SECSAdapt
{
    public partial class Form1 : Form, IUserInterfaceReport
    {
        HostControl HostControl;
        SECSInterface.SECSGEM SECS;
        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SECS = new SECSInterface.SECSGEM(this);
            HostControl = new HostControl(SECS);
          
            //指定使用的容器
            //this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            //建立NotifyIcon
            this.notifyIcon1.Icon = SECSAdapt.Properties.Resources.share_social_media_icon_127367;
            this.notifyIcon1.Text = "SECS Plug-in";

            //this.notifyIcon1.DoubleClick += NotifyIcon1_DoubleClick;
            //this.WindowState = FormWindowState.Minimized;
            this.notifyIcon1.Visible = true;
        }

        private void NotifyIcon1_DoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.notifyIcon1.Visible = false;
        }
        public Node GetNode(string Name)
        {
            return HostControl.GetNode(Name);
        }
        public void NewTask(string Id, TaskFlowManagement.Command TaskName, Dictionary<string, string> param = null)
        {
            HostControl.NewTask(Id, TaskName, param);
        }

        public void On_Alarm_Happen(TransferControl.Management.AlarmManagement.AlarmInfo Alarm)
        {

        }

        public void On_Command_Error(Node Node, Transaction Txn, CommandReturnMessage Msg)
        {

        }

        public void On_Command_Excuted(Node Node, Transaction Txn, CommandReturnMessage Msg)
        {

        }

        public void On_Command_Finished(Node Node, Transaction Txn, CommandReturnMessage Msg)
        {

        }

        public void On_Command_TimeOut(Node Node, Transaction Txn)
        {

        }

        public void On_Connection_Error(string DIOName, string ErrorMsg)
        {

        }

        public void On_Connection_Status_Report(string DIOName, string Status)
        {

        }

        public void On_DIO_Data_Chnaged(string Parameter, string Value, string Type)
        {

        }

        public void On_Event_Trigger(Node Node, CommandReturnMessage Msg)
        {

        }

        public void On_Job_Location_Changed(Job Job)
        {

        }

        public void On_Message_Log(string Type, string Message)
        {
            
            if (HostControl != null)
            {
                HostControl.MessageLog(Type, Message);
            }
            UI_Update.UI_Update.ShowLog(Type + ":" + Message);
        }

        public void On_Node_Connection_Changed(string NodeName, string Status)
        {

        }

        public void On_Node_State_Changed(Node Node, string Status)
        {

        }

        public void On_Status_Changed(string Type, string Message)
        {

        }

        public void On_TaskJob_Aborted(TaskFlowManagement.CurrentProcessTask Task, string NodeName, string ReportType, string Message)
        {

        }

        public void On_TaskJob_Ack(TaskFlowManagement.CurrentProcessTask Task)
        {

        }

        public void On_TaskJob_Finished(TaskFlowManagement.CurrentProcessTask Task)
        {

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.notifyIcon1.Visible = true;
            }

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.notifyIcon1.Visible)
            {
                e.Cancel = true;
                this.Hide();
                this.notifyIcon1.Visible = true;
            }
           
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.notifyIcon1.Visible = false;
        }

        private void exit_mu_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void notifyIcon1_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button == System.Windows.Forms.MouseButtons.Right)
            //{
            //    Type t = typeof(NotifyIcon);
            //    MethodInfo mi = t.GetMethod("ShowContextMenu", BindingFlags.NonPublic | BindingFlags.Instance);
            //    mi.Invoke(this.notifyIcon1, null);
            //}
        }

    
    }
}
