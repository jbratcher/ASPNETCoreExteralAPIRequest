using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ASPNETCoreExternalAPIRequest.Models;

namespace ASPNETCoreExternalAPIRequest.Data
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Photo> Photos { get; set; }
    }
}
