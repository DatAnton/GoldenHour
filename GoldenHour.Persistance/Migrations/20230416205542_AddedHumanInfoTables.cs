using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenHour.Persistance.Migrations
{
    public partial class AddedHumanInfoTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "meta");

            migrationBuilder.AddColumn<Guid>(
                name: "BloodGroupId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BrigadeId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "BloodGroups",
                schema: "meta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brigades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brigades", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                schema: "meta",
                table: "BloodGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1daaa8e0-b24b-4a78-84f7-c0d5e958fccd"), "Fourth — AB (ІV)" },
                    { new Guid("7148549f-6cbd-47e1-86d5-62a9a5661c07"), "Third — B (ІІІ)" },
                    { new Guid("89160257-98b1-4c69-bf39-fef973cad668"), "Second — A (ІІ)" },
                    { new Guid("ebe5ba94-2c9d-46f4-8188-4ca1fc677d70"), "First — 0 (І)" }
                });

            migrationBuilder.InsertData(
                table: "Brigades",
                columns: new[] { "Id", "Department", "Name" },
                values: new object[,]
                {
                    { new Guid("9a17a2e4-d02f-42c6-b46a-7ac43afa4b5a"), "97", "14th Mechanized Brigade 'Roman the Great' (MU A2331), Volodymyr-Volynsky, Volyn Oblast" },
                    { new Guid("cf2a2a3a-861f-45c9-9b35-456301093fa1"), "52", "24th Mechanized Brigade 'King Daniel' (MU A0998), Yavoriv, Lviv Oblast" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "BloodGroupId", "BrigadeId", "ConcurrencyStamp", "FullName", "NickName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { new Guid("7148549f-6cbd-47e1-86d5-62a9a5661c07"), new Guid("9a17a2e4-d02f-42c6-b46a-7ac43afa4b5a"), "6004bab2-7f98-4473-9bc0-21a9dbab3582", "Bondar Volodymyr Ivanovych", "Voan", "AQAAAAEAACcQAAAAEG190lt35mMfapd+fWA4tZTsAaI7pIZJtkbOzNYhQRgRyK42Wr4CQWh6Fd03jvmheQ==", "6ee57ce8-b013-4abf-8b3b-2540780676ec", "medic" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "BloodGroupId", "BrigadeId", "ConcurrencyStamp", "FullName", "NickName", "PasswordHash", "SecurityStamp" },
                values: new object[] { new Guid("7148549f-6cbd-47e1-86d5-62a9a5661c07"), new Guid("9a17a2e4-d02f-42c6-b46a-7ac43afa4b5a"), "9167e0b5-de33-49a2-b29c-8f0569872d39", "", "admin", "AQAAAAEAACcQAAAAEF0KQZoe1Hr93a3b16Rnp68neIxzZl1cKC8iVJCWoNvjZuaIb5Ali5qI2d7+x7QiRg==", "c601e864-6841-41f4-a132-6e9c201645c5" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BloodGroupId", "BrigadeId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NickName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3d77f1e7-5b82-4d87-9d73-04bd7d76d12d", 0, new Guid("89160257-98b1-4c69-bf39-fef973cad668"), new Guid("9a17a2e4-d02f-42c6-b46a-7ac43afa4b5a"), "dcc9c6ce-3591-4fc8-b0d6-d474a5a67e62", "serviceman@localhost.com", true, "Nazarenko Ivan Petrovych", false, null, "Prometey", "SERVICEMAN@LOCALHOST.COM", "SERVICEMAN", "AQAAAAEAACcQAAAAEDOz1kVDYR2Y0QVfA22owMe4ly7Zd+aJF+Ld6H+3fXWQuQb1Nc4R3qs/BskWIlk/XQ==", null, false, "e225c222-b7f2-4a56-8ead-aa4a30aff1bd", false, "serviceman" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6c4f337a-ad38-47c5-83b2-e959d752f071", "3d77f1e7-5b82-4d87-9d73-04bd7d76d12d" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BloodGroupId",
                table: "AspNetUsers",
                column: "BloodGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BrigadeId",
                table: "AspNetUsers",
                column: "BrigadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_BloodGroups_BloodGroupId",
                table: "AspNetUsers",
                column: "BloodGroupId",
                principalSchema: "meta",
                principalTable: "BloodGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Brigades_BrigadeId",
                table: "AspNetUsers",
                column: "BrigadeId",
                principalTable: "Brigades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_BloodGroups_BloodGroupId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Brigades_BrigadeId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BloodGroups",
                schema: "meta");

            migrationBuilder.DropTable(
                name: "Brigades");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BloodGroupId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BrigadeId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6c4f337a-ad38-47c5-83b2-e959d752f071", "3d77f1e7-5b82-4d87-9d73-04bd7d76d12d" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d77f1e7-5b82-4d87-9d73-04bd7d76d12d");

            migrationBuilder.DropColumn(
                name: "BloodGroupId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BrigadeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NickName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3306930e-624c-4790-984a-b95632753e8b",
                column: "ConcurrencyStamp",
                value: "54b97ee9-65c5-4d38-bb13-19da906921dd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "546bc2c7-db8d-4634-9bb9-a315bf9a2898",
                column: "ConcurrencyStamp",
                value: "63c6a71b-68e3-4825-addb-154bdbf50fd5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c4f337a-ad38-47c5-83b2-e959d752f071",
                column: "ConcurrencyStamp",
                value: "cc1231ff-e080-4419-a4f1-9a20f5a190e7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "047e2988-ad79-4d96-97b3-751ae8ad5a4c", "AQAAAAEAACcQAAAAEAa0W/LzoyYZfj5MowO27CQpYtTWUd3d75vwN/uABNabxm6vkTinTA7LWWhh2Ipztw==", "506a81af-011b-4a7e-8cf6-e22a77187c4c", "medic@localhost.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13fea4c8-0ef1-4069-9e6c-a8bf965b455c", "AQAAAAEAACcQAAAAEHZGUoTFH6I/fW7StdbbyF/LeNwyzKCRou8nkeogCzZXx4z2acXqoqPJkIjg0LeJ+w==", "7e56393e-8b9a-4809-9043-5b1c51d42655" });
        }
    }
}
