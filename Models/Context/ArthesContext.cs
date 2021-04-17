using Arthesanatus.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Arthesanatus.Models.Context
{
    public class ArthesContext :DbContext
    {
        public ArthesContext( ) : base( "ArthesDbConn" )
        {
            Database.SetInitializer( new MigrateDatabaseToLatestVersion<ArthesContext, Arthesanatus.Migrations.Configuration>() );

        }

        public DbSet<Cor> CORES { get; set; }
        public DbSet<Fabricante> FABRICANTES { get; set; }
        public DbSet<Linha> LINHAS { get; set; }
        public DbSet<Receita> RECEITAS { get; set; }
        public DbSet<Revista> REVISTAS { get; set; }
        public DbSet<TipoLinha> TIPOSLINHAS { get; set; }
        public DbSet<RevistasReceitasViewModel> REVISTASRECEITASVIEWMODELS { get; set; }
    }
}