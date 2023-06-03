namespace aspnetcore_tutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IMakeRepository repository;

        public MakesController(IMapper mapper, IMakeRepository repository)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        // GET: api/Makes
        [HttpGet]
        public async Task<ActionResult> GetMakes()
        {
            var makes = await repository.GetMakes();

            return Ok(mapper.Map<List<Make>, List<MakeResource>>(makes));
        }
    }
}
