using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Infrastructure.Migrations;

/// <inheritdoc />
public partial class CreateTokensTable : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Tokens",
            columns: table => new
            {
                Token = table.Column<string>(type: "text", nullable: false),
                UserId = table.Column<Guid>(type: "uuid", nullable: false),
                RefreshToken = table.Column<string>(type: "text", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_Tokens", x => x.Token));

        migrationBuilder.CreateIndex(
            name: "IX_Tokens_RefreshToken",
            table: "Tokens",
            column: "RefreshToken");

        migrationBuilder.CreateIndex(
            name: "IX_Tokens_UserId",
            table: "Tokens",
            column: "UserId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Tokens");
    }
}
