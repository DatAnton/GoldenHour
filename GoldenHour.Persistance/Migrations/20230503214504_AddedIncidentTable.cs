using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenHour.Persistance.Migrations
{
    public partial class AddedIncidentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceManId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incidents_AspNetUsers_MedicId",
                        column: x => x.MedicId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Incidents_AspNetUsers_ServiceManId",
                        column: x => x.ServiceManId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HelpPhotos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncidentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HelpPhotos_Incidents_IncidentId",
                        column: x => x.IncidentId,
                        principalTable: "Incidents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_HelpPhotos_IncidentId",
                table: "HelpPhotos",
                column: "IncidentId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_MedicId",
                table: "Incidents",
                column: "MedicId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_ServiceManId",
                table: "Incidents",
                column: "ServiceManId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HelpPhotos");

            migrationBuilder.DropTable(
                name: "Incidents");

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
        }
    }
}
