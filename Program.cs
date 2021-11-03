using System;
using System.Linq;
using Day10Class.Models;

namespace Day10Class
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Do you want to\n1.)Display Blogs \n2.)Add Blog\n3.)Display Posts\n4.)Add Post\n5.)Exit");
            int option = 0;
            try{
                option = Int32.Parse(Console.ReadLine());
            }
            catch(Exception){
                System.Console.WriteLine("Sorry not a number");
            }

            while(option != 5){
                switch (option){
                case 1:
                    //read blogs from database
                    using(var db = new BlogContext()){
                        System.Console.WriteLine("Here is the list of blogs");
                        foreach(var b in db.Blogs)
                        {
                            System.Console.WriteLine($"Blog #{b.BlogId}: {b.Name}");
                        }
                    }
                    break;
                case 2:
                    //Add Blog
                    //get the blog information
                    System.Console.WriteLine("What is the Blog Name?");
                    string blogName = Console.ReadLine();
                    //create the blog object
                    Blog blog = new Blog();
                    blog.Name = blogName;
                    //Save blog object to database
                    using (var db = new BlogContext())
                    {
                        try{
                        db.Add(blog);
                        db.SaveChanges();
                        }
                        catch(Exception){
                            System.Console.WriteLine("Sorry could not add your post to the Database");
                        }
                    }
                    break;
                case 3:
                    //Read Posts
                    using(var db = new BlogContext()){

                        System.Console.WriteLine("Here is the list of blogs");
                        foreach(var b in db.Blogs)
                        {
                            System.Console.WriteLine($"Blog #{b.BlogId}: {b.Name}");
                        }
                        System.Console.WriteLine("What Blogs Posts do you want to see?(Enter Number)");
                        int pickedBlog = Int32.Parse(Console.ReadLine());
                        var posts = db.Posts.Where(c => c.BlogId == pickedBlog);
                        System.Console.WriteLine($"Showing blog{pickedBlog}");
                        foreach(var x in posts){
                            System.Console.WriteLine($"Post #{x.PostId}\nBlogID:{x.BlogId}\nContent:{x.Content}\n");
                        }
                    }
                    break;
                case 4:
                    //Make Post
                    System.Console.WriteLine("Enter your post title");
                    var postTitle = Console.ReadLine();
                    var post = new Post();
                    post.Title = postTitle;
                    
                    using(var db = new BlogContext()){
                        foreach(var b in db.Blogs){
                            System.Console.WriteLine($"Blog #{b.BlogId}: {b.Name}");
                        }
                    }
                    System.Console.WriteLine("What blog do you want to add the Post to?");
                    int pickedPostBlog = Int32.Parse(Console.ReadLine());
                    post.BlogId = pickedPostBlog;
                    System.Console.WriteLine("What is in the post?(content)");
                    string content = Console.ReadLine();
                    post.Content = content;
                    //add post
                    using(var db = new BlogContext())
                    {
                        try{
                        db.Add(post);
                        db.SaveChanges();
                        }
                        catch(Exception){
                            System.Console.WriteLine("Sorry could not add your post to the Database");
                        }
                    }
                    break;
                    
                    
                }
                System.Console.WriteLine("Do you want to\n1.)Display Blogs \n2.)Add Blog\n3.)Display Posts\n4.)Add Post\n5.)Exit");
                option = Int32.Parse(Console.ReadLine());
            }







            // using(var db = new BlogContext()){
            //     var blog = db.Blogs.Where(x => x.BlogId == 1).FirstOrDefault();
            //     System.Console.WriteLine($"Posts for blog {blog.Name}");

                
            //     foreach(var post in blog.Post){
            //         System.Console.WriteLine(post);
            //     }



            // }
            
            // //add post to database
            // // System.Console.WriteLine("Enter your post name");
            // // var postTitle = Console.ReadLine();

            // // var post = new Post();
            // // post.Title = postTitle;
            // // post.BlogId = 1;

            // // using(var db = new BlogContext())
            // // {
            // //     db.Posts.Add(post);
            // //     db.SaveChanges();
            // // }

            // //read blogs from database
            // // using(var db = new BlogContext()){
            // //     System.Console.WriteLine("Here is the list of blogs");
            // //     foreach(var b in db.Blogs){
            // //         System.Console.WriteLine($"Blog: {b.BlogId}: {b.Name}");
            // //     }
            // // }



            // //Add blog to Database
            // // Console.WriteLine("Enter your Blog name");
            // // var blogName = Console.ReadLine();

            // // //Create new Blog
            // // var blog = new Blog();
            // // blog.Name = blogName;

            // // //Save blog object to database
            // // using (var db = new BlogContext())
            // // {
            // // db.Add(blog);
            // // db.SaveChanges();
            
            // // db.Dispose();
            // // }
        }
    }
}
