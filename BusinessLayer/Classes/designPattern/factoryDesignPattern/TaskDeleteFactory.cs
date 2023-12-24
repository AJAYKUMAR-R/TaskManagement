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
    public class TaskDeleteFactory
    {
        private string username;

        public TaskDeleteFactory(string username)
        {
            this.username = username;
        }
        public IDeleteTask createDelete(int type, IUserData userData, IUserTask userTask)
        {
            switch (type)
            {
                case 0:
                    return new DeleteTask(userData, userTask,username);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
