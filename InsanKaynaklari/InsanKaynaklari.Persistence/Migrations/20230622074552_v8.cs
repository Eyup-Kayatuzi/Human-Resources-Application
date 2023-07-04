using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsanKaynaklari.Persistence.Migrations
{
    public partial class v8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonnelExpense_AspNetUsers_AppIdentityUserId",
                table: "PersonnelExpense");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonnelExpense",
                table: "PersonnelExpense");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3231eda4-d8bb-49c8-9786-fa9462eca051");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cba1199-3121-4a2e-ab30-73e6daccecba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1a98373-4d56-4fad-adf8-c6989ac02b19");

            migrationBuilder.RenameTable(
                name: "PersonnelExpense",
                newName: "PersonnelExpenses");

            migrationBuilder.RenameIndex(
                name: "IX_PersonnelExpense_AppIdentityUserId",
                table: "PersonnelExpenses",
                newName: "IX_PersonnelExpenses_AppIdentityUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonnelExpenses",
                table: "PersonnelExpenses",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "29224189-f50b-49ff-a285-46dfc766b22b", "1", "Bu sirket yöneticisi roludur.", "AppIdentityRole", "sirketyoneticisi", "SIRKETADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "689502ec-adf3-4831-947a-b8b1bdf304e0", "2", "Bu site yöneticisi roludur.", "AppIdentityRole", "siteyoneticisi", "SITEADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "6f03866f-ccec-4b1e-be9b-57066e9735bc", "10", "Bu personel roludur.", "AppIdentityRole", "personel", "PERSONEL" });

            migrationBuilder.AddForeignKey(
                name: "FK_PersonnelExpenses_AspNetUsers_AppIdentityUserId",
                table: "PersonnelExpenses",
                column: "AppIdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonnelExpenses_AspNetUsers_AppIdentityUserId",
                table: "PersonnelExpenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonnelExpenses",
                table: "PersonnelExpenses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29224189-f50b-49ff-a285-46dfc766b22b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "689502ec-adf3-4831-947a-b8b1bdf304e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f03866f-ccec-4b1e-be9b-57066e9735bc");

            migrationBuilder.RenameTable(
                name: "PersonnelExpenses",
                newName: "PersonnelExpense");

            migrationBuilder.RenameIndex(
                name: "IX_PersonnelExpenses_AppIdentityUserId",
                table: "PersonnelExpense",
                newName: "IX_PersonnelExpense_AppIdentityUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonnelExpense",
                table: "PersonnelExpense",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "3231eda4-d8bb-49c8-9786-fa9462eca051", "10", "Bu personel roludur.", "AppIdentityRole", "personel", "PERSONEL" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "5cba1199-3121-4a2e-ab30-73e6daccecba", "2", "Bu site yöneticisi roludur.", "AppIdentityRole", "siteyoneticisi", "SITEADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "e1a98373-4d56-4fad-adf8-c6989ac02b19", "1", "Bu sirket yöneticisi roludur.", "AppIdentityRole", "sirketyoneticisi", "SIRKETADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_PersonnelExpense_AspNetUsers_AppIdentityUserId",
                table: "PersonnelExpense",
                column: "AppIdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
