using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arthesanatus.Models
{
    [Table( "Fabricante" )]
    public class Fabricante
    {
        public Fabricante( )
        {
            this.Linhas = new HashSet<Linha>();
        }

        [Key]
        public int FabricanteID { get; set; }

        [Required]
        [MaxLength( 100 )]
        [Display( Name = "Nome do Fabricante" )]
        public string Nome { get; set; }

        public virtual ICollection<Linha> Linhas { get; set; }
    }
}