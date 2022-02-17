using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet2.Models
{

    [Table("Login")]
    public class LoginModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoginId { get; set; }

        public String Usuario { get; set; }

        public String NomeUsuario { get; set; }

        public String Senha { get; set; }

        public String Token { get; set; }

        public DateTime Created { get; set; }

    }
}
