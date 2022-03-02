using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEvernote.WebApp.ViewModels
{
    public class OkeyViewModel:NotifyViewModelBase<string>
    {
        public OkeyViewModel()
        {
            Title = "İşlem başarılı!";
        }
    }
}