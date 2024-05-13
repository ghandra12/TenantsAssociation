using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TenantsAssociation.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePollNamings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PollAnswer_Polls_PollId",
                table: "PollAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PollAnswer",
                table: "PollAnswer");

            migrationBuilder.RenameTable(
                name: "PollAnswer",
                newName: "Answers");

            migrationBuilder.RenameIndex(
                name: "IX_PollAnswer_PollId",
                table: "Answers",
                newName: "IX_Answers_PollId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answers",
                table: "Answers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Polls_PollId",
                table: "Answers",
                column: "PollId",
                principalTable: "Polls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Polls_PollId",
                table: "Answers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answers",
                table: "Answers");

            migrationBuilder.RenameTable(
                name: "Answers",
                newName: "PollAnswer");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_PollId",
                table: "PollAnswer",
                newName: "IX_PollAnswer_PollId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PollAnswer",
                table: "PollAnswer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PollAnswer_Polls_PollId",
                table: "PollAnswer",
                column: "PollId",
                principalTable: "Polls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
