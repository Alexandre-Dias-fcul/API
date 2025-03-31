using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assembly.Projecto.Final.Data.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class deleteEntityLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityLinks_Employees_EntityId",
                table: "EntityLinks");

            migrationBuilder.AddForeignKey(
                name: "FK_EntityLinks_Employees_EntityId",
                table: "EntityLinks",
                column: "EntityId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityLinks_Employees_EntityId",
                table: "EntityLinks");

            migrationBuilder.AddForeignKey(
                name: "FK_EntityLinks_Employees_EntityId",
                table: "EntityLinks",
                column: "EntityId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
