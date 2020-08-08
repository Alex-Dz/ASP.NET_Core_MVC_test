using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebApp.Models
{
    public class User
    {
        public int IdUsuario { get; set; }
        
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(45, ErrorMessage = "Máximo 45 caracteres")]
        public string Name { get; set; }
    }
}