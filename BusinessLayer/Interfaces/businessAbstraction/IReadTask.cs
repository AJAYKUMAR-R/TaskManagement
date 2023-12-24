using DataAcessLayer.Classes.dtoConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces.businessAbstraction
{
    public interface IReadTask
    {
        public IEnumerable<TaskInformation> ReadTaskDetails(Status status, int taskId =0);
    }
}
