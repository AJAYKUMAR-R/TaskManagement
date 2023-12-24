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

        public bool UpdateTaskDetails(TaskInformation task,int clol)
        {
            var lastTask = _userTask.UserTask.Where((obj) => obj.TaskId == task.TaskId)
                .FirstOrDefault();

            if(lastTask is not null)
            {
                lastTask.TaskId = task.TaskId;  
                lastTask.TaskDescription = task.TaskDescription;
                lastTask.Status = task.Status;
                lastTask.DueDate = task.DueDate;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
