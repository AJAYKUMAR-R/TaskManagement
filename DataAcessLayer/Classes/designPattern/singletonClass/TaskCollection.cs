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
        public TaskCollection GetInstance { get; }
        public List<TaskInformation> UserTask { get; }
    }

    //Singleton class
    public class TaskCollection : IUserTask
    {
        //Backing Filed
        //readonly field can only be set in the Constructor
        private TaskCollection? _userTask;

        //To prevent from accesing using object created 
        public TaskCollection() { }

        //DbContext or Data which should contains here
        private List<TaskInformation> _userList = new List<TaskInformation>()
        {
           new TaskInformation()
           {
               TaskId = 1,
               TaskDescription = "Test",
               DueDate = DateTime.Now.AddMinutes(5),
               Status = Status.InProgress

           }
        };


        //return the thread safe created object by Lazy loading
        public TaskCollection GetInstance
        {
            get
            {
                //If two thread accesing it will access one after another
                lock (new object())
                {
                    if (_userTask == null)
                    {
                        return _userTask = new TaskCollection();
                    }
                    else
                    {
                        return _userTask;
                    }
                }
            }
        }

        //internal access withthin the Folder
        public List<TaskInformation> UserTask
        {
            get { return _userList; }

        }


    }
}
