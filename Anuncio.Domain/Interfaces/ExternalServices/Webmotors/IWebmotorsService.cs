using Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.ExternalServices.Webmotors
{
    public interface IWebmotorsService
    {
        Task<IEnumerable<MarcaDto>> ObterMarcasAsync();
        Task<IEnumerable<ModeloDto>> ObterModelosAsync(int marcaId);
        Task<IEnumerable<VersaoDto>> ObterVersoesAsync(int modeloId);

    }
}
