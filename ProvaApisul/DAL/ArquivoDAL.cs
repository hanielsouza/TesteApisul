using ProvaApisul.DTO;
using System.Text.Json;

namespace ProvaApisul.DAL.Arquivo;

public class ArquivoDAL
{
    const string CAMINHO_ARQUIVO = "DAL/Arquivo/input.json";

    public static IEnumerable<LevantamentoUsuarioDTO> lerArquivo()
    {
        var json = File.ReadAllText(CAMINHO_ARQUIVO) ?? throw new FileNotFoundException("Arquivo não encontrado");
        var arquivo = JsonSerializer.Deserialize<IEnumerable<LevantamentoUsuarioDTO>>(json);

        return arquivo ?? Array.Empty<LevantamentoUsuarioDTO>();
    }
}
