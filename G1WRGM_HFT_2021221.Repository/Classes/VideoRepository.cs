using G1WRGM_HFT_2021221.Data;
using G1WRGM_HFT_2021221.Models;
using G1WRGM_HFT_2021221.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1WRGM_HFT_2021221.Repository.Classes
{
    public class VideoRepository : Repository<Video>, IVideoRepository
    {
        YTDbContext db;
        public VideoRepository(YTDbContext db)
        {
            this.db = db;
        }

        //CRUD

        public override void Create(Video video)
        {
            db.Videos.Add(video);
            db.SaveChanges();
        }

        public override void Delete(int id)
        {
            db.Videos.Remove(Read(id));
            db.SaveChanges();
        }

        public override Video Read(int id)
        {
            return db.Videos.FirstOrDefault(x => x.VideoID == id);
        }

        public override IQueryable<Video> ReadAll() //GetAll csak ReadAll a neve, mert így logikusabb
        {
            return db.Videos;
        }

        public override void Update(Video video)
        {
            Video videoToUpdate = Read(video.VideoID);
            videoToUpdate.Title = video.Title;
            videoToUpdate.ViewCount = video.ViewCount;
            db.SaveChanges();
        }
    }
}
