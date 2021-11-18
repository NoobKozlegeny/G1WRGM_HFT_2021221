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
    public class CommentLogic : ICommentLogic
    {
        ICommentRepository commentRepo;
        public CommentLogic(ICommentRepository commentRepo)
        {
            this.commentRepo = commentRepo;
        }
        public void Create(Comment content)
        {
            commentRepo.Create(content);
        }

        public void Delete(int id)
        {
            commentRepo.Delete(id);
        }

        public Comment Read(int id)
        {
            return commentRepo.Read(id);
        }

        public IList<Comment> ReadAll()
        {
            return commentRepo.ReadAll().ToList();
        }

        public void Update(Comment content)
        {
            commentRepo.Update(content);
        }
    }
}
