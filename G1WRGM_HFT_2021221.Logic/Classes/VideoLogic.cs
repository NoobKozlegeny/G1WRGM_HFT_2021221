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
    public class VideoLogic : IVideoLogic
    {
        IVideoRepository videoRepo;
        public VideoLogic(IVideoRepository videoRepo)
        {
            this.videoRepo = videoRepo;
        }
        public void Create(Video content)
        {
            if (content != null && content.Title.Length > 0)
            {
                videoRepo.Create(content);
            }
            else
            {
                throw new ArgumentNullException("Dude, add a title, or I'm gonna call your mom");
            }
        }

        public void Delete(int id)
        {
            videoRepo.Delete(id);
        }

        public Video Read(int id)
        {
            return videoRepo.Read(id);
        }

        public IList<Video> ReadAll()
        {
            return videoRepo.ReadAll().ToList();
        }

        public void Update(Video content)
        {
            if (content != null && content.Title.Length > 0)
            {
                videoRepo.Update(content);
            }
            else
            {
                throw new ArgumentNullException("Do you want me to take the Geneva rules as Geneva suggestions?");
            }
        }

        //NON-CRUD
        public IEnumerable<Comment> First3MostLikedCommentFromVideo(int id)
        {
            if (id < 1)
            {
                throw new IndexOutOfRangeException("Add a positive ID");
            }
            else
            {
                return videoRepo.ReadAll().Where(x => x.VideoID == id).SelectMany(x => x.Comments).OrderByDescending(x => x.Likes).Take(3);
            }
        }

        public IEnumerable<KeyValuePair<string, Comment>> GetMostLikesCommentsFromVideos()
        {
            var result = from x in videoRepo.ReadAll()
                       group x by x.Title into g
                       select new KeyValuePair<string, Comment>
                       (
                           g.Key,
                           g.SelectMany(y=>y.Comments).OrderByDescending(y=>y.Likes).FirstOrDefault()
                       );
            return result;
        }
    }
}
