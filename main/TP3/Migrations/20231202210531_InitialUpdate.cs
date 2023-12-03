using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TP3.Migrations
{
    /// <inheritdoc />
    public partial class InitialUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    GenreName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Genres__3214EC276607FD67", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MembershipTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    SignUpFee = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DurationInMonths = table.Column<int>(type: "int", nullable: false),
                    DiscountRate = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Membersh__3214EC27A0C96EC1", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Genre_id = table.Column<int>(type: "int", nullable: true),
                    MovieAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Movie__3214EC27516FDD57", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Movie__Genre_id__2B3F6F97",
                        column: x => x.Genre_id,
                        principalTable: "Genres",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    membershiptype = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__3214EC273BF1F3D1", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Customers__membe__2E1BDC42",
                        column: x => x.membershiptype,
                        principalTable: "MembershipTypes",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "ID", "GenreName" },
                values: new object[,]
                {
                    { 22, "GenreFromJsonFile1" },
                    { 23, "GenreFromJsonFile2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_membershiptype",
                table: "Customers",
                column: "membershiptype");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Genre_id",
                table: "Movie",
                column: "Genre_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "MembershipTypes");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
