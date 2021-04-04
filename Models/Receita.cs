using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arthesanatus.Models
{
    [Table( "Receita" )]
    public class Receita
    {
        [Key]
        public int ReceitaId { get; set; }

        [Required]
        [MaxLength( 150 )]
        [Display( Name = "Nome:" )]
        public string Nome { get; set; }

        [Required]
        [MaxLength( 4000 )]
        [Display( Name = "Descrição:" )]
        [DataType( DataType.MultilineText )]
        public string Descricao { get; set; }

        [Required]
        [ForeignKey( "Revista" )]
        [Display( Name = "Tema da Revista:" )]
        public int RevistaId { get; set; }

        public virtual Revista Revista { get; set; }

    }
}