using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    [Table("users_aspnetcore")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(45)")]
        public string name { get; set; }
        [Column(TypeName = "varchar(45)")]
        public string email { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string phone { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string job { get; set; }
    }
}
