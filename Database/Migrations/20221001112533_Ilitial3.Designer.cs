﻿// <auto-generated />
using System;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Database.Migrations
{
    [DbContext(typeof(EventsDbContext))]
    [Migration("20221001112533_Ilitial3")]
    partial class Ilitial3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CommentUser", b =>
                {
                    b.Property<int>("LikedCommentsId")
                        .HasColumnType("int");

                    b.Property<int>("LikedUsersId")
                        .HasColumnType("int");

                    b.HasKey("LikedCommentsId", "LikedUsersId");

                    b.HasIndex("LikedUsersId");

                    b.ToTable("CommentUser");
                });

            modelBuilder.Entity("CommentUser1", b =>
                {
                    b.Property<int>("DislikedCommentsId")
                        .HasColumnType("int");

                    b.Property<int>("DislikedUsersId")
                        .HasColumnType("int");

                    b.HasKey("DislikedCommentsId", "DislikedUsersId");

                    b.HasIndex("DislikedUsersId");

                    b.ToTable("CommentUser1");
                });

            modelBuilder.Entity("Database.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Dislikes")
                        .HasColumnType("int");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<bool>("IsChanged")
                        .HasColumnType("bit");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int?>("PlaceId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ParentId");

                    b.HasIndex("PlaceId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Database.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EventTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Facebook")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Instagram")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsModerated")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOnline")
                        .HasColumnType("bit");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int?>("PlaceId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Site")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("PlaceId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Database.Models.EventType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("EventTypes");
                });

            modelBuilder.Entity("Database.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlaceId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("PlaceId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Database.Models.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Facebook")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("GoogleMaps")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Instagram")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Route")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Site")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("Database.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EventEventType", b =>
                {
                    b.Property<int>("EventsId")
                        .HasColumnType("int");

                    b.Property<int>("TypesId")
                        .HasColumnType("int");

                    b.HasKey("EventsId", "TypesId");

                    b.HasIndex("TypesId");

                    b.ToTable("EventEventType");
                });

            modelBuilder.Entity("EventTypePlace", b =>
                {
                    b.Property<int>("PlaceTypesId")
                        .HasColumnType("int");

                    b.Property<int>("PlacesId")
                        .HasColumnType("int");

                    b.HasKey("PlaceTypesId", "PlacesId");

                    b.HasIndex("PlacesId");

                    b.ToTable("EventTypePlace");
                });

            modelBuilder.Entity("EventUser", b =>
                {
                    b.Property<int>("LikedEventsId")
                        .HasColumnType("int");

                    b.Property<int>("LikedUsersId")
                        .HasColumnType("int");

                    b.HasKey("LikedEventsId", "LikedUsersId");

                    b.HasIndex("LikedUsersId");

                    b.ToTable("EventUser");
                });

            modelBuilder.Entity("EventUser1", b =>
                {
                    b.Property<int>("FavoriteEventsId")
                        .HasColumnType("int");

                    b.Property<int>("FavoriteUsersId")
                        .HasColumnType("int");

                    b.HasKey("FavoriteEventsId", "FavoriteUsersId");

                    b.HasIndex("FavoriteUsersId");

                    b.ToTable("EventUser1");
                });

            modelBuilder.Entity("PlaceUser", b =>
                {
                    b.Property<int>("LikedPlacesId")
                        .HasColumnType("int");

                    b.Property<int>("LikedUsersId")
                        .HasColumnType("int");

                    b.HasKey("LikedPlacesId", "LikedUsersId");

                    b.HasIndex("LikedUsersId");

                    b.ToTable("PlaceUser");
                });

            modelBuilder.Entity("PlaceUser1", b =>
                {
                    b.Property<int>("FavoritePlacesId")
                        .HasColumnType("int");

                    b.Property<int>("FavoriteUsersId")
                        .HasColumnType("int");

                    b.HasKey("FavoritePlacesId", "FavoriteUsersId");

                    b.HasIndex("FavoriteUsersId");

                    b.ToTable("PlaceUser1");
                });

            modelBuilder.Entity("CommentUser", b =>
                {
                    b.HasOne("Database.Models.Comment", null)
                        .WithMany()
                        .HasForeignKey("LikedCommentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Models.User", null)
                        .WithMany()
                        .HasForeignKey("LikedUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CommentUser1", b =>
                {
                    b.HasOne("Database.Models.Comment", null)
                        .WithMany()
                        .HasForeignKey("DislikedCommentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Models.User", null)
                        .WithMany()
                        .HasForeignKey("DislikedUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Models.Comment", b =>
                {
                    b.HasOne("Database.Models.Event", "Event")
                        .WithMany("Comments")
                        .HasForeignKey("EventId");

                    b.HasOne("Database.Models.User", "Owner")
                        .WithMany("CreatedComments")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Models.Comment", "Parent")
                        .WithMany("SubComments")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Database.Models.Place", "Place")
                        .WithMany("Comments")
                        .HasForeignKey("PlaceId");

                    b.Navigation("Event");

                    b.Navigation("Owner");

                    b.Navigation("Parent");

                    b.Navigation("Place");
                });

            modelBuilder.Entity("Database.Models.Event", b =>
                {
                    b.HasOne("Database.Models.User", "Owner")
                        .WithMany("CreatedEvents")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Models.Place", "Place")
                        .WithMany("Events")
                        .HasForeignKey("PlaceId");

                    b.Navigation("Owner");

                    b.Navigation("Place");
                });

            modelBuilder.Entity("Database.Models.EventType", b =>
                {
                    b.HasOne("Database.Models.EventType", "Parent")
                        .WithMany("SubEventTypes")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Database.Models.Image", b =>
                {
                    b.HasOne("Database.Models.Event", "Event")
                        .WithMany("Images")
                        .HasForeignKey("EventId");

                    b.HasOne("Database.Models.Place", "Place")
                        .WithMany("Images")
                        .HasForeignKey("PlaceId");

                    b.HasOne("Database.Models.User", "User")
                        .WithOne("Avatar")
                        .HasForeignKey("Database.Models.Image", "UserId");

                    b.Navigation("Event");

                    b.Navigation("Place");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Database.Models.Place", b =>
                {
                    b.HasOne("Database.Models.User", "Owner")
                        .WithMany("CreatedPlaces")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("EventEventType", b =>
                {
                    b.HasOne("Database.Models.Event", null)
                        .WithMany()
                        .HasForeignKey("EventsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Models.EventType", null)
                        .WithMany()
                        .HasForeignKey("TypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EventTypePlace", b =>
                {
                    b.HasOne("Database.Models.EventType", null)
                        .WithMany()
                        .HasForeignKey("PlaceTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Models.Place", null)
                        .WithMany()
                        .HasForeignKey("PlacesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EventUser", b =>
                {
                    b.HasOne("Database.Models.Event", null)
                        .WithMany()
                        .HasForeignKey("LikedEventsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Models.User", null)
                        .WithMany()
                        .HasForeignKey("LikedUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EventUser1", b =>
                {
                    b.HasOne("Database.Models.Event", null)
                        .WithMany()
                        .HasForeignKey("FavoriteEventsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Models.User", null)
                        .WithMany()
                        .HasForeignKey("FavoriteUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlaceUser", b =>
                {
                    b.HasOne("Database.Models.Place", null)
                        .WithMany()
                        .HasForeignKey("LikedPlacesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Models.User", null)
                        .WithMany()
                        .HasForeignKey("LikedUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlaceUser1", b =>
                {
                    b.HasOne("Database.Models.Place", null)
                        .WithMany()
                        .HasForeignKey("FavoritePlacesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Models.User", null)
                        .WithMany()
                        .HasForeignKey("FavoriteUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Models.Comment", b =>
                {
                    b.Navigation("SubComments");
                });

            modelBuilder.Entity("Database.Models.Event", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("Database.Models.EventType", b =>
                {
                    b.Navigation("SubEventTypes");
                });

            modelBuilder.Entity("Database.Models.Place", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Events");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("Database.Models.User", b =>
                {
                    b.Navigation("Avatar");

                    b.Navigation("CreatedComments");

                    b.Navigation("CreatedEvents");

                    b.Navigation("CreatedPlaces");
                });
#pragma warning restore 612, 618
        }
    }
}
