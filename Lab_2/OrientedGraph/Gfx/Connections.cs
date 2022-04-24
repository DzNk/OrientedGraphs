using Lab_2.OrientedGraph.Gfx.Primitives;
using SFML.Graphics;

namespace Lab_2.OrientedGraph.Gfx
{
    public class Connections : Drawable
    {
        private DirectedConnection[]? _directedConnections;

        private TwoWayConnection[]? _twoWayConnections;

        private int _directedSize;
        private int _twoWaySize;

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (_directedConnections != null)
                foreach (var connection in _directedConnections)
                    target.Draw(connection, states);

            if (_twoWayConnections != null)
                foreach (var connection in _twoWayConnections)
                    target.Draw(connection, states);
        }

        public void AddToDirected(Element a, Element b)
        {
            _directedSize++;
            if (_directedSize > 1)
            {
                DirectedConnection[]? temp = _directedConnections;
                _directedConnections = new DirectedConnection[_directedSize];
                temp?.CopyTo(_directedConnections, 0);
                _directedConnections[_directedSize - 1] = new(a, b);
            }
            else
            {
                _directedConnections = new DirectedConnection[1];
                _directedConnections[0] = new(a, b);
            }
        }

        public void AddToTwoWay(Element a, Element b)
        {
            _twoWaySize++;
            if (_twoWaySize > 1)
            {
                TwoWayConnection[]? temp = _twoWayConnections;
                _twoWayConnections = new TwoWayConnection[_twoWaySize];
                temp?.CopyTo(_twoWayConnections, 0);
                _twoWayConnections[_twoWaySize - 1] = new(a, b);
            }
            else
            {
                _twoWayConnections = new TwoWayConnection[1];
                _twoWayConnections[0] = new(a, b);
            }
        }
    }
}