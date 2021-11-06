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
        public YTContentCreatorRepository(DbContext ctx) : base(ctx) { }
        public void ChangeSubscriberCount(int id, int newCount)
        {
            var contentCreator = GetOne(id);
            contentCreator.SubscriberCount = newCount;
            ctx.SaveChanges();
        }

        public override YTContentCreator Create(string content)
        {
            throw new NotImplementedException();
        }

        public override YTContentCreator Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override YTContentCreator GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.CreatorID == id);
        }

        public override YTContentCreator Read(int id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<YTContentCreator> ReadAll()
        {
            throw new NotImplementedException();
        }

        public override YTContentCreator Update(int id, string content)
        {
            throw new NotImplementedException();
        }
    }
}
