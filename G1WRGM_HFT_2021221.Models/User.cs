using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1WRGM_HFT_2021221.Models
{
    class User
    {
        [Key]
        public string UserName { get; set; }
        //Foreign Key
        public string UserID { get; set; }
        //Foreign Key
        public string SocialMedia { get; set; }
        public ICollection<Post> AllPosts { get; set; }
    }
}

