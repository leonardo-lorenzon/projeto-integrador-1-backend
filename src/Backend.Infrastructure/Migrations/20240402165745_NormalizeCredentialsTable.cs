using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Infrastructure.Migrations;

/// <inheritdoc />
public partial class NormalizeCredentialsTable : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable("Credentials");

        migrationBuilder.CreateTable(
            name: "Credentials",
            columns: table => new
            {
                UserId = table.Column<Guid>(type: "uuid", nullable: false),
                HashedPassword = table.Column<string>(type: "varchar(100)", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_Credentials", x => x.UserId));
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable("Credentials");

        migrationBuilder.CreateTable(
            name: "Credentials",
            columns: table => new
            {
                Email = table.Column<string>(type: "varchar(50)", nullable: false),
                HashedPassword = table.Column<string>(type: "varchar(100)", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_Credentials", x => x.Email));
    }
}
