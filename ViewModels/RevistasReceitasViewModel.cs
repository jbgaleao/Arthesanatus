using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Arthesanatus.ViewModels
{
    [NotMapped]
    public class RevistasReceitasViewModel
    {
        public RevistasReceitasViewModel()
        {

        }
        [Display( Name = "Código" )]
        public int Id { get; set; }


        [Display( Name = "Tema da Revista" )]
        public string Tema { get; set; }


        [Display( Name = "Nome da Receita" )]
        public string Nome { get; set; }


        [Display( Name = "Descrção da Receita" )]
        public string Descricao { get; set; }
    }
}