using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TenantsAssociation.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class modifiedUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApartmentNumber",
                table: "Users",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApartmentNumber",
                table: "Users");
        }
    }
}
