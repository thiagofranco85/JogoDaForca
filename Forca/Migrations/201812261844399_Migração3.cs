namespace Forca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migração3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jogo", "PalavraId", c => c.Int(nullable: false));
            AlterColumn("dbo.Palpite", "Jogo_Id", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Palpite", "Jogo_Id", c => c.Int());
            AlterColumn("dbo.Jogo", "PalavraId", c => c.Int(nullable: false));
        }
    }
}
