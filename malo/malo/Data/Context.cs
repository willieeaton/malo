using System;
using System.Collections.Generic;
using System.Text;
using malo.Models;
using Microsoft.EntityFrameworkCore;

namespace malo.Data
{
    public class Context : DbContext
    {

        public DbSet<Iwad> Iwads { get; set; }
        public DbSet<Pwad> Pwads { get; set; }
        public DbSet<SourcePort> SourcePorts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureDeleted(); // DROPS DATABASE!
            // make sure the above isn't here once we're done using test data
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Iwad>().ToTable("Iwads");
            //modelBuilder.Entity<Pwad>().ToTable("Pwads");
            //modelBuilder.Entity<SourcePort>().ToTable("SourcePorts");
            //modelBuilder.Entity<Tag>().ToTable("Tags");
            modelBuilder.Entity<PwadTag>()
                .HasKey(pt => new { pt.PwadId, pt.TagId });
            modelBuilder.Entity<PwadTag>()
                .HasOne(pt => pt.Pwad)
                .WithMany(p => p.PwadTags)
                .HasForeignKey(pt => pt.PwadId);
            modelBuilder.Entity<PwadTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.PwadTags)
                .HasForeignKey(pt => pt.TagId);
            //modelBuilder.Entity<PwadTag>().ToTable("PwadTags");

            //note to self: commented-out code was stuff i was
            //trying while I couldn't get the Sqlite db to 
            //connect.  
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
        }
    }
}
