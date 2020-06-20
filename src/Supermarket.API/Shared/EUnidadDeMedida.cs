using System.ComponentModel;

namespace EUnidadDeMedida
{
    /// <summary>
    /// Clase de tipo enumerable 
    /// que permite representar las unidades de medida de un producto
    /// </summary>
    public enum EUnidadDeMedida : byte
    {
        [Description("Unidad")]
        Und = 1,

        [Description("miligramo")]
        mg = 2,

        [Description("Gramo")]
        gr = 3,

        [Description("Kilogramo")]
        Kg = 4,

        [Description("Litro")]
        Lt = 5
    }
}