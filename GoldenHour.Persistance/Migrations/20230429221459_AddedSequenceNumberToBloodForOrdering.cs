using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenHour.Persistance.Migrations
{
    public partial class AddedSequenceNumberToBloodForOrdering : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SequenceNumber",
                schema: "meta",
                table: "BloodGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3306930e-624c-4790-984a-b95632753e8b",
                column: "ConcurrencyStamp",
                value: "40a9b945-649b-41a7-a005-a7244f10f7f3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "546bc2c7-db8d-4634-9bb9-a315bf9a2898",
                column: "ConcurrencyStamp",
                value: "ac437dd8-4084-455b-a5ed-9dae5f739579");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c4f337a-ad38-47c5-83b2-e959d752f071",
                column: "ConcurrencyStamp",
                value: "c04d41e2-c7c6-4c39-b9a1-b4f940a8a020");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d77f1e7-5b82-4d87-9d73-04bd7d76d12d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6dca2abb-2864-41eb-b3e6-50d1a000b8b4", "AQAAAAEAACcQAAAAEIHJS3yViAiV3jPwKIIjYZxyJl7nlTMl0wGVQSpmChz4zyqd0lz4mYdTEwkY/va8eQ==", "92b0c848-27bf-40d6-955b-6b49c5dd02bc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8e2d1f9-411e-447d-b835-422de2855442", "AQAAAAEAACcQAAAAECj4sIY/HZIN1iVDj8NrTyhHtH4jW5iGDXad0YQbEjePEUO3CWibueorwdMSSRq1gA==", "e4516ef8-9cc0-45a5-99b8-85c6609396dc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2831e6c-0f06-4857-9dc3-1584be74b190", "AQAAAAEAACcQAAAAEOVWkgaUWDthn3Tt9YRmBCfOPh2saO/bORGYJxlf5fVM4eOGJlGRa+R+E0QNQa0KmQ==", "b6c9477e-6f29-4ddc-b61c-803d9c297b76" });

            migrationBuilder.UpdateData(
                schema: "meta",
                table: "BloodGroups",
                keyColumn: "Id",
                keyValue: new Guid("1daaa8e0-b24b-4a78-84f7-c0d5e958fccd"),
                column: "SequenceNumber",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "meta",
                table: "BloodGroups",
                keyColumn: "Id",
                keyValue: new Guid("7148549f-6cbd-47e1-86d5-62a9a5661c07"),
                column: "SequenceNumber",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "meta",
                table: "BloodGroups",
                keyColumn: "Id",
                keyValue: new Guid("89160257-98b1-4c69-bf39-fef973cad668"),
                column: "SequenceNumber",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "meta",
                table: "BloodGroups",
                keyColumn: "Id",
                keyValue: new Guid("ebe5ba94-2c9d-46f4-8188-4ca1fc677d70"),
                column: "SequenceNumber",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SequenceNumber",
                schema: "meta",
                table: "BloodGroups");

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
        }
    }
}
