using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiRest.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    LstName = table.Column<string>(nullable: true),
                    Cc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficeCod = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    BossName = table.Column<string>(nullable: true),
                    EmailBoss = table.Column<string>(nullable: true),
                    Atms = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    IsOpened = table.Column<bool>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Charge = table.Column<string>(nullable: true),
                    PendingVacations = table.Column<int>(nullable: false),
                    PenultimateVac = table.Column<DateTime>(nullable: false),
                    LastVacation = table.Column<DateTime>(nullable: false),
                    YearsNoVacation = table.Column<double>(nullable: false),
                    Required = table.Column<bool>(nullable: false),
                    ShouldApprove = table.Column<bool>(nullable: false),
                    Approved = table.Column<bool>(nullable: false),
                    OfficeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultants_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clients = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Waiting = table.Column<int>(nullable: false),
                    OfficeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Records_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientConsultants",
                columns: table => new
                {
                    RequestId = table.Column<int>(nullable: false),
                    ConsultantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientConsultants", x => new { x.RequestId, x.ConsultantId });
                    table.ForeignKey(
                        name: "FK_ClientConsultants_Consultants_ConsultantId",
                        column: x => x.ConsultantId,
                        principalTable: "Consultants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientConsultants_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientConsultants_ConsultantId",
                table: "ClientConsultants",
                column: "ConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultants_OfficeId",
                table: "Consultants",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_OfficeId",
                table: "Records",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ClientId",
                table: "Requests",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientConsultants");

            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "Consultants");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
