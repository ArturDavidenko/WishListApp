using Microsoft.EntityFrameworkCore;
using WishListApp.Models;

namespace WishListApp.Data
{
    public class WLContext : DbContext
    {
        public DbSet<WishItem> wishItems { get; set; }
        public WLContext(DbContextOptions<WLContext> options) : base(options) { }

    }
}
