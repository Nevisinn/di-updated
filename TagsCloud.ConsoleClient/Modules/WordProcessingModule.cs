using Autofac;
using TagsCloud.Infrastructure.Services.WordsProcessing;
using TagsCloud.Infrastructure.Services.WordsProcessing.DocumentWriters;
using TagsCloud.Infrastructure.Services.WordsProcessing.FileValidator;
using TagsCloud.Infrastructure.Services.WordsProcessing.WordsHandlers;
using TagsCloud.Infrastructure.Services.WordsProcessing.WordsPreprocessors;
using TagsCloud.Infrastructure.Services.WordsProcessing.WordsProviders;

namespace TagsCloud.Modules;

public class WordProcessingModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<TxtWriter>().Named<IDocumentWriter>("txt");
        builder.RegisterType<DocWriter>().Named<IDocumentWriter>("doc");
        builder.RegisterType<DocxWriter>().Named<IDocumentWriter>("docx");

        builder.RegisterType<FileValidator>().As<IFileValidator>();

        builder.Register(c =>
        {
            var workingDirectory = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDirectory)!.Parent!.Parent!.FullName;
            var boringWords =
                File.ReadAllText(Path.Combine($"{projectDirectory}", "BoringWordsFiles", "BoringWords.txt"));
            return new BoringWordsHandler(boringWords.Split(',').ToHashSet());
        }).As<IWordsHandler>();

        /*builder.RegisterType<BoringWordsHandler>().As<IWordsHandler>()
            .WithParameter(new TypedParameter(typeof(HashSet<string>), new HashSet<string> { "hello" }));*/

        builder.RegisterType<DefaultWordsPreprocessor>().As<IWordsPreprocessor>();

        builder.RegisterType<TxtWordsProvider>().Named<IWordsProvider>("txt");
        builder.RegisterType<DocWordsProvider>().Named<IWordsProvider>("doc");
        builder.RegisterType<DocxWordsProvider>().Named<IWordsProvider>("docx");

        builder.RegisterType<DefaultWordsPreprocessor>().As<IWordsPreprocessor>();
    }
}