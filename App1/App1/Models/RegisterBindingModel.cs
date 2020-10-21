using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
  public  class RegisterBindingModel
    {
        //[Required]
        //[Display(Name = "E-mail")]
        public string Email { get; set; }

        //[Required]
        //[StringLength(100, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        //[Display(Name = "Mot de passe")]
        public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirmer le mot de passe ")]
        //[Compare("Password", ErrorMessage = "Le mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }
    }
}
