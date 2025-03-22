using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assembly.Projecto.Final.Data.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class descriminator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EntityLinks_EntityId",
                table: "EntityLinks");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Appointments",
                newName: "Title");

            migrationBuilder.AlterColumn<int>(
                name: "EntityId",
                table: "EntityLinks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Appointments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_EntityLinks_EntityId",
                table: "EntityLinks",
                column: "EntityId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EntityLinks_EntityId",
                table: "EntityLinks");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Appointments",
                newName: "Type");

            migrationBuilder.AlterColumn<int>(
                name: "EntityId",
                table: "EntityLinks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_EntityLinks_EntityId",
                table: "EntityLinks",
                column: "EntityId",
                unique: true,
                filter: "[EntityId] IS NOT NULL");
        }
    }
}
