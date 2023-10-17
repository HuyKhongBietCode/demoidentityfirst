using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoIdentityEntityFramework.Models
{
    [Table("articles")]
    public class Article
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Phải Nhập {1}")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "The {0} must be have least 5 character")]
        [Column(TypeName = "nvarchar")]
        [DisplayName("Tiêu Đề")]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Ngay {1} phải được nhập")]
        [DisplayName("Ngày Tạo")]
        public DateTime Created { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Nội Dung Bài Viết")]
        public string Content { get;set; }
    }
}
