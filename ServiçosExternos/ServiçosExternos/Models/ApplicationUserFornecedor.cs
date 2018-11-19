using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ServiçosExternos.Models
{
    [Table("AspNetUsers_Fornecedors")]
    public class ApplicationUserFornecedor
    {
        [Key]
        public int Id { get; set; }        

        [Required]
        [ForeignKey("ApplicationUser")]
        [Display(Name = "Usuário")]
        public string ApplicationUserId { get; set; }

        [Display(Name = "Usuário")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        [ForeignKey("Fornecedor")]
        [Display(Name = "Fornecedor")]
        public int FornecedorId { get; set; }

        [Display(Name = "Fornecedor")]
        public virtual Fornecedor Fornecedor { get; set; }
    }
}