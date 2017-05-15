using GerenciamentoDeAnuncio.Domain.Entities;
using GerenciamentoDeAnuncio.Domain.Interfaces;
using GerenciamentoDeAnuncio.Domain.Interfaces.Repositories;

namespace GerenciamentoDeAnuncio.Infra.Data.Repositories
{
    public class AnuncioRepository : RepositoryBase<Anuncio>, IAnuncioRepository
    {
    }
}
