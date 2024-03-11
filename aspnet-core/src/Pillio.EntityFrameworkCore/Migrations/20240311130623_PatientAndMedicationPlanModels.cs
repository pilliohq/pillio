using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pillio.Migrations
{
    /// <inheritdoc />
    public partial class PatientAndMedicationPlanModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MedicationOrderId",
                table: "CloudFiles",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PatientVisitId",
                table: "CloudFiles",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationId",
                table: "AbpTenants",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "AbpTenants",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InsuranceCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: true),
                    FreeOfCharge = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nurses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    StationId = table.Column<Guid>(type: "uuid", nullable: true),
                    WorkingFromTime = table.Column<TimeSpan>(type: "interval", nullable: true),
                    WorkingToTime = table.Column<TimeSpan>(type: "interval", nullable: true),
                    IsLeadNurse = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nurses_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PZN = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PrescriptionRequired = table.Column<bool>(type: "boolean", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    PackageSize = table.Column<int>(type: "integer", nullable: false),
                    Formulation = table.Column<int>(type: "integer", nullable: false),
                    Provider = table.Column<string>(type: "text", nullable: true),
                    ActiveIngredients = table.Column<string>(type: "text", nullable: true),
                    Excipients = table.Column<string>(type: "text", nullable: true),
                    Other = table.Column<string>(type: "text", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimePlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: true),
                    WakeupTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    SleepTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    DosingSchedule1Value = table.Column<TimeSpan>(type: "interval", nullable: false),
                    DosingSchedule2Value = table.Column<TimeSpan>(type: "interval", nullable: false),
                    DosingSchedule3Value = table.Column<TimeSpan>(type: "interval", nullable: false),
                    DosingSchedule4 = table.Column<TimeSpan>(type: "interval", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimePlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    DoB = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    HeightInCm = table.Column<int>(type: "integer", nullable: false),
                    WeightInKg = table.Column<int>(type: "integer", nullable: false),
                    WeightInKgIncrease = table.Column<float>(type: "real", nullable: false),
                    StreetAndHouseNumber = table.Column<string>(type: "text", nullable: true),
                    AdditionalInformation = table.Column<string>(type: "text", nullable: true),
                    UseAsDeliveryAddress = table.Column<bool>(type: "boolean", nullable: false),
                    City = table.Column<string>(type: "text", nullable: true),
                    PostalCode = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    CareHomeId = table.Column<Guid>(type: "uuid", nullable: true),
                    PharmacyId = table.Column<Guid>(type: "uuid", nullable: true),
                    DoctorOfficeId = table.Column<Guid>(type: "uuid", nullable: true),
                    InsuranceCardId = table.Column<Guid>(type: "uuid", nullable: true),
                    TimePlanId = table.Column<Guid>(type: "uuid", nullable: true),
                    StationId = table.Column<Guid>(type: "uuid", nullable: true),
                    AvatarId = table.Column<Guid>(type: "uuid", nullable: true),
                    LeadNurseId = table.Column<Guid>(type: "uuid", nullable: true),
                    FamilyRelationship = table.Column<string>(type: "text", nullable: true),
                    FamilyFirstName = table.Column<string>(type: "text", nullable: true),
                    FamilyLastName = table.Column<string>(type: "text", nullable: true),
                    FamilyPhone = table.Column<string>(type: "text", nullable: true),
                    FamilyEmail = table.Column<string>(type: "text", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_CareHomes_CareHomeId",
                        column: x => x.CareHomeId,
                        principalTable: "CareHomes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_CloudFiles_AvatarId",
                        column: x => x.AvatarId,
                        principalTable: "CloudFiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_DoctorOffices_DoctorOfficeId",
                        column: x => x.DoctorOfficeId,
                        principalTable: "DoctorOffices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_InsuranceCards_InsuranceCardId",
                        column: x => x.InsuranceCardId,
                        principalTable: "InsuranceCards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_Nurses_LeadNurseId",
                        column: x => x.LeadNurseId,
                        principalTable: "Nurses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_TimePlans_TimePlanId",
                        column: x => x.TimePlanId,
                        principalTable: "TimePlans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicationIntakes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    OrderProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    MedicationPlanProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    PatientVisitId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationIntakes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicationOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    MedicationPlanId = table.Column<Guid>(type: "uuid", nullable: true),
                    NurseId = table.Column<Guid>(type: "uuid", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CareHomeId = table.Column<Guid>(type: "uuid", nullable: true),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsCurrentOrder = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationOrders_Nurses_NurseId",
                        column: x => x.NurseId,
                        principalTable: "Nurses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicationOrders_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicationPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: true),
                    CareHomeTenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    FamilyDoctorTenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    PharmacyTenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    CurrentOrderId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationPlans_AbpTenants_CareHomeTenantId",
                        column: x => x.CareHomeTenantId,
                        principalTable: "AbpTenants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicationPlans_AbpTenants_FamilyDoctorTenantId",
                        column: x => x.FamilyDoctorTenantId,
                        principalTable: "AbpTenants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicationPlans_AbpTenants_PharmacyTenantId",
                        column: x => x.PharmacyTenantId,
                        principalTable: "AbpTenants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicationPlans_MedicationOrders_CurrentOrderId",
                        column: x => x.CurrentOrderId,
                        principalTable: "MedicationOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicationPlans_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientVisit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    MedicationOrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    NurseId = table.Column<Guid>(type: "uuid", nullable: false),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false),
                    DosingSchedule1 = table.Column<bool>(type: "boolean", nullable: false),
                    DosingSchedule2 = table.Column<bool>(type: "boolean", nullable: false),
                    DosingSchedule3 = table.Column<bool>(type: "boolean", nullable: false),
                    NotesSummary = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientVisit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientVisit_MedicationOrders_MedicationOrderId",
                        column: x => x.MedicationOrderId,
                        principalTable: "MedicationOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientVisit_Nurses_NurseId",
                        column: x => x.NurseId,
                        principalTable: "Nurses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientVisit_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicationPlanProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    Frequency = table.Column<int>(type: "integer", nullable: false),
                    BillPack = table.Column<bool>(type: "boolean", nullable: false),
                    ExactlySamePrescription = table.Column<bool>(type: "boolean", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    WeeklyFrequencyDays = table.Column<List<string>>(type: "text[]", nullable: false),
                    MedicationPlanId = table.Column<Guid>(type: "uuid", nullable: true),
                    CurrentOrderId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: true),
                    DosingSchedule1Value = table.Column<float>(type: "real", nullable: false),
                    DosingSchedule2Value = table.Column<float>(type: "real", nullable: false),
                    DosingSchedule3Value = table.Column<float>(type: "real", nullable: false),
                    DosingSchedule4Value = table.Column<float>(type: "real", nullable: false),
                    IsInCurrentWorkflow = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationPlanProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationPlanProducts_MedicationOrders_CurrentOrderId",
                        column: x => x.CurrentOrderId,
                        principalTable: "MedicationOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicationPlanProducts_MedicationPlans_MedicationPlanId",
                        column: x => x.MedicationPlanId,
                        principalTable: "MedicationPlans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicationPlanProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    MedicationPlanProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsedCount = table.Column<float>(type: "real", nullable: false),
                    Count = table.Column<float>(type: "real", nullable: false),
                    StatusLastChanged = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    WorkflowPersonInChargeId = table.Column<Guid>(type: "uuid", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CurrentBatchEndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PrescriptionStatus = table.Column<int>(type: "integer", nullable: false),
                    ActionType = table.Column<int>(type: "integer", nullable: false),
                    MedicationOrderId = table.Column<long>(type: "bigint", nullable: true),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProducts_AbpTenants_WorkflowPersonInChargeId",
                        column: x => x.WorkflowPersonInChargeId,
                        principalTable: "AbpTenants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderProducts_MedicationOrders_PatientId",
                        column: x => x.PatientId,
                        principalTable: "MedicationOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_MedicationPlanProducts_MedicationPlanProductId",
                        column: x => x.MedicationPlanProductId,
                        principalTable: "MedicationPlanProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CloudFiles_MedicationOrderId",
                table: "CloudFiles",
                column: "MedicationOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CloudFiles_PatientVisitId",
                table: "CloudFiles",
                column: "PatientVisitId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationIntakes_MedicationPlanProductId",
                table: "MedicationIntakes",
                column: "MedicationPlanProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationIntakes_PatientVisitId",
                table: "MedicationIntakes",
                column: "PatientVisitId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationOrders_MedicationPlanId",
                table: "MedicationOrders",
                column: "MedicationPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationOrders_NurseId",
                table: "MedicationOrders",
                column: "NurseId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationOrders_PatientId",
                table: "MedicationOrders",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationPlanProducts_CurrentOrderId",
                table: "MedicationPlanProducts",
                column: "CurrentOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationPlanProducts_MedicationPlanId",
                table: "MedicationPlanProducts",
                column: "MedicationPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationPlanProducts_ProductId",
                table: "MedicationPlanProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationPlans_CareHomeTenantId",
                table: "MedicationPlans",
                column: "CareHomeTenantId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationPlans_CurrentOrderId",
                table: "MedicationPlans",
                column: "CurrentOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationPlans_FamilyDoctorTenantId",
                table: "MedicationPlans",
                column: "FamilyDoctorTenantId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationPlans_PatientId",
                table: "MedicationPlans",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationPlans_PharmacyTenantId",
                table: "MedicationPlans",
                column: "PharmacyTenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Nurses_StationId",
                table: "Nurses",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_MedicationPlanProductId",
                table: "OrderProducts",
                column: "MedicationPlanProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_PatientId",
                table: "OrderProducts",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_WorkflowPersonInChargeId",
                table: "OrderProducts",
                column: "WorkflowPersonInChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AvatarId",
                table: "Patients",
                column: "AvatarId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_CareHomeId",
                table: "Patients",
                column: "CareHomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DoctorOfficeId",
                table: "Patients",
                column: "DoctorOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_InsuranceCardId",
                table: "Patients",
                column: "InsuranceCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_LeadNurseId",
                table: "Patients",
                column: "LeadNurseId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PharmacyId",
                table: "Patients",
                column: "PharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_StationId",
                table: "Patients",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_TimePlanId",
                table: "Patients",
                column: "TimePlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientVisit_MedicationOrderId",
                table: "PatientVisit",
                column: "MedicationOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientVisit_NurseId",
                table: "PatientVisit",
                column: "NurseId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientVisit_PatientId",
                table: "PatientVisit",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_CloudFiles_MedicationOrders_MedicationOrderId",
                table: "CloudFiles",
                column: "MedicationOrderId",
                principalTable: "MedicationOrders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CloudFiles_PatientVisit_PatientVisitId",
                table: "CloudFiles",
                column: "PatientVisitId",
                principalTable: "PatientVisit",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicationIntakes_OrderProducts_MedicationPlanProductId",
                table: "MedicationIntakes",
                column: "MedicationPlanProductId",
                principalTable: "OrderProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicationIntakes_PatientVisit_PatientVisitId",
                table: "MedicationIntakes",
                column: "PatientVisitId",
                principalTable: "PatientVisit",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicationOrders_MedicationPlans_MedicationPlanId",
                table: "MedicationOrders",
                column: "MedicationPlanId",
                principalTable: "MedicationPlans",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CloudFiles_MedicationOrders_MedicationOrderId",
                table: "CloudFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_CloudFiles_PatientVisit_PatientVisitId",
                table: "CloudFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicationOrders_MedicationPlans_MedicationPlanId",
                table: "MedicationOrders");

            migrationBuilder.DropTable(
                name: "MedicationIntakes");

            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "PatientVisit");

            migrationBuilder.DropTable(
                name: "MedicationPlanProducts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "MedicationPlans");

            migrationBuilder.DropTable(
                name: "MedicationOrders");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "InsuranceCards");

            migrationBuilder.DropTable(
                name: "Nurses");

            migrationBuilder.DropTable(
                name: "TimePlans");

            migrationBuilder.DropIndex(
                name: "IX_CloudFiles_MedicationOrderId",
                table: "CloudFiles");

            migrationBuilder.DropIndex(
                name: "IX_CloudFiles_PatientVisitId",
                table: "CloudFiles");

            migrationBuilder.DropColumn(
                name: "MedicationOrderId",
                table: "CloudFiles");

            migrationBuilder.DropColumn(
                name: "PatientVisitId",
                table: "CloudFiles");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "AbpTenants");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "AbpTenants");
        }
    }
}
