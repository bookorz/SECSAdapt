using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferControl.CommandConvert;
using TransferControl.Engine;
using TransferControl.Management;

namespace SECSAdapt
{
    public partial class Form1 : Form,IUserInterfaceReport
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
        }

        public void NewTask(string Id, TaskFlowManagement.Command TaskName, Dictionary<string, string> param = null)
        {
            HostControl.NewTask(Id,  TaskName,  param);
        }

        public void On_Alarm_Happen(AlarmInfo Alarm)
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
            UI_Update.UI_Update.ShowLog(Type+":"+ Message);
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

        
    }
}
