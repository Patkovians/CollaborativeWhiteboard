using CollaborativeWhiteboard.DataInfrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CollaborativeWhiteboard.DataInfrastructure.DataContext;

public class WhiteboardDbContext : DbContext
{
    public WhiteboardDbContext(DbContextOptions<WhiteboardDbContext> options) : base(options) { }

    public DbSet<WhiteboardEntity> Whiteboards { get; set; }

    // If you need any specific configurations for your entity:
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WhiteboardEntity>().Property(w => w.BackgroundColor).HasDefaultValue("FFFFFF");
        // Add more configurations if needed.
    }
}