using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace HallBookingSystem
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public User(DataRow dr)
        {
            FirstName = Convert.ToString(dr["FirstName"]);
            LastName = Convert.ToString(dr["LastName"]);
            UserName = Convert.ToString(dr["UserName"]);
            Password = Convert.ToString(dr["Password"]);
        }
    }
}
