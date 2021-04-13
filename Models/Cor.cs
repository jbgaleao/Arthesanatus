﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arthesanatus.Models
{
    [Table( "Cor" )]
    public class Cor
    {
        public Cor()
        {

        }

        [Key]
        public int CorID { get; set; }

        [Required]
        [Display( Name = "Código da Cor" )]
        public int CorCodigo { get; set; }

        [Required]
        [ForeignKey("TipoLinha")]
        [Display(Name = "Tipo de Linha")]
        public int TipoLinhaID { get; set; }
        public virtual TipoLinha TipoLinha { get; set; }


        [Required]
        [MaxLength( 50 )]
        [Display( Name = "Nome da Cor" )]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Novelos Fechados")]
        public int QtdFechada { get; set; }

        [Required]
        [Display(Name = "Novelos Abertos")]
        public int QtdAberta { get; set; }




    }
}