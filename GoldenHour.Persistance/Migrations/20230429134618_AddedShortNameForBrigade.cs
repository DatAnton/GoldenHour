using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenHour.Persistance.Migrations
{
    public partial class AddedShortNameForBrigade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "Brigades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3306930e-624c-4790-984a-b95632753e8b",
                column: "ConcurrencyStamp",
                value: "95c4b7b5-f56d-42fb-a828-c8bdf9cb07cc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "546bc2c7-db8d-4634-9bb9-a315bf9a2898",
                column: "ConcurrencyStamp",
                value: "d3103057-7b4e-4d63-acfd-fdc45a3f4dc9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c4f337a-ad38-47c5-83b2-e959d752f071",
                column: "ConcurrencyStamp",
                value: "0f80fb69-d021-48fb-9078-5f6618d82e83");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d77f1e7-5b82-4d87-9d73-04bd7d76d12d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4fbe4b2c-5782-462f-a9fb-2b1e80f21119", "AQAAAAEAACcQAAAAEEACMEUWvcqOs13TMytwKJwbHD/TCy8Y3wEq6PQyMqhTsuG5w15eC83zhTsmEy2dwg==", "dbfe36b7-76b4-42ec-aa35-323995b9b753" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "026e71d0-49ff-4328-ba23-08d1d8370d83", "MEDIC", "AQAAAAEAACcQAAAAEOW2t4UJNZSpgPZHiX6+J+a2d3fZBlOw+NLxePQ6KuicnQc8jfiPGNABgS++fX17LQ==", "d7187d7f-f27e-45bb-b576-b02ecf140b71" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "b4f3cb66-56b5-46c8-8690-01d7d14e9563", "ADMIN", "AQAAAAEAACcQAAAAEAwLJ2n2LW4Gyj2HmB2dZcTzm0eq3casXCyfKu4m8al3S5nNjigOtNThReWHXmEF5Q==", "3381a8c3-805f-4e81-9c19-c8d2f9a28a6d", "admin" });

            migrationBuilder.UpdateData(
                table: "Brigades",
                keyColumn: "Id",
                keyValue: new Guid("9a17a2e4-d02f-42c6-b46a-7ac43afa4b5a"),
                column: "ShortName",
                value: "14th MB");

            migrationBuilder.UpdateData(
                table: "Brigades",
                keyColumn: "Id",
                keyValue: new Guid("cf2a2a3a-861f-45c9-9b35-456301093fa1"),
                column: "ShortName",
                value: "24th MB");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "Brigades");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3306930e-624c-4790-984a-b95632753e8b",
                column: "ConcurrencyStamp",
                value: "977e5c99-5960-4ff3-8255-4dfd0281729d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "546bc2c7-db8d-4634-9bb9-a315bf9a2898",
                column: "ConcurrencyStamp",
                value: "729ae95a-454d-4b2c-84a0-9f96d5224ef8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c4f337a-ad38-47c5-83b2-e959d752f071",
                column: "ConcurrencyStamp",
                value: "7d0e443c-8ce7-485f-b9e2-83c85f1a620d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d77f1e7-5b82-4d87-9d73-04bd7d76d12d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dcc9c6ce-3591-4fc8-b0d6-d474a5a67e62", "AQAAAAEAACcQAAAAEDOz1kVDYR2Y0QVfA22owMe4ly7Zd+aJF+Ld6H+3fXWQuQb1Nc4R3qs/BskWIlk/XQ==", "e225c222-b7f2-4a56-8ead-aa4a30aff1bd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6004bab2-7f98-4473-9bc0-21a9dbab3582", "MEDIC@LOCALHOST.COM", "AQAAAAEAACcQAAAAEG190lt35mMfapd+fWA4tZTsAaI7pIZJtkbOzNYhQRgRyK42Wr4CQWh6Fd03jvmheQ==", "6ee57ce8-b013-4abf-8b3b-2540780676ec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "9167e0b5-de33-49a2-b29c-8f0569872d39", "ADMIN@LOCALHOST.COM", "AQAAAAEAACcQAAAAEF0KQZoe1Hr93a3b16Rnp68neIxzZl1cKC8iVJCWoNvjZuaIb5Ali5qI2d7+x7QiRg==", "c601e864-6841-41f4-a132-6e9c201645c5", "admin@localhost.com" });
        }
    }
}
