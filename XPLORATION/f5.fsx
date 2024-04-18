#if INTERACTIVE

#r "nuget: Avalonia"
#r "nuget: Avalonia.Desktop"
#r "nuget: Avalonia.Themes.Simple"

#endif


open Avalonia
open Avalonia.Controls

let view1 () =
    let window = Window(Title = "Hello World App")
    let textBlock = "Hello World from Avalonia F#!"
    window.Content <- textBlock
    window

type App() = 
    inherit Application()

    override this.Initialize() =
        this.Styles.Add ( Avalonia.Themes.Simple.SimpleTheme() )

    override this.OnFrameworkInitializationCompleted() =
        printfn "OnFrameworkInitializationCompleted...block start"

        match this.ApplicationLifetime with
        | :? Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime as desktop ->
            //desktop.MainWindow <- view1 ()
            printfn "Avalonia app running...IClassicDesktopStyleApplicationLifetime"
        | _ -> printfn "OnFrameworkInitializationCompleted: ApplicationLifetime ()"


let app = 
    AppBuilder.Configure<App>()
        .UsePlatformDetect()
        //.StartWithClassicDesktopLifetime([||])
        //.SetupWithoutStarting()
        .SetupWithClassicDesktopLifetime([||])
        .Instance
//app.StartWithClassicDesktopLifetime([||])
//app.RunWithMainWindow
let cts = new System.Threading.CancellationTokenSource()

// code block works
//view1().Show()

app.Run(view1())
//app.Run(cts.Token)

//app.Start([||])
