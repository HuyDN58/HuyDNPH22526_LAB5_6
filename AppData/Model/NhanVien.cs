using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Model
{
    public class NhanVien
    {
        [Required]
        public Guid Id { get; set; }
        [StringLength(30)]
        public string? Ten { get; set; }
        [Range(18, 50, ErrorMessage = "Tuoi bat buoc cua cong ty toi tu 18 den 50")]
        public int Tuoi { get; set; }
        public int Role { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Range(5000000, 30000000, ErrorMessage = "Luong cua cong ty toi tu 5tr den 30tr")]
        public int Luong { get; set; }
        public bool TrangThai { get; set; }
    }
}
