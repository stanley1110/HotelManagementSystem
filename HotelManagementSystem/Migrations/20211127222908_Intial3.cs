using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagementSystem.Migrations
{
    public partial class Intial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guest_RoomStore_RoomStoreId",
                table: "Guest");

            migrationBuilder.DropForeignKey(
                name: "FK_Guest_Staff_CreatedByAgentID",
                table: "Guest");

            migrationBuilder.DropForeignKey(
                name: "FK_Guest_SuperAdmin_CreatedByAdminID",
                table: "Guest");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_SuperAdmin_ApprovedOrRejectedByAdminId",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_User_UserID",
                table: "Staff");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Staff_ApprovedOrRejectedByAdminId",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Staff_UserID",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Guest_CreatedByAdminID",
                table: "Guest");

            migrationBuilder.DropIndex(
                name: "IX_Guest_CreatedByAgentID",
                table: "Guest");

            migrationBuilder.DropIndex(
                name: "IX_Guest_RoomStoreId",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "ApprovalOrRejectedDate",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "ApprovedOrRejectedByAdminId",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "IsAssigned",
                table: "RoomStore");

            migrationBuilder.DropColumn(
                name: "RoomNo",
                table: "RoomStore");

            migrationBuilder.DropColumn(
                name: "CreatedByAdminID",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "CreatedByAgentID",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "RoomRervationId",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "RoomStoreId",
                table: "Guest");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Staff",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "RoomStore",
                newName: "RoomImages");

            migrationBuilder.RenameColumn(
                name: "IsBlacklisted",
                table: "RoomStore",
                newName: "Available");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "SuperAdmin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovalAdmin",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Staff",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Staff",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNo",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "RoomStore",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "RoomStore",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RoomStore",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "RoomStore",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNo",
                table: "Guest",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Guest",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Guest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Guest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Room = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuestID = table.Column<int>(type: "int", nullable: true),
                    GuestsId = table.Column<long>(type: "bigint", nullable: true),
                    Completed = table.Column<bool>(type: "bit", nullable: false),
                    RoomStoreId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Guest_GuestsId",
                        column: x => x.GuestsId,
                        principalTable: "Guest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_RoomStore_RoomStoreId",
                        column: x => x.RoomStoreId,
                        principalTable: "RoomStore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_GuestsId",
                table: "Bookings",
                column: "GuestsId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomStoreId",
                table: "Bookings",
                column: "RoomStoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "SuperAdmin");

            migrationBuilder.DropColumn(
                name: "ApprovalAdmin",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "PhoneNo",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "RoomStore");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "RoomStore");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "RoomStore");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "RoomStore");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Guest");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Staff",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "RoomImages",
                table: "RoomStore",
                newName: "Picture");

            migrationBuilder.RenameColumn(
                name: "Available",
                table: "RoomStore",
                newName: "IsBlacklisted");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovalOrRejectedDate",
                table: "Staff",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ApprovedOrRejectedByAdminId",
                table: "Staff",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Staff",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserID",
                table: "Staff",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAssigned",
                table: "RoomStore",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RoomNo",
                table: "RoomStore",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNo",
                table: "Guest",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Guest",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedByAdminID",
                table: "Guest",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedByAgentID",
                table: "Guest",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RoomRervationId",
                table: "Guest",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RoomStoreId",
                table: "Guest",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Staff_ApprovedOrRejectedByAdminId",
                table: "Staff",
                column: "ApprovedOrRejectedByAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_UserID",
                table: "Staff",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Guest_CreatedByAdminID",
                table: "Guest",
                column: "CreatedByAdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Guest_CreatedByAgentID",
                table: "Guest",
                column: "CreatedByAgentID");

            migrationBuilder.CreateIndex(
                name: "IX_Guest_RoomStoreId",
                table: "Guest",
                column: "RoomStoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guest_RoomStore_RoomStoreId",
                table: "Guest",
                column: "RoomStoreId",
                principalTable: "RoomStore",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guest_Staff_CreatedByAgentID",
                table: "Guest",
                column: "CreatedByAgentID",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guest_SuperAdmin_CreatedByAdminID",
                table: "Guest",
                column: "CreatedByAdminID",
                principalTable: "SuperAdmin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_SuperAdmin_ApprovedOrRejectedByAdminId",
                table: "Staff",
                column: "ApprovedOrRejectedByAdminId",
                principalTable: "SuperAdmin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_User_UserID",
                table: "Staff",
                column: "UserID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
