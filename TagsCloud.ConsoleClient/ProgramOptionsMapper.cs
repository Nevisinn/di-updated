using System.Drawing;
using TagsCloud.Dtos;
using TagsCloud.Infrastructure.Models;
using TagsCloud.Infrastructure.Services.ImageGeneration;
using TagsCloud.Infrastructure.Services.ImageGeneration.ColorProvider;
using TagsCloud.Infrastructure.Services.ImageGeneration.ColorSchemeProviders;
using TagsCloud.Infrastructure.Services.ImageGeneration.FontProviders;
using TagsCloud.Infrastructure.Services.LayoutAlgorithm.CloudLayouters;
using TagsCloud.Infrastructure.Services.WordsProcessing.WordsProviders;

namespace TagsCloud;

public class ProgramOptionsMapper
{
    private readonly IColorProvider colorProvider;
    private readonly IFontProvider fontProvider;
    private readonly ServiceResolver resolver;
    
    public ProgramOptionsMapper
    (
        ServiceResolver resolver,
        IColorProvider colorProvider,
        IFontProvider fontProvider
    )
    {
        this.resolver = resolver;
        this.colorProvider = colorProvider;
        this.fontProvider = fontProvider;
    }

    public ProgramOptions Map(ConsoleProgramOptionsDto dto)
    {
        return new ProgramOptions
        {
            InputWordsFilePath = dto.InputWordsFilePath,
            ImageOptions = new ImageOptions
            {
                BackgroundColor = colorProvider.GetColor(dto.BackgroundColor),
                ColorScheme = resolver.Resolve<IColorSchemeProvider>(dto.ColorScheme),
                Font = fontProvider.GetFont(dto.FontName, dto.FontSize),
                ImageFormat = ImageFormatParser.Parse(dto.ImageFormat),
                ImageSize = new Size(dto.ImageWidth, dto.ImageHeight),
                TextColors = colorProvider.GetColors(dto.TextColor.Split(',').ToArray())
            },
            Algorithm = resolver.Resolve<ICloudLayouter>(dto.AlgorithmName),
            WordsProvider = resolver.Resolve<IWordsProvider>(Path.GetExtension(dto.InputWordsFilePath).Trim('.'))
        };
    }
}