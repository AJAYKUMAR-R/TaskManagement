using BusinessLayer.Interfaces.businessAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Classes.dtoConsole;
using DataAcessLayer.Classes.designPattern.singletonClas;

namespace BusinessLayer.Classes.businessLogic
{
    public class CreateTask  : Authentication,ICreateTask
    {
        public readonly IUserData _userData;
        private readonly IUserTask _userTask;
        public CreateTask(IUserData _userData, IUserTask userTask,string username) : base(_userData, username)
        {
           this._userTask = userTask;
           this._userData = _userData;
          
        }
        public bool CreateTasks(TaskInformation task, string username,out bool isActive)
        {
            //out parameter should be assaigned otherwise it won't work
             isActive = _userData.GetInstance.UserProfiles.
                 FirstOrDefault((obj) => obj.UserName == username).IsActive;
            if (isActive)
            {
                _userTask.UserTask.Add(task);
                return true;
            }
            else
            {
                return false;
            }
    
        }
    }
}
