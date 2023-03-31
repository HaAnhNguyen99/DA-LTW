using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DA_LTW.Migrations
{
    /// <inheritdoc />
    public partial class adddetailforTour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Detail",
                table: "Tours",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detail",
                table: "Tours");
        }
    }
}
