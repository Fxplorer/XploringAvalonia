#if INTERACTIVE

#r "nuget: Avalonia"
#r "nuget: Avalonia.Desktop"
#r "nuget: Avalonia.Themes.Simple"

#endif


open Avalonia
open Avalonia.Controls

let mainWindow = Window(Title="Hello World", Content="Content")

// An Avalonia app will always need a style added.

type App() =
    inherit Avalonia.Application()

    override this.Initialize() =
        this.Styles.Add ( Avalonia.Themes.Simple.SimpleTheme() )
        //this.RequestedThemeVariant <- Styling.ThemeVariant.Dark

    override this.OnFrameworkInitializationCompleted() =
            match this.ApplicationLifetime with
            | :? Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime as desktop ->
                desktop.MainWindow <- mainWindow
            | _ -> ()

            base.OnFrameworkInitializationCompleted()


let buildAvaloniaApp () = 
    Avalonia.AppBuilder
        .Configure<App>()
        .UsePlatformDetect()
        

         
buildAvaloniaApp().StartWithClassicDesktopLifetime(Array.empty<string>)



 