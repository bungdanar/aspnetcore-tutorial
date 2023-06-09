namespace aspnetcore_tutorial.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<Photo, PhotoResource>();
            CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));
            CreateMap<Make, MakeResource>();
            CreateMap<Model, KeyValuePairResource>();
            CreateMap<Feature, KeyValuePairResource>();
            CreateMap<Vehicle, SaveVehicleResource>()
                .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResource
                {
                    Name = v.Contact.Name,
                    Email = v.Contact.Email,
                    Phone = v.Contact.Phone
                }))
                .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.VehicleFeatures.Select(vf => vf.FeatureId)));

            CreateMap<Vehicle, VehicleResource>()
                 .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResource
                 {
                     Name = v.Contact.Name,
                     Email = v.Contact.Email,
                     Phone = v.Contact.Phone
                 }))
                .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(f => new KeyValuePairResource { Id = f.Id, Name = f.Name })))
                .ForMember(vr => vr.Make, opt => opt.MapFrom(v => new MakeResource { Id = v.Model.Make.Id, Name = v.Model.Make.Name }));

            // API Resource to Domain
            CreateMap<VehicleQueryResource, VehicleQuery>();
            CreateMap<SaveVehicleResource, Vehicle>()
                .ForMember(v => v.Id, opt => opt.Ignore())
                .ForMember(v => v.Contact, opt => opt.MapFrom(vr => new Contact
                {
                    Name = vr.Contact.Name,
                    Email = vr.Contact.Email,
                    Phone = vr.Contact.Phone
                }))
                .ForMember(v => v.Features, opt => opt.Ignore())
                // .ForMember(v => v.VehicleFeatures, opt => opt.MapFrom(vr => vr.Features.Select(id => new VehicleFeature { FeatureId = id })))
                .ForMember(v => v.VehicleFeatures, opt => opt.Ignore())
                .AfterMap((vr, v) =>
                {
                    // Remove unselected features
                    // Using standar loop
                    var removedFeatures = new List<VehicleFeature>();
                    foreach (var f in v.VehicleFeatures)
                    {
                        if (!vr.Features.Contains(f.FeatureId))
                        {
                            removedFeatures.Add(f);
                        }
                    }

                    // Using LINQ (has bug!)
                    // var removedFeatures = v.VehicleFeatures.Where(f => !vr.Features.Contains(f.FeatureId));
                    foreach (var f in removedFeatures)
                        v.VehicleFeatures.Remove(f);

                    // Add new features
                    // Using standard loop
                    // foreach (var id in vr.Features)
                    // {
                    //     if (!v.VehicleFeatures.Any(f => f.FeatureId == id))
                    //     {
                    //         v.VehicleFeatures.Add(new VehicleFeature { FeatureId = id });
                    //     }
                    // }

                    // Using LINQ
                    var addedFeatures = vr.Features
                                            .Where(id => !v.VehicleFeatures.Any(f => f.FeatureId == id))
                                            .Select(id => new VehicleFeature { FeatureId = id });

                    foreach (var f in addedFeatures)
                        v.VehicleFeatures.Add(f);
                });

        }
    }
}