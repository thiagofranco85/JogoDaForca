namespace Forca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jogo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumChance = c.Int(nullable: false),
                        NumTentativa = c.Int(nullable: false),
                        Vitoria = c.Boolean(nullable: false),
                        PalavraId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Palavra", t => t.PalavraId, cascadeDelete: true)
                .Index(t => t.PalavraId);
            
            CreateTable(
                "dbo.Palavra",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Termo = c.String(unicode: false),
                        Dica = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Palpite",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Letra = c.String(unicode: false),
                        JogoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jogo", t => t.JogoId, cascadeDelete: true)
                .Index(t => t.JogoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Palpite", "JogoId", "dbo.Jogo");
            DropForeignKey("dbo.Jogo", "PalavraId", "dbo.Palavra");
            DropIndex("dbo.Palpite", new[] { "JogoId" });
            DropIndex("dbo.Jogo", new[] { "PalavraId" });
            DropTable("dbo.Palpite");
            DropTable("dbo.Palavra");
            DropTable("dbo.Jogo");
        }
    }
}
