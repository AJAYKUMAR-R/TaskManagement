using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Classes.dtoConsole
{
    public class UserProfile
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }   
    }
}
