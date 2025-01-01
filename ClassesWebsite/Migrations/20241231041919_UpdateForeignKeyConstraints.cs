using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassesWebsite.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForeignKeyConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
    name: "FK_Cities_States_StateId",
    table: "Cities",
    column: "StateId",
    principalTable: "States",
    principalColumn: "Id",
    onDelete: ReferentialAction.NoAction);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
