using Fiap.Web.AspNet2.Models;
using System.Collections.Generic;

namespace Fiap.Web.AspNet2.Repository.Interface
{
    public interface ILojaRepository
    {
        public LojaModel FindById(int id);

        public IList<LojaModel> FindAll();
    }
}
