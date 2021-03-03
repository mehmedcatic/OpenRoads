using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace openRoadsWebAPI.Migrations
{
    public partial class SetTheDBModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRoles",
                columns: table => new
                {
                    EmployeeRolesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRoles", x => x.EmployeeRolesId);
                });

            migrationBuilder.CreateTable(
                name: "Insurance",
                columns: table => new
                {
                    InsuranceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurance", x => x.InsuranceId);
                });

            migrationBuilder.CreateTable(
                name: "LoginData",
                columns: table => new
                {
                    LoginDataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginData", x => x.LoginDataId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleCategory",
                columns: table => new
                {
                    VehicleCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleCategory", x => x.VehicleCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleFuelType",
                columns: table => new
                {
                    VehicleFuelTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleFuelType", x => x.VehicleFuelTypeId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleManufacturer",
                columns: table => new
                {
                    VehicleManufacturerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleManufacturer", x => x.VehicleManufacturerId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTransmissionType",
                columns: table => new
                {
                    VehicleTransmissionTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTransmissionType", x => x.VehicleTransmissionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.VehicleTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZIPCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkingHoursFrom = table.Column<int>(type: "int", nullable: false),
                    WorkingHoursTo = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.BranchId);
                    table.ForeignKey(
                        name: "FK_Branch_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginDataId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Person_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Person_LoginData_LoginDataId",
                        column: x => x.LoginDataId,
                        principalTable: "LoginData",
                        principalColumn: "LoginDataId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModel",
                columns: table => new
                {
                    VehicleModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleManufacturerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModel", x => x.VehicleModelId);
                    table.ForeignKey(
                        name: "FK_VehicleModel_VehicleManufacturer_VehicleManufacturerId",
                        column: x => x.VehicleManufacturerId,
                        principalTable: "VehicleManufacturer",
                        principalColumn: "VehicleManufacturerId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Client_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Employee_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturedYear = table.Column<int>(type: "int", nullable: false),
                    PowerInHp = table.Column<int>(type: "int", nullable: false),
                    DoorsCount = table.Column<int>(type: "int", nullable: false),
                    SeatsCount = table.Column<int>(type: "int", nullable: false),
                    PriceByDay = table.Column<float>(type: "real", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PictureThumb = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false),
                    VehicleCategoryId = table.Column<int>(type: "int", nullable: false),
                    VehicleModelId = table.Column<int>(type: "int", nullable: false),
                    VehicleFuelTypeId = table.Column<int>(type: "int", nullable: false),
                    VehicleTransmissionTypeId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicle_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleCategory_VehicleCategoryId",
                        column: x => x.VehicleCategoryId,
                        principalTable: "VehicleCategory",
                        principalColumn: "VehicleCategoryId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleFuelType_VehicleFuelTypeId",
                        column: x => x.VehicleFuelTypeId,
                        principalTable: "VehicleFuelType",
                        principalColumn: "VehicleFuelTypeId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleModel_VehicleModelId",
                        column: x => x.VehicleModelId,
                        principalTable: "VehicleModel",
                        principalColumn: "VehicleModelId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleTransmissionType_VehicleTransmissionTypeId",
                        column: x => x.VehicleTransmissionTypeId,
                        principalTable: "VehicleTransmissionType",
                        principalColumn: "VehicleTransmissionTypeId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleType_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleType",
                        principalColumn: "VehicleTypeId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEmployeeRoles",
                columns: table => new
                {
                    EmployeeEmployeeRolesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeRolesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEmployeeRoles", x => x.EmployeeEmployeeRolesId);
                    table.ForeignKey(
                        name: "FK_EmployeeEmployeeRoles_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmployeeEmployeeRoles_EmployeeRoles_EmployeeRolesId",
                        column: x => x.EmployeeRolesId,
                        principalTable: "EmployeeRoles",
                        principalColumn: "EmployeeRolesId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Canceled = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    InsuranceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservation_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Reservation_Insurance_InsuranceId",
                        column: x => x.InsuranceId,
                        principalTable: "Insurance",
                        principalColumn: "InsuranceId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Reservation_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    RatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingInt = table.Column<int>(type: "int", nullable: false),
                    RatingString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_Rating_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Rating_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "ReservationId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Rating_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branch_CountryId",
                table: "Branch",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_PersonId",
                table: "Client",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_BranchId",
                table: "Employee",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PersonId",
                table: "Employee",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEmployeeRoles_EmployeeId",
                table: "EmployeeEmployeeRoles",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEmployeeRoles_EmployeeRolesId",
                table: "EmployeeEmployeeRoles",
                column: "EmployeeRolesId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_CountryId",
                table: "Person",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_LoginDataId",
                table: "Person",
                column: "LoginDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ClientId",
                table: "Rating",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ReservationId",
                table: "Rating",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_VehicleId",
                table: "Rating",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ClientId",
                table: "Reservation",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_InsuranceId",
                table: "Reservation",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_VehicleId",
                table: "Reservation",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_BranchId",
                table: "Vehicle",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleCategoryId",
                table: "Vehicle",
                column: "VehicleCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleFuelTypeId",
                table: "Vehicle",
                column: "VehicleFuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleModelId",
                table: "Vehicle",
                column: "VehicleModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleTransmissionTypeId",
                table: "Vehicle",
                column: "VehicleTransmissionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleTypeId",
                table: "Vehicle",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModel_VehicleManufacturerId",
                table: "VehicleModel",
                column: "VehicleManufacturerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeEmployeeRoles");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "EmployeeRoles");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Insurance");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "VehicleCategory");

            migrationBuilder.DropTable(
                name: "VehicleFuelType");

            migrationBuilder.DropTable(
                name: "VehicleModel");

            migrationBuilder.DropTable(
                name: "VehicleTransmissionType");

            migrationBuilder.DropTable(
                name: "VehicleType");

            migrationBuilder.DropTable(
                name: "LoginData");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "VehicleManufacturer");
        }
    }
}
