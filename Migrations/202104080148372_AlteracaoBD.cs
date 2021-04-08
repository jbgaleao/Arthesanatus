namespace Arthesanatus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteracaoBD : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ReceitaViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ReceitaViewModels",
                c => new
                    {
                        ReceitaViewModelID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        RevistaID = c.Int(nullable: false),
                        LinhaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReceitaViewModelID);
            
        }
    }
}
