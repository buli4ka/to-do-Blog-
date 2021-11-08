using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace to_do_listServer.Models
{
    public class User : BaseModel.BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public ICollection<Post> Posts { get; set; }
        
        public ICollection<User> Subscribers { get; set; }
        public ICollection<User> Subscribed { get; set; }
        
      

        [JsonIgnore] public string Password { get; set; }
    }
}