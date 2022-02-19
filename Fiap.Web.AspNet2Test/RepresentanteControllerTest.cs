using Fiap.Web.AspNet2.Controllers;
using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fiap.Web.AspNet2Test
{
    public class RepresentanteControllerTest
    {

        [Fact]
        public Task IndexReturnsViewResultWithListOfRepresentantes()
        {

            var repositoryMock = new Mock<IRepresentanteRepository>();
            repositoryMock.Setup(r => r.FindAll()).Returns( ListaRepresenantes3() );

            var controller = new RepresentanteController(repositoryMock.Object);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<RepresentanteModel>>(viewResult.Model);

            Assert.Equal(3, model.Count());

            return Task.CompletedTask;
        }

        [Fact]
        public Task IndexReturnsViewResultWithZeroOfRepresentantes()
        {
            var repositoryMock = new Mock<IRepresentanteRepository>();
            repositoryMock.Setup(r => r.FindAll()).Returns( new List<RepresentanteModel>());

            var controller = new RepresentanteController(repositoryMock.Object);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<RepresentanteModel>>(viewResult.Model);

            Assert.Empty(model);

            return Task.CompletedTask;
        }



        private IList<RepresentanteModel> ListaRepresenantes3()
        {
            return new List<RepresentanteModel>()
            {
                new RepresentanteModel(1,"Flávio"),
                new RepresentanteModel(2,"Eduardo"),
                new RepresentanteModel(3,"Moreni"),
            };
        }

    }
}
