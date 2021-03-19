using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NationalDrivingLicense.Migrations
{
    public partial class add_username : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverLicences_AspNetUsers_ApplicationUserId1",
                table: "DriverLicences");

            migrationBuilder.DropIndex(
                name: "IX_DriverLicences_ApplicationUserId1",
                table: "DriverLicences");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "DriverLicences");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "DriverLicences",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "DriverLicences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DriverLicences_ApplicationUserId",
                table: "DriverLicences",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverLicences_AspNetUsers_ApplicationUserId",
                table: "DriverLicences",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverLicences_AspNetUsers_ApplicationUserId",
                table: "DriverLicences");

            migrationBuilder.DropIndex(
                name: "IX_DriverLicences_ApplicationUserId",
                table: "DriverLicences");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "DriverLicences");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "DriverLicences",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "DriverLicences",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DriverLicences_ApplicationUserId1",
                table: "DriverLicences",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_DriverLicences_AspNetUsers_ApplicationUserId1",
                table: "DriverLicences",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
