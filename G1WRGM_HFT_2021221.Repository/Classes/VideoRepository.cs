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
    class VideoRepository : Repository<Video>, IVideoRepository
    {
        public VideoRepository(DbContext ctx) : base(ctx) { }
        public override Video Create(string content)
        {
            throw new NotImplementedException();
        }

        public override Video Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Video GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public override Video Read(int id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Video> ReadAll()
        {
            throw new NotImplementedException();
        }

        public override Video Update(int id, string content)
        {
            throw new NotImplementedException();
        }
    }
}
