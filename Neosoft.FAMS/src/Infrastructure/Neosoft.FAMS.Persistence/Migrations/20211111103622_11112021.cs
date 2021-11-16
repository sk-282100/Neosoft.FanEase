using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Neosoft.FAMS.Persistence.Migrations
{
    public partial class _11112021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VideoStatisticsDetails",
                columns: table => new
                {
                    VideoStatisticsId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoId = table.Column<long>(type: "bigint", nullable: true),
                    IsClicked = table.Column<bool>(type: "bit", nullable: true),
                    ClickedBy = table.Column<long>(type: "bigint", nullable: true),
                    ClickedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsViewed = table.Column<bool>(type: "bit", nullable: true),
                    ViewBy = table.Column<long>(type: "bigint", nullable: true),
                    ViewOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsLiked = table.Column<bool>(type: "bit", nullable: true),
                    LikeBy = table.Column<long>(type: "bigint", nullable: true),
                    LikeOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsShared = table.Column<bool>(type: "bit", nullable: true),
                    SharedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SharedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoStatisticsDetails", x => x.VideoStatisticsId);
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2022, 9, 11, 16, 6, 21, 87, DateTimeKind.Local).AddTicks(5945));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2022, 8, 11, 16, 6, 21, 87, DateTimeKind.Local).AddTicks(5593));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2022, 3, 11, 16, 6, 21, 87, DateTimeKind.Local).AddTicks(5871));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2022, 7, 11, 16, 6, 21, 87, DateTimeKind.Local).AddTicks(6028));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2022, 3, 11, 16, 6, 21, 87, DateTimeKind.Local).AddTicks(5796));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2022, 5, 11, 16, 6, 21, 84, DateTimeKind.Local).AddTicks(1876));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 11, 16, 6, 21, 88, DateTimeKind.Local).AddTicks(3759));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 11, 16, 6, 21, 88, DateTimeKind.Local).AddTicks(3697));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 11, 16, 6, 21, 88, DateTimeKind.Local).AddTicks(507));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 11, 16, 6, 21, 88, DateTimeKind.Local).AddTicks(3562));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 11, 16, 6, 21, 88, DateTimeKind.Local).AddTicks(4009));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 11, 16, 6, 21, 88, DateTimeKind.Local).AddTicks(3812));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 11, 16, 6, 21, 88, DateTimeKind.Local).AddTicks(3902));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                columns: new[] { "CreatedDate", "DateOfJoining" },
                values: new object[] { new DateTime(2021, 11, 11, 16, 6, 21, 87, DateTimeKind.Local).AddTicks(3873), new DateTime(2022, 5, 11, 16, 6, 21, 87, DateTimeKind.Local).AddTicks(959) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoStatisticsDetails");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2022, 9, 11, 11, 37, 50, 426, DateTimeKind.Local).AddTicks(7058));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2022, 8, 11, 11, 37, 50, 426, DateTimeKind.Local).AddTicks(5127));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2022, 3, 11, 11, 37, 50, 426, DateTimeKind.Local).AddTicks(6879));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2022, 7, 11, 11, 37, 50, 426, DateTimeKind.Local).AddTicks(7332));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2022, 3, 11, 11, 37, 50, 426, DateTimeKind.Local).AddTicks(6545));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2022, 5, 11, 11, 37, 50, 410, DateTimeKind.Local).AddTicks(8674));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 11, 11, 37, 50, 433, DateTimeKind.Local).AddTicks(1745));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 11, 11, 37, 50, 433, DateTimeKind.Local).AddTicks(1553));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 11, 11, 37, 50, 429, DateTimeKind.Local).AddTicks(441));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 11, 11, 37, 50, 433, DateTimeKind.Local).AddTicks(1101));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 11, 11, 37, 50, 433, DateTimeKind.Local).AddTicks(2301));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 11, 11, 37, 50, 433, DateTimeKind.Local).AddTicks(1918));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2021, 11, 11, 11, 37, 50, 433, DateTimeKind.Local).AddTicks(2127));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                columns: new[] { "CreatedDate", "DateOfJoining" },
                values: new object[] { new DateTime(2021, 11, 11, 11, 37, 50, 425, DateTimeKind.Local).AddTicks(7770), new DateTime(2022, 5, 11, 11, 37, 50, 424, DateTimeKind.Local).AddTicks(8732) });
        }
    }
}
