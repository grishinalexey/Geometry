using System.ComponentModel.DataAnnotations;

namespace Geometry.Core.Enums
{
    internal enum TypeByCorners
    {
        [Display(Name = "прямоугольный")]
        Right = 1,
        [Display(Name = "остроугольный")]
        Acute = 2,
        [Display(Name = "тупоугольный")]
        Obtuse = 3
    }
}
