using System;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Models
{
    public class Prototype1Context : DbContext
    {
        public Prototype1Context()
        {
        }

        public Prototype1Context(DbContextOptions<Prototype1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Filter> Filter { get; set; }
        public virtual DbSet<Interest> Interest { get; set; }
        public virtual DbSet<MatchedUsers> MatchedUsers { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Picture> Picture { get; set; }
        public virtual DbSet<PremiumUser> PremiumUser { get; set; }
        public virtual DbSet<University> University { get; set; }
        public virtual DbSet<UniversityAttendance> UniversityAttendance { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserInterest> UserInterest { get; set; }
        public virtual DbSet<UserTracking> UserTracking { get; set; }
        public virtual DbSet<UsersRelation> UsersRelation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http: //go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(
                    "Data Source=DESKTOP-46NBAHQ\\MSSQLSERVER01;Initial Catalog=Prototype1;Integrated Security=True",
                    x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Admin>(entity => { entity.Property(e => e.Salary).HasColumnType("money"); });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Filter>(entity =>
            {
                entity.HasOne(d => d.Interest)
                    .WithMany(p => p.Filter)
                    .HasForeignKey(d => d.InterestId)
                    .HasConstraintName("filter_interest");

                entity.HasOne(d => d.University)
                    .WithMany(p => p.Filter)
                    .HasForeignKey(d => d.UniversityId)
                    .HasConstraintName("filter_university");
            });

            modelBuilder.Entity<Interest>(entity =>
            {
                entity.Property(e => e.InterestId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<MatchedUsers>(entity =>
            {
                entity.HasKey(e => new { e.UserId1, e.UserId2 })
                    .HasName("Matched_users_pk");

                entity.ToTable("Matched_users");


                entity.Property(e => e.CreatedAt).HasColumnType("date");

                entity.HasOne(d => d.UserId1Navigation)
                    .WithMany(p => p.MatchedUsersUserId1Navigation)
                    .HasForeignKey(d => d.UserId1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("matched_users_user1");

                entity.HasOne(d => d.UserId2Navigation)
                    .WithMany(p => p.MatchedUsersUserId2Navigation)
                    .HasForeignKey(d => d.UserId2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("matched_users_user");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => new { e.SenderUserId, e.RecieverUserId, e.MessageId })
                    .HasName("Message_pk");


                entity.Property(e => e.CreatedAt).HasColumnType("date");

                entity.Property(e => e.Message1)
                    .IsRequired()
                    .HasColumnName("Message")
                    .HasMaxLength(255);

                entity.HasOne(d => d.MatchedUsers)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => new { d.SenderUserId, d.RecieverUserId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("message_matched_users");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Picture>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("Picture_pk");


                entity.Property(e => e.Order).HasColumnName("order");

                entity.Property(e => e.Picture1)
                    .IsRequired()
                    .HasColumnName("Picture")
                    .HasColumnType("image");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Picture)
                    .HasForeignKey<Picture>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("picture_user");
            });

            modelBuilder.Entity<PremiumUser>(entity => { entity.Property(e => e.CreatedAt).HasColumnType("date"); });

            modelBuilder.Entity<University>(entity =>
            {
                entity.Property(e => e.UniversityId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<UniversityAttendance>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.UniversityId })
                    .HasName("UniversityAttendance_pk");


                entity.Property(e => e.FieldOfStudy).HasMaxLength(255);

                entity.HasOne(d => d.University)
                    .WithMany(p => p.UniversityAttendance)
                    .HasForeignKey(d => d.UniversityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("university_attendance_university");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UniversityAttendance)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("university_attendance_user");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("user_city");
            });

            modelBuilder.Entity<UserInterest>(entity =>
            {
                entity.HasKey(e => new { e.InterestId, e.UserId })
                    .HasName("UserInterest_pk");


                entity.HasOne(d => d.Interest)
                    .WithMany(p => p.UserInterest)
                    .HasForeignKey(d => d.InterestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_interest_interest");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserInterest)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_interest_user");
            });

            modelBuilder.Entity<UserTracking>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("UserTracking_pk");


                //entity.Property(e => e.Localisation).IsRequired();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserTracking)
                    .HasForeignKey<UserTracking>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_tracking_user");
            });

            modelBuilder.Entity<UsersRelation>(entity =>
            {
                entity.HasKey(e => new { e.ActiveUserId, e.PassiveUserId })
                    .HasName("UsersRelation_pk");


                entity.Property(e => e.CreatedAt).HasColumnType("date");

                entity.HasOne(d => d.ActiveUser)
                    .WithMany(p => p.UsersRelationActiveUser)
                    .HasForeignKey(d => d.ActiveUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_relation_user1");

                entity.HasOne(d => d.PassiveUser)
                    .WithMany(p => p.UsersRelationPassiveUser)
                    .HasForeignKey(d => d.PassiveUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_relation_user");
            });

            //OnModelCreatingPartial(modelBuilder);
        }

        //private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        //{
        //    throw new NotImplementedException();
        //}
    }
}