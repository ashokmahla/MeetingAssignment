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
                   AttendeesId = table.Column<string>(nullable: true),
                   Agenda = table.Column<string>(nullable: true),
                   MeetingTime = table.Column<string>(nullable: true)
               });

            migrationBuilder.InsertData(
               table: "Meetings",
               columns: new[] { "Subject", "AttendeesId", "Agenda", "MeetingTime" },
               values: new object[] { "Discussion","1,2", "TX project discussion", "2020-02-20T09:45:00.000Z" });

            migrationBuilder.CreateTable(
            name: "Attendees",
            columns: table => new
            {
                 Id = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(nullable: true),
            });

            migrationBuilder.InsertData(
               table: "Attendees",
               columns: new[] { "Name" },
               values: new object[] { "a" });

            migrationBuilder.InsertData(
                table: "Attendees",
                columns: new[] { "Name" },
                values: new object[] { "b" });
            migrationBuilder.InsertData(
              table: "Attendees",
              columns: new[] { "Name" },
              values: new object[] { "c" });

            migrationBuilder.InsertData(
                table: "Attendees",
                columns: new[] { "Name" },
                values: new object[] { "d" });
            migrationBuilder.InsertData(
              table: "Attendees",
              columns: new[] { "Name" },
              values: new object[] { "e" });

            migrationBuilder.InsertData(
                table: "Attendees",
                columns: new[] { "Name" },
                values: new object[] { "f" });
            migrationBuilder.InsertData(
              table: "Attendees",
              columns: new[] { "Name" },
              values: new object[] { "g" });

            migrationBuilder.InsertData(
                table: "Attendees",
                columns: new[] { "Name" },
                values: new object[] { "h" });
            migrationBuilder.InsertData(
              table: "Attendees",
              columns: new[] { "Name" },
              values: new object[] { "i" });

            migrationBuilder.InsertData(
                table: "Attendees",
                columns: new[] { "Name" },
                values: new object[] { "j" });
            migrationBuilder.InsertData(
              table: "Attendees",
              columns: new[] { "Name" },
              values: new object[] { "k" });

            migrationBuilder.InsertData(
                table: "Attendees",
                columns: new[] { "Name" },
                values: new object[] { "l" });
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
