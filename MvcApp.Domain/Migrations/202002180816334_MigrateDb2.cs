namespace MvcApp.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDb2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tag = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArticleMark",
                c => new
                    {
                        ArticleId = c.Int(nullable: false),
                        MarkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArticleId, t.MarkId })
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .ForeignKey("dbo.Marks", t => t.MarkId, cascadeDelete: true)
                .Index(t => t.ArticleId)
                .Index(t => t.MarkId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArticleMark", "MarkId", "dbo.Marks");
            DropForeignKey("dbo.ArticleMark", "ArticleId", "dbo.Articles");
            DropIndex("dbo.ArticleMark", new[] { "MarkId" });
            DropIndex("dbo.ArticleMark", new[] { "ArticleId" });
            DropTable("dbo.ArticleMark");
            DropTable("dbo.Marks");
        }
    }
}
