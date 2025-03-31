using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assembly.Projecto.Final.Data.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class EntityLinkIdNovamente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "IX_Employees_EntityLinkId",
                table: "Employees",
                column: "EntityLinkId",
                unique: true,
                filter: "[EntityLinkId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EntityLinks_EntityLinkId",
                table: "Employees",
                column: "EntityLinkId",
                principalTable: "EntityLinks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EntityLinks_EntityLinkId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EntityLinkId",
                table: "Employees");

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
    }
}
