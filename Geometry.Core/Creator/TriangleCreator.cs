using Geometry.Core.Shapes;

namespace Geometry.Core.Creator
{
    public class TriangleCreator : ShapeCreator
    {
        private readonly double _sideA;
        private readonly double _sideB;
        private readonly double _sideC;

        public TriangleCreator(double sideA, double sideB, double sideC)
        {
            _sideA = sideA;
            _sideB = sideB;
            _sideC = sideC;
        }
        public override IShape CreateShape()
        {
            return new Triangle(_sideA, _sideB, _sideC);
        }
    }
}
