using Microsoft.EntityFrameworkCore.Migrations;

namespace DynaParseWebsite.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Correspondence",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ref = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    Re = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Correspondence", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GraveGrant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Applicant = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    Cemetery = table.Column<string>(nullable: true),
                    No = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Receipt = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraveGrant", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Correspondence");

            migrationBuilder.DropTable(
                name: "GraveGrant");
        }
    }
}
