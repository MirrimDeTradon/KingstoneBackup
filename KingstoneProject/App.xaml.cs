namespace KingstoneProject;

public partial class App : Application
{
    public static CharacterSheetRepository CharacterSheetRepo { get; private set; }

    public App(CharacterSheetRepository repo)
	{
        CharacterSheetRepo = repo;

        InitializeComponent();

		MainPage = new AppShell();        
    }
}
