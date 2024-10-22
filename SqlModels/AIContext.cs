using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AI_Updater.SqlModels;

public partial class AIContext : DbContext
{
    public AIContext()
    {
    }

    public AIContext(DbContextOptions<AIContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC2772EAF28E");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
