using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsanKaynaklari.Persistence.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<int>(
                name: "ExpenseType",
                table: "PersonnelExpense",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Currency",
                table: "PersonnelExpense",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "1225fb82-cdf3-459f-806c-db70d13fe7f9", "2", "Bu site yöneticisi roludur.", "AppIdentityRole", "siteyoneticisi", "SITEADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "20b2cb36-8e2b-42e3-ba86-3cf97678243e", "1", "Bu sirket yöneticisi roludur.", "AppIdentityRole", "sirketyoneticisi", "SIRKETADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "8cd7db37-252b-46c5-81e7-974260e6a2ee", "10", "Bu personel roludur.", "AppIdentityRole", "personel", "PERSONEL" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1225fb82-cdf3-459f-806c-db70d13fe7f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20b2cb36-8e2b-42e3-ba86-3cf97678243e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cd7db37-252b-46c5-81e7-974260e6a2ee");

            migrationBuilder.AlterColumn<string>(
                name: "ExpenseType",
                table: "PersonnelExpense",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "PersonnelExpense",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
        }
    }
}
