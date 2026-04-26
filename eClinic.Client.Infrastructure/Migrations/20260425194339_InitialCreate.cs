using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eClinic.Client.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "client");

            migrationBuilder.CreateTable(
                name: "Clients",
                schema: "client",
                columns: table => new
                {
                    ClienteId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Birtdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Complement = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Clients_P01", x => x.ClienteId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClienteId",
                schema: "client",
                table: "Clients",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Cpf",
                schema: "client",
                table: "Clients",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_PublicId",
                schema: "client",
                table: "Clients",
                column: "PublicId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients",
                schema: "client");
        }
    }
}
