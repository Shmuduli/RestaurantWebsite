using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebsite.UI.Models
{

    [Table("AdminTable")]
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Please enter your LoginId")]
        public string LoginId { set; get; }
        [Required(ErrorMessage = "Please enter your password")]
        //[RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Invalid password format.")]
        public string Password { set; get; }
        public string Type { get => "Admin"; }
    }
}
