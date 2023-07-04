using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsanKaynaklari.Persistence.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "PersonnelId",
                table: "PersonnelExpense");

            migrationBuilder.AlterColumn<int>(
                name: "ApprovalStatus",
                table: "PersonnelExpense",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "ApprovalStatus",
                table: "PersonnelExpense",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "PersonnelId",
                table: "PersonnelExpense",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
