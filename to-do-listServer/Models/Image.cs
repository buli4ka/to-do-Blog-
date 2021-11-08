using System;

namespace to_do_listServer.Models
{
    public class Image : BaseModel.BaseModel
    {
        public string ImageType { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }

        public Guid ParentId { get; set; }
        // public Post Parent { get; set; }

        
    }
}