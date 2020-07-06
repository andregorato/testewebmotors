using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Repository
{
    public interface IAnuncioRepository
    {
        IEnumerable<Anuncio> ListarTodos();
        Anuncio ObterPorId(int id);

        bool DeletarPorId(Anuncio anuncio);

        long Adicionar(Anuncio anuncio);

        bool Atualizar(Anuncio anuncio);


    }
}
