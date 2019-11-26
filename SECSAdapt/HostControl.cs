using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferControl.CommandConvert;
using TransferControl.Config;
using TransferControl.Digital_IO.Comm;
using TransferControl.Engine;
using TransferControl.Management;

namespace SECSAdapt
{
    public class HostControl: IConnectionReport
    {
        IUserInterfaceReport _Report;
        static SocketClient socket;
        public HostControl(IUserInterfaceReport Report)
        {
            _Report = Report;
            socket = new SocketClient(this);
            socket.Vendor = "BOOK";
            socket.Start();
        }

        public void NewTask(string Id, TaskFlowManagement.Command TaskName, Dictionary<string, string> param = null)
        {
            string Event = "NewTask";

            socket.Send(JsonConvert.SerializeObject(new { Event, Id, TaskName, param }) + Convert.ToChar(3));


        }

        public void MessageLog(string Type,string Message)
        {
            string Event = "MessageLog";

            socket.Send(JsonConvert.SerializeObject(new { Event, Type, Message }) + Convert.ToChar(3));

        }

        public void On_Connection_Connected(object Msg)
        {
            UI_Update.UI_Update.ChangeState("Control_lb", "Connected");
        }

        public void On_Connection_Connecting(string Msg)
        {
            UI_Update.UI_Update.ChangeState("Control_lb", "Connecting");
        }

        public void On_Connection_Disconnected(string Msg)
        {
            UI_Update.UI_Update.ChangeState("Control_lb", "Disconnected");
            socket.Start();
        }

        public void On_Connection_Error(string Msg)
        {
            UI_Update.UI_Update.ChangeState("Control_lb", "Error");
            socket.Start();
        }

        public void On_Connection_Message(object Msg)
        {
            try
            {
                JObject restoredObject = JsonConvert.DeserializeObject<JObject>(Msg.ToString());
                //JObject可使用LINQ方式存取
                //var q = from p in restoredObject.Properties()
                //        where p.Name == "Name"
                //        select p;
                TaskFlowManagement.CurrentProcessTask Task = null;
                Node Node = null;
                CommandReturnMessage ReturnMsg = null;
                Transaction Txn = null;
                switch (restoredObject.Property("Event").Value.ToString())
                {
                    case "SystemConfig":
                        SystemConfig SysCfg = JsonConvert.DeserializeObject<SystemConfig>(restoredObject.Property("SystemConfig").Value.ToString());
                        //Dictionary<string, string> param = new Dictionary<string, string>();
                        //param.Add("@Target","ROBOT01");
                        //NewTask("123123", TaskFlowManagement.Command.ROBOT_HOME,param);
                        break;
                    case "On_TaskJob_Ack":
                        Task = JsonConvert.DeserializeObject<TaskFlowManagement.CurrentProcessTask>(restoredObject.Property("Task").Value.ToString());
                        _Report.On_TaskJob_Ack(Task);
                        break;
                    case "On_TaskJob_Finished":
                        Task = JsonConvert.DeserializeObject<TaskFlowManagement.CurrentProcessTask>(restoredObject.Property("Task").Value.ToString());
                        _Report.On_TaskJob_Finished(Task);
                        break;
                    case "On_TaskJob_Aborted":
                        Task = JsonConvert.DeserializeObject<TaskFlowManagement.CurrentProcessTask>(restoredObject.Property("Task").Value.ToString());
                        string NodeName = restoredObject.Property("NodeName").Value.ToString();
                        string ReportType = restoredObject.Property("ReportType").Value.ToString();
                        string Message = restoredObject.Property("Message").Value.ToString();
                        _Report.On_TaskJob_Aborted(Task, NodeName, ReportType, Message);
                        break;
                    case "On_Alarm_Happend":
                        AlarmInfo Alarm = JsonConvert.DeserializeObject<AlarmInfo>(restoredObject.Property("Alarm").Value.ToString());
                        _Report.On_Alarm_Happen(Alarm);
                        break;
                    case "On_Event_Trigger":
                        Node = JsonConvert.DeserializeObject<Node>(restoredObject.Property("Node").Value.ToString());
                        ReturnMsg = JsonConvert.DeserializeObject<CommandReturnMessage>(restoredObject.Property("Msg").Value.ToString());
                        _Report.On_Event_Trigger(Node, ReturnMsg);
                        break;
                    case "On_Command_Excuted":
                        Node = JsonConvert.DeserializeObject<Node>(restoredObject.Property("Node").Value.ToString());
                        Txn = JsonConvert.DeserializeObject<Transaction>(restoredObject.Property("Txn").Value.ToString());
                        ReturnMsg = JsonConvert.DeserializeObject<CommandReturnMessage>(restoredObject.Property("Msg").Value.ToString());
                        _Report.On_Command_Excuted(Node, Txn, ReturnMsg);
                        break;
                    case "On_Command_Finished":
                        Node = JsonConvert.DeserializeObject<Node>(restoredObject.Property("Node").Value.ToString());
                        Txn = JsonConvert.DeserializeObject<Transaction>(restoredObject.Property("Txn").Value.ToString());
                        ReturnMsg = JsonConvert.DeserializeObject<CommandReturnMessage>(restoredObject.Property("Msg").Value.ToString());
                        _Report.On_Command_Finished(Node, Txn, ReturnMsg);
                        break;
                }
            }catch(Exception e)
            {
                MessageLog("CMD",e.Message);
                MessageLog("CMD", e.StackTrace);
                MessageLog("CMD", Msg.ToString());
            }
        }
    }
}
