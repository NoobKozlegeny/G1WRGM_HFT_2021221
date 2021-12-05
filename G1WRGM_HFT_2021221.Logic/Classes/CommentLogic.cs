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
            if (content == null)
            {
                throw new ArgumentNullException("Content is null");
            }
            else
            {
                commentRepo.Create(content);
            }
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
            if (content != null && content.Content.Length > 0)
            {
                commentRepo.Update(content);
            }
            else
            {
                throw new ArgumentNullException("Do you want me to take the Geneva rules as Geneva suggestions?");
            }
        }
    }
}
