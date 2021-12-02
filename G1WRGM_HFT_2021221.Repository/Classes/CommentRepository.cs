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
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        YTDbContext db;
        public CommentRepository(YTDbContext db)
        {
            this.db = db;
        }

        //CRUD

        public override void Create(Comment comment)
        {
            db.Comments.Add(comment);
            db.SaveChanges();
        }

        public override void Delete(int id)
        {
            var toDelete = Read(id);
            db.Comments.Remove(toDelete);
            db.SaveChanges();
        }


        public override Comment Read(int id)
        {
            return db.Comments.FirstOrDefault(x => x.CommentID == id);
        }

        public override IQueryable<Comment> ReadAll() //GetAll csak ReadAll a neve, mert így logikusabbnak gondoltam.
        {
            return db.Comments;
        }

        public override void Update(Comment comment) //The PUT problem arises here.
        {
            Comment commentToUpdate = Read(comment.CommentID);
            commentToUpdate = comment;
            db.SaveChanges();
        }

        //NON-CRUD
    }
}
