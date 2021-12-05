using ConsoleTools;
using G1WRGM_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace G1WRGM_HFT_2021221.Client
{
    //TODO: DELETE ALL THE UNNEEDED DEPENDENCIES! (Only Model can remain) (DONE)
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
                Console.WriteLine();
                Console.WriteLine("Hello there in my probably Spar budget App! :))");
                Console.WriteLine("These are your options for today, dear user:");
                Console.WriteLine("\t1: POST (C)"); //C
                Console.WriteLine("\t2: GETALL (R)"); //R
                Console.WriteLine("\t3: GET (R)"); //R
                Console.WriteLine("\t4: PUT (U)"); //U
                Console.WriteLine("\t5: DELETE (D)"); //D
                Console.WriteLine("----------------");
                Console.WriteLine("\t6: First3MostLikedCommentFromVideo");
                Console.WriteLine("\t7: GetMostWatchedVideoPerYoutubers");
                Console.WriteLine("\t8: GetVideosWithCommentsFromYoutuber");
                Console.WriteLine("\t9: VideosWithMoreThan30KViewsFromYoutuber");
                Console.WriteLine("\t10: AllNegCommsFromYTber");
                Console.WriteLine("\t11: GetMostLikesCommentsFromVideos");
                Console.WriteLine("----------------");
                Console.WriteLine("\t12: CommentsWithMorethanXLikesAndXContent");

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
                case 12:
                    COMMENTMORETHANXLIKEANDXCONTENT(); break;
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
        static void GET()
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
                    try
                    {
                        var gs = rest.GetSingle<YTContentCreator>($"ytcontentcreator/{id}");
                        Console.WriteLine($"CreatorID: {gs.CreatorID}, CreatorName: {gs.CreatorName}, Subscribers: {gs.SubscriberCount}, Creation: {gs.Creation}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    
                    break;
                case 2:
                    try
                    {
                        var gs = rest.GetSingle<Video>($"video/{id}");
                        Console.WriteLine($"\tVideoID: {gs.VideoID}, Title: {gs.Title}, Views: {gs.ViewCount}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    
                    break;
                case 3:
                    try
                    {
                        var gs = rest.GetSingle<Comment>($"comment/{id}");
                        Console.WriteLine($"\t\tCommentID: {gs.CommentID}, Username: {gs.Username}, Content: {gs.Content}, Likes: {gs.Likes}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
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
                    Console.Write("CreatorID: "); ytcc.CreatorID = Convert.ToInt32(Console.ReadLine());
                    ytcc.Videos = new List<Video>();
                    Console.WriteLine();

                    rest.Put(ytcc, "ytcontentcreator");
                    Console.WriteLine("Succesful put/update, please refresh the page." + Environment.NewLine);
                    break;
                case 2:
                    Video video = new Video();
                    Console.Write("Title: "); video.Title = Console.ReadLine();
                    Console.Write("Views: "); video.ViewCount = Convert.ToInt32(Console.ReadLine());
                    Console.Write("VideoID: ");
                    video.VideoID = Convert.ToInt32(Console.ReadLine());
                    video.Comments = new List<Comment>();
                    Console.WriteLine();

                    rest.Put(video, "video");
                    Console.WriteLine("Succesful put/update, please refresh the page." + Environment.NewLine);
                    break;
                case 3:
                    Comment comment = new Comment();
                    Console.Write("Username: "); comment.Username = Console.ReadLine();
                    Console.Write("Content: "); comment.Content = Console.ReadLine();
                    Console.Write("CommentID: ");
                    comment.CommentID = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Likes: "); comment.Likes = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    rest.Put(comment, "comment");
                    Console.WriteLine("Succesful put/update, please refresh the page." + Environment.NewLine);
                    break;
                default:
                    break;
            }
        }
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

            var result = rest.Get<Comment>($"/stat/first3mostlikedcommentfromvideo/{id}");
            result.ForEach(x => Console.WriteLine($"\t\tCommentID: {x.CommentID}, Username: {x.Username}, Content: {x.Content}, Likes: {x.Likes}"));
        }
        static void MOSTWATCHEDPERYOUTUBERS()
        {
            foreach (var vid in rest.Get<KeyValuePair<string, Video>>($"/stat/getmostwatchedvideoperyoutubers"))
            {
                Console.WriteLine($"\tCreatorName: {vid.Key}");
                if (vid.Value != null)
                {
                    Console.WriteLine($"\t\tVideoID: {vid.Value.VideoID}, Title: {vid.Value.Title}, Views: {vid.Value.ViewCount}");
                }
                else
                {
                    Console.WriteLine("\t\tNo videos here, just go ahead.");
                }
            }
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

            foreach (var com in rest.Get<Comment>($"/stat/allnegcommsfromytber/{id}"))
            {
                Console.WriteLine($"\t\tCommentID: {com.CommentID}, Username: {com.Username}, Content: {com.Content}, Likes: {com.Likes}");
            }
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

            foreach (var vid in rest.Get<Video>($"/stat/videoswithmorethan30kviewsfromyoutuber/{id}"))
            {
                Console.WriteLine($"\tVideoID: {vid.VideoID}, Title: {vid.Title}, Views: {vid.ViewCount}");
            }
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

            foreach (var vid in rest.Get<Video>($"/stat/getvideoswithcommentsfromyoutuber/{id}"))
            {
                Console.WriteLine($"VideoID: {vid.VideoID}, Title: {vid.Title}, Views: {vid.ViewCount}");
            }
        }
        static void MOSTLIKEDCOMMENTSPERVIDEOS()
        {
            foreach (var com in rest.Get<KeyValuePair<string, Comment>>($"/stat/getmostlikescommentsfromvideos"))
            {
                Console.WriteLine($"\tTitle: {com.Key}");
                if (com.Value != null)
                {
                    Console.WriteLine($"\t\tCommentID: {com.Value.CommentID}, Username: {com.Value.Username}, Content: {com.Value.Content}, Likes: {com.Value.Likes}");
                }
                else
                {
                    Console.WriteLine("\t\tNo comments here, just go ahead.");
                }
            }
        }
        
        static void COMMENTMORETHANXLIKEANDXCONTENT()
        {
            int likeX = default;
            int contentX = default;
            while (likeX == default(int) && contentX == default(int))
            {
                try
                {
                    Console.Write("Choose amount of likes: ");
                    likeX = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write("Choose length of content: ");
                    contentX = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please try this again:");
                }
            }

            var result = rest.Get<Comment>($"/stat/commorexlikexcontent/{likeX}/{contentX}");

            result.ForEach(x => Console.WriteLine($"\tUsername: {x.Username}, Content: {x.Content}, Likes: {x.Likes}"));
        }
    }
}
