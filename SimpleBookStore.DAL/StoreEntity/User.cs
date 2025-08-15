using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SimpleBookStore.DAL.StoreEntity
{
    public class User : IdentityUser
    {
        [MaxLength(250)]
        public string Address { set; get; }
        [MaxLength(10)]
        public string Gender { set; get; }
        public int Age { set; get; }
        public List<UserBook> User_Books { set; get; } 
        public List<Review> Review {  set; get; }
    }
}
