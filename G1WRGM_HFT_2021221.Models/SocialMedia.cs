using G1WRGM_HFT_2021221.Models.Other;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1WRGM_HFT_2021221.Models
{
    class SocialMedia
    {
        //Todo: LazyLoader
        //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="|DataDirectory|\SocialMediaDatabase.mdf";Integrated Security=True
        [Key]
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
        public DateTime CreationDate { get; set; }
        public PersonalRatingEnum PersonalRating { get; set; }
    }
}
