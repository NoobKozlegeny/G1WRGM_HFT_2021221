using ConsoleTools;
using G1WRGM_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace G1WRGM_HFT_2021221.Client
{
    //TODO: DELETE ALL THE UNNEEDED DEPENDENCIES! (Only Model can remain)
    class Program
    {
        static void Menu()
        {
            
        }
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);

            RestService rest = new RestService("http://localhost:42069");

            var ytcreators = rest.Get<Video>("video");
            var first3 = rest.Get<Video>("/stat/first3/5");

            YTContentCreator ytTest = new YTContentCreator { CreatorID = 7, CreatorName = "Boiii", Creation = 2021, SubscriberCount = 999, Videos = new List<Video>() };
            Video vTest = new Video { CreatorID = 7, YTContentCreator = ytTest, Title = "Video Title", VideoID = 13, Comments = new List<Comment>() };
            Comment cTest = new Comment { VideoID = 4, CommentID = 10, Content = "Commentttttt", Username = "Cheesyboi", Likes = 222 }; //Video = vTest
            vTest.Comments.Add(cTest);
            ytTest.Videos.Add(vTest);
            

            rest.Post<Comment>(new Comment { VideoID = 8, Content= "Loool", Username="Lolipop"}, "comment"); //MIÉRT NEM MŰKÖDIK???

            //---------------------------------------------------------------------

            

            ;
        }
    }
}
