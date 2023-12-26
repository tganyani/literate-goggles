// Data/AppDbContext.cs

using Microsoft.EntityFrameworkCore;
using CSharpCornerApi.Models;

namespace CSharpCornerApi.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CSharpCornerArticle> Articles { get; set; }
    }
}