namespace aspnetcore_tutorial.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Feature, FeatureResource>();

            // API Resource to Domain
            CreateMap<VehicleResource, Vehicle>()
                .ForMember(v => v.Contact, opt => opt.MapFrom(vr => new Contact
                {
                    Name = vr.Contact.Name,
                    Email = vr.Contact.Email,
                    Phone = vr.Contact.Phone
                }))
                .ForMember(v => v.Features, opt => opt.MapFrom(vr => vr.Features.Select(id => new Feature { Id = id })));
        }
    }
}