namespace Geometry.Core.Shapes
{
    public interface IShape
    {
        /// <summary>
        /// Получить площадь фигуры
        /// </summary>
        /// <returns></returns>
        double GetArea();
        /// <summary>
        /// Получить название фигуры
        /// </summary>
        string GetName();
        /// <summary>
        /// Правильно ли составлена фигура
        /// </summary>
        /// <returns></returns>
        bool IsValid();
    }
}
