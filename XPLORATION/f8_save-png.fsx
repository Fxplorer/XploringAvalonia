(*
This version of the script delays the main window creation until the app.Run(view1()) call.<br />
This will allow seperating out the app code and be able to parametrize the window to use when it is called in a later script version. 
*)

#if INTERACTIVE

#r "nuget: Avalonia"
#r "nuget: Avalonia.Desktop"
#r "nuget: Avalonia.Themes.Simple"
#r "nuget: Avalonia.Headless"

#endif


open Avalonia
open Avalonia.Controls
open Avalonia.Headless
open Avalonia.Threading
open System.Threading

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
    //let x = { new AvaloniaHeadlessPlatformOptions with member x.UseHeadlessDrawing = false }
    let headless = AvaloniaHeadlessPlatformOptions() 
    headless.UseHeadlessDrawing <- false

    AppBuilder.Configure<App>()
        //.UsePlatformDetect()
        //.SetupWithClassicDesktopLifetime([||])
        
        //.Instance //Gets the ``Avalonia.Application`` instance being initialized.
        // app is an AppBuilder until the .Instance call which turns it into an Avalonia.Application
        .UseSkia() // enable Skia renderer
        .UseHeadless(headless)


let session = HeadlessUnitTestSession.StartNew(typeof<App>)
// Dispatch actions
session.Dispatch(
    (fun () ->
        let window = view1()
        window.Show()
        let frame = window.CaptureRenderedFrame()
        frame.Save("file.png")
        ), CancellationToken.None
    )

// let window = view1()
// window.Show()
//Dispatcher.UIThread.RunJobs()
// starts the Avalonia.Application with the specified Window
//app.Run ( view1() )


    //     fun () ->

    // // Setup 
    // let textBox = TextBox()
    // let window = Window(Content=textBox)

    // // Show and focus 
    // window.Show()
    // textBox.Focus()

    // // Type text
    // window.KeyTextInput("Hello World")

    // // Assert
    // if textBox.Text <> "Hello World" then
    //     raise (Exception("Assert failed!"))

    // )} |> Async.AwaitTask

