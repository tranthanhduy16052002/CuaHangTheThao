using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CuaHangTheThao.Models
{
    public class DoTheThao
    {
        public int Id { get; set; }
        [Display(Name ="Tên Hàng")]
        public string Title { get; set; }
        
        [Display(Name = "Ngày Đặt Hàng")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Size")]
        public string Genre { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Giá Thành")]
        public decimal Price { get; set; }
        [Display(Name = "Tồn Kho")]
        public string Rating { get; set; }
    }
}
