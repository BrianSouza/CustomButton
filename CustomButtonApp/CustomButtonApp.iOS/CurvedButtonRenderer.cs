using Xamarin.Forms;
using CustomButtonApp.iOS;
using Xamarin.Forms.Platform.iOS;
using System.ComponentModel;
using CustomButtonApp;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CurvedButtonRenderer))]
namespace CustomButtonApp.iOS
{
    public   class CurvedButtonRenderer: ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
{
    base.OnElementChanged(e);
    var view = (CustomButton)Element;
    if (view == null) return;
    Paint(view);
}

protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
{
    base.OnElementPropertyChanged(sender, e);
    if (e.PropertyName == CustomButton.CustomBorderRadiusProperty.PropertyName ||
       e.PropertyName == CustomButton.CustomBorderColorProperty.PropertyName ||
       e.PropertyName == CustomButton.CustomBorderWidthProperty.PropertyName)
    {
        if (Element != null)
        {
            Paint((CustomButton)Element);
        }
    }
}
private void Paint(CustomButton view)
{
    this.Layer.CornerRadius = (float)view.CustomBorderRadius;
    this.Layer.BorderColor = view.CustomBorderColor.ToCGColor();
    this.Layer.BackgroundColor = view.CustomBackgroundColor.ToCGColor();
    this.Layer.BorderWidth = (int)view.CustomBorderWidth;
}
    }
}