namespace Arthesanatus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteraLinaCorTipoLinha : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cor", "TipoLinhaID", "dbo.TipoLinha");
            DropIndex("dbo.Cor", new[] { "TipoLinhaID" });
            AddColumn("dbo.Linha", "CorID", c => c.Int(nullable: false));
            CreateIndex("dbo.Linha", "CorID");
            AddForeignKey("dbo.Linha", "CorID", "dbo.Cor", "CorID", cascadeDelete: true);
            DropColumn("dbo.Cor", "TipoLinhaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cor", "TipoLinhaID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Linha", "CorID", "dbo.Cor");
            DropIndex("dbo.Linha", new[] { "CorID" });
            DropColumn("dbo.Linha", "CorID");
            CreateIndex("dbo.Cor", "TipoLinhaID");
            AddForeignKey("dbo.Cor", "TipoLinhaID", "dbo.TipoLinha", "TipoLinhaID", cascadeDelete: true);
        }
    }
}
