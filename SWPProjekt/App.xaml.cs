using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Markup;

namespace SWPProjekt
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pl-Pl"); ;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("pl-Pl"); ;
            FrameworkElement.LanguageProperty.OverrideMetadata(
              typeof(FrameworkElement),
              new FrameworkPropertyMetadata(
                    XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
            base.OnStartup(e);
        }
    }
}
