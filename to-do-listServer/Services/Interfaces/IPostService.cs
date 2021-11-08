using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using to_do_listServer.Models;
using to_do_listServer.ViewModels;

namespace to_do_listServer.Services.Interfaces
{
    public interface IPostService
    {
        public List<Post> GetAll();
        // public Task<Post> GetByIdWithImages(Guid id);
        public Post GetById(Guid id);
        public List<Post>  GetAllByAuthorId(Guid authorId);


        public Post Create(Post model);
        public Post Update(Post model);
        public void Delete(Guid id);
    }
}