using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1WRGM_HFT_2021221.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        //public T GetOne(int id);
        //public IQueryable<T> GetAll();

        //CRUD

        public void Create(T content); //C
        public T Read(int id); //R
        public IQueryable<T> ReadAll(); //R
        public void Update(T content); //U
        public void Delete(int id); //D

    }
}
