namespace Arthesanatus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ecluir_Tab_FotoReceitas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FotoReceita", "ReceitaId", "dbo.Receita");
            DropIndex("dbo.FotoReceita", new[] { "ReceitaId" });
            DropTable("dbo.FotoReceita");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FotoReceita",
                c => new
                    {
                        FotoReceitaId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 200),
                        CaminhoFoto = c.String(nullable: false, maxLength: 1024),
                        ReceitaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FotoReceitaId);
            
            CreateIndex("dbo.FotoReceita", "ReceitaId");
            AddForeignKey("dbo.FotoReceita", "ReceitaId", "dbo.Receita", "ReceitaId", cascadeDelete: true);
        }
    }
}
