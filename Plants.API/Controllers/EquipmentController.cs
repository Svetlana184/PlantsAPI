using Microsoft.AspNetCore.Mvc;
using Plants.API.Services;

namespace Plants.API.Controllers
{
    [Route("api/[controller]")]
    public class EquipmentController : GenericController<Equipment>
    {
        public EquipmentController(IService<Equipment> service) : base(service) { }
    }
}