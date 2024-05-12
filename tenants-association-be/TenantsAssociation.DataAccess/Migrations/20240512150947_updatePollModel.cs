using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TenantsAssociation.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updatePollModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PollAnswer_Polls_PollId",
                table: "PollAnswer");

            migrationBuilder.AlterColumn<int>(
                name: "PollId",
                table: "PollAnswer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PollAnswer_Polls_PollId",
                table: "PollAnswer",
                column: "PollId",
                principalTable: "Polls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PollAnswer_Polls_PollId",
                table: "PollAnswer");

            migrationBuilder.AlterColumn<int>(
                name: "PollId",
                table: "PollAnswer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PollAnswer_Polls_PollId",
                table: "PollAnswer",
                column: "PollId",
                principalTable: "Polls",
                principalColumn: "Id");
        }
    }
}
