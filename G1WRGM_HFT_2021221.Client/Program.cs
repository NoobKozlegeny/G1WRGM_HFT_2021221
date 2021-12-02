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
                Console.WriteLine("\t11: GetMostLikesCommentsFromVideos");

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
                case 11:
                    MOSTLIKEDCOMMENTSPERVIDEOS(); break;
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
                    Console.WriteLine("Succesful post, please refresh the page."+Environment.NewLine);
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
                    Console.WriteLine("Succesful post, please refresh the page." + Environment.NewLine);
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
                    Console.WriteLine("Succesful post, please refresh the page." + Environment.NewLine);
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
                    foreach (var item in rest.Get<YTContentCreator>("ytcontentcreator"))
                    {
                        Console.WriteLine($"CreatorID: {item.CreatorID}, CreatorName: {item.CreatorName}, Subscribers: {item.SubscriberCount}, Creation: {item.Creation}");
                        foreach (var vid in item.Videos)
                        {
                            Console.WriteLine($"\tVideoID: {vid.VideoID}, Title: {vid.Title}, Views: {vid.ViewCount}");
                            foreach (var com in vid.Comments)
                            {
                                Console.WriteLine($"\t\tCommentID: {com.CommentID}, Username: {com.Username}, Content: {com.Content}, Likes: {com.Likes}");
                            }
                        }
                    }
                    break;
                case 2:
                    foreach (var vid in rest.Get<Video>("video"))
                    {
                        Console.WriteLine($"\tVideoID: {vid.VideoID}, Title: {vid.Title}, Views: {vid.ViewCount}");
                        foreach (var com in vid.Comments)
                        {
                            Console.WriteLine($"\t\tCommentID: {com.CommentID}, Username: {com.Username}, Content: {com.Content}, Likes: {com.Likes}");
                        }
                    }
                    break;
                case 3:
                    foreach (var com in rest.Get<Comment>("comment"))
                    {
                        Console.WriteLine($"\t\tCommentID: {com.CommentID}, Username: {com.Username}, Content: {com.Content}, Likes: {com.Likes}");
                    }
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
                    Console.WriteLine("Succesful put/update, please refresh the page." + Environment.NewLine);
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
                    Console.WriteLine("Succesful put/update, please refresh the page." + Environment.NewLine);
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
                    Console.WriteLine("Succesful put/update, please refresh the page." + Environment.NewLine);
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
                    Console.WriteLine("Succesful delete, please refresh the page." + Environment.NewLine);
                    break;
                case 2:
                    rest.Delete(id, "video");
                    Console.WriteLine("Succesful delete, please refresh the page."+Environment.NewLine);
                    break;
                case 3:
                    rest.Delete(id, "comment");
                    Console.WriteLine("Succesful delete, please refresh the page."+Environment.NewLine);
                    break;
                default:
                    break;
            }
        }

        //NON-CRUDS (These can't get values but they work in unit tests tho)

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

            var result = rest.Get<Comment>($"/stat/first3mostlikedcommentfromvideo/{id}");
            result.ForEach(x => Console.WriteLine(x));
        }
        static void MOSTWATCHEDPERYOUTUBERS()
        {
            var result = rest.Get<Video>($"/stat/getmostwatchedvideoperyoutubers");
            ;
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

            var result = rest.Get<Comment>($"/stat/allnegcommsfromytber/{id}");
            ;
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

            var result = rest.Get<Video>($"/stat/videoswithmorethan30kviewsfromyoutuber/{id}");
            ;
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

            var result = rest.Get<Video>($"/stat/getvideoswithcommentsfromyoutuber/{id}");
            ;
        }
        static void MOSTLIKEDCOMMENTSPERVIDEOS()
        {
            foreach (var vid in rest.Get<Comment>($"/stat/getmostlikescommentsfromvideos"))
            {
                Console.WriteLine($"\tVideoID: {vid.VideoID}, Title: {vid.Title}, Views: {vid.ViewCount}");
                foreach (var com in vid.Comments)
                {
                    Console.WriteLine($"\t\tCommentID: {com.CommentID}, Username: {com.Username}, Content: {com.Content}, Likes: {com.Likes}");
                }
            }
        }
    }
}
