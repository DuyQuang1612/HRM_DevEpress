using System.ComponentModel.DataAnnotations;

namespace HRM_DevEpress.Models
{
    public class Login
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberLogin { get; set; }
        //public string ReturnUrl
        //{
        //    get
        //    {
        //        return string.IsNullOrEmpty(_ReturnUrl) ? "/Home" : _ReturnUrl;
        //    }
        //    set
        //    {
        //        { _ReturnUrl = value; }
        //    }
        //}
        public string Role { get; set; }
    }
}
