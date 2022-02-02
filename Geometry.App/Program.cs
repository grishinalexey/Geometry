using Geometry.Core;
using Geometry.Core.Creator;
using System;
using System.Collections.Generic;

namespace Geometry.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var shapeCreators = new List<ShapeCreator>
            {
                new CircleCreator(5), new TriangleCreator(2, 3, 4), new TriangleCreator(2, 3, 3), new TriangleCreator(3, 3, 3)
            };
            foreach (var creator in shapeCreators)
            {
                var shape = creator.CreateShape();
                Console.WriteLine($"Фигура: {shape.GetName()}, площадь: {shape.GetArea()}");
            }
            Console.ReadLine();
        }
    }
}
