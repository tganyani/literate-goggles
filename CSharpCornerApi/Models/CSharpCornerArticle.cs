// Models/CSharpCornerArticle.cs

using System;

namespace CSharpCornerApi.Models
{
    public class CSharpCornerArticle
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}