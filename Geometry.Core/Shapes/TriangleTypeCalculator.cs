using Geometry.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Geometry.Core.Shapes
{
    internal class TriangleTypeCalculator
    {
        public static TypeByCorners CalcTypeByCorners(Triangle triangle)
        {
            TypeBySides typeBySide = triangle.TypeBySides;
            if (typeBySide == 0)
            {
                typeBySide = CalcTypeBySides(triangle);
            }
            switch (typeBySide)
            {
                case TypeBySides.Scalene:
                    List<double> sideList = GetDescendingSideList(triangle);
                    return GetCornerTypeBySingleMaxSide(sideList);
                case TypeBySides.Equilateral:
                    return TypeByCorners.Acute;
                case TypeBySides.Isosceles:
                    List<double> sidesList = GetDescendingSideList(triangle);
                    if (sidesList.ElementAt(0) > sidesList.ElementAt(1))
                    {
                        return GetCornerTypeBySingleMaxSide(sidesList);
                    }
                    if (2 * Math.Pow(sidesList.First(), 2) == Math.Pow(sidesList.ElementAt(2), 2))
                    {
                        return TypeByCorners.Right;
                    }
                    return GetCornerTypeBySingleMaxSide(sidesList);
                default:
                    throw new NotSupportedException();
            }
        }

        public static TypeBySides CalcTypeBySides(Triangle triangle)
        {
            if (triangle.SideA != triangle.SideB && triangle.SideA != triangle.SideC
                && triangle.SideB != triangle.SideC)
            {
                return TypeBySides.Scalene;
            }
            else if (triangle.SideA == triangle.SideB && triangle.SideA == triangle.SideC
                && triangle.SideB == triangle.SideC)
            {
                return TypeBySides.Equilateral;
            }
            return TypeBySides.Isosceles;
        }

        private static TypeByCorners GetCornerTypeBySingleMaxSide(List<double> sideList)
        {
            var maxCos = GetMaxCos(sideList.First(), sideList.ElementAt(1), sideList.ElementAt(2));
            return GetCornerTypeByCos(maxCos);
        }

        private static List<double> GetDescendingSideList(Triangle triangle)
        {
            return new List<double>(3) { triangle.SideA, triangle.SideB, triangle.SideC }
                .OrderByDescending(x => x)
                .ToList();
        }

        private static TypeByCorners GetCornerTypeByCos(double maxCos)
        {
            return maxCos switch
            {
                > 0 => TypeByCorners.Acute,
                0 => TypeByCorners.Right,
                _ => TypeByCorners.Obtuse,
            };
        }

        private static double GetMaxCos(double maxSide, double secondSide, double thirdSide)
        {
            return (Math.Pow(secondSide, 2) + Math.Pow(thirdSide, 2) - Math.Pow(maxSide, 2)) / (2 * secondSide * thirdSide);
        }
    }
}
