using System;
using System.Collections.Generic;
using to_do_listServer.Models;
using to_do_listServer.Models.BaseModel;

namespace to_do_listServer.ViewModels
{
    public class PostView : BaseModel

    {

    public string Title { get; set; }
    public string Text { get; set; }

    public ICollection<Guid> ImageIds { get; set; }


    public User Author { get; set; }
    }
}