namespace Arthesanatus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteraTabelaFotoReceitas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FotoReceita", "Descricao", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FotoReceita", "Descricao");
        }
    }
}
