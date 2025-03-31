using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assembly.Projecto.Final.Data.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class EntityLinkId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityLinks_Employees_EntityId",
                table: "EntityLinks");

            migrationBuilder.DropIndex(
                name: "IX_EntityLinks_EntityId",
                table: "EntityLinks");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "EntityLinks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_EntityLinks_Employees_Id",
                table: "EntityLinks",
                column: "Id",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityLinks_Employees_Id",
                table: "EntityLinks");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "EntityLinks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_EntityLinks_EntityId",
                table: "EntityLinks",
                column: "EntityId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityLinks_Employees_EntityId",
                table: "EntityLinks",
                column: "EntityId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
