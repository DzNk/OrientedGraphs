using SFML.Graphics;
using SFML.System;

namespace Lab_2.OrientedGraph.Gfx.Primitives
{
    public class Element : Drawable
    {
        public int Number { get; private set; }

        public int Radius { get; private set; }

        public Vector2f ElementCenter { get; private set; }

        private CircleShape? _circle;

        private Text? _text;        

        private Color _getRandomColor()
        {
            Random random = new();
            byte red = (byte)random.Next(50, 210);
            byte green = (byte)random.Next(50, 210);
            byte blue = (byte)random.Next(50, 210);

            return new(red, green, blue, 255);
        }

        private void _createCircle(Vector2f center, int radius)
        {
            Radius = radius;
            ElementCenter = center;
            _circle = new(radius);

            _circle.Origin = new(radius, radius);
            _circle.Position = center;

            int thickness = radius / 5;
            Radius += thickness;
            _circle.OutlineThickness = thickness;
            _circle.OutlineColor = _getRandomColor();
        }

        private void _createText(int circlelimitRadius, int orderNumber)
        {
            Number = orderNumber;
            Font font = new("OrientedGraph/Gfx/Resources/Fonts/consola.ttf");
            _text = new(orderNumber.ToString(), font);
            _text.FillColor = Color.Black;
            _text.CharacterSize = (uint)(circlelimitRadius);
            _text.Origin = new(_text.GetLocalBounds().Width / 2,
                                  _text.GetLocalBounds().Height);
            _text.Position = this.ElementCenter;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(_circle, states);
            target.Draw(_text, states);
        }

        public Element(Vector2f center, int radius = 10, int orderNumber = 1)
        {
            _createCircle(center, radius);
            _createText(radius, orderNumber);
        }
    }
}