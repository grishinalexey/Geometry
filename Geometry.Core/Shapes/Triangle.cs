using Geometry.Core.Enums;
using Geometry.Core.Extensions;
using System;

namespace Geometry.Core.Shapes
{
    public class Triangle : IShape
    {
        private readonly double _sideA;
        private readonly double _sideB;
        private readonly double _sideC;
        private readonly TypeBySides _typeBySides;
        private readonly TypeByCorners _typeByCorners;
        private string _name;

        public double SideA => _sideA;
        public double SideB => _sideB;
        public double SideC => _sideC;

        internal TypeBySides TypeBySides => _typeBySides;
        internal TypeByCorners TypeByCorners => _typeByCorners;

        public Triangle(double sideA, double sideB, double sideC)
        {
            _sideA = sideA;
            _sideB = sideB;
            _sideC = sideC;
            EnsureValidShape();
            _typeBySides = TriangleTypeCalculator.CalcTypeBySides(this);
            _typeByCorners = TriangleTypeCalculator.CalcTypeByCorners(this);
        }

        public double GetArea()
        {
            var x = (_sideA + _sideB + _sideC) / 2;
            return Math.Sqrt(x * (x - _sideA) * (x - _sideB) * (x - _sideC));
        }

        public string GetName()
        {
            const string basicName = "треугольник";
            return _name ??= $"{_typeByCorners.GetDisplayName()} {_typeBySides.GetDisplayName()} {basicName}";
        }
        public bool IsValid()
        {
            return SidesGreaterThanZero()
                && _sideA + _sideB > _sideC
                && _sideA + _sideC > _sideB
                && _sideB + _sideC > _sideA;
        }

        private bool SidesGreaterThanZero()
        {
            return _sideA > 0 && _sideB > 0 && _sideC > 0;
        }
        private void EnsureValidShape()
        {
            if (!IsValid())
            {
                throw new ArgumentException("Треугольник с заданными сторонами не существует");
            }
        }
    }
}
