using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoIdentityEntityFramework.Models
{
    [Table("articles")]
    public class Article
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(100, MinimumLength =5, ErrorMessage ="The {0} must be have least 5 character")]
        [Column(TypeName ="nvarchar")]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        [Required]
        
        public DateTime Created { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get;set; }
    }
}
