using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudWebApi.Migrations
{
    /// <inheritdoc />
    public partial class fourthmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DepartamentoId",
                table: "Funcionarios",
                newName: "Departamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Departamento",
                table: "Funcionarios",
                newName: "DepartamentoId");
        }
    }
}
