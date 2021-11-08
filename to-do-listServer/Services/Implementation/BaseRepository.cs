using System;
using System.Collections.Generic;
using System.Linq;
using to_do_listServer.Database;
using to_do_listServer.Models.BaseModel;
using to_do_listServer.Services.Interfaces;
using to_do_listServer.ViewModels;


namespace to_do_listServer.Services.Implementation
{
    public class BaseRepository<TDbModel> : IBaseRepository<TDbModel> where TDbModel : BaseModel
    {
        protected Context Context { get; set; }

        public BaseRepository(Context context)
        {
            Context = context;
        }

        public TDbModel Create(TDbModel model)
        {
            Context.Set<TDbModel>().Add(model);
            Context.SaveChanges();
            return model;
        }

        public void Delete(Guid id)
        {
            var toDelete = Context.Set<TDbModel>().FirstOrDefault(m => m.Id == id);
            Context.Set<TDbModel>().Remove(toDelete);
            Context.SaveChanges();
        }

        public List<TDbModel> GetAll()
        {
            return Context.Set<TDbModel>().ToList();
        }

        public TDbModel Update(TDbModel model)
        {
            var toUpdate = Context.Set<TDbModel>().FirstOrDefault(m => m.Id == model.Id);
            if (toUpdate != null)
            {
                toUpdate = model;
            }

            Context.Update(toUpdate);
            Context.SaveChanges();
            return toUpdate;
        }

        public TDbModel GetById(Guid id)
        {
            return Context.Set<TDbModel>().FirstOrDefault(m => m.Id == id);
        }
    
       
    }
}