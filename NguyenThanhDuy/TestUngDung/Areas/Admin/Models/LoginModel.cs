using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestUngDung.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Vui lòng nhập Username")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập Password")]
        public string Password { set; get; }
        public int Status { set; get; }
    }
}
