namespace Arthesanatus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriaTabelaFotoReceitas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FotoReceita",
                c => new
                    {
                        FotoReceitaId = c.Int(nullable: false, identity: true),
                        CaminhoFoto = c.String(nullable: false, maxLength: 1024),
                        ReceitaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FotoReceitaId)
                .ForeignKey("dbo.Receita", t => t.ReceitaId, cascadeDelete: true)
                .Index(t => t.ReceitaId);
            
            DropTable("dbo.RevistasReceitasViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RevistasReceitasViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tema = c.String(),
                        Nome = c.String(),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.FotoReceita", "ReceitaId", "dbo.Receita");
            DropIndex("dbo.FotoReceita", new[] { "ReceitaId" });
            DropTable("dbo.FotoReceita");
        }
    }
}
