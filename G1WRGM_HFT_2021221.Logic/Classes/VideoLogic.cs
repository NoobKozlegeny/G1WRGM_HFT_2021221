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
            videoRepo.Create(content);
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
            videoRepo.Update(content);
        }
    }
}
