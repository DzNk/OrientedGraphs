using Lab_2.OrientedGraph.Utils;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Lab_2.OrientedGraph.Gfx
{
    public class Graphics
    {
        private readonly int _width;
        private readonly int _height;

        private readonly string _title;

        private Vector2f _centerPoint;

        private Color _bgColor;

        private Graph? _graph;

        private RenderWindow? _window;

        public Graphics(int width, int height, string title = "Sample")
        {
            _width = width;
            _height = height;
            _title = title;
        }

        public void SetBackgroundColor(int red, int green, int blue)
        {
            _bgColor = new((byte)red, (byte)green, (byte)blue);
        }

        public void CreateGraph(AdjacencyMatrix matrix)
        {
            _centerPoint = new(_width / 2f, _height / 2f);
            int radius = Math.Min(_width, _height) / 4;

            _graph = new(_centerPoint, radius, matrix);
        }

        public void Run()
        {
            _setup();
            while (_window is {IsOpen: true})
            {
                _window.Draw(_graph);
                _window.DispatchEvents();
                _window.Display();
            }
        }

        private void _setup()
        {
            ContextSettings settings = new();
            settings.AntialiasingLevel = 8;

            VideoMode mode = new VideoMode((uint)_width, (uint)_height);
            _window = new RenderWindow(mode, _title, Styles.Titlebar, settings);
            _window.Clear(_bgColor);
            _window.SetActive();
            _window.KeyPressed += OnKeyPressed;
        }

        private void OnKeyPressed(object? sender, KeyEventArgs e)
        {
            var window = (Window)sender!;
            if (e.Code == Keyboard.Key.Escape) window.Close();
        }
    }
}