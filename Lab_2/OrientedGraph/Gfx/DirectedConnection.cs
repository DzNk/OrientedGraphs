using Lab_2.OrientedGraph.Gfx.Primitives;
using SFML.Graphics;
using SFML.System;

namespace Lab_2.OrientedGraph.Gfx
{
    public class DirectedConnection : Drawable
    {
        private readonly Arrow _connectionArrow;

        private readonly Element _firstElement;
        private readonly Element _secondElement;

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(_connectionArrow);
            target.Draw(_firstElement);
            target.Draw(_secondElement);
        }

        public DirectedConnection(Element firstElement, Element secondElement)
        {
            _firstElement = firstElement;
            _secondElement = secondElement;

            Vector2f arrowCenter = (firstElement.ElementCenter + secondElement.ElementCenter) / 2;

            float distanceBetweenPoints = MathF.Sqrt(
                MathF.Pow(secondElement.ElementCenter.X - firstElement.ElementCenter.X, 2)
                +
                MathF.Pow(secondElement.ElementCenter.Y - firstElement.ElementCenter.Y, 2)
                                                    );
            float arrowHeight = (distanceBetweenPoints - firstElement.Radius * 2);
            float arrowWidth = firstElement.Radius / 2f;
            float arrowAngle = MathF.Atan2(arrowCenter.Y - secondElement.ElementCenter.Y,
                                           arrowCenter.X - secondElement.ElementCenter.X
                                           ) / MathF.PI * 180f;
            arrowAngle -= 90;

            _connectionArrow = new(arrowCenter, arrowHeight, arrowWidth, arrowAngle);
        }
    }
}