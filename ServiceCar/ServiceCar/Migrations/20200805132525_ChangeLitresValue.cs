using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceCar.Migrations
{
    public partial class ChangeLitresValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Litres",
                table: "Fills",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Litres",
                table: "Fills",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
