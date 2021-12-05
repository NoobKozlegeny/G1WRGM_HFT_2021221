using G1WRGM_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1WRGM_HFT_2021221.Logic.Interfaces
{
    public interface ICommentLogic
    {
        //CRUD
        public void Create(Comment content); //C
        public Comment Read(int id); //R
        public IList<Comment> ReadAll(); //R
        public void Update(Comment content); //U
        public void Delete(int id); //D

        //NON-CRUD
        public IEnumerable<Comment> CommentsWithMorethanXLikesAndXContent(int likeX, int contentX);
    }
}
