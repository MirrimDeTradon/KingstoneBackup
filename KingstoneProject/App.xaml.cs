namespace KingstoneProject;

public partial class App : Application
{
    public static CharacterSheetRepository CharacterSheetRepo { get; private set; }
    public static UpgradesTrackerRepository UpgradesTrackerRepository { get; private set; }
    public App(CharacterSheetRepository repo, UpgradesTrackerRepository repo2)
	{
        CharacterSheetRepo = repo;
        UpgradesTrackerRepository = repo2;

        InitializeComponent();

		MainPage = new AppShell();        
    }
}
