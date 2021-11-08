using System;
using System.Collections.Generic;
using to_do_listServer.Models;
using to_do_listServer.ViewModels;

namespace to_do_listServer.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(Guid id);
        AuthenticateResponse Register(RegisterRequest model);
        User Update(Guid id, UpdateRequest model);
        void Delete(Guid id);
        void Subscribe(SubscribeRequest model);
        void Unsubscribe(SubscribeRequest model);
        User GetAuthorById(Guid id);
    }
}