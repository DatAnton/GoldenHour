using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenHour.Persistance.Migrations
{
    public partial class UserRefreshTokenTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expire = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServiceManId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRefreshTokens_AspNetUsers_ServiceManId",
                        column: x => x.ServiceManId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3306930e-624c-4790-984a-b95632753e8b",
                column: "ConcurrencyStamp",
                value: "4e7f83e5-c5eb-4fd5-a867-4ac177c673ec");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "546bc2c7-db8d-4634-9bb9-a315bf9a2898",
                column: "ConcurrencyStamp",
                value: "9658c3ee-0895-425f-b8d5-09650855a590");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c4f337a-ad38-47c5-83b2-e959d752f071",
                column: "ConcurrencyStamp",
                value: "941da4f5-dce3-4929-9568-06a4189116c4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d77f1e7-5b82-4d87-9d73-04bd7d76d12d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e719da7-1d4f-422c-97c5-11d4558741af", "AQAAAAEAACcQAAAAEB5MoX+4qJ9bz2yNM1vyA5avdzQDzXE7CRNF/SPbT2opHaQKDDptgshLv6KGxPag2Q==", "4aee0faa-3fde-4712-af9f-16dcecb9f2b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f81ddda2-4dc0-4891-ba36-d853e87e5f9d", "AQAAAAEAACcQAAAAEGa31WakIQEsYDAIweEIeC2TzFiX7ikSkBdY4PvBqZZAPXHuBgE2Rli9s37N66uIsQ==", "b72afc41-5316-4cf7-ad9e-e0694ead3269" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d1b7e78-7d7b-49dc-b7c8-ae655edf7be7", "AQAAAAEAACcQAAAAECu7+j9sgu9cYPFucp/ixGW8jzH+qVKh9SK6A8/NM1Xjc6G9O6Ry3H4aS5kZpYBjKw==", "fb8e09d4-baf8-473f-a911-9ce711bc6ce0" });

            migrationBuilder.CreateIndex(
                name: "IX_UserRefreshTokens_ServiceManId",
                table: "UserRefreshTokens",
                column: "ServiceManId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRefreshTokens");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3306930e-624c-4790-984a-b95632753e8b",
                column: "ConcurrencyStamp",
                value: "c1b6eadf-8660-49c5-a67a-2007c0fa877d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "546bc2c7-db8d-4634-9bb9-a315bf9a2898",
                column: "ConcurrencyStamp",
                value: "17b6a3d7-532f-480e-b9bc-28d2a0b6fb62");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c4f337a-ad38-47c5-83b2-e959d752f071",
                column: "ConcurrencyStamp",
                value: "7691a281-ff5a-486a-b4a1-24ac325d1c70");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d77f1e7-5b82-4d87-9d73-04bd7d76d12d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2095388-fdf8-4bb1-888c-0bd518b645df", "AQAAAAEAACcQAAAAEEvcch99Y8sSvYDcKl72jFLIUFrjOEeSMF1EodaDGT0wBsWaP47eh7941UDZtqIGrA==", "05a3b4aa-6d05-4b34-9f8e-3de247b1d59d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13af52be-fb32-4cf0-9b94-d0d7ada39318", "AQAAAAEAACcQAAAAELeUhzpL07wAjs10IJOt6Tt0OSuqeJCTsWW2eIG9tP7SECWfXJuuhIzqHRZwy7gK8Q==", "67e7b856-a5ec-4e89-966b-b21c754ac8fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2668519c-79d8-48e6-afab-6b66e571819a", "AQAAAAEAACcQAAAAEKpO28hi/ibq5KsD/xNFF67T914c8Sddid+7OlXCxp894agZjWr0f3LOk5iMCkI/SA==", "f9e076e5-029d-461f-8f51-5201d3e053af" });
        }
    }
}
