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
            var r1 = ytccRepo.ReadAll().Where(x => x.CreatorID == id);
            var r2 = r1.SelectMany(x => x.Videos).Where(x => x.CreatorID == id);
            var r3 = r2.SelectMany(x => x.Comments).Where(x => x.Likes < 0);
            return r3;
        }

        public IEnumerable<Video> VideosWithMoreThanXViewsFromYoutuber(int id, int X)
        {
            return ytccRepo.ReadAll().Where(x => x.CreatorID == id).SelectMany(x => x.Videos)
                .Where(x => x.ViewCount > X);
        }
        public IEnumerable<Video> GetVideosWithCommentsFromYoutuber(int id)
        {
            return ytccRepo.ReadAll().Where(x => x.CreatorID == id).SelectMany(x => x.Videos)
                .Where(x => x.Comments.Count != 0);
        }

        public void ChangeSubscriberCount(int id, int newCount)
        {
            ytccRepo.ChangeSubscriberCount(id, newCount);
        }

        //CRUD
        public void Create(YTContentCreator content)
        {
            if (content != null && content.CreatorName.Length > 0)
            {
                ytccRepo.Create(content);
            }
            else
            {
                throw new Exception("Dude, add a CreatorName, or I'm gonna call your mom");
            }
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
            var result = ytccRepo.ReadAll().ToList();
            return result;
        }

        public void Update(YTContentCreator content)
        {
            if (content != null && content.CreatorName.Length > 0)
            {
                ytccRepo.Update(content);
            }
            else
            {
                throw new Exception("Do you want me to take the Geneva rules as Geneva suggestions?");
            }
        }

        
    }
}
