﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace InterCommunicationSystem.Models
{
    public partial class InterCommContext : DbContext
    {
        public InterCommContext()
        {
        }

        public InterCommContext(DbContextOptions<InterCommContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupInvitesRequest> GroupInvitesRequests { get; set; }
        public virtual DbSet<GroupMember> GroupMembers { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<UserProfiles> UserProfiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=InterComm;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.CommentId).ValueGeneratedNever();

                entity.HasOne(d => d.CommentedByNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CommentedBy)
                    .HasConstraintName("FK_Comments_Commented_By");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_Comments_PostID");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.GroupName).IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Groups_Created_By");
            });

            modelBuilder.Entity<GroupInvitesRequest>(entity =>
            {
                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.GroupInvitesRequestCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_Group_Invites_Requests_Created_by");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupInvitesRequests)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Group_Invites_Requests_GroupID");

                entity.HasOne(d => d.SentToNavigation)
                    .WithMany(p => p.GroupInvitesRequestSentToNavigations)
                    .HasForeignKey(d => d.SentTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Group_Invites_Requests_Sent_to");
            });

            modelBuilder.Entity<GroupMember>(entity =>
            {
                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupMembers)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Group_Members_GroupID");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.GroupMembers)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Group_Members_MemberID");
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.HasOne(d => d.Post)
                    .WithMany()
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_Likes_PostID");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Likes_UserId");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.PostType)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.PostedByNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.PostedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Posts_PostedBy");

                entity.HasOne(d => d.PostedOnNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.PostedOn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Posts_Posted_On");
            });

            modelBuilder.Entity<UserProfiles>(entity =>
            {
                entity.Property(e => e.AddressLine1).IsUnicode(false);

                entity.Property(e => e.AddressLine2).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Contact).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PermanentCity).IsUnicode(false);

                entity.Property(e => e.PermanentState).IsUnicode(false);

                entity.Property(e => e.State).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
