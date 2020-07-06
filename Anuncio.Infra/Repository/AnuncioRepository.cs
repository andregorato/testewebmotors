using Dapper.Contrib.Extensions;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Infra.Repository
{
    public class AnuncioRepository : IAnuncioRepository
    {
        private string _conn { get; set; }

        private IConfiguration _configuracoes;

        public AnuncioRepository(IConfiguration config)
        {
            _configuracoes = config;
            _conn = _configuracoes.GetConnectionString("BaseAnuncios");
        }

        public long Adicionar(Anuncio anuncio)
        {
            using MySqlConnection conexao = new MySqlConnection(_conn);

            return conexao.Insert(anuncio);
        }

        public bool Atualizar(Anuncio anuncio)
        {
            using MySqlConnection conexao = new MySqlConnection(_conn);

            return conexao.Update(anuncio);
        }

        public bool DeletarPorId(Anuncio anuncio)
        {
            using MySqlConnection conexao = new MySqlConnection(_conn);

            return conexao.Delete(anuncio);
        }

        public IEnumerable<Anuncio> ListarTodos()
        {
            using MySqlConnection conexao = new MySqlConnection(_conn);

            return conexao.GetAll<Anuncio>();
        }

        public Anuncio ObterPorId(int id)
        {
            using MySqlConnection conexao = new MySqlConnection(_conn);

            return conexao.Get<Anuncio>(id);
        }
    }
}
