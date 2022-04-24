using SFML.Graphics;
using SFML.System;

namespace Lab_2.OrientedGraph.Gfx.Primitives
{
    public class DoubleSidedArrow : Drawable
    {
        private readonly RectangleShape _rectangle;

        private readonly CircleShape _triangle1;
        private readonly CircleShape _triangle2;

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(_rectangle);
            target.Draw(_triangle1);
            target.Draw(_triangle2);
        }

        public DoubleSidedArrow(Vector2f center, float height, float width, float rotationDegree)
        {
            float radius = width / 2f;
            float triangleHeight = 3 * radius / 2;
            float rectangleWidth = radius / 2f;
            float rectangleHeight = height - triangleHeight * 2;

            _triangle1 = new(radius, 3);
            _triangle1.Origin = new(radius, height / 2);
            _triangle1.Position = center;

            _triangle2 = new(radius, 3);
            _triangle2.Origin = new(radius, height / 2);
            _triangle2.Position = center;
            _triangle2.Rotation = 180;

            Vector2f rectangleSize = new(rectangleWidth, rectangleHeight);
            _rectangle = new(rectangleSize);
            _rectangle.Origin = new(rectangleSize.X / 2, rectangleSize.Y / 2);
            _rectangle.Position = center;

            _triangle1.Rotation += rotationDegree;
            _triangle2.Rotation += rotationDegree;
            _rectangle.Rotation += rotationDegree;
        }
    }
}