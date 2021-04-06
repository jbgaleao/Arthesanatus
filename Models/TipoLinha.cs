using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arthesanatus.Models
{
    [Table( "TipoLinha" )]
    public class TipoLinha
    {
        public TipoLinha( )
        {
            this.Linhas = new HashSet<Linha>();
            this.Cores = new HashSet<Cor>();
        }

        [Key]
        public int TipoLinhaID { get; set; }

        [Required]
        [MaxLength( 100 )]
        [Display( Name = "Nome da Linha:" )]
        public string Nome { get; set; }

        [Required]
        [MaxLength( 8000 )]
        [Display( Name = "Descrição:" )]
        [DataType( DataType.MultilineText )]
        public string Descricao { get; set; }

        [Required]
        [MaxLength( 8000 )]
        [Display( Name = "Dados Técnicos:" )]
        [DataType( DataType.MultilineText )]
        public string DadosTecnicos { get; set; }


        public virtual ICollection<Linha> Linhas { get; set; }
        public virtual ICollection<Cor> Cores { get; set; }
    }
}