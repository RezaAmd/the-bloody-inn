using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheBloodyInn.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitGameTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                schema: "identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsBanned",
                schema: "identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsEmailConfirmed",
                schema: "identity",
                table: "Users");

            migrationBuilder.EnsureSchema(
                name: "Game");

            migrationBuilder.EnsureSchema(
                name: "Auth");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "identity",
                newName: "Users",
                newSchema: "Auth");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Auth",
                table: "Users",
                newName: "Nickname");

            migrationBuilder.CreateTable(
                name: "Innkeepers",
                schema: "Game",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    Cash = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)0),
                    CheckMoney = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)0),
                    PlayerTypeId = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Innkeepers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inns",
                schema: "Game",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaxPlayerCount = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    StateId = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Setting = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inns_Innkeepers_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Game",
                        principalTable: "Innkeepers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InnRooms",
                schema: "Game",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    InnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InnKeeperId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InnRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InnRooms_Innkeepers_InnKeeperId",
                        column: x => x.InnKeeperId,
                        principalSchema: "Game",
                        principalTable: "Innkeepers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InnRooms_Inns_InnId",
                        column: x => x.InnId,
                        principalSchema: "Game",
                        principalTable: "Inns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InnRooms_InnId",
                schema: "Game",
                table: "InnRooms",
                column: "InnId");

            migrationBuilder.CreateIndex(
                name: "IX_InnRooms_InnKeeperId",
                schema: "Game",
                table: "InnRooms",
                column: "InnKeeperId");

            migrationBuilder.CreateIndex(
                name: "IX_Inns_CreatorId",
                schema: "Game",
                table: "Inns",
                column: "CreatorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InnRooms",
                schema: "Game");

            migrationBuilder.DropTable(
                name: "Inns",
                schema: "Game");

            migrationBuilder.DropTable(
                name: "Innkeepers",
                schema: "Game");

            migrationBuilder.EnsureSchema(
                name: "identity");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "Auth",
                newName: "Users",
                newSchema: "identity");

            migrationBuilder.RenameColumn(
                name: "Nickname",
                schema: "identity",
                table: "Users",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "identity",
                table: "Users",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsBanned",
                schema: "identity",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEmailConfirmed",
                schema: "identity",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                schema: "identity",
                table: "Users",
                column: "Email",
                unique: true);
        }
    }
}
