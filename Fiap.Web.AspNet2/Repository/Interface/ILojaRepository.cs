using Fiap.Web.AspNet2.Models;

namespace Fiap.Web.AspNet2.Repository.Interface
{
    public interface ILojaRepository
    {
        public LojaModel FindById(int id);
    }
}
