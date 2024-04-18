(*
This version of the script delays the main window creation until the app.Run(view1()) call.<br />
This will allow seperating out the app code and be able to parametrize the window to use when it is called in a later script version. 
*)

#if INTERACTIVE

#r "nuget: Avalonia"
#r "nuget: Avalonia.Desktop"
#r "nuget: Avalonia.Themes.Simple"
#r "nuget: Avalonia.Skia"


#endif


open Avalonia
open Avalonia.Controls
open Avalonia.Media.Imaging
open System.IO


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
        | :? Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime as desktop ->
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

let pixelsize = PixelSize(600, 400)
let dpi = new Vector(96, 96)
let target = new RenderTargetBitmap(pixelsize, dpi);

target.Render( view1() );

// Save image
let pngStream = File.OpenWrite("window.png") 
target.Save(pngStream)
