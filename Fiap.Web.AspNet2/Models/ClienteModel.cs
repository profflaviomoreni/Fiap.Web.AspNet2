using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.AspNet2.Models
{
    public class ClienteModel
    {

        public int ClienteId { get; set; }

        public String Nome { get; set; }

        public String Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public String  Observacao { get; set; }

    }
}
