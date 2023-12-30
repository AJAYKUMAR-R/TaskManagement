using DataAcessLayer.Classes.dtoConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Classes.designPattern.singletonClas
{
    public interface IUserTask
    {
        List<TaskInformation> UserTask { get; }


    }

 
    public class TaskCollection : IUserTask
    {
       

        //To prevent from accesing using object created 
        public TaskCollection() { }

        //DbContext or Data which should contains here
        private List<TaskInformation> _userList = new List<TaskInformation>()
        {
           new TaskInformation()
           {
               TaskId = 1,
               TaskDescription = "Test",
               DueDate = DateTime.Now.AddMinutes(0.5),
               Status = Status.InProgress

           },
           new TaskInformation()
           {
               TaskId = 2,
               TaskDescription = "Test",
               DueDate = DateTime.Now.AddMinutes(1),
               Status = Status.InProgress

           }
        };


        

        //internal access withthin the Folder
        public List<TaskInformation> UserTask
        {
            get { return _userList; }

        }


    }
}
