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
    public class YTContentCreatorRepository : Repository<YTContentCreator>, IYTContentCreatorRepository
    {
        YTDbContext db;
        public YTContentCreatorRepository(YTDbContext db)
        {
            this.db = db;
        }
        
        public void ChangeSubscriberCount(int id, int newCount)
        {
            var contentCreator = Read(id);
            contentCreator.SubscriberCount = newCount;
            db.SaveChanges();
        }

        //CRUD

        public override void Create(YTContentCreator contentCreator)
        {
            db.YTContentCreators.Add(contentCreator);
            db.SaveChanges();
        }

        public override void Delete(int id)
        {
            db.YTContentCreators.Remove(Read(id));
            db.SaveChanges();
        }

        public override YTContentCreator Read(int id)
        {
            return db.YTContentCreators.First(x=>x.CreatorID == id);
        }

        public override IQueryable<YTContentCreator> ReadAll() //GetAll csak ReadAll a neve, mert így logikusabb
        {
            return db.YTContentCreators;
        }

        public override void Update(YTContentCreator contentCreator)
        {
            YTContentCreator contentCreatorInDireNeedForUpdating = Read(contentCreator.CreatorID);
            contentCreatorInDireNeedForUpdating.CreatorName = contentCreator.CreatorName;
            contentCreatorInDireNeedForUpdating.Creation = contentCreator.Creation;
            contentCreator.SubscriberCount = contentCreator.SubscriberCount;
            db.SaveChanges();
        }

        
    }
}
