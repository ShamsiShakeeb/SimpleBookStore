using SimpleBookStore.DAL.CommonEntity;
using System.ComponentModel.DataAnnotations;

namespace SimpleBookStore.DAL.LogEntity
{
    public class Logs : DbEntity
    {
        [Key]
        public int Id { get; set; }
        public bool Success { get; set; }
        [Required]
        public string Message {  get; set; }
        public string ErrorMessage {  get; set; }
    }
}
