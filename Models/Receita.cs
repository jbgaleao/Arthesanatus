using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arthesanatus.Models
{
    [Table( "Receita" )]
    public class Receita
    {
        public Receita( )
        {
            this.Linhas = new HashSet<Linha>();
        }


        [Key]
        public int ReceitaId { get; set; }

        [Required]
        [MaxLength( 150 )]
        [Display( Name = "Nome" )]
        public string Nome { get; set; }

        [Required]
        [MaxLength( 8000 )]
        [Display( Name = "Descrição" )]
        [DataType( DataType.MultilineText )]
        public string Descricao { get; set; }

        [Required]
        [ForeignKey( "Revista" )]
        [Display( Name = "Tema da Revista" )]
        public int RevistaId { get; set; }
        public virtual Revista Revista { get; set; }


        public virtual ICollection<Linha> Linhas { get; set; }

    }
}