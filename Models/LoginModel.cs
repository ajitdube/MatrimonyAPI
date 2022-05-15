using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatrimonyAPI.Models
{
    public class LoginModel
    {
        public int UserId  { get; set; }
        public string Username { get; set; }
        
        public string message { get; set; }
        
    }
}