using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenHour.Persistance.Migrations
{
    public partial class AddedUniqueConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brigades",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "meta",
                table: "BloodGroups",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NickName",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3306930e-624c-4790-984a-b95632753e8b",
                column: "ConcurrencyStamp",
                value: "e6dbaf0c-eb65-4917-8e2d-15dbe21497cd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "546bc2c7-db8d-4634-9bb9-a315bf9a2898",
                column: "ConcurrencyStamp",
                value: "2ced3e09-430d-4609-8ada-24ea6ebad8db");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c4f337a-ad38-47c5-83b2-e959d752f071",
                column: "ConcurrencyStamp",
                value: "9707a027-5e06-47e1-8277-f0217f67242c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d77f1e7-5b82-4d87-9d73-04bd7d76d12d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b0ced9d-6a0e-402f-8b39-1fad86d1d254", "AQAAAAEAACcQAAAAEItn4Q+vkeQmgh94mH5awPsL0LhCuRB/+5JMTCZtGQaYNWu1IM+fXkO2ydSUVVvVBA==", "17e6da44-a826-4cf9-8bd3-268be73b88d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e68d1ad9-f6ac-4db7-b34a-2c0eb7f7ae26", "AQAAAAEAACcQAAAAEOnUc6M4AvqG2z2WG5YVe8s+e6euwMN9fKtigx9U2tWy/XdC6Ve6OmCXUBRHkJAjfQ==", "c327ee29-a7a6-4035-9bcc-6bb215b77602" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e36af39-b6f5-4fd1-81f9-8b5566105e2f", "AQAAAAEAACcQAAAAEFrhCHHzt6XVz8Y1XCfJ8SXT/iW/ww63MAcwKc7JCOLK1Y7YLPbfNGvz3fKcwvGjzA==", "00ba7637-0c4a-4c48-a9c1-e52d7e721e06" });

            migrationBuilder.CreateIndex(
                name: "IX_Brigades_Name",
                table: "Brigades",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BloodGroups_Name",
                schema: "meta",
                table: "BloodGroups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_NickName",
                table: "AspNetUsers",
                column: "NickName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Brigades_Name",
                table: "Brigades");

            migrationBuilder.DropIndex(
                name: "IX_BloodGroups_Name",
                schema: "meta",
                table: "BloodGroups");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_NickName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brigades",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "meta",
                table: "BloodGroups",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "NickName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "026e71d0-49ff-4328-ba23-08d1d8370d83", "AQAAAAEAACcQAAAAEOW2t4UJNZSpgPZHiX6+J+a2d3fZBlOw+NLxePQ6KuicnQc8jfiPGNABgS++fX17LQ==", "d7187d7f-f27e-45bb-b576-b02ecf140b71" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4f3cb66-56b5-46c8-8690-01d7d14e9563", "AQAAAAEAACcQAAAAEAwLJ2n2LW4Gyj2HmB2dZcTzm0eq3casXCyfKu4m8al3S5nNjigOtNThReWHXmEF5Q==", "3381a8c3-805f-4e81-9c19-c8d2f9a28a6d" });
        }
    }
}
