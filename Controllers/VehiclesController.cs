namespace aspnetcore_tutorial.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IMapper mapper;

        public VehiclesController(IMapper mapper)
        {
            this.mapper = mapper;

        }

        [HttpPost]
        public async Task<ActionResult> CreateVehicle(VehicleResource vehicleResource)
        {
            var vehicle = mapper.Map<VehicleResource, Vehicle>(vehicleResource);

            return Ok(vehicle);
        }
    }
}