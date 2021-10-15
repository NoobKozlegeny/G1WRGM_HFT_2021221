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
        public string UserName { get; set; }
        [ForeignKey("SocialMedia")]
        public string SocialMediaID { get; set; }
        public virtual SocialMedia SocialMedia { get; set; }
        public virtual ICollection<Post> AllPosts { get; set; }
    }
}

