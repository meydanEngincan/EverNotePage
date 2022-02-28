using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEvernoteEntities.ValueObjects
{
    public class RegisterViewModel
    {
        [DisplayName("Kullanıcı adı"), Required(ErrorMessage = "{0} Alanı boş geçilemez."), StringLength(25, ErrorMessage = "{0} max {1} karakter olmalı.")]
        public string UserName { get; set; }
        [DisplayName("E-Posta"), Required(ErrorMessage = " {0} Alanı boş geçilemez."), DataType(DataType.Password), StringLength(70, ErrorMessage = "{0} max {1} karakter olmalı."), EmailAddress(ErrorMessage = "{0} için geçerli bir adres giriniz.")]
        public string EMail { get; set; }
        [DisplayName("Şifre"), Required(ErrorMessage = " {0} Alanı boş geçilemez."), DataType(DataType.Password), StringLength(25, ErrorMessage = "{0} max {1} karakter olmalı.")]
        public string Password { get; set; }

        [DisplayName("Şifre Tekrar"), Required(ErrorMessage = " {0} Alanı boş geçilemez."), DataType(DataType.Password), StringLength(25, ErrorMessage = "{0} max {1} karakter olmalı."), Compare("Password", ErrorMessage ="{0} ile {1} uyuşmuyor")]
        public string RePassword { get; set; }
    }
}