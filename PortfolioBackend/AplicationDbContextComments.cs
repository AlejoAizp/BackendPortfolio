using Microsoft.EntityFrameworkCore;
using PortfolioBackend.Models;

namespace PortfolioBackend
{
    public class AplicationDbContextComments : DbContext
    {
        public DbSet<Comments> Comments { get; set; }

        public AplicationDbContextComments(DbContextOptions<AplicationDbContextComments> options) : base(options)
        {

        }

    }

}