using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class EventsDbContext : DbContext
    {
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventType> EventTypes { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public EventsDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>().Property(i => i.Title)
                                        .HasMaxLength(200)
                                        .IsRequired(false);

            modelBuilder.Entity<Image>().Property(i => i.Path)
                                        .IsRequired(true);

            OnUserCreating(modelBuilder);
            OnCommentCreating(modelBuilder);
            OnEventCreating(modelBuilder);

            modelBuilder.Entity<EventType>().Property(et => et.Name)
                                            .HasMaxLength(100)
                                            .IsRequired(true);
        }
        private void OnUserCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u => u.Name)
                                       .HasMaxLength(100)
                                       .IsRequired(true);

            modelBuilder.Entity<User>().Property(u => u.Email)
                                       .HasMaxLength(200)
                                       .IsRequired(true);

            modelBuilder.Entity<User>().Property(u => u.Password)
                                       .HasMaxLength(50)
                                       .IsRequired(true);

            modelBuilder.Entity<User>().Property(u => u.CreationTime)
                                       .IsRequired(true);

            modelBuilder.Entity<User>().HasOne(u => u.Avatar)
                                       .WithOne(i => i.User)
                                       .HasForeignKey<Image>(i => i.UserId)
                                       .IsRequired(false);


            modelBuilder.Entity<User>().HasMany(u => u.CreatedComments)
                                       .WithOne(c => c.Owner);

            modelBuilder.Entity<User>().HasMany(u => u.LikedComments)
                                       .WithMany(c => c.LikeUsers);

            modelBuilder.Entity<User>().HasMany(u => u.DislikedComments)
                                       .WithMany(c => c.DislikeUsers);


            modelBuilder.Entity<User>().HasMany(u => u.CreatedEvents)
                                       .WithOne(e => e.Owner);

            modelBuilder.Entity<User>().HasMany(u => u.LikedEvents)
                                       .WithMany(e => e.LikedUsers);

            modelBuilder.Entity<User>().HasMany(u => u.FavoriteEvents)
                                       .WithMany(e => e.FavoriteUsers);
        }

        private void OnCommentCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().Property(u => u.Text)
                                          .HasMaxLength(1000)
                                          .IsRequired(true);

            modelBuilder.Entity<Comment>().Property(u => u.CreationTime)
                                          .IsRequired(true);

            modelBuilder.Entity<Comment>().Property(u => u.IsChanged)
                                          .IsRequired(true);

            modelBuilder.Entity<Comment>().Property(u => u.CreationTime)
                                          .IsRequired(true);

            modelBuilder.Entity<Comment>().HasOne(c => c.Parent)
                                          .WithMany(c => c.SubComments)
                                          .HasForeignKey(c => c.ParentId)
                                          .IsRequired(false)
                                          .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<Comment>().Property(c => c.Likes)
                                          .IsRequired(true);

            modelBuilder.Entity<Comment>().Property(c => c.Dislikes)
                                          .IsRequired(true);
        }

        private void OnEventCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().Property(e => e.Title)
                                        .HasMaxLength(200)
                                        .IsRequired(true);

            modelBuilder.Entity<Event>().Property(e => e.Text)
                                        .HasMaxLength(3000)
                                        .IsRequired(true);

            modelBuilder.Entity<Event>().Property(e => e.CreationTime)
                                        .IsRequired(true);

            modelBuilder.Entity<Event>().Property(e => e.EventTime)
                                        .IsRequired(true);

            modelBuilder.Entity<Event>().HasMany(e => e.Types)
                                        .WithMany(et => et.Events);

            modelBuilder.Entity<Event>().Property(e => e.Price)
                                        .IsRequired(true);

            modelBuilder.Entity<Event>().HasMany(e => e.Images)
                                        .WithOne(i => i.Event)
                                        .IsRequired(false);
        }
    }
}
