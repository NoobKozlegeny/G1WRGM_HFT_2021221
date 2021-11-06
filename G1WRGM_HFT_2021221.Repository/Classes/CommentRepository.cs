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
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(DbContext ctx) : base(ctx) { }

        public override Comment Create(string content)
        {
            throw new NotImplementedException();
        }

        public override Comment Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Comment GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public override Comment Read(int id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Comment> ReadAll()
        {
            throw new NotImplementedException();
        }

        public override Comment Update(int id, string content)
        {
            throw new NotImplementedException();
        }
    }
}
