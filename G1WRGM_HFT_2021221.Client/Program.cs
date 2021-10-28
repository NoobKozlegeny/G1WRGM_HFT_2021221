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
            YTDbContext db = new YTDbContext();
            ;
            //Test 1: List all Youtubers and their subscriber counts.
            Console.WriteLine("\n:: ALL RECORDS ::\n");
            db.YTContentCreators.ToList().ForEach(x => Console.WriteLine($"\t{x.CreatorName} -- {x.SubscriberCount}"));
            db.SaveChanges();
        }
    }
}
