using Microsoft.AspNetCore.Mvc;
using Plants.API.Services;

namespace Plants.API.Controllers
{
    [Route("api/[controller]")]
    public class RecipeComponentController : GenericController<RecipeComponent>
    {
        public RecipeComponentController(IService<RecipeComponent> service) : base(service) { }
    }
}