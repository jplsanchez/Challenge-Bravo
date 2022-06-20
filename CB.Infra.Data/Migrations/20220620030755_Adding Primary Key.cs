using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CB.Infra.Data.Migrations
{
    public partial class AddingPrimaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LongName",
                table: "Currencies",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LongName",
                table: "Currencies");
        }
    }
}
