using Dapper.Contrib.Extensions;

namespace Domain.Entities
{
    [Table("tb_anunciowebmotors")]
    public class Anuncio
    {
        [ExplicitKey]
        public int ID { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Versao { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public string Observacao { get; set; }

    }
}
