using System.Collections.ObjectModel;

namespace PropostaConsignado.Api.Dominio.Proponentes.Infraestrutura
{
    public class ProponenteRepositorio
    {
        private readonly ReadOnlyCollection<string> blackList = new(
        [
            "18182432022",
            "34194834062"
        ]);

        public bool VerificaCpfLiberado(string cpf)
        {
            var result = !blackList.Contains(cpf);
            return result;
        }
    }
}