using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1WRGM_HFT_2021221.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetOne(int id);
        IQueryable<T> GetAll();
        //CRUD
        T Create(string content); //C
        T Read(int id); //R
        IQueryable<T> ReadAll(); //R
        T Update(int id, string content); //U
        T Delete(int id); //D

    }
}
