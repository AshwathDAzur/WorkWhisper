using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NewWorkWhisperAPI.Models;

public partial class NewWorkWhisperContext : DbContext
{
    public NewWorkWhisperContext()
    {
    }

    public NewWorkWhisperContext(DbContextOptions<NewWorkWhisperContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<FeedBack> FeedBacks { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Like> Likes { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<Squad> Squads { get; set; }

    public virtual DbSet<SquadImage> SquadImages { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserSquad> UserSquads { get; set; }

    public virtual DbSet<Whisper> Whispers { get; set; }

    public virtual DbSet<WhisperTopic> WhisperTopics { get; set; }

    public virtual DbSet<WhisperType> WhisperTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PSILENL154;Database=NewWorkWhisper;Trusted_Connection=true;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("Comment_pk");

            entity.ToTable("Comment");

            entity.Property(e => e.CommentId).ValueGeneratedNever();
            entity.Property(e => e.UserUserId).HasColumnName("User_UserId");
            entity.Property(e => e.WhisperWhispId).HasColumnName("Whisper_WhispId");
        });

        modelBuilder.Entity<FeedBack>(entity =>
        {
            entity.HasKey(e => e.FeedBackId).HasName("FeedBack_pk");

            entity.ToTable("FeedBack");

            entity.Property(e => e.FeedBackId).ValueGeneratedOnAdd(); // Use ValueGeneratedOnAdd() for identity column
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.FeedBack1).HasColumnName("FeedBack");
            entity.Property(e => e.SquadSquadId).HasColumnName("Squad_SquadId");
            entity.Property(e => e.UserUserId).HasColumnName("User_UserId");
        });


        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.ImgId).HasName("Image_pk");

            entity.ToTable("Image");

            entity.Property(e => e.ImgId).ValueGeneratedNever();
            entity.Property(e => e.ImgUrl).HasColumnName("ImgURL");
            entity.Property(e => e.WhisperWhispId).HasColumnName("Whisper_WhispId");
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.HasKey(e => e.LikeId).HasName("Like_pk");

            entity.ToTable("Like");

            entity.Property(e => e.LikeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("LikeID");
            entity.Property(e => e.Like1).HasColumnName("Like");
            entity.Property(e => e.UserUserId).HasColumnName("User_UserId");
            entity.Property(e => e.WhisperWhispId).HasColumnName("Whisper_WhispId");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.MatId).HasName("Materials_pk");

            entity.Property(e => e.MatId).ValueGeneratedNever();
            entity.Property(e => e.Material1).HasColumnName("Material");
            entity.Property(e => e.Topic).HasMaxLength(1);
            entity.Property(e => e.WhisperTopicWtopicId).HasColumnName("WhisperTopic_WTopicId");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotiId).HasName("Notification_pk");

            entity.ToTable("Notification");

            entity.Property(e => e.NotiId).ValueGeneratedNever();
            entity.Property(e => e.Notiication).HasMaxLength(1);
            entity.Property(e => e.UserUserId).HasColumnName("User_UserId");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("Role_pk");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).ValueGeneratedNever();
            entity.Property(e => e.Role1)
                .HasMaxLength(1)
                .HasColumnName("Role");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.SkillId).HasName("Skills_pk");

            entity.Property(e => e.SkillId).ValueGeneratedNever();
            entity.Property(e => e.Proficiency).HasMaxLength(1);
            entity.Property(e => e.Skill1)
                .HasMaxLength(1)
                .HasColumnName("Skill");
            entity.Property(e => e.UserUserId).HasColumnName("User_UserId");
        });

        modelBuilder.Entity<Squad>(entity =>
        {
            entity.HasKey(e => e.SquadId).HasName("Squad_pk");

            entity.ToTable("Squad");

            entity.Property(e => e.SquadId).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("date");
            entity.Property(e => e.DeadLine).HasColumnType("date");
            entity.Property(e => e.Description).HasMaxLength(1);
            entity.Property(e => e.Title).HasMaxLength(1);
        });

        modelBuilder.Entity<SquadImage>(entity =>
        {
            entity.HasKey(e => e.SqimgId).HasName("SquadImage_pk");

            entity.ToTable("SquadImage");

            entity.Property(e => e.SqimgId)
                .ValueGeneratedNever()
                .HasColumnName("SQImgId");
            entity.Property(e => e.SqimgUrl).HasColumnName("SQimgURL");
            entity.Property(e => e.SquadSquadId).HasColumnName("Squad_SquadId");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("Status_pk");

            entity.ToTable("Status");

            entity.Property(e => e.StatusId).ValueGeneratedNever();
            entity.Property(e => e.SquadSquadId).HasColumnName("Squad_SquadId");
            entity.Property(e => e.Status1)
                .HasMaxLength(1)
                .HasColumnName("Status");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("User_pk");

            entity.ToTable("User");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(1);
            entity.Property(e => e.Nickname).HasMaxLength(1);
            entity.Property(e => e.Password).HasMaxLength(1);
            entity.Property(e => e.RoleRoleId).HasColumnName("Role_RoleId");
            entity.Property(e => e.UserName).HasMaxLength(1);
            
        });

        modelBuilder.Entity<UserSquad>(entity =>
        {
            entity.HasKey(e => e.UserSquadId).HasName("UserSquad_pk");

            entity.ToTable("UserSquad");

            entity.Property(e => e.UserSquadId).ValueGeneratedNever();
            entity.Property(e => e.SquadSquadId).HasColumnName("Squad_SquadId");
            entity.Property(e => e.UserUserId).HasColumnName("User_UserId");
        });

        modelBuilder.Entity<Whisper>(entity =>
        {
            entity.HasKey(e => e.WhispId).HasName("Whisper_pk");

            entity.ToTable("Whisper");

            entity.Property(e => e.WhispId).ValueGeneratedNever();
            entity.Property(e => e.SquadSquadId).HasColumnName("Squad_SquadId");
            entity.Property(e => e.UserUserId).HasColumnName("User_UserId");
            entity.Property(e => e.WhisperContent).HasMaxLength(1);
            entity.Property(e => e.WhisperTopicWtopicId).HasColumnName("WhisperTopic_WTopicId");
            entity.Property(e => e.WhisperTypeWtypeId).HasColumnName("WhisperType_WTypeId");
        });

        modelBuilder.Entity<WhisperTopic>(entity =>
        {
            entity.HasKey(e => e.WtopicId).HasName("WhisperTopic_pk");

            entity.ToTable("WhisperTopic");

            entity.Property(e => e.WtopicId)
                .ValueGeneratedNever()
                .HasColumnName("WTopicId");
            entity.Property(e => e.Topic).HasMaxLength(1);
        });

        modelBuilder.Entity<WhisperType>(entity =>
        {
            entity.HasKey(e => e.WtypeId).HasName("WhisperType_pk");

            entity.ToTable("WhisperType");

            entity.Property(e => e.WtypeId)
                .ValueGeneratedNever()
                .HasColumnName("WTypeId");
            entity.Property(e => e.Type).HasMaxLength(1);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
