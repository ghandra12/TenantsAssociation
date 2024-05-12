using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TenantsAssociation.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedPasswordSaltForHashing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PaswordSalt",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaswordSalt",
                table: "Users");
        }
    }
}
