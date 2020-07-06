using Application.ViewModels;
using Domain.Dto;
using Domain.Entities;
using Domain.Interfaces.ExternalServices.Webmotors;
using Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application
{
    public class AnuncioApplication : IAnuncioApplication
    {
        private IAnuncioRepository _anuncioRepository;
        private IWebmotorsService _webmotorsService;

        public AnuncioApplication(IAnuncioRepository anuncioRepository,
            IWebmotorsService webmotorsService)
        {
            _anuncioRepository = anuncioRepository;
            _webmotorsService = webmotorsService;

        }

        public long Adicionar(AnuncioViewModel anuncioViewModel)
        {
            var anuncio = new Anuncio
            {
                ID = anuncioViewModel.ID,
                Ano = anuncioViewModel.Ano,
                Marca = anuncioViewModel.Marca.Split('|')[1],
                Modelo = anuncioViewModel.Modelo.Split('|')[1],
                Observacao = anuncioViewModel.Observacao,
                Quilometragem = anuncioViewModel.Quilometragem,
                Versao = anuncioViewModel.Versao.Split('|')[1],
            };

            return _anuncioRepository.Adicionar(anuncio);


        }

        public bool Atualizar(AnuncioViewModel anuncioViewModel)
        {
            var anuncio = new Anuncio
            {
                ID = anuncioViewModel.ID,
                Ano = anuncioViewModel.Ano,
                Marca = anuncioViewModel.Marca.Split('|')[1],
                Modelo = anuncioViewModel.Modelo.Split('|')[1],
                Observacao = anuncioViewModel.Observacao,
                Quilometragem = anuncioViewModel.Quilometragem,
                Versao = anuncioViewModel.Versao.Split('|')[1],
            };

            return _anuncioRepository.Atualizar(anuncio);
        }

        public bool DeletarPorId(Anuncio anuncio)
        {
            return _anuncioRepository.DeletarPorId(anuncio);
        }

        public IEnumerable<Anuncio> ListarTodos()
        {
            return _anuncioRepository.ListarTodos();
        }

        public Task<IEnumerable<MarcaDto>> ObterMarcasAsync()
        {
            return _webmotorsService.ObterMarcasAsync();
        }

        public Task<IEnumerable<ModeloDto>> ObterModelosAsync(int marcaId)
        {
            return _webmotorsService.ObterModelosAsync(marcaId);
        }

        public Anuncio ObterPorId(int id)
        {
            return _anuncioRepository.ObterPorId(id);
        }

        public Task<IEnumerable<VersaoDto>> ObterVersoesAsync(int modeloId)
        {
            return _webmotorsService.ObterVersoesAsync(modeloId);
        }
    }
}
