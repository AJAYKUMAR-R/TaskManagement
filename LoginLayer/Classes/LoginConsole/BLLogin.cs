using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Classes;
using DataAcessLayer.Classes.designPattern.singletonClas;

namespace LoginLayer.Classes.LoginConsole
{
    public class BLLogin
    {
        private readonly IUserData _userData;
       
        public BLLogin(IUserData singleton) {
            //using the class
            this._userData = singleton.GetInstance;
            
        }

        public bool isAccessible(string username,string password)
        {
            //instead of not equal to we are using not null because 
            //it can't override
            var isAccessed = false;
            if(_userData.UserProfiles is not null)
            {
                foreach (var item in _userData.UserProfiles)
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
