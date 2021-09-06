using Data.Context;
using Data.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class BaseRepository<M> where M: BaseModel
    {
        public void Create(M model)
        {
            using (var context = new EstoContext())
            {
                context.Set<M>().Add(model);
                context.SaveChanges();
            }
        }

        public List<M> Read()
        {
            List<M> lista = new List<M>();
            using (var context = new EstoContext())
            {
                lista = context.Set<M>().ToList();
            }
            return lista;
        }

        public M Read(int id)
        {
            M model = Activator.CreateInstance<M>();
            using (var context = new EstoContext())
            {
                model = context.Set<M>().Find(id);
            }
            return model;
        }

        public void Update(M model)
        {
            using (var context = new EstoContext())
            {
                context.Entry<M>(model).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new EstoContext())
            {
                context.Entry<M>(Read(id)).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }

}

