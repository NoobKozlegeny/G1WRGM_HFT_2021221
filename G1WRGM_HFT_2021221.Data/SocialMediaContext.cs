using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1WRGM_HFT_2021221.Models
{
    public class SocialMediaContext : DbContext
    {
        public virtual DbSet<SocialMedia> SocialMedias { get; set; }
        public SocialMediaContext()
        {
            this.Database.EnsureCreated();
            OnModelCreating();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SocialMediaDatabase.mdf;Integrated Security=True");



            }
        }

        protected void OnModelCreating()
        {
            SocialMedias.Add(new SocialMedia { Name = "Facebook", Creation = 2004, Users = null });
            SocialMedias.Add(new SocialMedia { Name = "Twitter", Creation = 2006, Users = null });
            SocialMedias.Add(new SocialMedia { Name = "Reddit", Creation = 2005, Users = null });
        }
    }
}
