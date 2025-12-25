using System.Drawing;
using TagsCloud.Dtos;
using TagsCloud.Infrastructure.Models;
using TagsCloud.Infrastructure.Selectors;
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
    private readonly IColorSchemeSelector colorSchemeSelector;
    private readonly IWordsProviderSelector wordsProviderSelector;
    private readonly IAlgorithmSelector algorithmSelector;
    
    public ProgramOptionsMapper
    (
        IColorProvider colorProvider,
        IFontProvider fontProvider, 
        IColorSchemeSelector colorSchemeSelector,
        IWordsProviderSelector wordsProviderSelector,
        IAlgorithmSelector algorithmSelector)
    {
        this.colorProvider = colorProvider;
        this.fontProvider = fontProvider;
        this.colorSchemeSelector = colorSchemeSelector;
        this.wordsProviderSelector = wordsProviderSelector;
        this.algorithmSelector = algorithmSelector;
    }

    public ProgramOptions Map(ConsoleProgramOptionsDto dto)
    {
        return new ProgramOptions
        {
            InputWordsFilePath = dto.InputWordsFilePath,
            InputBoringWordsFilePath = dto.InputBoringWordsFilePath,
            ImageOptions = new ImageOptions
            {
                BackgroundColor = colorProvider.GetColor(dto.BackgroundColor),
                ColorScheme = colorSchemeSelector.Select(dto.ColorScheme),
                Font = fontProvider.GetFont(dto.FontName, dto.FontSize),
                ImageFormat = ImageFormatParser.Parse(dto.ImageFormat),
                ImageSize = new Size(dto.ImageWidth, dto.ImageHeight),
                TextColors = colorProvider.GetColors(dto.TextColor.Split(',').ToArray())
            },
            Algorithm = algorithmSelector.Select(dto.AlgorithmName),
            WordsProvider = wordsProviderSelector.Select(Path.GetExtension(dto.InputWordsFilePath).Trim('.'))
        };
    }
}