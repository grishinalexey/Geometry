using Geometry.Core.Shapes;

namespace Geometry.Core.Creator

{
    public class CircleCreator : ShapeCreator
    {
        private readonly double _radius;

        public CircleCreator(double radius)
        {
            _radius = radius;
        }
        public override IShape CreateShape()
        {
            return new Circle(_radius);
        }
    }
}
