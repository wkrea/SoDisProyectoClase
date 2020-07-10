using System.ComponentModel;

namespace Supermarket.API.Dominio.Entidades
{
    public enum EUndMedida : byte
    {
        [Description("unidad")]
        und = 1,

        [Description("miligramo")]
        mg = 2,

        [Description("gramo")]
        gr = 3,

        [Description("kilogramo")]
        kg = 4,

        [Description("litro")]
        L = 5
    }
}