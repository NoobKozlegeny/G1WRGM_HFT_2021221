using G1WRGM_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1WRGM_HFT_2021221.Logic.Interfaces
{
    public interface IVideoLogic
    {
        //CRUD
        public void Create(Video content); //C
        public Video Read(int id); //R
        public IList<Video> ReadAll(); //R
        public void Update(Video content); //U
        public void Delete(int id); //D

        //NON-CRUD
        public IList<Video> VideosWithZeroComments();
        public Comment MostLikedComment(int id);
    }
}
