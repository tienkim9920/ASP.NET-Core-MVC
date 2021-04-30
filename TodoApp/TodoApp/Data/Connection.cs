using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Data
{
    public class Connection : DbContext
    {
        public Connection(DbContextOptions<Connection> options)
            : base(options)
        {
        }

        public DbSet<USER> USER { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<USER>(eb => {
                    eb.ToTable("USER");
                });

        }

    }
}
