using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pillio.Migrations
{
    /// <inheritdoc />
    public partial class updatepatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicationPlans_AbpTenants_FamilyDoctorTenantId",
                table: "MedicationPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_MedicationOrders_PatientId",
                table: "OrderProducts");

            migrationBuilder.RenameColumn(
                name: "FamilyDoctorTenantId",
                table: "MedicationPlans",
                newName: "DoctorTenantId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicationPlans_FamilyDoctorTenantId",
                table: "MedicationPlans",
                newName: "IX_MedicationPlans_DoctorTenantId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Patients",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "Patients",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "Patients",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Patients",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Patients",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Patients",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "Patients",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "OrderProducts",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicationPlans_AbpTenants_DoctorTenantId",
                table: "MedicationPlans",
                column: "DoctorTenantId",
                principalTable: "AbpTenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_MedicationOrders_PatientId",
                table: "OrderProducts",
                column: "PatientId",
                principalTable: "MedicationOrders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicationPlans_AbpTenants_DoctorTenantId",
                table: "MedicationPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_MedicationOrders_PatientId",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "DoctorTenantId",
                table: "MedicationPlans",
                newName: "FamilyDoctorTenantId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicationPlans_DoctorTenantId",
                table: "MedicationPlans",
                newName: "IX_MedicationPlans_FamilyDoctorTenantId");

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "OrderProducts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicationPlans_AbpTenants_FamilyDoctorTenantId",
                table: "MedicationPlans",
                column: "FamilyDoctorTenantId",
                principalTable: "AbpTenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_MedicationOrders_PatientId",
                table: "OrderProducts",
                column: "PatientId",
                principalTable: "MedicationOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
