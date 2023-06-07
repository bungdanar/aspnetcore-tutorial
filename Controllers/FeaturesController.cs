namespace aspnetcore_tutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IFeatureRepository repository;

        public FeaturesController(IMapper mapper, IFeatureRepository repository)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet, Authorize]
        public async Task<ActionResult> GetFeatures()
        {
            var features = await repository.GetFeatures();

            return Ok(mapper.Map<List<Feature>, List<KeyValuePairResource>>(features));
        }
    }
}