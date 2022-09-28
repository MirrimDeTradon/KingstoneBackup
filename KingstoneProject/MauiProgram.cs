namespace KingstoneProject;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("TCM_____.TTF", "TCM");
                fonts.AddFont("Ringbearer.ttf", "Ringbearer");
                fonts.AddFont("HarlowSolidItalicItalic.ttf", "Harlow");
            });

        string dbPath = FileAccessHelper.GetLocalFilePath("people.db3");
        builder.Services.AddSingleton<CharacterSheetRepository>(s => ActivatorUtilities.CreateInstance<CharacterSheetRepository>(s, dbPath));

        return builder.Build();
	}
}
