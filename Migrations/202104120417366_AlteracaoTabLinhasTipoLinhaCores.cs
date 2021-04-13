namespace Arthesanatus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteracaoTabLinhasTipoLinhaCores : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Linha", "CorID", "dbo.Cor");
            DropIndex("dbo.Linha", new[] { "CorID" });
            AddColumn("dbo.Cor", "TipoLinhaID", c => c.Int(nullable: false));
            CreateIndex("dbo.Cor", "TipoLinhaID");
            AddForeignKey("dbo.Cor", "TipoLinhaID", "dbo.TipoLinha", "TipoLinhaID", cascadeDelete: true);
            DropColumn("dbo.Linha", "CorID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Linha", "CorID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Cor", "TipoLinhaID", "dbo.TipoLinha");
            DropIndex("dbo.Cor", new[] { "TipoLinhaID" });
            DropColumn("dbo.Cor", "TipoLinhaID");
            CreateIndex("dbo.Linha", "CorID");
            AddForeignKey("dbo.Linha", "CorID", "dbo.Cor", "CorID", cascadeDelete: true);
        }
    }
}
