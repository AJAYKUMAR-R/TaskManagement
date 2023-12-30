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
        public static TaskInformation UpdateSerialize(int id, string input)
        {
            TaskInformation taskInformation = new TaskInformation();
            string[] strings = input.Split(",");
            var field = int.TryParse(strings[0],out int result);
            if (result == 1)
            {
               taskInformation.DueDate = Convert.ToDateTime(strings[0]);
            }else if(result == 0)
            {
                taskInformation.TaskDescription = strings[0];
            }else if(result == 2)
            {
                Status status;
                if (strings[1].ToLower() == "inprogress")
                {
                    status = Status.InProgress;
                }else if (strings[1].ToLower() == "achived")
                {
                    status = Status.Achived;
                }
                else
                {
                    status = Status.Failed;
                }
                taskInformation.Status = status;
            }

            return taskInformation;
            
        }
        public static TaskInformation Serialize(string userinput,int length)
        {
            if (!string.IsNullOrEmpty(userinput))
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
