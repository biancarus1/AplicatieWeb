using Microsoft.EntityFrameworkCore.Migrations;


namespace AplicatieWeb.Migrations
{
    public partial class AppointmentService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HairstylistID",
                table: "Appointment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Hairstylist",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeHairstylist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrenumeHairstylist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experienta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hairstylist", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentService",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointemntID = table.Column<int>(type: "int", nullable: false),
                    AppointmentID = table.Column<int>(type: "int", nullable: true),
                    ServiceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentService", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AppointmentService_Appointment_AppointmentID",
                        column: x => x.AppointmentID,
                        principalTable: "Appointment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppointmentService_Service_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "Service",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_HairstylistID",
                table: "Appointment",
                column: "HairstylistID");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentService_AppointmentID",
                table: "AppointmentService",
                column: "AppointmentID");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentService_ServiceID",
                table: "AppointmentService",
                column: "ServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Hairstylist_HairstylistID",
                table: "Appointment",
                column: "HairstylistID",
                principalTable: "Hairstylist",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Hairstylist_HairstylistID",
                table: "Appointment");

            migrationBuilder.DropTable(
                name: "AppointmentService");

            migrationBuilder.DropTable(
                name: "Hairstylist");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_HairstylistID",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "HairstylistID",
                table: "Appointment");
        }
    }
}
