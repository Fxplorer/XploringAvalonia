---
jupyter:
  kernelspec:
    display_name: ".NET (F#)"
    language: "F#"
    name: .net-fsharp
  language_info:
    name: polyglot-notebook
  nbformat: 4
  nbformat_minor: 2
  polyglot_notebook:
    kernelInfo:
      defaultKernelName: fsharp
      items:
      - languageName: fsharp
        name: fsharp
---

::: {.cell .code execution_count="1" dotnet_interactive="{\"language\":\"fsharp\"}" polyglot_notebook="{\"kernelName\":\"fsharp\"}"}
``` F#
#if INTERACTIVE

#r "nuget: Avalonia"
#r "nuget: Avalonia.Desktop"
#r "nuget: Avalonia.Themes.Simple"

#endif
```

::: {.output .display_data}
```{=html}
<div><div></div><div></div><div><strong>Installed Packages</strong><ul><li><span>Avalonia, 11.0.10</span></li><li><span>Avalonia.Desktop, 11.0.10</span></li><li><span>Avalonia.Themes.Simple, 11.0.10</span></li></ul></div></div>
```
:::

::: {.output .display_data}
    Loading extensions from `/home/linux/.nuget/packages/skiasharp/2.88.7/interactive-extensions/dotnet/SkiaSharp.DotNet.Interactive.dll`
:::
:::

::: {.cell .code execution_count="2" dotnet_interactive="{\"language\":\"fsharp\"}" polyglot_notebook="{\"kernelName\":\"fsharp\"}"}
``` F#
open Avalonia
open Avalonia.Controls
```
:::

::: {.cell .code execution_count="3" dotnet_interactive="{\"language\":\"fsharp\"}" polyglot_notebook="{\"kernelName\":\"fsharp\"}"}
``` F#
let view1 () =
    let window = Window(Title = "Hello World App")
    let textBlock = "Hello World from Avalonia F#!"
    window.Content <- textBlock
    window
```
:::

::: {.cell .code execution_count="4" dotnet_interactive="{\"language\":\"fsharp\"}" polyglot_notebook="{\"kernelName\":\"fsharp\"}"}
``` F#
type App() = 
    inherit Application()

    override this.Initialize() =
        this.Styles.Add ( Avalonia.Themes.Simple.SimpleTheme() )

    override this.OnFrameworkInitializationCompleted() =

        match this.ApplicationLifetime with
        | :? Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime as desktop ->
            desktop.MainWindow <- view1 ()
            printfn "Avalonia app running..."
        | _ -> ()
```
:::

::: {.cell .code execution_count="5" dotnet_interactive="{\"language\":\"fsharp\"}" polyglot_notebook="{\"kernelName\":\"fsharp\"}"}
``` F#
let app = 
    AppBuilder.Configure<App>()
        .UsePlatformDetect()
        .StartWithClassicDesktopLifetime([||])
```

::: {.output .stream .stdout}
    Avalonia app running...
:::
:::
