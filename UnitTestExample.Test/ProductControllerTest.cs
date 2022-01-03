using System.Collections.Generic;
using System.Threading.Tasks;
using UnitTestExample.App.Models;
using Xunit;

namespace UnitTestExample.Test
{
    public class ProductControllerTest : Base<Product>
    {
        [Fact]
        public async Task Index_GetRepoExecutes_ReturnAllData()
        {
            var result = await _repo.GetAll();
            Assert.NotNull(result);
        }
    }
}


