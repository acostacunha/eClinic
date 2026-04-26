using System.ComponentModel;

namespace eClinic.Client.API.Model
{
    public record PaginationResult(
        [property: Description("Número de clientes a retornar em única página de resultados")]
    [property: DefaultValue(10)]
    int PageSize = 10,

        [property: Description("O índice da página de resultados a retornar")]
    [property: DefaultValue(0)]
    int PageIndex = 0
    );
}
