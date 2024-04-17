
//#if INTERACTIVE

#r "nuget: Avalonia"
#r "nuget: Avalonia.Desktop"
#r "nuget: Avalonia.Themes.Simple"

//#endif

namespace TempNamespace 

using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;


public class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.Title = "Avalonia Basic Example";
        this.Content = "Hello World from C# Avalonia!";
        this.Width = 400;
        this.Height = 400;
    }
}

public class App : Avalonia.Application
{
   //  public override void Initialize()
   //  {
   //      AvaloniaXamlLoader.Load(this);
   //  }

   
   public override void OnFrameworkInitializationCompleted()
   {
      if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
      {
         desktop.MainWindow = new MainWindow();
      }

      base.OnFrameworkInitializationCompleted();
   }
}

class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    public static void Go(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}


Program.Go();
