using System;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Util;
using Android.Widget;

namespace MyMvvmCrossApp.Droid.Widgets
{
    public class BigButton : Button
    {
        private bool _isTransparent;
        private Color _backgroundColor;
        private int _cornerRadiusDp = 8;

        public Color BackgroundColor
        {
            get => _backgroundColor;
            set
            {
                _backgroundColor = value;
                SetProperties(Context);
            }
        }
        public Color TextColor { get; set; }
        public float FontSize { get; set; }
        public bool IsTransparent
        {
            get => _isTransparent;
            set
            {
                _isTransparent = value;
                SetProperties(Context);
            }
        }

        public int CornerRadiusDp
        {
            get => _cornerRadiusDp;
            set
            {
                _cornerRadiusDp = value;
                SetProperties(Context);
            }
        }

        protected BigButton(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {

        }

        public void Enable(bool enable)
        {
            Enabled = enable;
            BackgroundColor = enable ? (BackgroundColor != null ? BackgroundColor : Color.Orange) : Color.OrangeRed;
        }

        public BigButton(Context context)
            : base(context)
        {
            SetProperties(context);
        }

        public BigButton(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            SetAttributes(context, attrs);
            SetProperties(context);
        }

        public BigButton(Context context, IAttributeSet attrs, int defStyleAttr)
            : base(context, attrs, defStyleAttr)
        {
            SetAttributes(context, attrs);
            SetProperties(context);
        }

        public BigButton(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
            : base(context, attrs, defStyleAttr, defStyleRes)
        {
            SetAttributes(context, attrs);
            SetProperties(context);
        }

        private void SetAttributes(Context context, IAttributeSet attrs)
        {
            var typedArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.BigButton, 0, 0);
            BackgroundColor = typedArray.GetColor(Resource.Styleable.BigButton_BackgroundColor, _isTransparent ? Color.Transparent : Color.Orange);
            TextColor = typedArray.GetColor(Resource.Styleable.BigButton_TextColor, Color.Black);
            FontSize = typedArray.GetDimension(Resource.Styleable.BigButton_FontSize, Resources.GetDimension(Resource.Dimension.GameDescriptionFontSize));
            typedArray.Recycle();
        }

        private void SetProperties(Context context)
        {
            SetTextColor(TextColor);
            SetTextSize(ComplexUnitType.Sp, FontSize / Resources.DisplayMetrics.Density);

            var tempDrawable = ContextCompat.GetDrawable(context, _isTransparent ? Resource.Drawable.BigButton_Transparent : Resource.Drawable.BigButton);
            var bubble = (LayerDrawable)tempDrawable;
            var rotateDrawable = (RotateDrawable)bubble.FindDrawableByLayerId(_isTransparent ? Resource.Id.bigbuttontransparent : Resource.Id.bigbutton);
            var solidColor = (GradientDrawable)rotateDrawable.Drawable;
            solidColor.SetColor(_isTransparent ? Color.Transparent : BackgroundColor);

            if (CornerRadiusDp > 0)
            {
                solidColor.SetCornerRadius(CornerRadiusDp * context.Resources.DisplayMetrics.Density + 0.5f);
            }

            Background = tempDrawable;
        }
    }
}
