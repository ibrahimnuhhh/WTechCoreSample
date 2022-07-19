﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace WTechCoreSample.Migrations
{
    public partial class BlogPostViewCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "BlogPosts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "BlogPosts");
        }
    }
}
