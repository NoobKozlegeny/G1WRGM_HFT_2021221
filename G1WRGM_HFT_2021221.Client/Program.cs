using G1WRGM_HFT_2021221.Data;
using G1WRGM_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace G1WRGM_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            SocialMediaDbContext db = new SocialMediaDbContext();
            //db.SocialMedias.Add(new SocialMedia { Name = "Facebook", Creation = 2004, Users = null });
            //db.SocialMedias.Add(new SocialMedia { Name = "Twitter", Creation = 2006, Users = null });
            //db.SocialMedias.Add(new SocialMedia { Name = "Reddit", Creation = 2005, Users = null });

            db.SaveChanges();
            //foreach (var item in db.SocialMedias)
            //{
            //    Console.WriteLine($"{item.Name} -- {item.Creation} -- {item.Users}");
            //}
        }
    }
}
