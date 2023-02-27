﻿using ShapeTask.Shapes;

namespace ShapeTask.Comparers;

public class ShapePerimeterComparer : IComparer<IShape>
{
    public int Compare(IShape shape1, IShape shape2)
    {
        return shape1.GetPerimeter().CompareTo(shape2.GetPerimeter());
    }
}