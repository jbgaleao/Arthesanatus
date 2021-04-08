using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arthesanatus.Models
{
    [Table( "Cor" )]
    public class Cor
    {
        public Cor()
        {
            this.Linhas = new HashSet<Linha>();
        }

        [Key]
        public int CorID { get; set; }

        [Required]
        [Display( Name = "Código da Cor" )]
        public int CorCodigo { get; set; }

        [Required]
        [MaxLength( 50 )]
        [Display( Name = "Nome da Cor" )]
        public string Nome { get; set; }

        public virtual ICollection<Linha> Linhas { get; set; }
    }
}