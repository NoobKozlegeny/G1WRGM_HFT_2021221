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
            //Test 1: Idk.
            IEnumerable<YTContentCreator> t1_1 = db.YTContentCreators.Where(x => x.CreatorName == "Zsdav").ToList();
            foreach (var item in t1_1)
            {
                Console.WriteLine($"{item.CreatorName} -- {item.Creation}");
            }
            db.SaveChanges();
        }
    }
}
