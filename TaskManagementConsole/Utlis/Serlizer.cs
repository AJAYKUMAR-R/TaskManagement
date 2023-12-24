using DataAcessLayer.Classes.dtoConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementConsole.Utlis
{
    public class Serlizer
    {
        public static TaskInformation Serialize(string userinput,int length)
        {
            if (string.IsNullOrEmpty(userinput))
            {
                string[] inputs = userinput.Split(',');
                TaskInformation taskInformation = new TaskInformation()
                {
                   TaskDescription = inputs[0],
                   TaskId = length + 1,
                   DueDate = DateTime.Now,
                   Status = Status.InProgress
                };
                return taskInformation;
            }
            else
            {
                return null;
            }
        }
    }
}
