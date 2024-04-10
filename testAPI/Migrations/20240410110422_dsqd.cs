using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testAPI.Migrations
{
    /// <inheritdoc />
    public partial class dsqd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Clients_ClientId1",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ClientId1",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ClientId1",
                table: "Clients");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId1",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 1,
                column: "ClientId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 2,
                column: "ClientId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 3,
                column: "ClientId1",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientId1",
                table: "Clients",
                column: "ClientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Clients_ClientId1",
                table: "Clients",
                column: "ClientId1",
                principalTable: "Clients",
                principalColumn: "ClientId");
        }
    }
}
