using System.ComponentModel.DataAnnotations;

namespace Geometry.Core.Enums
{
    internal enum TypeBySides
    {
        [Display(Name = "разносторонний")]
        Scalene = 1,
        [Display(Name = "равносторонний")]
        Equilateral = 2,
        [Display(Name = "равнобедренный")]
        Isosceles = 3
    }
}
