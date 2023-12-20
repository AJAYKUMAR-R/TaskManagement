using DataAcessLayer.Classes.dtoConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Classes.designPattern
{
    //For Applying the Dependency Injection
    public interface ISingleton
    {
        public UserData GetInstance { get; }
    }
    //if it is internal we can't access outside the library by adding 
    //References
    public sealed class UserData : ISingleton
    {
        //Backing Filed
        //readonly field can only be set in the Constructor
        private  UserData? _userData;

        //To prevent from accesing using object created 
        public UserData() { }

        //DbContext or Data which should contains here
        private List<UserProfile> _userList = new List<UserProfile>()
        {
            new UserProfile
            {
                UserName = "Ajay",
                IsActive = true,
                Password = "Ajay@1234",
                CreatedDate = DateTime.Now.AddYears(-1),
            }
        };


        //return the thread safe created object by Lazy loading
        public UserData GetInstance
        {
            get
            {
                //If two thread accesing it will access one after another
                lock(new object())
                {
                    if (_userData == null)
                    {
                        return _userData = new UserData();
                    }
                    else
                    {
                        return _userData;
                    }
                }
            }
        }

        //internal access withthin the Folder
        public List<UserProfile> UserProfiles
        {
            get { return this._userList;}
            
        }

      
    }
}
