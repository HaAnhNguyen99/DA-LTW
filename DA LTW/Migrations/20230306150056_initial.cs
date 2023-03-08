using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DA_LTW.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    sdt = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email_Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.sdt);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    IdTour = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_tour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    People = table.Column<int>(type: "int", nullable: false),
                    Tour_guide = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Difficult = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Started_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.IdTour);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    sdt = table.Column<int>(type: "int", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.sdt);
                    table.ForeignKey(
                        name: "FK_Accounts_Customers_sdt",
                        column: x => x.sdt,
                        principalTable: "Customers",
                        principalColumn: "sdt",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sdt = table.Column<int>(type: "int", nullable: true),
                    IdTour = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Histories_Customers_sdt",
                        column: x => x.sdt,
                        principalTable: "Customers",
                        principalColumn: "sdt");
                    table.ForeignKey(
                        name: "FK_Histories_Tours_IdTour",
                        column: x => x.IdTour,
                        principalTable: "Tours",
                        principalColumn: "IdTour",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Histories_IdTour",
                table: "Histories",
                column: "IdTour");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_sdt",
                table: "Histories",
                column: "sdt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Tours");
        }
    }
}
