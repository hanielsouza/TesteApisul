using System.Text.Json.Serialization;

namespace ProvaApisul.DTO;

public class LevantamentoUsuarioDTO
{
    [JsonPropertyName("andar")]
    public int Andar { get; set; }

    [JsonPropertyName("elevador")]
    public char Elevador { get; set; }

    [JsonPropertyName("turno")]
    public char Turno { get; set; }
}

