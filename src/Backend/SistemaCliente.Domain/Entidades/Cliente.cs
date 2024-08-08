namespace SistemaCliente.Domain.Entidades;

    public class Cliente : EntidadeBase
    {
        public string NomeEmpresa { get; set; } = string.Empty;

        public Porte Porte { get; set; }
    }

    