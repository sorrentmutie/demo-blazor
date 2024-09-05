using Microsoft.JSInterop;

namespace Blazor.UI.Library.Interop;

public class Helper
{
    public Helper(string Nome)
    {
        this.Nome = Nome;
    }

    public string Nome { get; }

    [JSInvokable]
    public string Saluta()
    {
        return $"Ciao {Nome}";
    }
}
