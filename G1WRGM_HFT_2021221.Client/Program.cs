using G1WRGM_HFT_2021221.Data;
using G1WRGM_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace G1WRGM_HFT_2021221.Client
{
    //TODO: DELETE ALL THE UNNEEDED DEPENDENCIES! (Only Model can remain)
    class Program
    {
        static void Main(string[] args)
        {
            SocialMediaDbContext db = new SocialMediaDbContext();
            //Test 1: Can I write all the informations for Reddit?
            IEnumerable<SocialMedia> t1_1 = db.SocialMedias.Where(x => x.SocialMediaName == "Reddit").ToList();
            foreach (var item in t1_1)
            {
                Console.WriteLine($"{item.SocialMediaName} -- {item.Creation}");
            }
            db.SaveChanges();
        }
    }
}
