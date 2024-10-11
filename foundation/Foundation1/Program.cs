// This program only demonstrates the principle of abstraction
// (Encapsulation excluded) based on the project requirements

using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store the videos
        List<Video> videos = new List<Video>();

        // Create and add videos with comments.
        Video video1 = new Video("Introduction to C#", "John Doe", 300);
        video1.AddComment(new Comment("Alice", "Great introduction!"));
        video1.AddComment(new Comment("Bob", "Very informative."));
        video1.AddComment(new Comment("Charlie", "Helped me a lot, thanks!"));
        videos.Add(video1);

        Video video2 = new Video("Advanced C# Techniques", "Jane Smith", 500);
        video2.AddComment(new Comment("Dave", "Loved the advanced tips."));
        video2.AddComment(new Comment("Eve", "A bit too complex for me."));
        video2.AddComment(new Comment("Frank", "Very well explained."));
        video2.AddComment(new Comment("Victor", "I'm falling in love with c# already."));
        videos.Add(video2);

        Video video3 = new Video("C# for Beginners", "Tom Brown", 400);
        video3.AddComment(new Comment("Grace", "Perfect for beginners."));
        video3.AddComment(new Comment("Hank", "This made learning so easy!"));
        video3.AddComment(new Comment("Ivy", "Loved the examples provided."));
        videos.Add(video3);

        // Iterate over videos list and display each video
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            // Iterate over comments list and display each comment
            foreach (Comment comment in video._comments)
            {
                Console.WriteLine($"\t{comment._commenter}: {comment._text}");
            }
            Console.WriteLine();
        }
    }
}