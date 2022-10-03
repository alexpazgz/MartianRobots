using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class DBInitialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Surface",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    XCoordinate = table.Column<int>(type: "int", nullable: false),
                    YCoordinate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surface", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExploredSurface",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurfaceId = table.Column<int>(type: "int", nullable: false),
                    XCoordinate = table.Column<int>(type: "int", nullable: false),
                    YCoordinate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExploredSurface", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExploredSurface_Surface_SurfaceId",
                        column: x => x.SurfaceId,
                        principalTable: "Surface",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Robot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Instruction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurfaceId = table.Column<int>(type: "int", nullable: false),
                    Orientation = table.Column<int>(type: "int", nullable: false),
                    XCoordinate = table.Column<int>(type: "int", nullable: false),
                    YCoordinate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Robot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Robot_Surface_SurfaceId",
                        column: x => x.SurfaceId,
                        principalTable: "Surface",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Output",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lost = table.Column<bool>(type: "bit", nullable: false),
                    RobotId = table.Column<int>(type: "int", nullable: false),
                    Orientation = table.Column<int>(type: "int", nullable: false),
                    XCoordinate = table.Column<int>(type: "int", nullable: false),
                    YCoordinate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Output", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Output_Robot_RobotId",
                        column: x => x.RobotId,
                        principalTable: "Robot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExploredSurface_SurfaceId",
                table: "ExploredSurface",
                column: "SurfaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Output_RobotId",
                table: "Output",
                column: "RobotId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Robot_SurfaceId",
                table: "Robot",
                column: "SurfaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExploredSurface");

            migrationBuilder.DropTable(
                name: "Output");

            migrationBuilder.DropTable(
                name: "Robot");

            migrationBuilder.DropTable(
                name: "Surface");
        }
    }
}
