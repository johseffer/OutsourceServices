using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ServiçosExternos.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Valor")]
        //[HtmlProperties(CssClass = "currency")]
        public decimal Value { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data")]
        public DateTime? Date { get; set; }

        [Required]
        [Display(Name = "Tipo de Serviço")]
        public string ServiceType { get; set; }

        [Required]
        [ForeignKey("Cliente")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [Display(Name = "Cliente")]
        public virtual Cliente Cliente { get; set; }

        [Required]
        [ForeignKey("Fornecedor")]
        [Display(Name = "Fornecedor")]
        public int FornecedorId { get; set; }

        [Display(Name = "Fornecedor")]
        public virtual Fornecedor Fornecedor { get; set; }
    }
}