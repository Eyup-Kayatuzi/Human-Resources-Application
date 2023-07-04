using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsanKaynaklari.Persistence.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33606781-b536-402d-9ac8-371ab28b7d3f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cd67e8f-23f4-471f-9777-9c5357c75265");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcb1b363-66e4-411a-9178-b82d1c2fda7c");

            migrationBuilder.CreateTable(
                name: "PersonnelExpense",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpenseAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReplyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FolderPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonnelId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppIdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonnelExpense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonnelExpense_AspNetUsers_AppIdentityUserId",
                        column: x => x.AppIdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "43695b8e-a9c5-46ed-bcfc-850960fa97f2", "1", "Bu sirket yöneticisi roludur.", "AppIdentityRole", "sirketyoneticisi", "SIRKETADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "c380cbe5-6544-4854-9b8f-f3f931a4df2f", "2", "Bu site yöneticisi roludur.", "AppIdentityRole", "siteyoneticisi", "SITEADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "fcde4f5f-58fe-4954-a462-cd144002ea3e", "10", "Bu personel roludur.", "AppIdentityRole", "personel", "PERSONEL" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelExpense_AppIdentityUserId",
                table: "PersonnelExpense",
                column: "AppIdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonnelExpense");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43695b8e-a9c5-46ed-bcfc-850960fa97f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c380cbe5-6544-4854-9b8f-f3f931a4df2f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcde4f5f-58fe-4954-a462-cd144002ea3e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "33606781-b536-402d-9ac8-371ab28b7d3f", "10", "Bu personel roludur.", "AppIdentityRole", "personel", "PERSONEL" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "5cd67e8f-23f4-471f-9777-9c5357c75265", "2", "Bu site yöneticisi roludur.", "AppIdentityRole", "siteyoneticisi", "SITEADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "dcb1b363-66e4-411a-9178-b82d1c2fda7c", "1", "Bu sirket yöneticisi roludur.", "AppIdentityRole", "sirketyoneticisi", "SIRKETADMIN" });
        }
    }
}
