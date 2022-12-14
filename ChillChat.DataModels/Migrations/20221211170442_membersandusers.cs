using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ChillChat.DataModels.Migrations
{
    /// <inheritdoc />
    public partial class membersandusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Messages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DisplayName = table.Column<string>(type: "text", nullable: false),
                    ObjectInfoDeleted = table.Column<bool>(name: "ObjectInfo_Deleted", type: "boolean", nullable: false),
                    ObjectInfoCreator = table.Column<string>(name: "ObjectInfo_Creator", type: "text", nullable: false),
                    ObjectInfoModifier = table.Column<string>(name: "ObjectInfo_Modifier", type: "text", nullable: false),
                    ObjectInfoModified = table.Column<ZonedDateTime>(name: "ObjectInfo_Modified", type: "timestamp with time zone", nullable: false),
                    ObjectInfoCreated = table.Column<ZonedDateTime>(name: "ObjectInfo_Created", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DisplayName = table.Column<string>(type: "text", nullable: false),
                    ServerId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ObjectInfoDeleted = table.Column<bool>(name: "ObjectInfo_Deleted", type: "boolean", nullable: false),
                    ObjectInfoCreator = table.Column<string>(name: "ObjectInfo_Creator", type: "text", nullable: false),
                    ObjectInfoModifier = table.Column<string>(name: "ObjectInfo_Modifier", type: "text", nullable: false),
                    ObjectInfoModified = table.Column<ZonedDateTime>(name: "ObjectInfo_Modified", type: "timestamp with time zone", nullable: false),
                    ObjectInfoCreated = table.Column<ZonedDateTime>(name: "ObjectInfo_Created", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Member_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "ServerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Member_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MemberId",
                table: "Messages",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_ServerId",
                table: "Member",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_UserId",
                table: "Member",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Member_MemberId",
                table: "Messages",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);


            migrationBuilder.Sql(@"
INSERT INTO public.""User"" 
(""Name"", 
""DisplayName"", 
""ObjectInfo_Deleted"",
""ObjectInfo_Creator"",
""ObjectInfo_Modifier"",
""ObjectInfo_Modified"",
""ObjectInfo_Created"") 
VALUES('Test', 'Test', false, 'Test', 'Test', '2022-12-14 20:03:35.000', '2022-12-14 20:03:35.000');

INSERT INTO public.""Servers""
(""Name"", 
""ObjectInfo_Deleted"", 
""ObjectInfo_Creator"",
""ObjectInfo_Modifier"", 
""ObjectInfo_Modified"", 
""ObjectInfo_Created"") 
VALUES('TestServer', false, 'Test', 'Test', '2022-12-14 20:23:46.000', '2022-12-14 20:23:46.000');

INSERT INTO public.""Member""
(""DisplayName"", 
""ServerId"", 
""UserId"", 
""ObjectInfo_Deleted"", 
""ObjectInfo_Creator"", 
""ObjectInfo_Modifier"",
""ObjectInfo_Modified"", 
""ObjectInfo_Created"") 
VALUES('Test', 1, 1, false, 'test', 'test', '2022-12-14 20:23:46.000', '2022-12-14 20:23:46.000');


");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Member_MemberId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Messages_MemberId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Messages");
        }
    }
}
