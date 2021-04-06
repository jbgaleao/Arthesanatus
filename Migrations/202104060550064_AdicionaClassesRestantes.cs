namespace Arthesanatus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionaClassesRestantes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cor",
                c => new
                    {
                        CorID = c.Int(nullable: false, identity: true),
                        CorCodigo = c.Int(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 50),
                        TipoLinhaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CorID)
                .ForeignKey("dbo.TipoLinha", t => t.TipoLinhaID, cascadeDelete: true)
                .Index(t => t.TipoLinhaID);
            
            CreateTable(
                "dbo.TipoLinha",
                c => new
                    {
                        TipoLinhaID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Descricao = c.String(nullable: false),
                        DadosTecnicos = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TipoLinhaID);
            
            CreateTable(
                "dbo.Linha",
                c => new
                    {
                        LinhaID = c.Int(nullable: false, identity: true),
                        QtdFechada = c.Int(nullable: false),
                        QtdAberta = c.Int(nullable: false),
                        TipoLinhaID = c.Int(nullable: false),
                        FabricanteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LinhaID)
                .ForeignKey("dbo.Fabricante", t => t.FabricanteID, cascadeDelete: true)
                .ForeignKey("dbo.TipoLinha", t => t.TipoLinhaID, cascadeDelete: true)
                .Index(t => t.TipoLinhaID)
                .Index(t => t.FabricanteID);
            
            CreateTable(
                "dbo.Fabricante",
                c => new
                    {
                        FabricanteID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.FabricanteID);
            
            CreateTable(
                "dbo.ReceitaLinhas",
                c => new
                    {
                        Receita_ReceitaId = c.Int(nullable: false),
                        Linha_LinhaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Receita_ReceitaId, t.Linha_LinhaID })
                .ForeignKey("dbo.Receita", t => t.Receita_ReceitaId, cascadeDelete: true)
                .ForeignKey("dbo.Linha", t => t.Linha_LinhaID, cascadeDelete: true)
                .Index(t => t.Receita_ReceitaId)
                .Index(t => t.Linha_LinhaID);
            
            AlterColumn("dbo.Receita", "Descricao", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cor", "TipoLinhaID", "dbo.TipoLinha");
            DropForeignKey("dbo.Linha", "TipoLinhaID", "dbo.TipoLinha");
            DropForeignKey("dbo.ReceitaLinhas", "Linha_LinhaID", "dbo.Linha");
            DropForeignKey("dbo.ReceitaLinhas", "Receita_ReceitaId", "dbo.Receita");
            DropForeignKey("dbo.Linha", "FabricanteID", "dbo.Fabricante");
            DropIndex("dbo.ReceitaLinhas", new[] { "Linha_LinhaID" });
            DropIndex("dbo.ReceitaLinhas", new[] { "Receita_ReceitaId" });
            DropIndex("dbo.Linha", new[] { "FabricanteID" });
            DropIndex("dbo.Linha", new[] { "TipoLinhaID" });
            DropIndex("dbo.Cor", new[] { "TipoLinhaID" });
            AlterColumn("dbo.Receita", "Descricao", c => c.String(nullable: false, maxLength: 4000));
            DropTable("dbo.ReceitaLinhas");
            DropTable("dbo.Fabricante");
            DropTable("dbo.Linha");
            DropTable("dbo.TipoLinha");
            DropTable("dbo.Cor");
        }
    }
}
