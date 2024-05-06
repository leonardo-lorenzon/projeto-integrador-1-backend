using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Infrastructure.Migrations;

/// <inheritdoc />
public partial class CreateServicesTable : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Services",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                AccountId = table.Column<Guid>(type: "uuid", nullable: false),
                Type = table.Column<string>(type: "varchar(30)", nullable: false),
                Description = table.Column<string>(type: "text", nullable: false),
                City = table.Column<string>(type: "varchar(40)", nullable: false),
                State = table.Column<string>(type: "varchar(30)", nullable: false),
                Country = table.Column<string>(type: "varchar(20)", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_Services", x => x.Id));

        migrationBuilder.CreateIndex(
            name: "IX_Services_City",
            table: "Services",
            column: "City");

        migrationBuilder.CreateIndex(
            name: "IX_Services_Type",
            table: "Services",
            column: "Type");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Services");
    }
}
