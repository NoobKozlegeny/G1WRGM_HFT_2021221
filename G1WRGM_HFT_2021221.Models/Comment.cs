using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace G1WRGM_HFT_2021221.Models
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Technically this is the defaul DB generation.
        [Key]
        public int CommentID { get; set; }
        [ForeignKey(nameof(Video))]
        public int VideoID { get; set; }
        [NotMapped]
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Video Video { get; set; }
        [MaxLength(200)]
        public string Username { get; set; } //Potentional 4th table?
        public string Content { get; set; }
        public int Likes { get; set; }
        public string AllData { get; set; }
        public Comment()
        {
            AllData = $"Username: {Username} -- Content: {Content} -- Likes: {Likes}";
        }
    }
}
