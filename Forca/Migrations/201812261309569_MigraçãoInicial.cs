namespace Forca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigraçãoInicial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Palavra", "Jogo_Id", "dbo.Jogo");
            DropForeignKey("dbo.Jogo", "Palpite_Id", "dbo.Palpite");
            DropIndex("dbo.Jogo", new[] { "Palpite_Id" });
            DropIndex("dbo.Palavra", new[] { "Jogo_Id" });
            AddColumn("dbo.Jogo", "Palavra_Id", c => c.Int());
            AddColumn("dbo.Palpite", "Jogo_Id", c => c.Int());
            CreateIndex("dbo.Jogo", "Palavra_Id");
            CreateIndex("dbo.Palpite", "Jogo_Id");
            AddForeignKey("dbo.Palpite", "Jogo_Id", "dbo.Jogo", "Id");
            AddForeignKey("dbo.Jogo", "Palavra_Id", "dbo.Palavra", "Id");
            DropColumn("dbo.Jogo", "Palpite_Id");
            DropColumn("dbo.Palavra", "Jogo_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Palavra", "Jogo_Id", c => c.Int());
            AddColumn("dbo.Jogo", "Palpite_Id", c => c.Int());
            DropForeignKey("dbo.Jogo", "Palavra_Id", "dbo.Palavra");
            DropForeignKey("dbo.Palpite", "Jogo_Id", "dbo.Jogo");
            DropIndex("dbo.Palpite", new[] { "Jogo_Id" });
            DropIndex("dbo.Jogo", new[] { "Palavra_Id" });
            DropColumn("dbo.Palpite", "Jogo_Id");
            DropColumn("dbo.Jogo", "Palavra_Id");
            CreateIndex("dbo.Palavra", "Jogo_Id");
            CreateIndex("dbo.Jogo", "Palpite_Id");
            AddForeignKey("dbo.Jogo", "Palpite_Id", "dbo.Palpite", "Id");
            AddForeignKey("dbo.Palavra", "Jogo_Id", "dbo.Jogo", "Id");
        }
    }
}
