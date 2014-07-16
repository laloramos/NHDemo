using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernateSample.Domain.Entities;

namespace NHibernateSample.Domain.Mapping
{
    public class MovieMapping : ClassMapping<Movie>
    {
        public MovieMapping()
        {
            Id(x => x.Id,  map => map.Generator(Generators.Identity));
            Property(x=>x.Name);
        }
    }
}