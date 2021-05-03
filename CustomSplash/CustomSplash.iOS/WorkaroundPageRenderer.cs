[assembly: Xamarin.Forms.ExportRenderer(typeof(Xamarin.Forms.Page), typeof(CustomSplash.iOS.WorkaroundPageRenderer))]

namespace CustomSplash.iOS
{
    using System.Reflection;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;

    // a workaround PageRenderer from https://kent-boogaart.com/blog/hacking-xamarin.forms-page.appearing-for-ios
    public sealed class WorkaroundPageRenderer : PageRenderer
    {
        private static readonly FieldInfo AppearedField = typeof(PageRenderer).GetField("_appeared", BindingFlags.NonPublic | BindingFlags.Instance);
        private static readonly FieldInfo DisposedField = typeof(PageRenderer).GetField("_disposed", BindingFlags.NonPublic | BindingFlags.Instance);

        private IPageController PageController => this.Element as IPageController;

        private bool Appeared
        {
            get => (bool)AppearedField.GetValue(this);
            set => AppearedField.SetValue(this, value);
        }

        private bool Disposed
        {
            get => (bool)DisposedField.GetValue(this);
            set => DisposedField.SetValue(this, value);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (Appeared || Disposed) return;

            // by setting this to true, we also ensure that PageRenderer does not invoke SendAppearing a second time when ViewDidAppear fires
            Appeared = true;
            PageController.SendAppearing();
        }
    }
}
