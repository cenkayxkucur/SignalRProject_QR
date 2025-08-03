using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_slider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    SliderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SliderTitle1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SliderTitle2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SliderTitle3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SliderDescription1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SliderDescription2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SliderDescription3 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.SliderID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sliders");
        }
    }
}
