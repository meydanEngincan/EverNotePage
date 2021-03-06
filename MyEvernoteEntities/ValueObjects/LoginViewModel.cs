using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEvernoteEntities.ValueObjects
{
    public class LoginViewModel
    {
        [DisplayName("Kullanıcı adı"), Required(ErrorMessage = "{0} Alanı boş geçilemez."), StringLength(25, ErrorMessage = "{0} max {1} karakter olmalı.")]
        public string UserName { get; set; }

        [DisplayName("Şifre"), Required(ErrorMessage = " {0} Alanı boş geçilemez."),DataType(DataType.Password), StringLength(25, ErrorMessage = "{0} max {1} karakter olmalı.")]
        public string Password { get; set; }
    }
}