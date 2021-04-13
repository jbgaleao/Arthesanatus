namespace Arthesanatus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjustesTabelaCores : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cor", "QtdFechada", c => c.Int(nullable: false));
            AddColumn("dbo.Cor", "QtdAberta", c => c.Int(nullable: false));
            DropColumn("dbo.Linha", "QtdFechada");
            DropColumn("dbo.Linha", "QtdAberta");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Linha", "QtdAberta", c => c.Int(nullable: false));
            AddColumn("dbo.Linha", "QtdFechada", c => c.Int(nullable: false));
            DropColumn("dbo.Cor", "QtdAberta");
            DropColumn("dbo.Cor", "QtdFechada");
        }
    }
}
