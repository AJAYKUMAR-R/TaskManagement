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
    public class ReadTask : Authentication,IReadTask
    {
       
        private readonly IUserTask _userTask;
        public ReadTask(IUserData _userData, IUserTask userTask,string username) : base(_userData, username)
        {
            this._userTask = userTask;
           
        }

        public IEnumerable<TaskInformation> ReadTaskDetails( Status status, int taskId = 0)
        {
            if(taskId != 0)
            {
                return _userTask.UserTask.Where((obj)=> obj.TaskId == taskId);
            }
            else
            {
                return _userTask.UserTask.Where((obj) => obj.Status == status);
            }
        }
    }
}
