
//#if INTERACTIVE

#r "nuget: Avalonia"
#r "nuget: Avalonia.Desktop"
#r "nuget: Avalonia.Themes.Simple"

//#endif

using Avalonia;
using Avalonia.Controls;
using Avalonia.Themes.Simple;


Application app = Application.Current ?? AppBuilder.Configure<Application>().UsePlatformDetect().SetupWithoutStarting().Instance;
app.Styles.Add(new SimpleTheme() );
app.Run(new Window() { Title = "Avalonia Basic Example", Content = "Hello Avalonia!" });
