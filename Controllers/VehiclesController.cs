namespace aspnetcore_tutorial.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly AppDbContext context;

        public VehiclesController(IMapper mapper, AppDbContext context)
        {
            this.context = context;
            this.mapper = mapper;

        }

        [HttpPost]
        public async Task<ActionResult> CreateVehicle(VehicleResource vehicleResource)
        {
            var vehicle = mapper.Map<VehicleResource, Vehicle>(vehicleResource);

            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }
    }
}