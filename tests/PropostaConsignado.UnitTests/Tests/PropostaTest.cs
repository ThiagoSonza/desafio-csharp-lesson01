using PropostaConsignado.Api.Dominio.Agentes.Model;
using PropostaConsignado.Api.Dominio.Proposta.Enumerations;
using PropostaConsignado.Api.Dominio.Proposta.Model;
using PropostaConsignado.Api.Dominio.Regras.Infraestrutura;
using PropostaConsignado.UnitTests.Builders;

namespace PropostaConsignado.UnitTests.Tests
{
    public class PropostaTest
    {
        [Theory]
        [InlineData("AGENTE_01", "RS", 100_000)]
        public void DeveRetornarErro_AoInformarEstadoEValor(string usuario, string estado, decimal valor)
        {
            // Arrange
            var regras = RegraRepositorio.RegrasCriacaoProposta;
            var propostaCommand = CriarPropostaSetupBuilder.CriarPropostaCommandComEstadoEValor(usuario, estado, valor);
            var agenteDominio = AgenteDominio.Criar(usuario, true);

            // Act
            var resultado = PropostaDominio.Criar(propostaCommand.Value, agenteDominio.Value, regras);

            // Assert
            Assert.True(resultado.IsFailure);
            Assert.Equal($"Valor não permitido para o estado {estado}", resultado.Error);
        }

        [Theory]
        [InlineData("AGENTE_01", "SC", 30_000)]
        public void DeveRetornarSucesso_AoInformarEstadoEValor(string usuario, string estado, decimal valor)
        {
            // Arrange
            var regras = RegraRepositorio.RegrasCriacaoProposta;
            var propostaCommand = CriarPropostaSetupBuilder.CriarPropostaCommandComEstadoEValor(usuario, estado, valor);
            var agenteDominio = AgenteDominio.Criar(usuario, true);

            // Act
            var resultado = PropostaDominio.Criar(propostaCommand.Value, agenteDominio.Value, regras);

            // Assert
            Assert.True(resultado.IsSuccess);
        }

        [Theory]
        [InlineData("AGENTE_01", "1988-09-11", 840)]
        public void DeveRetornarErro_AoInformarDataNascimentoEParcelas(string usuario, DateTime dataNascimento, int parcelas)
        {
            // Arrange
            var regras = RegraRepositorio.RegrasCriacaoProposta;
            var propostaCommand = CriarPropostaSetupBuilder.CriarPropostaCommandComDataNascimentoEParcelas(usuario, dataNascimento, parcelas);
            var agenteDominio = AgenteDominio.Criar(usuario, true);

            // Act
            var resultado = PropostaDominio.Criar(propostaCommand.Value, agenteDominio.Value, regras);

            // Assert
            Assert.True(resultado.IsFailure);
            Assert.Equal("Numero de parcelas ultrapassa o limite.", resultado.Error);
        }

        [Theory]
        [InlineData("AGENTE_01", "1975-01-01", 6)]
        public void DeveRetornarSucesso_AoInformarDataNascimentoEParcelas(string usuario, DateTime dataNascimento, int parcelas)
        {
            // Arrange
            var regras = RegraRepositorio.RegrasCriacaoProposta;
            var propostaCommand = CriarPropostaSetupBuilder.CriarPropostaCommandComDataNascimentoEParcelas(usuario, dataNascimento, parcelas);
            var agenteDominio = AgenteDominio.Criar(usuario, true);

            // Act
            var resultado = PropostaDominio.Criar(propostaCommand.Value, agenteDominio.Value, regras);

            // Assert
            Assert.True(resultado.IsSuccess);
        }

        [Theory]
        [InlineData("AGENTE_01", "RJ", "21")]
        public void DeveRetornarSucesso_AoProcessarAssinaturaEletronica(string usuario, string estado, string prefixo)
        {
            // Arrange
            var regras = RegraRepositorio.RegrasCriacaoProposta;
            var propostaCommand = CriarPropostaSetupBuilder.CriarPropostaCommandComEstadoEPrefixoTelefone(usuario, estado, prefixo);
            var agenteDominio = AgenteDominio.Criar(usuario, true);

            // Act
            var resultado = PropostaDominio.Criar(propostaCommand.Value, agenteDominio.Value, regras);

            // Assert
            Assert.True(resultado.IsSuccess);
            Assert.Equal((int)TipoAssinaturaEnum.AssinaturaEletronica, resultado.Value.TipoAssinatura);
        }

        [Theory]
        [InlineData("AGENTE_01", "RS", "11")]
        public void DeveRetornarSucesso_AoProcessarAssinaturaFigital(string usuario, string estado, string prefixo)
        {
            // Arrange
            var regras = RegraRepositorio.RegrasCriacaoProposta;
            var propostaCommand = CriarPropostaSetupBuilder.CriarPropostaCommandComEstadoEPrefixoTelefone(usuario, estado, prefixo);
            var agenteDominio = AgenteDominio.Criar(usuario, true);

            // Act
            var resultado = PropostaDominio.Criar(propostaCommand.Value, agenteDominio.Value, regras);

            // Assert
            Assert.True(resultado.IsSuccess);
            Assert.Equal((int)TipoAssinaturaEnum.AssinaturaFigital, resultado.Value.TipoAssinatura);
        }

        [Theory]
        [InlineData("AGENTE_01", "SC", "47")]
        public void DeveRetornarSucesso_AoProcessarAssinaturaHibrida(string usuario, string estado, string prefixo)
        {
            // Arrange
            var regras = RegraRepositorio.RegrasCriacaoProposta;
            var propostaCommand = CriarPropostaSetupBuilder.CriarPropostaCommandComEstadoEPrefixoTelefone(usuario, estado, prefixo);
            var agenteDominio = AgenteDominio.Criar(usuario, true);

            // Act
            var resultado = PropostaDominio.Criar(propostaCommand.Value, agenteDominio.Value, regras);

            // Assert
            Assert.True(resultado.IsSuccess);
            Assert.Equal((int)TipoAssinaturaEnum.AssinaturaHibrida, resultado.Value.TipoAssinatura);
        }
    }
}