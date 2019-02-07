using System.Drawing;

namespace DX9OverlayAPIWrapper
{
    public class Line : Overlay
    {
        public override bool IsVisible
        {
            get => base.IsVisible;
            set
            {
                Dx9Overlay.LineSetShown(Id, value);
                base.IsVisible = value;
            }
        }

        private Color _color;
        public Color Color
        {
            get => _color;
            set
            {
                Dx9Overlay.LineSetColor(Id, (uint)value.ToArgb());
                _color = value;
            }
        }

        private int _width;
        public int Width
        {
            get => _width;
            set
            {
                Dx9Overlay.LineSetWidth(Id, value);
                _width = value;
            }
        }

        private Point _startPosition;
        public Point StartPosition
        {
            get => _startPosition;
            set
            {
                Dx9Overlay.LineSetPos(Id, value.X, value.Y, _endPosition.X, _endPosition.Y);
                _startPosition = value;
            }
        }

        private Point _endPosition;
        public Point EndPosition
        {
            get => _endPosition;
            set
            {
                Dx9Overlay.LineSetPos(Id, _startPosition.X, _startPosition.Y, value.X, value.Y);
                _endPosition = value;
            }
        }

        public Line(Point startPosition, Point endPosition, int width, Color color, bool show)
        {
            Id = Dx9Overlay.LineCreate(startPosition.X, startPosition.Y, endPosition.X, endPosition.Y, width, (uint)color.ToArgb(), show);
            _startPosition = startPosition;
            _endPosition = endPosition;
            _width = width;
            _color = color;
            base.IsVisible = show;
        }

        public override void Destroy()
        {
            Dx9Overlay.LineDestroy(Id);
        }
    }
}
