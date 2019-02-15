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
                if (this.IsVisible == value) return;

                Dx9Overlay.TextSetShown(this.Id, value);
                base.IsVisible = value;
            }
        }

        private string _text;
        public string Text
        {
            get => this._text;
            set
            {
                if (this._text == value) return;

                Dx9Overlay.TextSetString(this.Id, value);
                this._text = value;
            }
        }

        public TypeFace TypeFace { get; set; }

        public int FontSize { get; set; }

        public string Font { get; set; }

        private bool _shadow;
        public bool Shadow
        {
            get => this._shadow;
            set
            {
                if (this._shadow == value) return;

                Dx9Overlay.TextSetShadow(this.Id, value);
                this._shadow = value;
            }
        }

        private Color _color;
        public Color Color
        {
            get => this._color;
            set
            {
                if (this._color == value) return;

                Dx9Overlay.TextSetColor(this.Id, (uint)value.ToArgb());
                this._color = value;
            }
        }

        private Point _position;
        public Point Position
        {
            get => this._position;
            set
            {
                if (this._position == value) return;

                Dx9Overlay.TextSetPos(this.Id, value.X, value.Y);
                this._position = value;
            }
        }

        public TextLabel(string font, int size, int x, int y, Color color, string text, bool shadow = true,
            bool show = true, TypeFace typeFace = TypeFace.None)
        {
            this.Id = Dx9Overlay.TextCreate(font, size, typeFace.HasFlag(TypeFace.Bold),
                typeFace.HasFlag(TypeFace.Italic), x, y, (uint) color.ToArgb(), text, shadow, show);
            this._text = text;
            this._shadow = shadow;
            base.IsVisible = show;
            this._color = color;
            this._position = new Point(x, y);
            this.TypeFace = typeFace;
            this.FontSize = size;
            this.Font = font;
        }

        // This is the legacy constructor from the older DX9OverlayWrapper
        public TextLabel(string font, int size, TypeFace typeFace, Point position, Color color, string text,
            bool shadow, bool show) : this(font, size, position.X, position.Y, color, text, shadow, show, typeFace)
        {

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
