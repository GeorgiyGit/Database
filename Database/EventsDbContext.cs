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
        public virtual DbSet<Models.Genre> Genres { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Place> Places { get; set; }
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
            OnEventTypeCreating(modelBuilder);
            OnPlaceCreating(modelBuilder);
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
                                       .WithMany(c => c.LikedUsers);

            modelBuilder.Entity<User>().HasMany(u => u.DislikedComments)
                                       .WithMany(c => c.DislikedUsers);


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


            modelBuilder.Entity<Comment>().HasOne(c => c.Place)
                                          .WithMany(p => p.Comments)
                                          .IsRequired(false);

            modelBuilder.Entity<Comment>().HasOne(c => c.Event)
                                          .WithMany(e=>e.Comments)
                                          .IsRequired(false);

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

            modelBuilder.Entity<Event>().Property(e => e.Rating)
                                        .IsRequired(true)
                                        .HasDefaultValue(1);

            modelBuilder.Entity<Event>().Property(e => e.IsOnline)
                                        .IsRequired(true);

            modelBuilder.Entity<Event>().Property(e => e.IsModerated)
                                        .IsRequired(true);

            modelBuilder.Entity<Event>().Property(e => e.Site)
                                        .HasMaxLength(500)
                                        .IsRequired(false);

            modelBuilder.Entity<Event>().HasOne(e => e.Place)
                                        .WithMany(p => p.Events)
                                        .HasForeignKey(e=>e.PlaceId)
                                        .IsRequired(false);

            modelBuilder.Entity<Event>().Property(e => e.Facebook)
                                        .HasMaxLength(200)
                                        .IsRequired(false);

            modelBuilder.Entity<Event>().Property(e => e.Instagram)
                                        .HasMaxLength(200)
                                        .IsRequired(false);

            modelBuilder.Entity<Event>().Property(e => e.Rating)
                                        .HasDefaultValue(1)
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
                                        .IsRequired(false)
                                        .OnDelete(DeleteBehavior.Cascade);
        }

        private void OnEventTypeCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Genre>().Property(et => et.Name)
                                            .HasMaxLength(100)
                                            .IsRequired(true);

            modelBuilder.Entity<Models.Genre>().HasOne(c => c.Parent)
                                            .WithMany(c => c.SubEventTypes)
                                            .HasForeignKey(c => c.ParentId)
                                            .IsRequired(false)
                                            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Models.Genre>().HasMany(et => et.Places)
                                            .WithMany(p => p.PlaceTypes);
        }

        private void OnPlaceCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Place>().Property(p => p.Name)
                                        .HasMaxLength(100)
                                        .IsRequired(true);

            modelBuilder.Entity<Place>().Property(p => p.Rating)
                                        .IsRequired(true)
                                        .HasDefaultValue(1);

            modelBuilder.Entity<Place>().Property(p => p.Text)
                                        .HasMaxLength(3000)
                                        .IsRequired(true);

            modelBuilder.Entity<Place>().Property(p => p.Route)
                                        .HasMaxLength(200)
                                        .IsRequired(true);

            modelBuilder.Entity<Place>().Property(p => p.Site)
                                        .HasMaxLength(500)
                                        .IsRequired(false);

            modelBuilder.Entity<Place>().Property(p => p.Facebook)
                                        .HasMaxLength(500)
                                        .IsRequired(false);

            modelBuilder.Entity<Place>().Property(p => p.Instagram)
                                        .HasMaxLength(500)
                                        .IsRequired(false);

            modelBuilder.Entity<Place>().Property(p => p.GoogleMaps)
                                        .HasMaxLength(500)
                                        .IsRequired(true);

            modelBuilder.Entity<Place>().HasOne(p => p.Owner)
                                        .WithMany(u => u.CreatedPlaces)
                                        .IsRequired(true);

            modelBuilder.Entity<Place>().HasMany(p => p.LikedUsers)
                                        .WithMany(u => u.LikedPlaces);

            modelBuilder.Entity<Place>().HasMany(p => p.FavoriteUsers)
                                        .WithMany(u => u.FavoritePlaces);

            modelBuilder.Entity<Place>().HasMany(p => p.Images)
                                        .WithOne(i => i.Place)
                                        .IsRequired(false);
                                        
        }
    }
}
