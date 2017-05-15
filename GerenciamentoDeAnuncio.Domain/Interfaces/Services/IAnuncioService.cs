using GerenciamentoDeAnuncio.Domain.Entities;
using GerenciamentoDeAnuncio.Domain.Interfaces.Repositories;

namespace GerenciamentoDeAnuncio.Domain.Interfaces.Services
{
    public interface IAnuncioService  : IRepositoryBase<Anuncio>
    {
    }
}
