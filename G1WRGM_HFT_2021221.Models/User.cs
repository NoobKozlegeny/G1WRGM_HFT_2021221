using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1WRGM_HFT_2021221.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [MaxLength(30)]
        public string UserName { get; set; }
        public string SocialMediaName { get; set; }
        [NotMapped]
        public virtual SocialMedia SocialMedia { get; set; }
        public virtual ICollection<Post> AllPosts { get; set; }
    }
}

