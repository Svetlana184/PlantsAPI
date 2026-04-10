using Microsoft.AspNetCore.Mvc;
using Plants.API.Services;

namespace Plants.API.Controllers
{
    [Route("api/[controller]")]
    public class StepParameterController : GenericController<StepParameter>
    {
        public StepParameterController(IService<StepParameter> service) : base(service) { }
    }
}