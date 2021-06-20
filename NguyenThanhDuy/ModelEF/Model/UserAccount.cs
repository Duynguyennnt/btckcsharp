namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAccount")]
    public partial class UserAccount
    {

        public int ID { get; set; }
        [Required]
        [Display(Name = "Tài Khoản")]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Mật Khẩu")]
        public string Password { get; set; }
        [Required]
        public int? Status { get; set; }
    }
}
