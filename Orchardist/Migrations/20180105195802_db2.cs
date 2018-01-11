using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Orchardist.Migrations
{
    public partial class db2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GlobalPlantList",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comments = table.Column<string>(nullable: true),
                    FruitVariety = table.Column<string>(maxLength: 60, nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Origin = table.Column<string>(nullable: true),
                    Use = table.Column<string>(nullable: true),
                    YearDeveloped = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalPlantList", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserPlantList",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comments = table.Column<string>(nullable: true),
                    DatePlanted = table.Column<DateTime>(nullable: false),
                    FruitVariety = table.Column<string>(maxLength: 60, nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Origin = table.Column<string>(maxLength: 60, nullable: false),
                    Parentage = table.Column<string>(maxLength: 60, nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    TreeCount = table.Column<int>(nullable: false),
                    Use = table.Column<string>(nullable: true),
                    YearDeveloped = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPlantList", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GlobalPlantList");

            migrationBuilder.DropTable(
                name: "UserPlantList");
        }
    }
}
