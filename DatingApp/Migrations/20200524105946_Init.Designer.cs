﻿// <auto-generated />
using System;
using DatingApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;

namespace DatingApp.Migrations
{
    [DbContext(typeof(Prototype1Context))]
    [Migration("20200524105946_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DatingApp.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("CityId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("DatingApp.Models.Filter", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<int?>("InterestId")
                        .HasColumnType("int");

                    b.Property<int?>("MaxSearchDistance")
                        .HasColumnType("int");

                    b.Property<int?>("UniversityId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("InterestId");

                    b.HasIndex("UniversityId");

                    b.ToTable("Filter");
                });

            modelBuilder.Entity("DatingApp.Models.Interest", b =>
                {
                    b.Property<int>("InterestId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("InterestId");

                    b.ToTable("Interest");
                });

            modelBuilder.Entity("DatingApp.Models.MatchedUsers", b =>
                {
                    b.Property<string>("UserId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId2")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("date");

                    b.HasKey("UserId1", "UserId2")
                        .HasName("Matched_users_pk");

                    b.HasIndex("UserId2");

                    b.ToTable("Matched_users");
                });

            modelBuilder.Entity("DatingApp.Models.Message", b =>
                {
                    b.Property<string>("SenderUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RecieverUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("MessageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("date");

                    b.Property<string>("Message1")
                        .IsRequired()
                        .HasColumnName("Message")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("SenderUserId", "RecieverUserId", "MessageId")
                        .HasName("Message_pk");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("DatingApp.Models.Person", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("date");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .IsUnicode(false);

                    b.Property<string>("PersonId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("DatingApp.Models.Picture", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Order")
                        .HasColumnName("order")
                        .HasColumnType("int");

                    b.Property<byte[]>("Picture1")
                        .IsRequired()
                        .HasColumnName("Picture")
                        .HasColumnType("image");

                    b.HasKey("UserId")
                        .HasName("Picture_pk");

                    b.ToTable("Picture");
                });

            modelBuilder.Entity("DatingApp.Models.University", b =>
                {
                    b.Property<int>("UniversityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("UniversityId");

                    b.ToTable("University");
                });

            modelBuilder.Entity("DatingApp.Models.UniversityAttendance", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UniversityId")
                        .HasColumnType("int");

                    b.Property<string>("FieldOfStudy")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<bool?>("IsGraduated")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "UniversityId")
                        .HasName("UniversityAttendance_pk");

                    b.HasIndex("UniversityId");

                    b.ToTable("UniversityAttendance");
                });

            modelBuilder.Entity("DatingApp.Models.UserInterest", b =>
                {
                    b.Property<int>("InterestId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("InterestId", "UserId")
                        .HasName("UserInterest_pk");

                    b.HasIndex("UserId");

                    b.ToTable("UserInterest");
                });

            modelBuilder.Entity("DatingApp.Models.UserTracking", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ActivityIntensity")
                        .HasColumnType("int");

                    b.Property<Geometry>("Localisation")
                        .IsRequired()
                        .HasColumnType("geography");

                    b.Property<int>("Popularity")
                        .HasColumnType("int");

                    b.HasKey("UserId")
                        .HasName("UserTracking_pk");

                    b.ToTable("UserTracking");
                });

            modelBuilder.Entity("DatingApp.Models.UsersRelation", b =>
                {
                    b.Property<string>("ActiveUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PassiveUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("date");

                    b.Property<bool>("IsLiking")
                        .HasColumnType("bit");

                    b.HasKey("ActiveUserId", "PassiveUserId")
                        .HasName("UsersRelation_pk");

                    b.HasIndex("PassiveUserId");

                    b.ToTable("UsersRelation");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DatingApp.Models.Admin", b =>
                {
                    b.HasBaseType("DatingApp.Models.Person");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("money");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("DatingApp.Models.User", b =>
                {
                    b.HasBaseType("DatingApp.Models.Person");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.HasIndex("CityId");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("DatingApp.Models.PremiumUser", b =>
                {
                    b.HasBaseType("DatingApp.Models.User");

                    b.HasDiscriminator().HasValue("PremiumUser");
                });

            modelBuilder.Entity("DatingApp.Models.Filter", b =>
                {
                    b.HasOne("DatingApp.Models.Interest", "Interest")
                        .WithMany("Filter")
                        .HasForeignKey("InterestId")
                        .HasConstraintName("filter_interest");

                    b.HasOne("DatingApp.Models.University", "University")
                        .WithMany("Filter")
                        .HasForeignKey("UniversityId")
                        .HasConstraintName("filter_university");

                    b.HasOne("DatingApp.Models.User", "User")
                        .WithOne("Filter")
                        .HasForeignKey("DatingApp.Models.Filter", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DatingApp.Models.MatchedUsers", b =>
                {
                    b.HasOne("DatingApp.Models.User", "UserId1Navigation")
                        .WithMany("MatchedUsersUserId1Navigation")
                        .HasForeignKey("UserId1")
                        .HasConstraintName("matched_users_user1")
                        .IsRequired();

                    b.HasOne("DatingApp.Models.User", "UserId2Navigation")
                        .WithMany("MatchedUsersUserId2Navigation")
                        .HasForeignKey("UserId2")
                        .HasConstraintName("matched_users_user")
                        .IsRequired();
                });

            modelBuilder.Entity("DatingApp.Models.Message", b =>
                {
                    b.HasOne("DatingApp.Models.MatchedUsers", "MatchedUsers")
                        .WithMany("Message")
                        .HasForeignKey("SenderUserId", "RecieverUserId")
                        .HasConstraintName("message_matched_users")
                        .IsRequired();
                });

            modelBuilder.Entity("DatingApp.Models.Picture", b =>
                {
                    b.HasOne("DatingApp.Models.User", "User")
                        .WithOne("Picture")
                        .HasForeignKey("DatingApp.Models.Picture", "UserId")
                        .HasConstraintName("picture_user")
                        .IsRequired();
                });

            modelBuilder.Entity("DatingApp.Models.UniversityAttendance", b =>
                {
                    b.HasOne("DatingApp.Models.University", "University")
                        .WithMany("UniversityAttendance")
                        .HasForeignKey("UniversityId")
                        .HasConstraintName("university_attendance_university")
                        .IsRequired();

                    b.HasOne("DatingApp.Models.User", "User")
                        .WithMany("UniversityAttendance")
                        .HasForeignKey("UserId")
                        .HasConstraintName("university_attendance_user")
                        .IsRequired();
                });

            modelBuilder.Entity("DatingApp.Models.UserInterest", b =>
                {
                    b.HasOne("DatingApp.Models.Interest", "Interest")
                        .WithMany("UserInterest")
                        .HasForeignKey("InterestId")
                        .HasConstraintName("user_interest_interest")
                        .IsRequired();

                    b.HasOne("DatingApp.Models.User", "User")
                        .WithMany("UserInterest")
                        .HasForeignKey("UserId")
                        .HasConstraintName("user_interest_user")
                        .IsRequired();
                });

            modelBuilder.Entity("DatingApp.Models.UserTracking", b =>
                {
                    b.HasOne("DatingApp.Models.User", "User")
                        .WithOne("UserTracking")
                        .HasForeignKey("DatingApp.Models.UserTracking", "UserId")
                        .HasConstraintName("user_tracking_user")
                        .IsRequired();
                });

            modelBuilder.Entity("DatingApp.Models.UsersRelation", b =>
                {
                    b.HasOne("DatingApp.Models.User", "ActiveUser")
                        .WithMany("UsersRelationActiveUser")
                        .HasForeignKey("ActiveUserId")
                        .HasConstraintName("users_relation_user1")
                        .IsRequired();

                    b.HasOne("DatingApp.Models.User", "PassiveUser")
                        .WithMany("UsersRelationPassiveUser")
                        .HasForeignKey("PassiveUserId")
                        .HasConstraintName("users_relation_user")
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DatingApp.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DatingApp.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatingApp.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DatingApp.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DatingApp.Models.User", b =>
                {
                    b.HasOne("DatingApp.Models.City", "City")
                        .WithMany("User")
                        .HasForeignKey("CityId")
                        .HasConstraintName("user_city");
                });
#pragma warning restore 612, 618
        }
    }
}
