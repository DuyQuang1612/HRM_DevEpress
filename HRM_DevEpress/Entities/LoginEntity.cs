using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM.Web.Entities;

public class LoginEntity
{

    public int Id { get; set; }
    [Required]
    [Display(Name = "Username")]
    public string UserName { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public bool RememberLogin { get; set; }
    public string ReturnUrl { get; set; }
    public string Role { get; set; }
}
