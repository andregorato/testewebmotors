using Application.ViewModels;
using Domain.Dto;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application
{
    public interface IAnuncioApplication
    {
        long Adicionar(AnuncioViewModel anuncio);

        bool Atualizar(AnuncioViewModel anuncio);

        IEnumerable<Anuncio> ListarTodos();

        Anuncio ObterPorId(int id);
        bool DeletarPorId(Anuncio anuncio);

        Task<IEnumerable<MarcaDto>> ObterMarcasAsync();
        Task<IEnumerable<ModeloDto>> ObterModelosAsync(int marcaId);
        Task<IEnumerable<VersaoDto>> ObterVersoesAsync(int modeloId);

    }
}
