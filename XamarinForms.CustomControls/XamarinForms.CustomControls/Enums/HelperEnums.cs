using System.ComponentModel;

namespace XamarinForms.CustomControls.Enums
{
    public enum HorizontalAlignment
    {
        [Description("Left")]
        Left,
        [Description("Center")]
        Center
        //,[Description("Right")]
        //Right,
    };

    public enum FontAttributes
    {
        [Description("Italic")]
        Italic,
        [Description("Bold")]
        Bold,
        [Description("BoldItalic")]
        BoldItalic,
        [Description("Normal")]
        Normal
    };
}