namespace aspnetcore_tutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public FeaturesController(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeatureResource>>> GetFeatures()
        {
            var features = await _context.Features.ToListAsync();

            return _mapper.Map<List<Feature>, List<FeatureResource>>(features);
        }
    }
}