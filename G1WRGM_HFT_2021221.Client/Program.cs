using G1WRGM_HFT_2021221.Data;
using G1WRGM_HFT_2021221.Models;
using G1WRGM_HFT_2021221.Repository.Classes;
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
            db.SaveChanges();
            //Test 1: List all Youtubers and their subscriber counts.
            Console.WriteLine("\n:: ALL RECORDS ::\n");
            db.YTContentCreators.ToList().ForEach(x => Console.WriteLine($"\t{x.CreatorName} -- {x.SubscriberCount}"));

            //Teszt
            YTContentCreatorRepository ytcr = new YTContentCreatorRepository(db);
            YTContentCreator ytc = new YTContentCreator
            {
                /* Ez a rész nem kell, mert az auto increment ID algoritmust bezavarod és ezért lesz
                 * Identity SET OFF hiba, még ha a [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                 * is fel van téve az osztályra
                CreatorID = 69696969,*/
                Creation = 2018,
                CreatorName = "Jóságos Béla",
                SubscriberCount = 1022
            };
            ytcr.Create(ytc);
            ytcr.Delete(ytc.CreatorID);

            Console.ReadLine();
        }
    }
}
