using DataAcessLayer.Classes.designPattern.singletonClas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Classes.businessLogic
{
    public abstract class Authentication
    {
        protected string userName;
        public readonly IUserData _userData;

        protected Authentication(IUserData userData,string username)
        {
            _userData = userData;
            this.userName = username;
            IsAuthenticated();

        }
        public bool isAccessed { get; private set; }
        public void IsAuthenticated() { 
            var user = _userData.UserProfiles.Where((obj) => obj.UserName == userName).FirstOrDefault();
            if(user is  null)
            {
                 throw new Exception("Not Authentivated user");
            }   
        }
    }
}
