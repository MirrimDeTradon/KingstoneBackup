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
                fonts.AddFont("impact.ttf", "Impact");
            });

        string dbPath = FileAccessHelper.GetLocalFilePath("charactersheets.db3");
        string dbPath2 = FileAccessHelper.GetLocalFilePath("upgradetrackers.db3");
        builder.Services.AddSingleton<CharacterSheetRepository>(s => ActivatorUtilities.CreateInstance<CharacterSheetRepository>(s, dbPath));
        builder.Services.AddSingleton<UpgradesTrackerRepository>(s => ActivatorUtilities.CreateInstance<UpgradesTrackerRepository>(s, dbPath2));

        return builder.Build();
	}
}
