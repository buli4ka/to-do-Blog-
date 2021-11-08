using System;

namespace to_do_listServer.ViewModels
{
    public class SubscribeRequest
    {
        public Guid userId { get; set; }
        public Guid authorId { get; set; }
    }
}