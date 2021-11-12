using G1WRGM_HFT_2021221.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1WRGM_HFT_2021221.Repository.Classes
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        #region Sipos gondolatmenet hátha mégis kell
        //protected DbContext ctx;
        //public Repository(DbContext ctx)
        //{
        //    this.ctx = ctx;
        //}

        //public abstract T GetOne(int id);

        //public IQueryable<T> GetAll()
        //{
        //    return ctx.Set<T>();
        //}

        //public abstract IQueryable<T> GetAll();
        //public abstract T GetOne(int id);
        #endregion

        //CRUD

        public abstract void Create(T content); //C
        public abstract void Delete(int id); //D       
        public abstract T Read(int id); //R
        public abstract IQueryable<T> ReadAll(); //R
        public abstract void Update(T content); //U
    }
}
