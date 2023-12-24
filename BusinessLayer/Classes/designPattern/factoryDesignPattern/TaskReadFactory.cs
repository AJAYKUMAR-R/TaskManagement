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
    public class TaskReadFactory
    {
        private string username;

        public TaskReadFactory(string username)
        {
            this.username = username;
        }
        public IReadTask createRead(int type, IUserData userData, IUserTask userTask)
        {
            switch (type)
            {
                case 0:
                    return new ReadTask(userData, userTask,username);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
