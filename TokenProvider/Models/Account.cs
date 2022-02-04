using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TokenProvider.Models
{
    public class Account
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }   
        public string UserPsswd { get; set; }   
        public string UserRole { get; set; }

    }
}
