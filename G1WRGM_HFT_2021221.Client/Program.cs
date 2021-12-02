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
        static RestService rest = new RestService("http://localhost:42069");

        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);



            Menu();

            ;
        }

        static void Menu()
        {
            bool quit = false;
            while (quit == false)
            {
                Console.WriteLine("Hello there in my probably Spar budget App! :))");
                Console.WriteLine("These are your options for today, dear user:");
                Console.WriteLine("\t1: POST (C)"); //C
                Console.WriteLine("\t2: GETALL (R)"); //R
                Console.WriteLine("\t3: GET (R) -- JSON DESERIALIZE EXCEPTION"); //R
                Console.WriteLine("\t4: PUT (U)"); //U
                Console.WriteLine("\t5: DELETE (D)"); //D
                Console.WriteLine("----------------");
                Console.WriteLine("\t6: First3MostLikedCommentFromVideo");
                Console.WriteLine("\t7: GetMostWatchedVideoPerYoutubers");
                Console.WriteLine("\t8: GetVideosWithCommentsFromYoutuber");
                Console.WriteLine("\t9: VideosWithMoreThan30KViewsFromYoutuber");
                Console.WriteLine("\t10: AllNegCommsFromYTber");

                int result = 0;
                while (result == 0)
                {
                    try
                    {
                        Console.Write("What would be on the plate for today? ");
                        result = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please try this again:");
                    }
                }

                RESTRunner(result);
            }
        }

        static void RESTRunner(int result)
        {
            switch (result)
            {
                case 1:
                    POST(); break;
                case 2:
                    GETALL(); break;
                case 3:
                    GET(); break;
                case 4:
                    PUT(); break;
                case 5:
                    DELETE(); break;
                case 6:
                    FIRST3(); break;
                case 7:
                    MOSTWATCHEDPERYOUTUBERS(); break;
                case 8:
                    VIDEOSWITHCOMMENTSFROMYTBER(); break;
                case 9:
                    VIDEOSWITHMORETHAN30KVIEWSFROMYTBER(); break;
                case 10:
                    ALLNEGATIVECOMMENTS(); break;
                default:
                    break;
            }
        }

        static void POST()
        {
            Console.WriteLine("Please choose one form these:");
            Console.WriteLine("\t1: Youtuber");
            Console.WriteLine("\t2: Video");
            Console.WriteLine("\t3: Comment");

            int result = 0;
            while (result == 0)
            {
                try
                {
                    Console.Write("What would be on the plate for today? ");
                    result = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please try this again:");
                }
            }



            switch (result)
            {
                case 1:
                    YTContentCreator ytcc = new YTContentCreator();
                    Console.Write("Name: "); ytcc.CreatorName = Console.ReadLine();
                    Console.Write("Creation Date: "); ytcc.Creation = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Subscriber: "); ytcc.SubscriberCount = Convert.ToInt32(Console.ReadLine());
                    ytcc.Videos = new List<Video>();
                    Console.WriteLine();

                    rest.Post(ytcc, "ytcontentcreator");
                    break;
                case 2:
                    Video video = new Video();
                    Console.Write("Title: "); video.Title = Console.ReadLine();
                    Console.Write("Views: "); video.ViewCount = Convert.ToInt32(Console.ReadLine());
                    Console.Write("To which Youtuber (add CreatorID): "); 
                    video.CreatorID = Convert.ToInt32(Console.ReadLine());
                    video.Comments = new List<Comment>();
                    Console.WriteLine();

                    rest.Post(video, "video");
                    break;
                case 3:
                    Comment comment = new Comment();
                    Console.Write("Username: "); comment.Username = Console.ReadLine();
                    Console.Write("Content: "); comment.Content = Console.ReadLine();
                    Console.Write("To which Video (add VideoID): ");
                    comment.VideoID = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Likes: "); comment.Likes = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    rest.Post(comment, "comment");
                    break;
                default:
                    break;
            }
        }
        static void GETALL()
        {
            Console.WriteLine("Please choose one form these:");
            Console.WriteLine("\t1: Youtuber");
            Console.WriteLine("\t2: Video");
            Console.WriteLine("\t3: Comment");

            int result = 0;
            while (result == 0)
            {
                try
                {
                    Console.Write("What would be on the plate for today? ");
                    result = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please try this again:");
                }
            }

            switch (result)
            {
                case 1:
                    rest.Get<YTContentCreator>("ytcontentcreator");
                    break;
                case 2:
                    rest.Get<Video>("video");
                    break;
                case 3:
                    rest.Get<Comment>("comment");
                    break;
                default:
                    break;
            }
        }
        static void GET() //Json Deserialize exception
        {
            Console.WriteLine("Please choose one form these:");
            Console.WriteLine("\t1: Youtuber");
            Console.WriteLine("\t2: Video");
            Console.WriteLine("\t3: Comment");

            int result = 0;
            while (result == 0)
            {
                try
                {
                    Console.Write("What would be on the plate for today? ");
                    result = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please try this again:");
                }
            }

            int id = 0;
            while (id == 0)
            {
                try
                {
                    Console.Write("Choose an ID as well: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please try this again:");
                }
            }

            switch (result)
            {
                case 1:
                    rest.Get<YTContentCreator>($"ytcontentcreator/{id}");
                    break;
                case 2:
                    rest.Get<Video>($"video/{id}");
                    break;
                case 3:
                    rest.Get<Comment>($"comment/{id}");
                    break;
                default:
                    break;
            }
        }
        static void PUT()
        {
            Console.WriteLine("Please choose one form these:");
            Console.WriteLine("\t1: Youtuber");
            Console.WriteLine("\t2: Video");
            Console.WriteLine("\t3: Comment");

            int result = 0;
            while (result == 0)
            {
                try
                {
                    Console.Write("What would be on the plate for today? ");
                    result = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please try this again:");
                }
            }

            switch (result)
            {
                case 1:
                    YTContentCreator ytcc = new YTContentCreator();
                    Console.Write("Name: "); ytcc.CreatorName = Console.ReadLine();
                    Console.Write("Creation Date: "); ytcc.Creation = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Subscriber: "); ytcc.SubscriberCount = Convert.ToInt32(Console.ReadLine());
                    ytcc.Videos = new List<Video>();
                    Console.WriteLine();

                    rest.Put(ytcc, "ytcontentcreator");
                    break;
                case 2:
                    Video video = new Video();
                    Console.Write("Title: "); video.Title = Console.ReadLine();
                    Console.Write("Views: "); video.ViewCount = Convert.ToInt32(Console.ReadLine());
                    Console.Write("To which Youtuber (add CreatorID): ");
                    video.CreatorID = Convert.ToInt32(Console.ReadLine());
                    video.Comments = new List<Comment>();
                    Console.WriteLine();

                    rest.Put(video, "video");
                    break;
                case 3:
                    Comment comment = new Comment();
                    Console.Write("Username: "); comment.Username = Console.ReadLine();
                    Console.Write("Content: "); comment.Content = Console.ReadLine();
                    Console.Write("To which Video (add VideoID): ");
                    comment.VideoID = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Likes: "); comment.Likes = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    rest.Put(comment, "comment");
                    break;
                default:
                    break;
            }
        } //Doesn't work
        static void DELETE()
        {
            Console.WriteLine("Please choose one form these:");
            Console.WriteLine("\t1: Youtuber");
            Console.WriteLine("\t2: Video");
            Console.WriteLine("\t3: Comment");

            int result = 0;
            while (result == 0)
            {
                try
                {
                    Console.Write("What would be on the plate for today? ");
                    result = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please try this again:");
                }
            }

            int id = 0;
            while (id == 0)
            {
                try
                {
                    Console.Write("Choose an ID as well: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please try this again:");
                }
            }

            switch (result)
            {
                case 1:
                    rest.Delete(id, "ytcontentcreator");
                    break;
                case 2:
                    rest.Delete(id, "video");
                    break;
                case 3:
                    rest.Delete(id, "comment");
                    break;
                default:
                    break;
            }
        }

        //NON-CRUDS

        static void FIRST3()
        {
            int id = 0;
            while (id == 0 || id < 0)
            {
                try
                {
                    Console.Write("Choose a VideoID: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please try this again:");
                }
            }

            List<Video> result = rest.Get<Video>($"/stat/first3/{id}");
            result.ForEach(x => Console.WriteLine(x));
        }
        static void MOSTWATCHEDPERYOUTUBERS()
        {
            rest.Get<Video>($"/stat/mostwatched");
        }
        static void ALLNEGATIVECOMMENTS()
        {
            int id = 0;
            while (id == 0 || id < 0)
            {
                try
                {
                    Console.Write("Choose a CreatorID: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please try this again:");
                }
            }

            rest.Get<YTContentCreator>($"/stat/allnegcommsfromytber/{id}");
        }
        static void VIDEOSWITHMORETHAN30KVIEWSFROMYTBER()
        {
            int id = 0;
            while (id == 0 || id < 0)
            {
                try
                {
                    Console.Write("Choose a CreatorID: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please try this again:");
                }
            }

            rest.Get<YTContentCreator>($"/stat/vidmorexviews/{id}");
        }
        static void VIDEOSWITHCOMMENTSFROMYTBER()
        {
            int id = 0;
            while (id == 0 || id < 0)
            {
                try
                {
                    Console.Write("Choose a CreatorID: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please try this again:");
                }
            }

            rest.Get<YTContentCreator>($"/stat/vidwithmorecomm/{id}");
        }
    }
}
