using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAratoBackend.Services
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class UserManager
    {
        public Dictionary<string, User> Users = new Dictionary<string, User>() {
            {"jasonbryant28", new User(){ Password="megaman64" , UserName="jasonbryant28" } },
                        {"hitmandam", new User(){ Password="Thinkdam1" , UserName="hitmandam" } }


        };
    }

}
