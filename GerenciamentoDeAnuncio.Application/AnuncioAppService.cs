using GerenciamentoDeAnuncio.Application.Interface;
using GerenciamentoDeAnuncio.Domain.Entities;
using GerenciamentoDeAnuncio.Domain.Interfaces.Services;

namespace GerenciamentoDeAnuncio.Application
{
    public class AnuncioAppService : AppServiceBase<Anuncio>, IAnuncioAppService
    {
        private readonly IAnuncioService _anuncioService;

        public AnuncioAppService(IAnuncioService anuncioService) : base(anuncioService)
        {
            _anuncioService = anuncioService;
        }

    }
}