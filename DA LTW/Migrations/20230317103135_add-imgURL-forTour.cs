using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DA_LTW.Migrations
{
    /// <inheritdoc />
    public partial class addimgURLforTour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgURL",
                table: "Tours",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgURL",
                table: "Tours");
        }
    }
}
