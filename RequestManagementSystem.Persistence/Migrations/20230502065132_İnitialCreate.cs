using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RequestManagementSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class İnitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactMethod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetailType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Priority",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Level = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priority", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    InternalNumber = table.Column<string>(type: "text", nullable: true),
                    ContactNumber = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    ImagePath = table.Column<string>(type: "text", nullable: true),
                    AllowNotification = table.Column<bool>(type: "boolean", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Token = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Expires = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    FileUploadPath = table.Column<string>(type: "text", nullable: true),
                    CreateUserId = table.Column<int>(type: "integer", nullable: false),
                    ExecutorUserId = table.Column<int>(type: "integer", nullable: true),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    RequestTypeId = table.Column<int>(type: "integer", nullable: false),
                    RequestStatusId = table.Column<int>(type: "integer", nullable: false),
                    PriorityId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Request_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Request_Priority_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "Priority",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Request_RequestStatus_RequestStatusId",
                        column: x => x.RequestStatusId,
                        principalTable: "RequestStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Request_RequestType_RequestTypeId",
                        column: x => x.RequestTypeId,
                        principalTable: "RequestType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Request_User_CreateUserId",
                        column: x => x.CreateUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Request_User_ExecutorUserId",
                        column: x => x.ExecutorUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserCategory",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    IsCreatable = table.Column<bool>(type: "boolean", nullable: false),
                    IsExecutable = table.Column<bool>(type: "boolean", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCategory", x => new { x.CategoryId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCategory_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Action",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RequestId = table.Column<int>(type: "integer", nullable: false),
                    RequestStatusId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Action", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Action_RequestStatus_RequestStatusId",
                        column: x => x.RequestStatusId,
                        principalTable: "RequestStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Action_Request_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Request",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Action_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RequestId = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    FileUploadPath = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Request_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Request",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RequestId = table.Column<int>(type: "integer", nullable: false),
                    CreateUserId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    InitialExecutionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExecutionTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    ExecutorUserId = table.Column<int>(type: "integer", nullable: true),
                    ClosedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RequestStatusId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Report_Request_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Request",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PriorityId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    Result = table.Column<string>(type: "text", nullable: false),
                    Solution = table.Column<string>(type: "text", nullable: false),
                    ExecutionTime = table.Column<double>(type: "double precision", nullable: false),
                    PlannedExecutionTime = table.Column<double>(type: "double precision", nullable: false),
                    DetailTypeId = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    SolmanRequestNumber = table.Column<string>(type: "text", nullable: false),
                    ContactMethodId = table.Column<int>(type: "integer", nullable: false),
                    Routine = table.Column<bool>(type: "boolean", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    RootCause = table.Column<string>(type: "text", nullable: false),
                    RequestId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestDetail_ContactMethod_ContactMethodId",
                        column: x => x.ContactMethodId,
                        principalTable: "ContactMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestDetail_DetailType_DetailTypeId",
                        column: x => x.DetailTypeId,
                        principalTable: "DetailType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestDetail_Request_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Request",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4469), "3E - AGIS" },
                    { 2, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4473), "3E - dəstək" },
                    { 3, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4475), "3rd Party" },
                    { 4, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4476), "abc web site" },
                    { 5, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4477), "AGIS - Debitor" },
                    { 6, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4479), "AD SOCAR Romania" },
                    { 7, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4480), "Agis - Proqram təminatı" },
                    { 8, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4481), "ailem.socar.az" },
                    { 9, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4482), "ant.socar.az" },
                    { 10, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4484), "ASAN web service" },
                    { 11, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4485), "Azeriqaz sms" },
                    { 12, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4486), "azkob.az" },
                    { 13, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4487), "Call Center" },
                    { 14, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4487), "CIC web site" },
                    { 15, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4488), "CVS web site" },
                    { 16, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4489), "AD SOCAR Romania" },
                    { 17, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4490), "ailem.socar.az" }
                });

            migrationBuilder.InsertData(
                table: "ContactMethod",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4557), "Email" },
                    { 2, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4559), "Phone" },
                    { 3, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4560), "SOLMAN" },
                    { 4, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4561), "REQUEST" }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4586), "Information Technologies" },
                    { 2, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4589), "Human Resources" },
                    { 3, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4590), "Data Analysis" }
                });

            migrationBuilder.InsertData(
                table: "DetailType",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4613), "Application Maintenance" },
                    { 2, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4616), "Application Development" }
                });

            migrationBuilder.InsertData(
                table: "Priority",
                columns: new[] { "Id", "CreatedAt", "Level" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4633), "Low" },
                    { 2, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4635), "Medium" },
                    { 3, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4636), "High" }
                });

            migrationBuilder.InsertData(
                table: "RequestStatus",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4653), "Open" },
                    { 2, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4657), "In Execution" },
                    { 3, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4658), "Rejected" },
                    { 4, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4659), "Waiting" },
                    { 5, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4660), "Approved" },
                    { 6, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4662), "Close" }
                });

            migrationBuilder.InsertData(
                table: "RequestType",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4683), "APP Change" },
                    { 2, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4685), "APP Issue" },
                    { 3, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4686), "APP New Requirement" },
                    { 4, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4686), "Change the Report" },
                    { 5, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4688), "Crate Custom Report" },
                    { 6, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4689), "Create New Rrport" },
                    { 7, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4690), "Incident" },
                    { 8, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4691), "Master Data Change" },
                    { 9, new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4692), "Service Request" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AllowNotification", "ContactNumber", "CreatedAt", "DepartmentId", "ImagePath", "InternalNumber", "Name", "Password", "Position", "Role" },
                values: new object[,]
                {
                    { 1, true, "+995 551234567", new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4711), 1, null, "123456", "Nigar", "nigar123", "meslehetci", "Admin" },
                    { 2, true, "+995 551234567", new DateTime(2023, 5, 2, 6, 51, 32, 435, DateTimeKind.Utc).AddTicks(4718), 2, null, "123456", "Ferec", "ferec123", "meslehetci", "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Action_RequestId",
                table: "Action",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Action_RequestStatusId",
                table: "Action",
                column: "RequestStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Action_UserId",
                table: "Action",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_RequestId",
                table: "Comment",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_RequestId",
                table: "Report",
                column: "RequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Request_CategoryId",
                table: "Request",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_CreateUserId",
                table: "Request",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_ExecutorUserId",
                table: "Request",
                column: "ExecutorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_PriorityId",
                table: "Request",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_RequestStatusId",
                table: "Request",
                column: "RequestStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_RequestTypeId",
                table: "Request",
                column: "RequestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestDetail_ContactMethodId",
                table: "RequestDetail",
                column: "ContactMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestDetail_DetailTypeId",
                table: "RequestDetail",
                column: "DetailTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestDetail_RequestId",
                table: "RequestDetail",
                column: "RequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_DepartmentId",
                table: "User",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCategory_UserId",
                table: "UserCategory",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Action");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "RequestDetail");

            migrationBuilder.DropTable(
                name: "UserCategory");

            migrationBuilder.DropTable(
                name: "ContactMethod");

            migrationBuilder.DropTable(
                name: "DetailType");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Priority");

            migrationBuilder.DropTable(
                name: "RequestStatus");

            migrationBuilder.DropTable(
                name: "RequestType");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
