using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces.businessAbstraction
{
    public interface  IDeleteTask
    {
        public bool DeleteTaskDetails(int id);
    }
}
