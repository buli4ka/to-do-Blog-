using AutoMapper.Configuration;
using Microsoft.EntityFrameworkCore;
using to_do_listServer.Models;

namespace to_do_listServer.Database
{
    public class Context : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Image> Images { get; set; }


        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}