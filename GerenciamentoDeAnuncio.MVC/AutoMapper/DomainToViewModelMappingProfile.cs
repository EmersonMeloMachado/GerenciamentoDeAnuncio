using AutoMapper;
using GerenciamentoDeAnuncio.Domain.Entities;
using GerenciamentoDeAnuncio.MVC.ViewModels;

namespace GerenciamentoDeAnuncio.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected  void Configure()
        {
            CreateMap<Anuncio, AnuncioViewModel>();
        }
    }
}