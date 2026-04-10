using Microsoft.AspNetCore.Mvc;
using Plants.API.Services;

namespace Plants.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : GenericController<Product>
    {
        public ProductController(IService<Product> service) : base(service) { }
    }
}