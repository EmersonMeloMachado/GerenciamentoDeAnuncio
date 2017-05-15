using AutoMapper;

namespace GerenciamentoDeAnuncio.MVC.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegistraMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}