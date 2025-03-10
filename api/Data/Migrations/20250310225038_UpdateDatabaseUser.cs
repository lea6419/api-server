using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class UpdateDatabaseUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_UserId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Backups",
                table: "Backups");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProgressId",
                table: "Progresses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Customers",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Customers",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                newName: "IX_Customers_userId");

            migrationBuilder.AlterColumn<int>(
                name: "BackupId",
                table: "Backups",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Backups",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Backups",
                table: "Backups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_userId",
                table: "Customers",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_userId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Backups",
                table: "Backups");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Backups");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Progresses",
                newName: "ProgressId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Customers",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customers",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_userId",
                table: "Customers",
                newName: "IX_Customers_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "BackupId",
                table: "Backups",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Backups",
                table: "Backups",
                column: "BackupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_UserId",
                table: "Customers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
