using KingstoneProject.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace KingstoneProject;

public partial class CharacterPage : ContentPage
{
    List<String> backgroundList = new();
    CharacterSheet characterSheet = new();
    ObservableCollection<String> subBackgroundList = new();
    ObservableCollection<String> classList = new();
    ObservableCollection<String> PAWList = new();
    ObservableCollection<String> DistinctionList = new();
    ObservableCollection<String> PrimaryDisciplineList = new();
    ObservableCollection<String> SecondaryDisciplineList = new();

    public CharacterPage()
	{
        InitializeComponent();
    }
    public async void getPreset()
    {
        if(App.CharacterSheetRepo != null){
            characterSheet = await App.CharacterSheetRepo.GetCharacterSheet(App.CharacterSheetRepo.currentSheetId);
        }
        if (characterSheet != null)
        {
            if (characterSheet.CharacterImage != null)
            {
                if (!string.Equals(characterSheet.CharacterImage, "sheetspagefavicon.png"))
                {
                    string cacheDir = FileSystem.Current.CacheDirectory;
                    CharacterImage.Source = Path.Combine(cacheDir, characterSheet.CharacterImage);
                }
                else
                {
                    CharacterImage.Source = characterSheet.CharacterImage;
                }
            }

            if (characterSheet.Name is not null)
            {
                CharacterName.Text = characterSheet.Name;
            }


            backgroundList.Add("Nature's Keepers");
            backgroundList.Add("the Edified");
            backgroundList.Add("the Lost");
            backgroundList.Add("the Bestials");
            backgroundList.Add("the Awoken");
            backgroundList.Add("Worldbearers");
            backgroundPicker.ItemsSource = backgroundList;

            backgroundPicker.SelectedIndex = -1;
            if (characterSheet.Background != null)
            {
                backgroundPicker.SelectedIndex = backgroundList.IndexOf(characterSheet.Background);
            }
            subBackgroundPicker.ItemsSource = subBackgroundList;

            subBackgroundPicker.SelectedIndex = -1;
            if (characterSheet.SubBackground != null)
            {
                subBackgroundPicker.SelectedIndex = subBackgroundList.IndexOf(characterSheet.SubBackground);
            }

            classList.Clear();
            classList.Add("Expert");
            classList.Add("Spellsword");
            classList.Add("Spellweaver");
            classPicker.ItemsSource = classList;

            classPicker.SelectedIndex = -1;
            if (characterSheet.CharacterClass != null)
            {
                classPicker.SelectedIndex = classList.IndexOf(characterSheet.CharacterClass);
            }

            PAWList.Clear();
            PAWList.Add("0 1 2");
            PAWList.Add("0 2 1");
            PAWList.Add("1 0 2");
            PAWList.Add("1 2 0");
            PAWList.Add("2 1 0");
            PAWList.Add("2 0 1");
            PAWPicker.ItemsSource = PAWList;

            PAWPicker.SelectedIndex = -1;
            if (characterSheet.Paw != null)
            {
                PAWPicker.SelectedIndex = PAWList.IndexOf(characterSheet.Paw);
            }

            DistinctionPicker.SetValue(IsVisibleProperty, false);
            DistinctionLabel.SetValue(IsVisibleProperty, false);
            DistinctionFrame.SetValue(IsVisibleProperty, false);
            PrimaryDisciplinePicker.SetValue(IsVisibleProperty, false);
            PrimaryDisciplineLabel.SetValue(IsVisibleProperty, false);
            PrimaryDisciplineFrame.SetValue(IsVisibleProperty, false);
            SecondaryDisciplinePicker.SetValue(IsVisibleProperty, false);
            SecondaryDisciplineLabel.SetValue(IsVisibleProperty, false);
            SecondaryDisciplineFrame.SetValue(IsVisibleProperty, false);

            DistinctionList.Clear();
            DistinctionList.Add("Strength");
            DistinctionList.Add("Endurance");
            DistinctionList.Add("Ready");
            DistinctionList.Add("Agility");
            DistinctionList.Add("Knowledge");
            DistinctionList.Add("Proficiency");
            DistinctionList.Add("Charisma");
            DistinctionList.Add("Awareness");
            DistinctionPicker.ItemsSource = DistinctionList;

            DistinctionPicker.SelectedIndex = -1;
            if (characterSheet.Distinction != null)
            {
                DistinctionPicker.SelectedIndex = DistinctionList.IndexOf(characterSheet.Distinction);
            }

            PrimaryDisciplineList.Clear();
            PrimaryDisciplineList.Add("Destruction");
            PrimaryDisciplineList.Add("Transmutation");
            PrimaryDisciplineList.Add("Restoration");

            PrimaryDisciplinePicker.ItemsSource = PrimaryDisciplineList;

            PrimaryDisciplinePicker.SelectedIndex = -1;
            if (characterSheet.PrimaryDiscipline != null)
            {
                PrimaryDisciplinePicker.SelectedIndex = PrimaryDisciplineList.IndexOf(characterSheet.PrimaryDiscipline);
            }

            if (characterSheet.CharacterClass != null)
            {
                if (characterSheet.CharacterClass.Equals("Expert"))
                {
                    PrimaryDisciplinePicker.SetValue(IsVisibleProperty, false);
                    PrimaryDisciplineLabel.SetValue(IsVisibleProperty, false);
                    PrimaryDisciplineFrame.SetValue(IsVisibleProperty, false);
                }
                if (!characterSheet.CharacterClass.Equals("Spellweaver"))
                {
                    PrimaryDisciplinePicker.SetValue(IsVisibleProperty, false);
                    PrimaryDisciplineLabel.SetValue(IsVisibleProperty, false);
                    PrimaryDisciplineFrame.SetValue(IsVisibleProperty, false);
                }
                if (!characterSheet.CharacterClass.Equals("Expert"))
                {
                    DistinctionPicker.SetValue(IsVisibleProperty, false);
                    DistinctionLabel.SetValue(IsVisibleProperty, false);
                    DistinctionFrame.SetValue(IsVisibleProperty, false);
                }
            } else
            {
                PrimaryDisciplinePicker.SetValue(IsVisibleProperty, false);
                PrimaryDisciplineLabel.SetValue(IsVisibleProperty, false);
                PrimaryDisciplineFrame.SetValue(IsVisibleProperty, false);
                SecondaryDisciplinePicker.SetValue(IsVisibleProperty, false);
                SecondaryDisciplineLabel.SetValue(IsVisibleProperty, false);
                SecondaryDisciplineFrame.SetValue(IsVisibleProperty, false);
                DistinctionPicker.SetValue(IsVisibleProperty, false);
                DistinctionLabel.SetValue(IsVisibleProperty, false);
                DistinctionFrame.SetValue(IsVisibleProperty, false);
            }

            SecondaryDisciplineList.Clear();
            if (characterSheet.PrimaryDiscipline == null)
            {
                SecondaryDisciplineList.Add("Destruction");
                SecondaryDisciplineList.Add("Transmutation");
                SecondaryDisciplineList.Add("Restoration");
            }
            else if (characterSheet.PrimaryDiscipline.Equals("Destruction"))
            {
                SecondaryDisciplineList.Add("Transmutation");
                SecondaryDisciplineList.Add("Restoration");
            }
            else if (characterSheet.PrimaryDiscipline.Equals("Transmutation"))
            {
                SecondaryDisciplineList.Add("Destruction");
                SecondaryDisciplineList.Add("Restoration");
            }
            else if (characterSheet.PrimaryDiscipline.Equals("Restoration"))
            {
                SecondaryDisciplineList.Add("Destruction");
                SecondaryDisciplineList.Add("Transmutation");
            }

            SecondaryDisciplinePicker.ItemsSource = SecondaryDisciplineList;

            SecondaryDisciplinePicker.SelectedIndex = -1;
            if (characterSheet.SecondaryDiscipline != null)
            {
                SecondaryDisciplinePicker.SelectedIndex = SecondaryDisciplineList.IndexOf(characterSheet.SecondaryDiscipline);
            }

            LeftHand.Text = "";
            if (characterSheet.LeftHandName != null)
            {
                LeftHand.Text = characterSheet.LeftHandName;
            }

            RightHand.Text = "";
            if (characterSheet.RightHandName != null)
            {
                RightHand.Text = characterSheet.RightHandName;
            }

            if (characterSheet.LeftHandImage != null)
            {
                if (!string.Equals(characterSheet.LeftHandImage, "lefthanddefault.png"))
                {
                    string cacheDir2 = FileSystem.Current.CacheDirectory;
                    LeftHandImage.Source = Path.Combine(cacheDir2, characterSheet.LeftHandImage);
                }
                else
                {
                    LeftHandImage.Source = characterSheet.LeftHandImage;
                }
            }

            if (characterSheet.RightHandImage != null)
            {
                if (!string.Equals(characterSheet.RightHandImage, "righthanddefault.png"))
                {
                    string cacheDir2 = FileSystem.Current.CacheDirectory;
                    RightHandImage.Source = Path.Combine(cacheDir2, characterSheet.RightHandImage);
                }
                else
                {
                    RightHandImage.Source = characterSheet.RightHandImage;
                }
            }
            if (characterSheet.Foibles != null)
            {
                FoibleEditor.Text = characterSheet.Foibles;
            }
            if (characterSheet.Specials != null)
            {
                SpecialEditor.Text = characterSheet.Specials;
            }
        }
        else
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                DisplayAlert("Warning", "Go make a Character Sheet on the Sheets Page before you continue!", "Sure");
            });
            await Shell.Current.GoToAsync("///sheets");
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        getPreset();
    }

    public void OnCharacterImageClicked(object sender, EventArgs e)
    {
        ChooseAPhoto();
    }
    public async void ChooseAPhoto()
    {
        FileResult photo = await MediaPicker.PickPhotoAsync();
        if (photo == null)
        {
            return;
        }
        var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
        using (var stream = await photo.OpenReadAsync())
        using (var newStream = File.OpenWrite(newFile))
            await stream.CopyToAsync(newStream);

        CharacterImage.Source = newFile;
        characterSheet.CharacterImage = newFile;
        await App.CharacterSheetRepo.UpdateCharacterSheet(characterSheet);
    }

    private async void OnCharacterNameTextChanged(object sender, TextChangedEventArgs e)
    {
        characterSheet.Name = CharacterName.Text;
        await App.CharacterSheetRepo.UpdateCharacterSheet(characterSheet);
    }

    public void GetHarm()
    {
        List<ImageButton> Harm = new List<ImageButton>();
        int HarmFestered = characterSheet.HarmFestered;
        int HarmTaken = characterSheet.HarmTaken;
        grid = grid as Grid;
        grid.Clear();
        ImageButton Harm1 = new ImageButton();
        Harm.Add(Harm1);
        ImageButton Harm2 = new ImageButton();
        Harm.Add(Harm2);
        ImageButton Harm3 = new ImageButton();
        Harm.Add(Harm3);
        ImageButton Harm4 = new ImageButton();
        Harm.Add(Harm4);
        ImageButton Harm5 = new ImageButton();
        Harm.Add(Harm5);
        ImageButton Harm6 = new ImageButton();
        Harm.Add(Harm6);
        ImageButton Harm7 = new ImageButton();
        Harm.Add(Harm7);
        ImageButton Harm8 = new ImageButton();
        Harm.Add(Harm8);
        ImageButton Harm9 = new ImageButton();
        Harm.Add(Harm9);
        ImageButton Harm10 = new ImageButton();
        Harm.Add(Harm10);
        int HarmTotal = 0;
        if (characterSheet.CharacterClass == null || (characterSheet.CharacterClass.Equals("Spellweaver")))
        {
            HarmTotal = 5;
        } else if (characterSheet.CharacterClass.Equals("Spellsword")){
            HarmTotal = 6;
        } else if (characterSheet.CharacterClass.Equals("Expert")){
            HarmTotal = 7;
        }

        if(characterSheet.Endurance >= 18)
        {
            HarmTotal++;
        }

        if (characterSheet.Endurance >= 126)
        {
            HarmTotal += 2;
        }

        for (int i = 0; i < HarmTotal; i++)
        {
            Harm[i].Clicked += OnHarmClicked;
            Harm[i].Source = "harmcircle.png";
            if (HarmTaken > 0)
            {
                Harm[i].Source = "harmcirclefilled.png";
                HarmTaken--;
            }
            else if (HarmFestered > 0)
            {
                Harm[i].Source = "harmcirclefestered.png";
                HarmFestered--;
            }
        }

        
        if ((HarmTotal == 5) || (HarmTotal == 0))
        {
            grid.Add(Harm1, 1, 2);
            grid.Add(Harm2, 3, 2);
            grid.Add(Harm3, 1, 1);
            grid.Add(Harm4, 3, 1);
            grid.Add(Harm5, 2, 0);
        } else if(HarmTotal == 6)
        {
            grid.Add(Harm1, 1, 2);
            grid.Add(Harm2, 2, 2);
            grid.Add(Harm3, 3, 2);
            grid.Add(Harm4, 1, 1);
            grid.Add(Harm5, 3, 1);
            grid.Add(Harm6, 2, 0);
        } else if (HarmTotal == 7)
        {
            grid.Add(Harm1, 1, 2);
            grid.Add(Harm2, 2, 2);
            grid.Add(Harm3, 3, 2);
            grid.Add(Harm4, 1, 1);
            grid.Add(Harm5, 2, 1);
            grid.Add(Harm6, 3, 1);
            grid.Add(Harm7, 2, 0);
        } else if (HarmTotal == 8)
        {
            grid.Add(Harm1, 0, 2);
            grid.Add(Harm2, 1, 2);
            grid.Add(Harm3, 3, 2);
            grid.Add(Harm4, 4, 2);
            grid.Add(Harm5, 1, 1);
            grid.Add(Harm6, 2, 1);
            grid.Add(Harm7, 3, 1);
            grid.Add(Harm8, 2, 0);
        } else if (HarmTotal == 9)
        {
            grid.Add(Harm1, 0, 2);
            grid.Add(Harm2, 1, 2);
            grid.Add(Harm3, 2, 2);
            grid.Add(Harm4, 3, 2);
            grid.Add(Harm5, 4, 2);
            grid.Add(Harm6, 1, 1);
            grid.Add(Harm7, 2, 1);
            grid.Add(Harm8, 3, 1);
            grid.Add(Harm9, 2, 0);
        } else if (HarmTotal == 10)
        {
            grid.Add(Harm1, 0, 2);
            grid.Add(Harm2, 1, 2);
            grid.Add(Harm3, 2, 2);
            grid.Add(Harm4, 3, 2);
            grid.Add(Harm5, 4, 2);
            grid.Add(Harm6, 1, 1);
            grid.Add(Harm7, 2, 1);
            grid.Add(Harm8, 3, 1);
            grid.Add(Harm9, 1, 0);
            grid.Add(Harm10, 3, 0);
        }
    }

    public async void OnHarmClicked(object sender, EventArgs e)
    {
        ImageButton button = sender as ImageButton;
        string path = button.Source.ToString();
        path = path.Remove(0,6);

        if (path.Equals("harmcircle.png"))
        {
            button.Source = "harmcirclefilled.png";
            characterSheet.HarmTaken++;
            await App.CharacterSheetRepo.UpdateCharacterSheet(characterSheet);
        } 
        else if (path.Equals("harmcirclefilled.png"))
        {
            button.Source = "harmcirclefestered.png";
            characterSheet.HarmTaken--;
            characterSheet.HarmFestered++;
            await App.CharacterSheetRepo.UpdateCharacterSheet(characterSheet);
        } 
        else if (path.Equals("harmcirclefestered.png"))
        {
            button.Source = "harmcircle.png";
            characterSheet.HarmFestered--;
            await App.CharacterSheetRepo.UpdateCharacterSheet(characterSheet);
        }
    }

    private async void OnBackgroundPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        characterSheet.Background = backgroundPicker.SelectedItem as String;
        await App.CharacterSheetRepo.UpdateCharacterSheet(characterSheet);
        subBackgroundList.Clear();
        if (characterSheet.Background == "Nature's Keepers")
        {
            subBackgroundList.Add("Elfin");
            subBackgroundList.Add("Burrowfolk");
            subBackgroundList.Add("Fae");
        }
        else if (characterSheet.Background == "the Edified")
        {
            subBackgroundList.Add("Skill at Crafting");
            subBackgroundList.Add("Strong Character");
            subBackgroundList.Add("Warrior's Resilience");
        }
        else if (characterSheet.Background == "the Lost")
        {
            subBackgroundList.Add("Anger");
            subBackgroundList.Add("Greed");
            subBackgroundList.Add("Mania");
        }
        else if (characterSheet.Background == "the Bestials")
        {
            subBackgroundList.Add("Force");
            subBackgroundList.Add("Guile");
            subBackgroundList.Add("Adroit");
        }
        else if (characterSheet.Background == "the Awoken")
        {
            subBackgroundList.Add("Undead");
            subBackgroundList.Add("Elemental");
            subBackgroundList.Add("Vegetation");
        }
        else if (characterSheet.Background == "Worldbearers")
        {
            subBackgroundList.Add("Descended");
            subBackgroundList.Add("Diminished");
            subBackgroundList.Add("Defenders");
        }
        
        subBackgroundPicker.ItemsSource = subBackgroundList;
        subBackgroundPicker.SelectedIndex = -1;
        if (characterSheet.SubBackground != null)
        {
            subBackgroundPicker.SelectedIndex = subBackgroundList.IndexOf(characterSheet.SubBackground);
        }
    }
    private async void OnSubBackgroundPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        characterSheet.SubBackground = subBackgroundPicker.SelectedItem as String;
        await App.CharacterSheetRepo.UpdateCharacterSheet(characterSheet);
    }
    private async void OnClassPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        characterSheet.CharacterClass = classPicker.SelectedItem as String;
        await App.CharacterSheetRepo.UpdateCharacterSheet(characterSheet);
        GetHarm();
        DistinctionPicker.SetValue(IsVisibleProperty, true);
        DistinctionLabel.SetValue(IsVisibleProperty, true);
        DistinctionFrame.SetValue(IsVisibleProperty, true);
        PrimaryDisciplinePicker.SetValue(IsVisibleProperty, true);
        PrimaryDisciplineLabel.SetValue(IsVisibleProperty, true);
        PrimaryDisciplineFrame.SetValue(IsVisibleProperty, true);
        SecondaryDisciplinePicker.SetValue(IsVisibleProperty, true);
        SecondaryDisciplineLabel.SetValue(IsVisibleProperty, true);
        SecondaryDisciplineFrame.SetValue(IsVisibleProperty, true);
        if (characterSheet.CharacterClass != null)
        {
            if (!characterSheet.CharacterClass.Equals("Expert"))
            {
                DistinctionPicker.SetValue(IsVisibleProperty, false);
                DistinctionLabel.SetValue(IsVisibleProperty, false);
                DistinctionFrame.SetValue(IsVisibleProperty, false);
            }
            else if (characterSheet.CharacterClass.Equals("Expert"))
            {
                PrimaryDisciplinePicker.SetValue(IsVisibleProperty, false);
                PrimaryDisciplineLabel.SetValue(IsVisibleProperty, false);
                PrimaryDisciplineFrame.SetValue(IsVisibleProperty, false);
            }
            if (!characterSheet.CharacterClass.Equals("Spellweaver"))
            {
                SecondaryDisciplinePicker.SetValue(IsVisibleProperty, false);
                SecondaryDisciplineLabel.SetValue(IsVisibleProperty, false);
                SecondaryDisciplineFrame.SetValue(IsVisibleProperty, false);
            }
        }
    }
    private async void OnPAWPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        characterSheet.Paw = PAWPicker.SelectedItem as String;
        await App.CharacterSheetRepo.UpdateCharacterSheet(characterSheet);
    }
    private async void OnDistinctionPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        characterSheet.Distinction = DistinctionPicker.SelectedItem as String;
        await App.CharacterSheetRepo.UpdateCharacterSheet(characterSheet);
    }
    private async void OnPrimaryDisciplinePickerSelectedIndexChanged(object sender, EventArgs e)
    {
        characterSheet.PrimaryDiscipline = PrimaryDisciplinePicker.SelectedItem as String;
        await App.CharacterSheetRepo.UpdateCharacterSheet(characterSheet);

        SecondaryDisciplineList.Clear();
        if (characterSheet.CharacterClass != null)
        {
            if (characterSheet.PrimaryDiscipline == null)
            {
                SecondaryDisciplineList.Add("Destruction");
                SecondaryDisciplineList.Add("Transmutation");
                SecondaryDisciplineList.Add("Restoration");
            }
            else if (characterSheet.PrimaryDiscipline.Equals("Destruction") & characterSheet.CharacterClass.Equals("Spellweaver"))
            {
                SecondaryDisciplineList.Add("Transmutation");
                SecondaryDisciplineList.Add("Restoration");
            }
            else if (characterSheet.PrimaryDiscipline.Equals("Transmutation") & characterSheet.CharacterClass.Equals("Spellweaver"))
            {
                SecondaryDisciplineList.Add("Destruction");
                SecondaryDisciplineList.Add("Restoration");
            }
            else if (characterSheet.PrimaryDiscipline.Equals("Restoration") & characterSheet.CharacterClass.Equals("Spellweaver"))
            {
                SecondaryDisciplineList.Add("Destruction");
                SecondaryDisciplineList.Add("Transmutation");
            }
        }
        SecondaryDisciplinePicker.ItemsSource = SecondaryDisciplineList;

        SecondaryDisciplinePicker.SelectedIndex = -1;
        if (characterSheet.SecondaryDiscipline != null)
        {
            SecondaryDisciplinePicker.SelectedIndex = SecondaryDisciplineList.IndexOf(characterSheet.SecondaryDiscipline);
        }
    }
    private async void OnSecondaryDisciplinePickerSelectedIndexChanged(object sender, EventArgs e)
    {
        characterSheet.SecondaryDiscipline = SecondaryDisciplinePicker.SelectedItem as String;
        await App.CharacterSheetRepo.UpdateCharacterSheet(characterSheet);
    }
    
    private async void OnLeftHandTextChanged(object sender, EventArgs e)
    {
        characterSheet.LeftHandName = LeftHand.Text;
        await App.CharacterSheetRepo.UpdateCharacterSheet(characterSheet);
    }
    private async void OnRightHandTextChanged(object sender, EventArgs e)
    {
        characterSheet.RightHandName = RightHand.Text;
        await App.CharacterSheetRepo.UpdateCharacterSheet(characterSheet);
    }
    private async void OnLeftHandImageClicked(object sender, EventArgs e)
    {
        FileResult photo = await MediaPicker.PickPhotoAsync();
        if (photo == null)
        {
            return;
        }
        var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
        using (var stream = await photo.OpenReadAsync())
        using (var newStream = File.OpenWrite(newFile))
            await stream.CopyToAsync(newStream);

        LeftHandImage.Source = newFile;
        characterSheet.LeftHandImage = newFile;
        await App.CharacterSheetRepo.UpdateCharacterSheet(characterSheet);
    }
    private async void OnRightHandImageClicked(object sender, EventArgs e)
    {
        FileResult photo = await MediaPicker.PickPhotoAsync();
        if (photo == null)
        {
            return;
        }
        var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
        using (var stream = await photo.OpenReadAsync())
        using (var newStream = File.OpenWrite(newFile))
            await stream.CopyToAsync(newStream);

        RightHandImage.Source = newFile;
        characterSheet.RightHandImage = newFile;
        await App.CharacterSheetRepo.UpdateCharacterSheet(characterSheet);
    }
    
    private async void OnFoibleEditorTextChanged(object sender, EventArgs e)
    {
        characterSheet.Foibles = FoibleEditor.Text as String;
        await App.CharacterSheetRepo.UpdateCharacterSheet(characterSheet);
    }
    
    private async void OnSpecialEditorTextChanged(object sender, EventArgs e)
    {
        characterSheet.Specials = SpecialEditor.Text as String;
        await App.CharacterSheetRepo.UpdateCharacterSheet(characterSheet);
    }
}   
