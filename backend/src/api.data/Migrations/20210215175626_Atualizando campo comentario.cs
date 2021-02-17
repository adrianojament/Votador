using Microsoft.EntityFrameworkCore.Migrations;

namespace api.data.Migrations
{
    public partial class Atualizandocampocomentario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "comentario",
                table: "votos",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "comentario",
                table: "votos");
        }
    }
}
