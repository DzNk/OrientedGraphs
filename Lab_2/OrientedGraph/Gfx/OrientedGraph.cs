using Lab_2.OrientedGraph.Gfx.Primitives;
using Lab_2.OrientedGraph.Utils;
using SFML.Graphics;
using SFML.System;

namespace Lab_2.OrientedGraph.Gfx;

public class Graph : Drawable
{
    private readonly Element[] _elements;

    private Connections? _connections;

    private int Size { get; }

    private static Vector2f _rotatePointAroundCenter(Vector2f center, Vector2f point,
        float radians)
    {

        Vector2f pos;
        pos.X = (point.X - center.X) * MathF.Cos(radians) -
                (point.Y - center.Y) * MathF.Sin(radians) +
                center.X;
        pos.Y = (point.X - center.X) * MathF.Sin(radians) +
                (point.Y - center.Y) * MathF.Cos(radians) +
                center.Y;

        return pos;
    }

    private void _createConnections(AdjacencyMatrix matrix)
    {
        _connections = new();

        bool[,] tempMatrix = (bool[,])matrix.Data.Clone();

        for (int i = 0; i < matrix.N; i++)
        {
            for (int j = 0; j < matrix.N; j++)
            {
                if ((tempMatrix[i, j] & tempMatrix[j, i]))
                {
                    tempMatrix[j, i] = false;
                    _connections.AddToTwoWay(_elements[i], _elements[j]);
                }
                else if (tempMatrix[i, j])
                {
                    _connections.AddToDirected(_elements[i], _elements[j]);
                }
            }
        }
    }

    public void Draw(RenderTarget target, RenderStates states)
    {
        target.Draw(_connections);
        foreach (var element in _elements)
            target.Draw(element);
    }

    public Graph(Vector2f center, int radius, AdjacencyMatrix matrix)
    {
        Size = matrix.N;

        int elementRadius = (int)(radius * 2 * Math.PI) / matrix.N / 4;
        float radiansBetweenElements = (360.0f / matrix.N) * MathF.PI / 180;

        Vector2f firstElementPosition = center;

        _elements = new Element[matrix.N];

        if (Size > 1)
        {
            firstElementPosition.Y -= radius;
            _elements[0] = new(firstElementPosition, elementRadius, 1);
            float currentRadians = radiansBetweenElements;
            for (int i = 1; i < Size; i++)
            {
                Vector2f pos = _rotatePointAroundCenter(center, firstElementPosition,
                    currentRadians);

                _elements[i] = new(pos, elementRadius, i + 1);
                currentRadians += radiansBetweenElements;
            }
        }
        else
        {
            _elements[0] = new(firstElementPosition, elementRadius, 1);
        }

        _createConnections(matrix);
    }
}