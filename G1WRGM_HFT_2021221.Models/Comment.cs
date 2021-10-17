using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1WRGM_HFT_2021221.Models
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public int VideoID { get; set; }
        [NotMapped]
        public virtual Video Video { get; set; }
        [MaxLength(200)]
        public string Content { get; set; }
        public int Likes { get; set; }
    }
}
