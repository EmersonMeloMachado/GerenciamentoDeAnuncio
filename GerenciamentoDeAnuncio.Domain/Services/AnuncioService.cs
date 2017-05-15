using GerenciamentoDeAnuncio.Domain.Entities;
using GerenciamentoDeAnuncio.Domain.Interfaces.Repositories;
using GerenciamentoDeAnuncio.Domain.Interfaces.Services;

namespace GerenciamentoDeAnuncio.Domain.Services
{
    public class AnuncioService : ServiceBase<Anuncio>, IAnuncioService
    {
        private readonly IAnuncioRepository _anuncioRepository;
        public AnuncioService(IAnuncioRepository anuncioRepository) : base(anuncioRepository)
        {
            _anuncioRepository = anuncioRepository;
        }
    }
}
