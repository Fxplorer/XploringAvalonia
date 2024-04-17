

#r "nuget: Avalonia"
#r "nuget: Avalonia.Headless"
#r "nuget: Avalonia.Themes.Simple"


open Avalonia
open System.Threading

let go =

    // Build app
    let app = AppBuilder.Configure<App>()
                  .UsePlatformDetect()
                  .SetupWithoutStarting()
                  .Instance

    // Register shutdown 
    let cts = new CancellationTokenSource()    

    // Start app
    app.Run(AppMain, argv, cts.Token)

    0

// App main 
let AppMain (app: Application) argv =

    // Show window 
    Window().Show()

    // Start event loop 
    app.Run(cts.Token)
