using System;
using System.Text;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations.SqlServerMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            //Setting up default user

            byte[] passwordSalt;
            byte[] passwordHash;
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("ashok@123"));
            }


            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "FirstName", "LastName", "Username", "PasswordHash", "PasswordSalt" },
                values: new object[] { "Ashok", "Kumar", "Ashok", passwordHash, passwordSalt });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(nullable: true),
                    Agenda = table.Column<string>(nullable: true),
                    MeetingTime = table.Column<string>(nullable: true)
                }
                ,
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.Id);
                }); 

            migrationBuilder.InsertData(
               table: "Meetings",
               columns: new[] { "Subject","Agenda", "MeetingTime" },
               values: new object[] { "Discussion","TX project discussion", "2020-02-20T09:45:00.000Z" });

            migrationBuilder.CreateTable(
                name: "AttendiesMeetings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    MeetingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendiesMeetings", x => x.Id);

                    table.ForeignKey(
                    name: "FK_AttendiesMeetings_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                    name: "FK_AttendiesMeetings_Meetings_MeetingId",
                    column: x => x.MeetingId,
                    principalTable: "Meetings",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                });
               

            migrationBuilder.InsertData(
            table: "AttendiesMeetings",
            columns: new[] { "UserId", "MeetingId" },
            values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
              name: "Meetings");

            migrationBuilder.DropTable(
              name: "Attendees");
        }
    }
}
