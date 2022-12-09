﻿using Autofac;
using CommandLine;
using TagCloud;

namespace App.ConsoleApplication;

public class ConsoleOptions
{
    [Option('f', "file", Required = true, HelpText = "Image file to read words")]
    public string File { get; set; }
    
    [Option('F', "font", Required = false, HelpText = "Font name")]
    public string FontName { get; set; }
        
    [Option('W', "width", Required = true, HelpText = "Image width")]
    public int Width { get; set; }

    [Option('H', "height", Required = true, HelpText = "Image height")]
    public int Height { get; set; }

    public void Apply(IContainer container)
    {
        ApplySizeOption(container);
        ApplyFontOption(container);
        ApplyFileOption(container);
    }
    
    private void ApplySizeOption(IComponentContext container)
    {
        var sizeProperties = container.Resolve<SizeProperties>();
        sizeProperties.ImageSize = new Size(Width, Height);
        container.Resolve<CloudProperties>().Center = sizeProperties.ImageCenter;
    }
    
    private void ApplyFontOption(IComponentContext container)
    {
        container.Resolve<FontProperties>().Family = new FontFamily(FontName);
    }
    
    private void ApplyFileOption(IComponentContext container)
    {
        container.Resolve<ApplicationProperties>().Path = File;
    }
}