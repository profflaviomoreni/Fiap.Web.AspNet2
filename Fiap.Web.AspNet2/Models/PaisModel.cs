using System;

namespace Fiap.Web.AspNet2.Models
{
    public class PaisModel
    {
        public PaisModel()
        {
        }

        public PaisModel(string nomePais, string continente)
        {
            NomePais = nomePais;
            Continente = continente;
        }

        public PaisModel(int paisId, string nomePais, string continente)
        {
            PaisId = paisId;
            NomePais = nomePais;
            Continente = continente;
        }

        public int PaisId { get; set; }

        public String NomePais { get; set; }

        public String Continente { get; set; }

    }
}
