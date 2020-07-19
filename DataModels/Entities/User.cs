using System;
using DataModels.Base;

namespace DataModels.Entities
{
    public class User: IdBase
    {
        public string Username { get; set; }

        public string Fullname { get; set; }
        public string Password { get; set; }
        public bool Valid { get; set; } = true;
        public DateTime LastOnline { get; set; }
    }
}