using DataAcessLayer.Classes.designPattern.singletonClas;
using DataAcessLayer.Classes.dtoConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Classes.businessLogic
{
    public class StatusCheck
    {
        private  IUserTask _userTask;
        

        public StatusCheck(IUserTask userTask)
        {
            this._userTask = userTask;
        }

        public void checkStatus()
        {
            bool loop = true; 
            while (loop)
            {
                Func<TaskInformation, bool> checkTime = (obj) =>
                {
                    if (obj.DueDate > DateTime.Now && obj.Status == Status.InProgress)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                };
                var flag = this._userTask.UserTask.Where(checkTime).ToList();
                if(flag.Count > 0)
                {
                    
                    foreach (var task in flag)
                    {
                        
                        Console.WriteLine(
                                @$"These tasks Times Up{task.TaskId} and {task.TaskDescription}"
                            );
                    }

                    //Invoking the Alarm here
                    Alarm.InvokeAlarm();
                    Thread.Sleep(5000);
                    foreach (var inner in flag)
                    {
                        foreach (var outer in _userTask.UserTask)
                        {
                            if(outer.TaskId == inner.TaskId)
                            {
                                outer.Status = Status.Failed;
                            }
                        }
                    }

                    // Run an infinite loop to keep the application running
                    while (true)
                    {
                        // Check if a key is pressed
                        if (Console.KeyAvailable)
                        {
                            // Read and discard the key
                            Console.ReadKey(true);

                            // Break out of the loop, allowing the application to exit
                            break;
                        }

                        // Do other work or processing here

                        // Optionally, introduce a delay to reduce CPU usage
                        // System.Threading.Thread.Sleep(100);
                    }

                }

            }

        }

        

       
    }
}
