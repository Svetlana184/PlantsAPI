using Microsoft.AspNetCore.Mvc;
using Plants.API.Services;

namespace Plants.API.Controllers
{
    [Route("api/[controller]")]
    public class TechStepController : GenericController<TechStep>
    {
        public TechStepController(IService<TechStep> service) : base(service) { }
    }
}