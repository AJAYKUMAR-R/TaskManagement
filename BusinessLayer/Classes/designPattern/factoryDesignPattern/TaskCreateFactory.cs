using BusinessLayer.Classes.businessLogic;
using BusinessLayer.Interfaces.businessAbstraction;
using DataAcessLayer.Classes.designPattern.singletonClas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Classes.designPattern.factoryDesignPattern
{
    public class TaskCreateFactory
    {
        private string username;

        public TaskCreateFactory(string username)
        {
           this.username = username;
        }
        public ICreateTask createTask(int type,IUserData userData,IUserTask userTask)
        {
            switch (type)
            {
                case 0:
                    return new CreateTask(userData,userTask,username);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
