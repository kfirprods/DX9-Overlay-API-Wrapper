using System.Drawing;

namespace DX9OverlayAPIWrapper
{
    public class Image : OverlayEntity
    {
        public override bool IsVisible
        {
            get => base.IsVisible;
            set
            {
                Dx9Overlay.ImageSetShown(Id, value);
                base.IsVisible = value;
            }
        }

        private int _rotation;
        public int Rotation
        {
            get => _rotation;
            set
            {
                Dx9Overlay.ImageSetRotation(Id, value);
                _rotation = value;
            }
        }

        private Point _position;
        public Point Position
        {
            get => _position;
            set
            {
                Dx9Overlay.ImageSetPos(Id, value.X, value.Y);
                _position = value;
            }
        }

        private Align _align;
        public Align Align
        {
            get => _align;
            set
            {
                Dx9Overlay.ImageSetAlign(Id, (int)value);
                _align = value;
            }
        }

        public Image(string path, Point position, int rotation, Align align, bool show)
        {
            Id = Dx9Overlay.ImageCreate(path, position.X, position.Y, rotation, (int)align, show);
            _position = position;
            _rotation = rotation;
            _align = align;
            base.IsVisible = show;
        }

        public override void Destroy()
        {
            Dx9Overlay.ImageDestroy(Id);
        }
    }
}
