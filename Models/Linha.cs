using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arthesanatus.Models
{
    [Table( "Linha" )]
    public class Linha
    {

        public Linha( )
        {
            this.Receitas = new HashSet<Receita>(); 
        }


        [Key]
        public int LinhaID { get; set; }

        [Required]
        [Display( Name = "Novelos Fechados:" )]
        public int QtdFechada { get; set; }

        [Required]
        [Display( Name = "Novelos Abertos:" )]
        public int QtdAberta { get; set; }

        [Required]
        [ForeignKey( "TipoLinha" )]
        [Display( Name = "Tipo da Linha:" )]
        public int TipoLinhaID { get; set; }
        public virtual TipoLinha TipoLinha { get; set; }

        [Required]
        [ForeignKey( "Fabricante" )]
        [Display( Name = "Fabricante:" )]
        public int FabricanteID { get; set; }
        public virtual Fabricante Fabricante { get; set; }


        public virtual ICollection<Receita> Receitas { get; set; }
    }
}




