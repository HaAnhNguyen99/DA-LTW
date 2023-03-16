using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DA_LTW.Migrations
{
    /// <inheritdoc />
    public partial class addtotaldayTour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalDay",
                table: "Tours",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalDay",
                table: "Tours");
        }
    }
}
