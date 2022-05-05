using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SectraDataApp.Migrations
{
    public partial class AddSiteInfoToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SiteInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cmpid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nameofsoftware = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    versionpatch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hostgroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    root = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteInfos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiteInfos");
        }
    }
}
