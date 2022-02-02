using System;

namespace Geometry.Core.Shapes
{
    public class Circle : IShape
    {
        private readonly double _radius;
        public Circle(double radius)
        {
            _radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(_radius, 2);
        }
        string IShape.GetName() => "окружность";

        public bool IsValid() => _radius > 0;

    }
}
