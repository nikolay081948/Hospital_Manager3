using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data_Hospital_Manager.Migrations
{
    /// <inheritdoc />
    public partial class conf1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Address", "BedsCount", "CreatedOn", "Email", "IsDeleted", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Казанлък", 200, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "hospital1@gmail.com", false, "МБАЛ Казанлък", "0888123456" },
                    { 2, "Стара Загора", 350, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "hospital2@gmail.com", false, "УМБАЛ Стара Загора", "0888123457" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
