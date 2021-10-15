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
            SocialMediaContext db = new SocialMediaContext();
            SocialMedia fb = db.SocialMedias.FindAsync("Facebook").Result;
            Console.WriteLine(fb.Name);
        }
    }
}
