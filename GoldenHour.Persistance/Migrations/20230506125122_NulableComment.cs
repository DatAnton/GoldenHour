using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenHour.Persistance.Migrations
{
    public partial class NulableComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Incidents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Incidents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3306930e-624c-4790-984a-b95632753e8b",
                column: "ConcurrencyStamp",
                value: "c8c10746-1850-4ee3-8257-2183294183c6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "546bc2c7-db8d-4634-9bb9-a315bf9a2898",
                column: "ConcurrencyStamp",
                value: "be3395fc-7ace-4594-a034-c41275e60e52");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c4f337a-ad38-47c5-83b2-e959d752f071",
                column: "ConcurrencyStamp",
                value: "ca66346b-8d4e-440d-bc4b-5800797a16ca");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d77f1e7-5b82-4d87-9d73-04bd7d76d12d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67ebb246-baca-45db-a4c1-6b595d46123a", "AQAAAAEAACcQAAAAELSFRLFlPLZAWI0o6uhb0e76V8ck9HtE0b0jjVspeoeP9HDVXrLYeob73EGKk55mew==", "0816ac4c-e317-46fc-b269-1b5ae14d02d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d27a898f-1088-4b25-b8d9-4f9893bbc5e8", "AQAAAAEAACcQAAAAEByxMDfPN4Fb0YbvnAWUhq9puGLcmGM4qQH42PYC+aPuDB9T5h4i1QtgSafbBbBbcg==", "f8c9ac02-0173-4962-9070-1f12dfb01170" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3761fdac-534a-4f6a-a973-56d261d86ff8", "AQAAAAEAACcQAAAAEKc0n0rsDoYCc2w2mZ8eRZt9yBrw0p//2qXOT4fzn05ww7uzdHPrqCjNcnd202hUkw==", "543ba7d2-44d8-449f-947f-693ddf0ea4b0" });
        }
    }
}
