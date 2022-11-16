using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelloMvc.Migrations
{
    public partial class seed_holiday_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "HolidayCode", "DisplayName" },
                values: new object[,]
                {
                    { "CD", "Columbus Day" },
                    { "CM", "Christmas" },
                    { "ID", "Independence Day" },
                    { "JTTH", "Juneteenth" },
                    { "LD", "Labor Day" },
                    { "MD", "Memorial Day" },
                    { "MLKJD", "Martin Luther King Jr. Day" },
                    { "NYD", "New Year's Day" },
                    { "TG", "Thanksgiving" },
                    { "VD", "Veterans Day" },
                    { "WB", "Washington's Birthday" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "HolidayCode",
                keyValue: "CD");

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "HolidayCode",
                keyValue: "CM");

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "HolidayCode",
                keyValue: "ID");

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "HolidayCode",
                keyValue: "JTTH");

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "HolidayCode",
                keyValue: "LD");

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "HolidayCode",
                keyValue: "MD");

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "HolidayCode",
                keyValue: "MLKJD");

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "HolidayCode",
                keyValue: "NYD");

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "HolidayCode",
                keyValue: "TG");

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "HolidayCode",
                keyValue: "VD");

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "HolidayCode",
                keyValue: "WB");
        }
    }
}
