using System.Drawing;

namespace DX9OverlayAPIWrapper
{
    public class Box : Overlay
    {
        public override bool IsVisible
        {
            get => base.IsVisible;
            set
            {
                Dx9Overlay.BoxSetShown(Id, value);
                base.IsVisible = value;
            }
        }

        private Color _color;
        public Color Color
        {
            get => _color;
            set
            {
                Dx9Overlay.BoxSetColor(Id, (uint)value.ToArgb());
                _color = value;
            }
        }

        private Rectangle _rectangle;
        public Rectangle Rectangle
        {
            get => _rectangle;
            set
            {
                Dx9Overlay.BoxSetPos(Id, value.X, value.Y);
                Dx9Overlay.BoxSetWidth(Id, value.Width);
                Dx9Overlay.BoxSetHeight(Id, value.Height);
                _rectangle = value;
            }
        }

        private bool _borderShown;
        public bool BorderShown
        {
            get => _borderShown;
            set
            {
                Dx9Overlay.BoxSetBorder(Id, _borderHeight, value);
                _borderShown = value;
            }
        }

        private int _borderHeight;
        public int BorderHeight
        {
            get => _borderHeight;
            set
            {
                Dx9Overlay.BoxSetBorder(Id, value, _borderShown);
                _borderHeight = value;
            }
        }

        private Color _borderColor;
        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                Dx9Overlay.BoxSetBorderColor(Id, (uint)value.ToArgb());
                _borderColor = value;
            }
        }

        public Box(Rectangle rectangle, Color color, bool show, bool borderShown = false, int borderHeight = 0, Color borderColor = default(Color))
        {
            Id = Dx9Overlay.BoxCreate(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, (uint)color.ToArgb(), show);
            if (borderHeight != 0)
            {
                Dx9Overlay.BoxSetBorder(Id, borderHeight, borderShown);
                _borderHeight = borderHeight;
                _borderShown = borderShown;
            }
            if (borderColor != default(Color))
            {
                Dx9Overlay.BoxSetBorderColor(Id, (uint)borderColor.ToArgb());
                _borderColor = borderColor;
            }
            _rectangle = rectangle;
            base.IsVisible = show;
            _color = color;
        }

        public override void Destroy()
        {
            Dx9Overlay.BoxDestroy(Id);
        }
    }
}
