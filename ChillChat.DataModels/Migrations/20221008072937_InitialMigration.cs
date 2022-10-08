using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ChillChat.DataModels.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    ServerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ObjectInfo_Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    ObjectInfo_Creator = table.Column<string>(type: "text", nullable: false),
                    ObjectInfo_Modifier = table.Column<string>(type: "text", nullable: false),
                    ObjectInfo_Modified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ObjectInfo_Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.ServerId);
                });

            migrationBuilder.CreateTable(
                name: "Channels",
                columns: table => new
                {
                    ChannelId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ChannelType = table.Column<byte>(type: "smallint", nullable: false),
                    ServerId = table.Column<int>(type: "integer", nullable: false),
                    ObjectInfo_Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    ObjectInfo_Creator = table.Column<string>(type: "text", nullable: false),
                    ObjectInfo_Modifier = table.Column<string>(type: "text", nullable: false),
                    ObjectInfo_Modified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ObjectInfo_Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channels", x => x.ChannelId);
                    table.ForeignKey(
                        name: "FK_Channels_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "ServerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: false),
                    ChannelId = table.Column<int>(type: "integer", nullable: true),
                    ObjectInfo_Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    ObjectInfo_Creator = table.Column<string>(type: "text", nullable: false),
                    ObjectInfo_Modifier = table.Column<string>(type: "text", nullable: false),
                    ObjectInfo_Modified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ObjectInfo_Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_Channels_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Channels",
                        principalColumn: "ChannelId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Channels_ServerId",
                table: "Channels",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChannelId",
                table: "Messages",
                column: "ChannelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Channels");

            migrationBuilder.DropTable(
                name: "Servers");
        }
    }
}
