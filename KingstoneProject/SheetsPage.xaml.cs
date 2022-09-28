using KingstoneProject.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace KingstoneProject;

public partial class SheetsPage : ContentPage
{
    ObservableCollection<CharacterSheet> charactersheets { get; set; }
    public SheetsPage()
    {
        InitializeComponent();
        
        GetSQL();
    }

    public async void OnNewButtonClicked(object sender, EventArgs args)
    {

        await App.CharacterSheetRepo.AddNewCharacterSheet(newCharacterSheet.Text, null, null, null, null, null, null, null, 0, 0, null, "lefthanddefault.png", null, "righthanddefault.png", null, "sheetspagefavicon.png", null, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        newCharacterSheet.Text = "";
        GetSQL();
    }

    public async void GetSQL()
    {
        charactersheets = await App.CharacterSheetRepo.GetAllCharacterSheets();
        characterSheetList.ItemsSource = charactersheets;
        App.CharacterSheetRepo.currentSheetId = (characterSheetList.CurrentItem as CharacterSheet).Id;
    }

    private async void OnDeleteInvoked(object sender, EventArgs e)
    {
        CharacterSheet charactersheet = characterSheetList.CurrentItem as CharacterSheet;
        if (charactersheet == null)
            return;
        await App.CharacterSheetRepo.RemoveCharacterSheet(characterSheetList.CurrentItem as CharacterSheet)   ;
        GetSQL();
    }

    private void OnPositionChanged(object sender, EventArgs e)
    {
        CharacterSheet charactersheet = characterSheetList.CurrentItem as CharacterSheet;
        App.CharacterSheetRepo.currentSheetId = charactersheet.Id;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        int currentSheetId = App.CharacterSheetRepo.currentSheetId;
        if (charactersheets != null)
        {
            CharacterSheet currentCharacterSheet = new CharacterSheet();
            for (int i = 0; i < charactersheets.Count; i++)
            {
                if(charactersheets[i].Id == currentSheetId)
                {
                    charactersheets[i] = await App.CharacterSheetRepo.GetCharacterSheet(currentSheetId);
                }
            }
        }
    }
}