using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Classes.dtoConsole;

namespace BusinessLayer.Interfaces.businessAbstraction
{
    public interface ICreateTask
    {
        public bool CreateTasks(TaskInformation task, string username,out bool isActive);
    }
}
