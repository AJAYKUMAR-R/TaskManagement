using DataAcessLayer.Classes.dtoConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Classes.designPattern.singletonClas
{
    //For Applying the Dependency Injection
    public interface IUserData
    {
        public List<UserProfile> UserProfiles { get; }
    }
    //if it is internal we can't access outside the library by adding 
    //References
    public sealed class UserData : IUserData
    {
      

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
            },
             new UserProfile
            {
                UserName = "Ajay",
                IsActive = true,
                Password = "Ajay@1234",
                CreatedDate = DateTime.Now.AddMinutes(1),
            }
        };


        
        //internal access withthin the Folder
        public List<UserProfile> UserProfiles
        {
            get { return _userList; }

        }


    }
}
