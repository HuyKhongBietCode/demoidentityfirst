using System;
using Bogus;
using DemoIdentityEntityFramework.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoIdentityEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class initDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.ID);
                });

            Randomizer.Seed = new Random(8675309);
            var fakerArticle = new Faker<Article>();
            fakerArticle.RuleFor(a => a.Title, f => f.Lorem.Sentence(5, 5));
            fakerArticle.RuleFor(a => a.Created, f => f.Date.Between(new DateTime(2021, 9, 11),
                new DateTime(2023, 12, 23)));
            fakerArticle.RuleFor(a => a.Content, f => f.Lorem.Paragraphs(1, 4));


            for (int i = 0; i < 150; i++)
            {
                Article newArticle = fakerArticle.Generate();
                migrationBuilder.InsertData(table: "articles",
               columns: new string[] { "Title", "Created", "Content" },
               values: new object[] {
               newArticle.Title,
               newArticle.Created ,
               newArticle.Content});
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");
        }
    }
}
