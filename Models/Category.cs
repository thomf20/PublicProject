using Azure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PublicProject.Models
{
    //    public class Category
    //    {
    //        public int Id { get; set; }
    //        public int Name { get; set; }
    //        public List<SubCategory>? SubCategories { get; set; }
    //    }

    //    public class SubCategory
    //    {
    //        public int Id { get; set; }
    //        public int Name { get; set; }
    //        public List<Blog>? Blogs { get; set; }
    //    }

    //    public class Blog
    //    {
    //        public int Id { get; set; }
    //        public string Title { get; set; }
    //        public string Text { get; set; }
    //        public string Image { get; set; }
    //        public DateTime Date { get; set; }
    //        public string UserId { get; set; }
    //        public int? Popularity { get; set; } 
    //        public string? Facebook { get; set; }
    //        public string? Instagram { get; set; }
    //        public string? YouTube { get; set; }
    //        public string? Twitter { get; set; }
    //        //public int Style { get; set; }
    //        public List <Comment>? Comments { get; set; }
    //    }

    //    public class Comment
    //    {
    //        public string Id { get; set; }
    //        public string Author { get; set; }
    //        public string Text { get; set; }
    //        public string? Image { get; set; }
    //        public DateTime Date { get; set; }
    //    }
    //}

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }

    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Blog> Blogs { get; set; }
    }

    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public int? Popularity { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string YouTube { get; set; }
        public string Twitter { get; set; }
        public List<Comment> Comments { get; set; }
    }

    public class Comment
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}