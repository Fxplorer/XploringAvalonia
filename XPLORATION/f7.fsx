
#if INTERACTIVE

#r "nuget: Avalonia"
#r "nuget: Avalonia.Skia"

#endif

open Avalonia
open Avalonia.Controls
open Avalonia.Media
open Avalonia.Skia
open Avalonia.Rendering
open Avalonia.Layout
open Avalonia.Media.Imaging
open System.IO


// Create window 
let window = Avalonia.Controls.Window()
window.Title <- "Avalonia"
let textBlock = TextBlock(Text="Hello from F#!", HorizontalAlignment=HorizontalAlignment.Center, VerticalAlignment=VerticalAlignment.Center)
window.Background <- SolidColorBrush(Colors.LightBlue)
window.Content <- textBlock

// Render target bitmap
let pixelsize = PixelSize(600, 400)
let dpi = new Vector(96, 96)
let target = new RenderTargetBitmap(pixelsize, dpi);
target.Render(window);

// Save image
let pngStream = File.OpenWrite("window.png") 
target.Save(pngStream)
