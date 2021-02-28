using api.crossCutting.Mappings;
using AutoMapper;
using System;
using Xunit;

namespace api.services.test
{
    public abstract class BaseTesteService
    {
        public IMapper mapper { get; set; }
        public BaseTesteService()
        {
            mapper = new AutoMapperFixture().GetMapper();
        }
    }

    public class AutoMapperFixture : IDisposable
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new DtoToEntityProfile());                
            });

            return config.CreateMapper();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
