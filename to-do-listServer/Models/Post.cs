using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace to_do_listServer.Models
{
    public class Post : BaseModel.BaseModel
    {
        public string Title { get; set; }
        public string Text { get; set; }

        public Guid AuthorId { get; set; }

        [JsonIgnore] public User Author { get; set; }
        
        // public ICollection<Image> Images { get; set; }

        
    }
}