//#if INTERACTIVE

#r "nuget: Avalonia"
#r "nuget: Avalonia.Headless"
#r "nuget: Avalonia.Themes.Simple"

//#endif



open Avalonia
open Avalonia.Controls 
open Avalonia.Headless

// Setup
let textBox = TextBox() 
let window = Window(Content = textBox)

type App() =
    inherit Avalonia.Application()

    override this.Initialize() =
        this.Styles.Add ( Avalonia.Themes.Simple.SimpleTheme() )

    override this.OnFrameworkInitializationCompleted() =
            match this.ApplicationLifetime with
            | :? Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime as desktop ->
                desktop.MainWindow <- window
            | _ -> ()

            base.OnFrameworkInitializationCompleted()



// Start headless session

let session = HeadlessUnitTestSession.StartNew(typeof<App>)

session.Dispatch(fun () -> 
// Dispatch actions to session's thread  
    // Show window
    window.Show() 

    // Focus text box
    textBox.Focus()

    // Type text
    window.KeyTextInput("Hello World")


) |> Async.AwaitTask
