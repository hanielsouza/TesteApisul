using ProvaApisul.DAL.Arquivo;
using ProvaApisul.DTO;

namespace ProvaApisul.Services.Elevador;

public class ElevadorService : IElevadorService
{
    private readonly List<LevantamentoUsuarioDTO> _dadosLevantamento;

    public ElevadorService()
    {
        _dadosLevantamento = ArquivoDAL.lerArquivo().ToList();
    }

    public List<int> andarMenosUtilizado()
    {
        return _dadosLevantamento
            .GroupBy(p => p.Andar)
            .OrderBy(p => p.Count())
            .Select(p => p.Key)
            .ToList();
    }

    public List<char> elevadorMaisFrequentado()
    {
        return _dadosLevantamento
            .GroupBy(p => p.Elevador)
            .OrderByDescending(p => p.Count())
            .Select(p => p.Key)
            .ToList();
    }

    public List<char> elevadorMenosFrequentado()
    {
        var teste = _dadosLevantamento
            .GroupBy(p => p.Elevador)
            .OrderBy(p => p.Count())
            .Select(p => p.Key)
            .ToList();

        return _dadosLevantamento
            .GroupBy(p => p.Elevador)
            .OrderBy(p => p.Count())
            .Select(p => p.Key)
            .ToList();
    }

    public float percentualDeUsoElevadorA() => CalcularPercentualDeUso(Elevador.A);

    public float percentualDeUsoElevadorB() => CalcularPercentualDeUso(Elevador.B);

    public float percentualDeUsoElevadorC() => CalcularPercentualDeUso(Elevador.C);

    public float percentualDeUsoElevadorD() => CalcularPercentualDeUso(Elevador.D);

    public float percentualDeUsoElevadorE() => CalcularPercentualDeUso(Elevador.E);

    public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
    {
        var elevadoresMaisFrequentes = _dadosLevantamento
                .GroupBy(d => d.Elevador)
                .OrderByDescending(g => g.Count())
                .Select(d => d.Key)
                .ToList();

        var turnosMaisFrequentes = new List<char>();

        foreach (var elevador in elevadoresMaisFrequentes)
        {
            var gruposPorTurno = _dadosLevantamento
                .Where(d => d.Elevador == elevador)
                .GroupBy(d => d.Turno)
                .OrderByDescending(g => g.Count());

            var turnoMaisFrequente = gruposPorTurno.First().Key;

            if (turnoMaisFrequente != default(char))
                turnosMaisFrequentes.Add(turnoMaisFrequente);
        }

        return turnosMaisFrequentes;
    }

    public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
    {
        return _dadosLevantamento
            .GroupBy(p => p.Turno)
            .OrderByDescending(p => p.Count())
            .Select(p => p.Key)
            .ToList();
    }

    public List<char> periodoMenorFluxoElevadorMenosFrequentado()
    {
        var elevadoresMenosFrequentes = _dadosLevantamento
                .GroupBy(d => d.Elevador)
                .OrderBy(g => g.Count())
                .Select(d => d.Key)
                .ToList();

        var turnosMenosFrequentes = new List<char>();

        foreach (var elevador in elevadoresMenosFrequentes)
        {
            var gruposPorTurno = _dadosLevantamento
                .Where(d => d.Elevador == elevador)
                .GroupBy(d => d.Turno)
                .OrderBy(g => g.Count());

            var turnoMenosFrequente = gruposPorTurno.First().Key;

            if (turnoMenosFrequente != default(char))
                turnosMenosFrequentes.Add(turnoMenosFrequente);
        }

        return turnosMenosFrequentes;
    }

    private float CalcularPercentualDeUso(Elevador elevador)
    {
        var nomeElevador = elevador.ToString();
        int totalDeOcorrencias = _dadosLevantamento.Count;
        int ocorrenciasDoElevador = _dadosLevantamento.Count(d => d.Elevador == char.Parse(nomeElevador));

        if (totalDeOcorrencias == 0)
            return 0.0F;

        // Calcular o percentual de uso multiplicando por 100
        var percentual = (float)ocorrenciasDoElevador / totalDeOcorrencias * 100;

        return (float)Math.Round(percentual, 2);
    }


    private enum Elevador
    {
        A,
        B,
        C,
        D,
        E
    }
}

