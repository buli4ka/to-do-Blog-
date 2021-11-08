using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using to_do_listServer.Config;
using to_do_listServer.Config.Jwt;
using to_do_listServer.Database;
using to_do_listServer.Models;
using to_do_listServer.ViewModels;

namespace to_do_listServer.Services
{
    public class UserService : IUserService
    {
        private Context _context;
        private IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;

        public UserService(
            Context context,
            IJwtUtils jwtUtils,
            IMapper mapper)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.Users.SingleOrDefault(x => x.Username == model.Username);


            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
                throw new AppException("Username or password is incorrect");

            var response = _mapper.Map<AuthenticateResponse>(user);
            response.JwtToken = _jwtUtils.GenerateToken(user);
            return response;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(Guid id)
        {
            var user = _context.Users
                .Include(entity => entity.Subscribed)
                .Include(entity => entity.Subscribers)
                .Include(entity =>entity.Posts)
                .FirstOrDefault(p => p.Id == id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

        public AuthenticateResponse Register(RegisterRequest model)
        {
            if (_context.Users.Any(x => x.Username == model.Username))
                throw new AppException("Username '" + model.Username + "' is already taken");

            var user = _mapper.Map<User>(model);

            user.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);

            _context.Users.Add(user);
            _context.SaveChanges();
            var response = _mapper.Map<AuthenticateResponse>(user);
            response.JwtToken = _jwtUtils.GenerateToken(user);
            return response;
        }


        public User Update(Guid id, UpdateRequest model)
        {
            var user = GetUser(id);

            if (model.Username != user.Username && _context.Users.Any(x => x.Username == model.Username))
                throw new AppException("Username '" + model.Username + "' is already taken");

            if (!string.IsNullOrEmpty(model.Password))
                user.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);

            _mapper.Map(model, user);
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }

        public void Delete(Guid id)
        {
            var user = GetUser(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void Subscribe(SubscribeRequest model)
        {
            var user = GetUser(model.userId);
            var author = GetUser(model.authorId);
            var subscribed = user.Subscribed != null
                ? new List<User>(user.Subscribed) {author}
                : new List<User> {author};
            user.Subscribed = subscribed;

            var subscribers = author.Subscribers != null
                ? new List<User>(author.Subscribers) {user}
                : new List<User> {user};
            author.Subscribers = subscribers;
            _context.Users.Update(user);
            _context.Users.Update(author);

            _context.SaveChanges();
        }

        public void Unsubscribe(SubscribeRequest model)
        {
            var user = GetUser(model.userId);
            var author = GetUser(model.authorId);
            
            var subscribed = new List<User>(user.Subscribed);
            user.Subscribed.Remove(author);
            var subscribers = new List<User>(author.Subscribers);
            subscribers.Remove(user);
              
            user.Subscribed = subscribed;
            author.Subscribers = subscribers;

            _context.Users.Update(user);
            _context.Users.Update(author);
         
            _context.SaveChanges();
        }

        public User GetAuthorById(Guid id)
        {
            var user = _context.Users
                .Include(entity => entity.Subscribed)
                .Include(entity => entity.Subscribers)
                .Include(entity =>entity.Posts)
                .FirstOrDefault(p => p.Id == id);
            if (user == null) throw new KeyNotFoundException("User not found");
            user.Password = null;
            return user;
        }


        private User GetUser(Guid id)
        {
            var user = _context.Users
                .Include(entity => entity.Subscribed)
                .Include(entity => entity.Subscribers)
                .FirstOrDefault(p => p.Id == id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
    }
}