namespace MvcApp.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDb3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ArticleMark", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.ArticleMark", "MarkId", "dbo.Marks");
            DropIndex("dbo.ArticleMark", new[] { "ArticleId" });
            DropIndex("dbo.ArticleMark", new[] { "MarkId" });
            AddColumn("dbo.Articles", "Tag", c => c.String());
            DropTable("dbo.Marks");
            DropTable("dbo.ArticleMark");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ArticleMark",
                c => new
                    {
                        ArticleId = c.Int(nullable: false),
                        MarkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArticleId, t.MarkId });
            
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tag = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Articles", "Tag");
            CreateIndex("dbo.ArticleMark", "MarkId");
            CreateIndex("dbo.ArticleMark", "ArticleId");
            AddForeignKey("dbo.ArticleMark", "MarkId", "dbo.Marks", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ArticleMark", "ArticleId", "dbo.Articles", "Id", cascadeDelete: true);
        }
    }
}
