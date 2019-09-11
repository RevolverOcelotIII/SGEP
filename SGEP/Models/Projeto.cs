using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

using SGEP.Models.Validacao;

namespace SGEP.Models
{
    public class Projeto : IAutoValida
    {
        [Key]
        public int Id { get; set; }
        public string Nome {get; set;}
        [DataType(DataType.Date)]
        [Display(Name = "Data de in�cio")]
        public DateTime DataInicio {get; set;}
        [DataType(DataType.Date)]
        [Display(Name = "Data final estimada")]
        public DateTime PrazoEstimado {get; set;}
        [DataType(DataType.Date)]
        [Display(Name = "Data de T�rmino")]
        public DateTime? DataFim { get; set; } 
        public EstadoProjeto Estado { get; set; } = EstadoProjeto.Andamento;

        public bool Validar() => !string.IsNullOrEmpty(Nome) && PrazoEstimado >= DataInicio && 
                                 (DataFim == null       && Estado == EstadoProjeto.Andamento || 
                                  DataFim >= DataInicio && Estado == EstadoProjeto.Finalizado);

        //public Dictionary <Material,double> Materiais {get; set;}

        //public void AlocarMaterial(Material m, double quantidade)
        //{
        //  if(quantidade > 0)
        //    Materiais.Add(m, quantidade);
        //}
        //public void Finalizar(DateTime dataFim)
        //{
        //    DataFim = dataFim;
        //    Estado = EstadoProjeto.Finalizado;
        //}
    }
}
