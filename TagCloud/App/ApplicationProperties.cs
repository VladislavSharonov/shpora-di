﻿using TagCloud;

namespace App;

public class ApplicationProperties
{
    public ApplicationProperties()
    {
        CloudProperties.Center = SizeProperties.ImageCenter;
    }

    public string Path { get; set; } = "";
    public Palette Palette { get; set; } = new Palette(Color.Tan, Color.Teal);
    public FontProperties FontProperties { get; set; } = new();
    public SizeProperties SizeProperties { get; set; } = new();
    public CloudProperties CloudProperties { get; set; } = new()
    {
        Density = 0.1,
        AngleStep = 0.1
    };
}