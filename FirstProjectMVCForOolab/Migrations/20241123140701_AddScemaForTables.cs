using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstProjectMVCForOolab.Migrations
{
    public partial class AddScemaForTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "movies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MembershipTypeId",
                table: "customers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    genre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "membershipTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    signUpFee = table.Column<int>(type: "INTEGER", nullable: false),
                    DurationInMonth = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_membershipTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movies_GenreId",
                table: "movies",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_customers_MembershipTypeId",
                table: "customers",
                column: "MembershipTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_customers_membershipTypes_MembershipTypeId",
                table: "customers",
                column: "MembershipTypeId",
                principalTable: "membershipTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_movies_genres_GenreId",
                table: "movies",
                column: "GenreId",
                principalTable: "genres",
                principalColumn: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customers_membershipTypes_MembershipTypeId",
                table: "customers");

            migrationBuilder.DropForeignKey(
                name: "FK_movies_genres_GenreId",
                table: "movies");

            migrationBuilder.DropTable(
                name: "genres");

            migrationBuilder.DropTable(
                name: "membershipTypes");

            migrationBuilder.DropIndex(
                name: "IX_movies_GenreId",
                table: "movies");

            migrationBuilder.DropIndex(
                name: "IX_customers_MembershipTypeId",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "MembershipTypeId",
                table: "customers");
        }
    }
}
