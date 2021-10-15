using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1WRGM_HFT_2021221.Models
{
    class Post
    {
        [Key]
        public string PostID { get; set; }
        [ForeignKey(nameof(User))]
        public string UserID { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        [NotMapped]
        public ICollection<string> Comments { get; set; }
    }
}
