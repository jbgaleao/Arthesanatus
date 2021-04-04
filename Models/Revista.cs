using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arthesanatus.Models
{
    [Table( "Revista" )]
    public class Revista
    {
        public Revista( )
        {
            Receitas = new List<Receita>();
        }

        [Key]
        public int RevistaID { get; set; }

        [Required]
        [Display( Name = "Número da Edição:" )]
        [Range( 1, 9999 )]
        public int NumeroEdicao { get; set; }

        [Required]
        [Display( Name = "Ano da Edição:" )]
        [Range(2017, 2025)]
        public int AnoEdicao { get; set; }

        [Required]
        [Display( Name = "Mês da Edição:" )]
        public Mes MesEdicao { get; set; }

        [Required]
        [MaxLength( 150 )]
        [Display( Name = "Tema:" )]
        public string Tema { get; set; }

        [Display( Name = "Foto de Capa:" )]
        public byte[] Foto { get; set; }

        public virtual List<Receita> Receitas { get; set; }

    }
}