using System.ComponentModel.DataAnnotations;

namespace SimpleBookStore.Model.Request
{
    public class LoginRequestModel
    {
        [Required]
        public string UserName { set; get; }
        [Required]
        public string Password { set; get; }
    }
}
