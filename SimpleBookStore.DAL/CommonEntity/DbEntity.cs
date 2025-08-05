using System.ComponentModel.DataAnnotations;

namespace SimpleBookStore.DAL.CommonEntity
{
    public class DbEntity
    {
        [Required]
        [MaxLength(100)]
        public string Createdby { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow.AddHours(6);
        public string Updatedby { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
