namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Tên Sản Phẩm")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Đơn Giá")]
        public decimal? UnitCost { get; set; }
        [Display(Name = "Số Lượng")]
        [Required]
        public int? Quantity { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Hình Ảnh")]
        public string Image { get; set; }
        [Display(Name = "Mô Tả")]
        [StringLength(250)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Trạng Thái")]
        public int? Status { get; set; }
        [Display(Name = "Loại Sản Phẩm")]
        public int? IDCategory { get; set; }

        public virtual Category Category { get; set; }
    }
}
