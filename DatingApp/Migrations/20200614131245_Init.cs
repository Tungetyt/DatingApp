using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Interest",
                columns: table => new
                {
                    InterestId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interest", x => x.InterestId);
                });

            migrationBuilder.CreateTable(
                name: "University",
                columns: table => new
                {
                    UniversityId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_University", x => x.UniversityId);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<string>(nullable: false),
                    Email = table.Column<string>(unicode: false, nullable: false),
                    PasswordHash = table.Column<string>(unicode: false, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "date", nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Salary = table.Column<decimal>(type: "money", nullable: true),
                    Gender = table.Column<int>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    CityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                    table.ForeignKey(
                        name: "user_city",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Filter",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    MaxSearchDistance = table.Column<int>(nullable: true),
                    Age = table.Column<int>(nullable: true),
                    Gender = table.Column<int>(nullable: true),
                    UniversityId = table.Column<string>(nullable: true),
                    InterestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filter", x => x.UserId);
                    table.ForeignKey(
                        name: "filter_interest",
                        column: x => x.InterestId,
                        principalTable: "Interest",
                        principalColumn: "InterestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "filter_university",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "UniversityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Filter_Person_UserId",
                        column: x => x.UserId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matched_users",
                columns: table => new
                {
                    UserId1 = table.Column<string>(nullable: false),
                    UserId2 = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Matched_users_pk", x => new { x.UserId1, x.UserId2 });
                    table.ForeignKey(
                        name: "matched_users_user1",
                        column: x => x.UserId1,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "matched_users_user",
                        column: x => x.UserId2,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    Picture = table.Column<byte[]>(type: "image", nullable: false),
                    order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Picture_pk", x => x.UserId);
                    table.ForeignKey(
                        name: "picture_user",
                        column: x => x.UserId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UniversityAttendance",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    UniversityId = table.Column<string>(nullable: false),
                    IsGraduated = table.Column<bool>(nullable: true),
                    FieldOfStudy = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UniversityAttendance_pk", x => new { x.UserId, x.UniversityId });
                    table.ForeignKey(
                        name: "university_attendance_university",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "UniversityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "university_attendance_user",
                        column: x => x.UserId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserInterest",
                columns: table => new
                {
                    InterestId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UserInterest_pk", x => new { x.InterestId, x.UserId });
                    table.ForeignKey(
                        name: "user_interest_interest",
                        column: x => x.InterestId,
                        principalTable: "Interest",
                        principalColumn: "InterestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "user_interest_user",
                        column: x => x.UserId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersRelation",
                columns: table => new
                {
                    ActiveUserId = table.Column<string>(nullable: false),
                    PassiveUserId = table.Column<string>(nullable: false),
                    IsLiking = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UsersRelation_pk", x => new { x.ActiveUserId, x.PassiveUserId });
                    table.ForeignKey(
                        name: "users_relation_user1",
                        column: x => x.ActiveUserId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "users_relation_user",
                        column: x => x.PassiveUserId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTracking",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    Popularity = table.Column<int>(nullable: false),
                    ActivityIntensity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UserTracking_pk", x => x.UserId);
                    table.ForeignKey(
                        name: "user_tracking_user",
                        column: x => x.UserId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    SenderUserId = table.Column<string>(nullable: false),
                    RecieverUserId = table.Column<string>(nullable: false),
                    MessageId = table.Column<int>(nullable: false),
                    Message = table.Column<string>(maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Message_pk", x => new { x.SenderUserId, x.RecieverUserId, x.MessageId });
                    table.ForeignKey(
                        name: "message_matched_users",
                        columns: x => new { x.SenderUserId, x.RecieverUserId },
                        principalTable: "Matched_users",
                        principalColumns: new[] { "UserId1", "UserId2" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filter_InterestId",
                table: "Filter",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_Filter_UniversityId",
                table: "Filter",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Matched_users_UserId2",
                table: "Matched_users",
                column: "UserId2");

            migrationBuilder.CreateIndex(
                name: "IX_Person_CityId",
                table: "Person",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityAttendance_UniversityId",
                table: "UniversityAttendance",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterest_UserId",
                table: "UserInterest",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRelation_PassiveUserId",
                table: "UsersRelation",
                column: "PassiveUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filter");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropTable(
                name: "UniversityAttendance");

            migrationBuilder.DropTable(
                name: "UserInterest");

            migrationBuilder.DropTable(
                name: "UsersRelation");

            migrationBuilder.DropTable(
                name: "UserTracking");

            migrationBuilder.DropTable(
                name: "Matched_users");

            migrationBuilder.DropTable(
                name: "University");

            migrationBuilder.DropTable(
                name: "Interest");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
