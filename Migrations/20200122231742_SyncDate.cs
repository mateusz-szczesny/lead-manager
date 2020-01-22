using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LeadManager.Migrations
{
    public partial class SyncDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ExternalId",
                table: "Activities",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "SyncDateTime",
                table: "Activities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "SyncDateTime",
                table: "Activities");
        }
    }
}
