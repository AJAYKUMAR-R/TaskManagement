using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Classes.dtoConsole
{
    public enum Status
    {
        Deleted,
        Achived,
        InProgress

    }
    internal class TaskInformation
    {
        public int TaskId {  get; set; }
        public string TaskDescription { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public Status Status { get; set; }
    }
}
