using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Classes.designPattern;
using DataAcessLayer.Classes;

namespace LoginLayer.Classes.LoginConsole
{
    public class BLLogin
    {
        private readonly UserData userData;
        public BLLogin(ISingleton singleton) {
            //using the class
            this.userData = singleton.GetInstance;
        }

        public bool Authentication(string username,string password)
        {
            //instead of not equal to we are using not null because 
            //it can't override
            var isAccessed = false;
            if(userData.UserProfiles is not null)
            {
                foreach (var item in userData.UserProfiles)
                {
                    if(item.UserName.Equals(username) &&
                        item.Password.Equals(password))
                    {
                        isAccessed = true;
                    }
                    
                }
                return isAccessed;
            }
            else
            {
                return isAccessed;
            }
        }


    }
}
