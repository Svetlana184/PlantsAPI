using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Plants.API.Services;

namespace Plants.API.Controllers
{
    [Route("api/[controller]")]
    public class BatchParameterController : GenericController<BatchParameter>
    {
        public BatchParameterController(IService<BatchParameter> service) : base(service) { }
    }
}