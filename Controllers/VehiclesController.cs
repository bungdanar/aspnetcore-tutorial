namespace aspnetcore_tutorial.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly AppDbContext context;
        private readonly IVehicleRepository repository;

        public VehiclesController(IMapper mapper, AppDbContext context, IVehicleRepository repository)
        {
            this.repository = repository;
            this.context = context;
            this.mapper = mapper;

        }

        [HttpPost]
        public async Task<ActionResult> CreateVehicle([FromBody] SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var model = await context.Models.FindAsync(vehicleResource.ModelId);
            if (model == null)
            {
                ModelState.AddModelError("ModelId", "Invalid modelId.");
                return BadRequest(ModelState);
            }

            var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdated = DateTime.Now;

            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();

            vehicle = await repository.GetVehicle(vehicle.Id);

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVehicle(int id, [FromBody] SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var vehicle = await repository.GetVehicle(id);

            if (vehicle == null)
                return NotFound();

            mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdated = DateTime.Now;

            await context.SaveChangesAsync();

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVehicle(int id)
        {
            var vehicle = await context.Vehicles.FindAsync(id);

            if (vehicle == null)
                return NotFound();

            context.Vehicles.Remove(vehicle);
            await context.SaveChangesAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetVehicle(int id)
        {
            var vehicle = await repository.GetVehicle(id);

            if (vehicle == null)
                return NotFound();

            var vehicleResource = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(vehicleResource);
        }
    }
}