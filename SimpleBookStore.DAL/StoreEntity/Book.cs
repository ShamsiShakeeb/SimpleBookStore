using System.ComponentModel.DataAnnotations;
using SimpleBookStore.DAL.CommonEntity;

namespace SimpleBookStore.DAL.StoreEntity
{
    public class Book : DbEntity
    {
        [Key]
        public int Id { get; set; }  
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }    
        [Required]
        [MaxLength(50)]
        public string Author { get; set; }   
        [Required]
        [MaxLength(50)]
        public string ISBN { get; set; }   
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime PublishedDate { get; set; }

        [Required]
        public int Stock {  get; set; }
        public List<UserBook> User_Books { set; get; }
        public List<Review> Review { set; get; }
    }
}
