using System.Drawing;

namespace DX9OverlayAPIWrapper
{
    public class TextLabel : OverlayEntity
    {
        public override bool IsVisible
        {
            get => base.IsVisible;
            set 
            {
                Dx9Overlay.TextSetShown(Id, value);
                base.IsVisible = value;
            }
        }

        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                Dx9Overlay.TextSetString(Id, value);
                _text = value;
            }
        }

        private bool _shadow;
        public bool Shadow
        {
            get => _shadow;
            set
            {
                Dx9Overlay.TextSetShadow(Id, value);
                _shadow = value;
            }
        }

        private Color _color;
        public Color Color
        {
            get => _color;
            set
            {
                Dx9Overlay.TextSetColor(Id, (uint)value.ToArgb());
                _color = value;
            }
        }

        private Point _position;
        public Point Position
        {
            get => _position;
            set
            {
                Dx9Overlay.TextSetPos(Id, value.X, value.Y);
                _position = value;
            }
        }

        public TextLabel(string font, int size, TypeFace type, Point position, Color color, string text, bool shadow, bool show)
        {
            Id = Dx9Overlay.TextCreate(font, size, type.HasFlag(TypeFace.Bold), type.HasFlag(TypeFace.Italic), position.X, position.Y, (uint)color.ToArgb(), text, shadow, show);
            _text = text;
            _shadow = shadow;
            base.IsVisible = show;
            _color = color;
            _position = position;
        }

        public override void Destroy()
        {
            Dx9Overlay.TextDestroy(Id);
        }

        public void TextUpdate(string font, int size, bool bold, bool italic)
        {
            Dx9Overlay.TextUpdate(Id, font, size, bold, italic);
        }
    }
}
