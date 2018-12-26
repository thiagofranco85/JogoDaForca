namespace Forca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migração2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jogo", "Palavra_Id", "dbo.Palavra");
            DropIndex("dbo.Jogo", new[] { "Palavra_Id" });
            RenameColumn(table: "dbo.Jogo", name: "Palavra_Id", newName: "PalavraId");
            AlterColumn("dbo.Jogo", "PalavraId", c => c.Int(nullable: false));
            CreateIndex("dbo.Jogo", "PalavraId");
            AddForeignKey("dbo.Jogo", "PalavraId", "dbo.Palavra", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jogo", "PalavraId", "dbo.Palavra");
            DropIndex("dbo.Jogo", new[] { "PalavraId" });
            AlterColumn("dbo.Jogo", "PalavraId", c => c.Int());
            RenameColumn(table: "dbo.Jogo", name: "PalavraId", newName: "Palavra_Id");
            CreateIndex("dbo.Jogo", "Palavra_Id");
            AddForeignKey("dbo.Jogo", "Palavra_Id", "dbo.Palavra", "Id");
        }
    }
}
