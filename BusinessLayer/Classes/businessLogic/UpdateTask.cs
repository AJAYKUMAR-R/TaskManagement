using BusinessLayer.Interfaces.businessAbstraction;
using DataAcessLayer.Classes.designPattern.singletonClas;
using DataAcessLayer.Classes.dtoConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Classes.businessLogic
{
    public class UpdateTask : Authentication,IUpdateTask
    {

       
        private readonly IUserTask _userTask;
        public UpdateTask(IUserData _userData, IUserTask userTask,string username) : base(_userData,username)
        {
            this._userTask = userTask;
            
        }

        public bool UpdateTaskDetails(int id, string input)
        {
            foreach (var lastTask in _userTask.UserTask)
            {
                if(lastTask.TaskId == id)
                {
                    string[] strings = input.Split(",");
                    var field = int.TryParse(strings[0], out int result);
                    if (result == 1)
                    {
                        lastTask.DueDate = Convert.ToDateTime(strings[0]);
                    }
                    else if (result == 0)
                    {
                        lastTask.TaskDescription = strings[0];
                    }
                    else if (result == 2)
                    {
                        Status status;
                        if (strings[0].ToLower() == "inprogress")
                        {
                            status = Status.InProgress;
                        }
                        else if (strings[0].ToLower() == "achived")
                        {
                            status = Status.Achived;
                        }
                        else
                        {
                            status = Status.Failed;
                        }
                        lastTask.Status = status;
                    }
                    return true;
                   
                }
            }
            return false;
           
        }
    }
}
