using DataAcessLayer.Classes.dtoConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces.businessAbstraction
{
    public interface IUpdateTask
    {
        public bool UpdateTaskDetails(int id,string input);
    }
}
