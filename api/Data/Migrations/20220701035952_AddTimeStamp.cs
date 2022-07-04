﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace matricula_api.Data.Migrations
{
    public partial class AddTimeStamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RegisterCreated",
                table: "Matriculas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegisterCreated",
                table: "Matriculas");
        }
    }
}
