
#if INTERACTIVE

#r "nuget: Avalonia"
#r "nuget: Avalonia.Desktop"
#r "nuget: Avalonia.Themes.Simple"

#endif


using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

class Program {
   public static void Main(string[] args) {
      BuildAvaloniaApp()
         .StartWithClassicDesktopLifetime(args);

      new Window {
         Title = "Hello World",
         Content = new TextBlock { Text = "Hello World from Avalonia!" }
      }.Show();
   }

   public static AppBuilder BuildAvaloniaApp() {
      return AppBuilder.Configure<App>()
         .UsePlatformDetect();
   } 
}

class App : Application {
}
