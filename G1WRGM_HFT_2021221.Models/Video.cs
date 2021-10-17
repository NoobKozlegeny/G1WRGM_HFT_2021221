using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1WRGM_HFT_2021221.Models
{
    public class Video
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Technically this is the defaul DB generation.
        [Key]
        public int VideoID { get; set; }
        [MaxLength(30)]
        public string Title { get; set; }
        [ForeignKey(nameof(YTContentCreator))]
        public string CreatorName { get; set; }
        [NotMapped]
        public virtual YTContentCreator YTContentCreator { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public int ViewCount { get; set; }

        public Video()
        {
            Comments = new List<Comment>();
        }
    }
}

