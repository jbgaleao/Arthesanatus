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

        public DbSet<Revista> REVISTAS { get; set; }
        public DbSet<Receita> RECEITAS { get; set; }
    }
}