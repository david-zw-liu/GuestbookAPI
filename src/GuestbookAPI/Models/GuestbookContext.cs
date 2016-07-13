using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace GuestbookAPI.Models
{
    public class GuestbookContext : DbContext
    {
        public GuestbookContext(DbContextOptions<GuestbookContext> options)
            : base(options)
        { }

        public DbSet<Comment> Comments { get; set; }
    }
}
