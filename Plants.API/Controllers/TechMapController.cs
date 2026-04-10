using Microsoft.AspNetCore.Mvc;
using Plants.API.Services;

namespace Plants.API.Controllers
{
    [Route("api/[controller]")]
    public class TechMapController : GenericController<TechMap>
    {
        public TechMapController(IService<TechMap> service) : base(service) { }
    }
}