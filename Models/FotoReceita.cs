using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arthesanatus.Models
{
    [Table( "FotoReceita" )]
    public class FotoReceita
    {
        public FotoReceita()
        {

        }

        [Key]
        public int FotoReceitaId { get; set; }

        [Required]
        [MaxLength( 200 )]
        [Display( Name = "Descrição" )]
        public string Descricao { get; set; }

        [Required]
        [MaxLength( 1024 )]
        [Display( Name = "Foto" )]
        [DataType(DataType.ImageUrl)]
        public string Foto { get; set; }

        [NotMapped]
        public HttpPostedFileBase FileImage { get; set; }

        [Required]
        [ForeignKey( "Receita" )]
        [Display( Name = "Tema da Revista" )]
        public int ReceitaId { get; set; }
        public virtual Receita Receita { get; set; }
    }
}