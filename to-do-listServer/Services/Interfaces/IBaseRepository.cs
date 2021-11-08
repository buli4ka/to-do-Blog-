using to_do_listServer.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace to_do_listServer.Services.Interfaces
{
    public interface IBaseRepository<TDbModel>
    {
        public List<TDbModel> GetAll();
        public TDbModel GetById(Guid id);
        
        public TDbModel Create(TDbModel model);
        public TDbModel Update(TDbModel model);
        public void Delete(Guid id);
    }
}
