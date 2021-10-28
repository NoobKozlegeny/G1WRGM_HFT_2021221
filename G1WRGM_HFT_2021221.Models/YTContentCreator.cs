using G1WRGM_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1WRGM_HFT_2021221.Models
{
    public class YTContentCreator
    {
        //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="|DataDirectory|\SocialMediaDatabase.mdf";Integrated Security=True
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Technically this is the defaul DB generation.
        [Key]
        public string CreatorName { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
        public int Creation { get; set; }
        public int SubscriberCount { get; set; }
        public string AllData { get; }

        public YTContentCreator()
        {
            Videos = new List<Video>();
            AllData = $"Name: {CreatorName} -- Creation: {Creation} -- Subscribers: {SubscriberCount}";
        }
    }
}
