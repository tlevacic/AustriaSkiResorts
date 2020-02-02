using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AustriaSkiResorts.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "resort",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true),
                    length = table.Column<float>(nullable: false),
                    height = table.Column<float>(nullable: false),
                    price = table.Column<int>(nullable: false),
                    snowRange = table.Column<string>(nullable: true),
                    shortInfo = table.Column<string>(nullable: true),
                    longInfo = table.Column<string>(nullable: true),
                    urlPicture = table.Column<string>(nullable: true),
                    availableNumberOfTermins = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resort", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "resort");
        }
    }
}
