using SFML.Graphics;
using SFML.System;

namespace Lab_2.OrientedGraph.Gfx.Primitives
{
    public class Arrow : Drawable
    {
        private readonly RectangleShape _rectangle;

        private readonly CircleShape _triangle;

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(_rectangle, states);
            target.Draw(_triangle, states);
        }

        public Arrow(Vector2f center, float height, float width, float rotationDegree)
        {
            float radius = width / 2f;
            float rectangleWidth = radius / 2f;
            float triangleHeight = 3 * radius / 2;
            float rectangleHeight = height - triangleHeight;

            Vector2f rectangleSize = new(rectangleWidth, rectangleHeight);
            _rectangle = new(rectangleSize);
            _rectangle.Origin = new(rectangleSize.X / 2, (height / 2) - triangleHeight);
            _rectangle.Position = center;

            _triangle = new(radius, 3);
            _triangle.Origin = new(radius, height / 2);
            _triangle.Position = center;

            _triangle.Rotation = rotationDegree;
            _rectangle.Rotation = rotationDegree;
        }
    }
}