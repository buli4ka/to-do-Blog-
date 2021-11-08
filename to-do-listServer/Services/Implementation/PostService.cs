using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using to_do_listServer.Database;
using to_do_listServer.Models;
using to_do_listServer.Services.Interfaces;
using to_do_listServer.ViewModels;

namespace to_do_listServer.Services.Implementation
{
    public class PostService : IPostService
    {
        private readonly Context _context;

        public PostService(Context context)
        {
            _context = context;
        }


        public Post Create(Post model)
        {
            var post = new Post
            {
                Title = model.Title,
                Text = model.Text,
                AuthorId = model.AuthorId
            };
            _context.Add(post);
            _context.SaveChanges();
            return post;
        }

        public void Delete(Guid id)
        {
            var toDelete = _context.Set<Post>().FirstOrDefault(m => m.Id == id);
            _context.Set<Post>().Remove(toDelete);
            _context.SaveChanges();
        }

        public List<Post> GetAll()
        {
            return _context.Set<Post>().ToList();
        }

        public Post Update(Post model)
        {
            var toUpdate = _context.Set<Post>().FirstOrDefault(m => m.Id == model.Id);
            if (toUpdate != null)
            {
                toUpdate = model;
            }

            _context.Update(toUpdate);
            _context.SaveChanges();
            return toUpdate;
        }

        // public Task<Post> GetByIdWithImages(Guid id)
        // {
        //     var post = _context.Posts.OrderBy(i => i.Id == id)
        //         .Include(e => e.Images)
        //         .AsSplitQuery()
        //         .FirstOrDefaultAsync();
        //     // var post=   _context.Set<Post>().FirstOrDefault(user => user.Id == id);
        //     return post ?? null;
        //     // var images = _context.Set<Image>().Where(image => image.PostId == id).ToList();
        //     // var imageIds = images.Select(i => i.Id).ToList();
        //     // var result = new PostView
        //     // {
        //     //     Id = post.Id,
        //     //     Title = post.Title,
        //     //     Text = post.Text,
        //     //     Author = post.Author,
        //     //     ImageIds = imageIds
        //     // };
        // }

        public Post GetById(Guid id)
        {
            var post = _context.Posts
                .Include(e => e.Author)
                .FirstOrDefault(p => p.Id == id);
            if (post == null) return null;
            post.Author.Password = null;
            post.Author.FirstName = null;
            post.Author.LastName = null;

            return post;
        }

        public List<Post> GetAllByAuthorId(Guid authorId)
        {
            var posts = _context.Set<Post>()
                .Where(p => p.AuthorId == authorId)
                .Include(e => e.Author)
                .ToList();
            return posts ?? null;
        }
    }
}