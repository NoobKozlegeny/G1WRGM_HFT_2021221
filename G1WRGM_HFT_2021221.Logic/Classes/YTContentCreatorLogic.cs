using G1WRGM_HFT_2021221.Logic.Interfaces;
using G1WRGM_HFT_2021221.Models;
using G1WRGM_HFT_2021221.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1WRGM_HFT_2021221.Logic.Classes
{
    public class YTContentCreatorLogic : IYTContentCreatorLogic
    {
        IYTContentCreatorRepository ytccRepo;

        public YTContentCreatorLogic(IYTContentCreatorRepository ytccRepo) //DEPENDENCY INJECTION
        {
            this.ytccRepo = ytccRepo;
        }

        //NON-CRUD
        public IEnumerable<Comment> GetAllNegativeCommentsFromYoutuber(int id)
        {
            return ytccRepo.ReadAll().Where(x => x.CreatorID == id).SelectMany(x => x.Videos)
                .Where(x => x.CreatorID == id).SelectMany(x => x.Comments).Where(x => x.Likes < 0);
        }

        public IEnumerable<Video> VideosWithMoreThanXViewsFromYoutuber(int id, int X)
        {
            return ytccRepo.ReadAll().Where(x => x.CreatorID == id).SelectMany(x => x.Videos)
                .Where(x => x.ViewCount > X);
        }
        public IEnumerable<Comment> GetLongestCommentsPerYoutuber()
        {
            //IEnumerable<int> allView = ytccRepo.ReadAll().Select(x => x.Videos.Sum(y => y.ViewCount));
            return ytccRepo.ReadAll().SelectMany(x => x.Videos).SelectMany(y => y.Comments).OrderBy(z => z.Content.Length);
        }

        public void ChangeSubscriberCount(int id, int newCount)
        {
            ytccRepo.ChangeSubscriberCount(id, newCount);
        }

        //CRUD
        public void Create(YTContentCreator content)
        {
            ytccRepo.Create(content);
        }

        public void Delete(int id)
        {
            ytccRepo.Delete(id);
        }

        public YTContentCreator Read(int id)
        {
            return ytccRepo.Read(id);
        }

        public IList<YTContentCreator> ReadAll()
        {
            return ytccRepo.ReadAll().ToList();
        }

        public void Update(YTContentCreator content)
        {
            ytccRepo.Update(content);
        }

        
    }
}
