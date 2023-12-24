using BusinessLayer.Interfaces.businessAbstraction;
using DataAcessLayer.Classes.designPattern.singletonClas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Classes.businessLogic
{
    public class DeleteTask : Authentication,IDeleteTask
    {
        
        private readonly IUserTask _userTask;
        public DeleteTask(IUserData _userData, IUserTask userTask,string username):base(_userData, username)
        {
            this._userTask = userTask;
            
        }

        public bool DeleteTaskDetails(int id)
        {
            var lastTask = _userTask.UserTask.Where((obj) => obj.TaskId == id)
                .FirstOrDefault();
            if(lastTask is bool)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
