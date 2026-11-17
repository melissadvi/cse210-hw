using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();
        Video v1 = new Video ("Making a Grandmother's recepit", "lovehobbies",600);
        v1.AddComment(new Comment ("Charles", "Great idea, I want to do too!"));
        v1.AddComment(new Comment ("Mary", "I loved this video! It's so creative!!"));
        v1.AddComment(new Comment ("John", "In my family my grandfather is who cooking LOL"));
        v1.AddComment(new Comment ("Ashley", "I loved so much this, I will tell to my grandmother and cooking with her"));
        videos.Add(v1);

        Video v2 = new Video("Learning to Knit with My Grandmother", "lovehobbies", 540);
        v2.AddComment(new Comment("Daniel", "This reminds me of my childhood, so nostalgic!"));
        v2.AddComment(new Comment("Sophia", "Can you make a video about knitting a scarf?"));
        v2.AddComment(new Comment("Michael", "Your grandmother is adorable, she has so much patience!"));
        v2.AddComment(new Comment("Emily", "I tried it today and my first row is a mess, haha"));
        videos.Add(v2);

        Video v3 = new Video("Planting a Family Garden: Easy Tips for Beginners", "lovehobbies", 720);
        v3.AddComment(new Comment("Lucas", "I never knew basil was so easy to grow!"));
        v3.AddComment(new Comment("Olivia", "Great tips, I'm starting my garden this weekend."));
        v3.AddComment(new Comment("Henry", "Where did you buy those flower pots? They're beautiful!"));
        v3.AddComment(new Comment("Grace", "This channel makes me want to try every hobby!"));
        videos.Add(v3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Time: {video._lengthSeconds}");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" - {comment._name}: {comment._text}");
            }
            
            Console.WriteLine();
        }
    }

}