(*
This version of the script delays the main window creation until the app.Run(view1()) call.<br />
This will allow seperating out the app code and be able to parametrize the window to use when it is called in a later script version. 
*)

#if INTERACTIVE

#r "nuget: Avalonia, 11.1.0-beta1"
#r "nuget: Avalonia.Desktop, 11.1.0-beta1"
#r "nuget: Avalonia.Themes.Simple, 11.1.0-beta1"

#endif


open Avalonia
open Avalonia.Controls


let view1 () =
    let window = Window(Title = "Hello World App")
    let textBlock = "Hello World from Avalonia F#!"
    window.Content <- textBlock
    window //return

type App() = 
    inherit Application()

    override this.Initialize() =
        this.Styles.Add ( Avalonia.Themes.Simple.SimpleTheme() )

    override this.OnFrameworkInitializationCompleted() =
        printfn "OnFrameworkInitializationCompleted...block start"

        match this.ApplicationLifetime with
        | :? ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime as desktop ->
            printfn "Avalonia app running...IClassicDesktopStyleApplicationLifetime"
        | _ -> printfn "OnFrameworkInitializationCompleted: ApplicationLifetime ()"


let app = 
    AppBuilder.Configure<App>()
        .UsePlatformDetect()
        .SetupWithClassicDesktopLifetime([||])
        
        .Instance //Gets the ``Avalonia.Application`` instance being initialized.
        // app is an AppBuilder until the .Instance call which turns it into an Avalonia.Application


// starts the Avalonia.Application with the specified Window
app.Run ( view1() )

