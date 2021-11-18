using G1WRGM_HFT_2021221.Logic.Classes;
using G1WRGM_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1WRGM_HFT_2021221.Logic.Interfaces
{
    public interface IYTContentCreatorLogic
    {
        //CRUD
        public void Create(YTContentCreator content); //C
        public YTContentCreator Read(int id); //R
        public IList<YTContentCreator> ReadAll(); //R
        public void Update(YTContentCreator content); //U
        public void Delete(int id); //D

        //NON-CRUD
        public void ChangeSubscriberCount(int id, int newCount);
        public IEnumerable<Video> VideosWithMoreThanXViewsFromYoutuber(int id, int X);
        public IEnumerable<Comment> GetAllNegativeCommentsFromYoutuber(int id);
        public IEnumerable<Comment> GetLongestCommentsPerYoutuber();

    }
}
