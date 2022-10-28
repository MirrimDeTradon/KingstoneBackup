using KingstoneProject.Models;

namespace KingstoneProject;

public partial class MarksPage : ContentPage
{
    CharacterSheet characterSheet = new();
    public MarksPage()
    {
        InitializeComponent();
    }
    public async void getPreset()
    {
        characterSheet = await App.CharacterSheetRepo.GetCharacterSheet(App.CharacterSheetRepo.currentSheetId);

        setUpStat(strengthPlusMinusGrid, characterSheet.Strength, "Strength", new Grid[] { sGrid1, sGrid2, sGrid3, sGrid4, sGrid5, sGrid6 }, strengthGrid);
        setUpStat(endurancePlusMinusGrid, characterSheet.Endurance, "Endurance", new Grid[] { eGrid1, eGrid2, eGrid3, eGrid4, eGrid5, eGrid6 }, enduranceGrid);
        setUpStat(readyPlusMinusGrid, characterSheet.Ready, "Ready", new Grid[] { rGrid1, rGrid2, rGrid3, rGrid4, rGrid5, rGrid6 }, readyGrid);
        setUpStat(agilityPlusMinusGrid, characterSheet.Agility, "Agility", new Grid[] { aGrid1, aGrid2, aGrid3, aGrid4, aGrid5, aGrid6 }, agilityGrid);
        setUpStat(knowledgePlusMinusGrid, characterSheet.Knowledge, "Knowledge", new Grid[] { kGrid1, kGrid2, kGrid3, kGrid4, kGrid5, kGrid6 }, knowledgeGrid);
        setUpStat(proficiencyPlusMinusGrid, characterSheet.Proficiency, "Proficiency", new Grid[] { pGrid1, pGrid2, pGrid3, pGrid4, pGrid5, pGrid6 }, proficiencyGrid);
        setUpStat(charismaPlusMinusGrid, characterSheet.Charisma, "Charisma", new Grid[] { cGrid1, cGrid2, cGrid3, cGrid4, cGrid5, cGrid6 }, charismaGrid);
        setUpStat(awarenessPlusMinusGrid, characterSheet.Awareness, "Awareness", new Grid[] { awGrid1, awGrid2, awGrid3, awGrid4, awGrid5, awGrid6 }, awarenessGrid);
        setUpStat(destructionPlusMinusGrid, characterSheet.Destruction, "Destruction", new Grid[] { dGrid1, dGrid2, dGrid3, dGrid4, dGrid5, dGrid6 }, destructionGrid);
        setUpStat(transmutationPlusMinusGrid, characterSheet.Transmutation, "Transmutation", new Grid[] { tGrid1, tGrid2, tGrid3, tGrid4, tGrid5, tGrid6 }, transmutationGrid);
        setUpStat(restorationPlusMinusGrid, characterSheet.Restoration, "Restoration", new Grid[] { resGrid1, resGrid2, resGrid3, resGrid4, resGrid5, resGrid6 }, restorationGrid);

        destructionMainGrid.SetValue(IsVisibleProperty, false);
        destructionGrid.SetValue(IsVisibleProperty, false);
        transmutationMainGrid.SetValue(IsVisibleProperty, false);
        transmutationGrid.SetValue(IsVisibleProperty, false);
        restorationMainGrid.SetValue(IsVisibleProperty, false);
        restorationGrid.SetValue(IsVisibleProperty, false);
        if (characterSheet.PrimaryDiscipline != null)
        {
            if (characterSheet.CharacterClass != null)
            {
                if (characterSheet.CharacterClass.Equals("Spellweaver") || characterSheet.CharacterClass.Equals("Spellsword"))
                {
                    if (characterSheet.PrimaryDiscipline.Equals("Destruction"))
                    {
                        destructionMainGrid.SetValue(IsVisibleProperty, true);
                        destructionGrid.SetValue(IsVisibleProperty, true);
                    }
                    else if (characterSheet.PrimaryDiscipline.Equals("Transmutation"))
                    {
                        transmutationMainGrid.SetValue(IsVisibleProperty, true);
                        transmutationGrid.SetValue(IsVisibleProperty, true);
                    }
                    else if (characterSheet.PrimaryDiscipline.Equals("Restoration"))
                    {
                        restorationMainGrid.SetValue(IsVisibleProperty, true);
                        restorationGrid.SetValue(IsVisibleProperty, true);
                    }
                }
            }
        }
        if (characterSheet.SecondaryDiscipline != null)
        {
            if (characterSheet.CharacterClass != null)
            {
                if (characterSheet.CharacterClass.Equals("Spellweaver"))
                {
                    if (characterSheet.SecondaryDiscipline.Equals("Destruction"))
                    {
                        destructionMainGrid.SetValue(IsVisibleProperty, true);
                        destructionGrid.SetValue(IsVisibleProperty, true);
                    }
                    else if (characterSheet.SecondaryDiscipline.Equals("Transmutation"))
                    {
                        transmutationMainGrid.SetValue(IsVisibleProperty, true);
                        transmutationGrid.SetValue(IsVisibleProperty, true);
                    }
                    else if (characterSheet.SecondaryDiscipline.Equals("Restoration"))
                    {
                        restorationMainGrid.SetValue(IsVisibleProperty, true);
                        restorationGrid.SetValue(IsVisibleProperty, true);
                    }
                }
            }
        }
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        getPreset();
    }

    public List<ImageButton> getAddSubtract(Grid grid, int stat, string statName)
    {
        List<ImageButton> result = new();

        ImageButton plus = new();
        plus.Source = "plusbutton";
        result.Add(plus);
        grid.Add(plus, 1, 0);

        ImageButton minus = new();
        minus.Source = "minusbutton";
        result.Add(minus);
        grid.Add(minus, 0, 0);

        return result;
    }

    public List<List<Image>> getMarks(Grid grid, int stat, string statName, Grid[] skGridArray)
    {
        int[] pointMarks = new int[] { 6, 18, 36, 60, 90, 126 };
        List<List<Image>> result = new();

        int trueStat = stat;

        if (characterSheet.Background != null)
        {
            if ((characterSheet.Background.Equals("the Edified") & (statName.Equals("Strength") || statName.Equals("Knowledge"))) ||
                (characterSheet.Background.Equals("the Lost") & (statName.Equals("Endurance") || statName.Equals("Charisma"))) ||
                 (characterSheet.Background.Equals("the Bestials") & (statName.Equals("Charisma") || statName.Equals("Awareness"))))
            {
                trueStat += 6;
            }
        }
        if (characterSheet.SubBackground != null)
        {
            if ((characterSheet.SubBackground.Equals("Elfin") & (statName.Equals("Knowledge") || statName.Equals("Agility"))) ||
                (characterSheet.SubBackground.Equals("Burrowfolk") & (statName.Equals("Ready") || statName.Equals("Proficiency"))) ||
                 (characterSheet.SubBackground.Equals("Fae") & (statName.Equals("Awareness") || statName.Equals("Charisma"))) ||
                  (characterSheet.SubBackground.Equals("Undead") & (statName.Equals("Endurance") || statName.Equals("Knowledge"))) ||
                   (characterSheet.SubBackground.Equals("Vegetation") & (statName.Equals("Proficiency") || statName.Equals("Ready"))) ||
                    (characterSheet.SubBackground.Equals("Descended") & (statName.Equals("Charisma") || statName.Equals("Agility"))) ||
                     (characterSheet.SubBackground.Equals("Diminshed") & (statName.Equals("Strength") || statName.Equals("Ready"))) ||
                     (characterSheet.SubBackground.Equals("Defenders") & (statName.Equals("Strength") || statName.Equals("Proficiency"))))
            {
                trueStat += 6;
            }
            else if (characterSheet.SubBackground.Equals("Elemental") & statName.Equals("Agility"))
            {
                trueStat += 18;
            }
        }

        for (int i = 0; i < 6; i++)
        {
            List<Image> lines = new();
            for(int j = 0; j < i+1; j++)
            {
                Image line = new();
                if(trueStat > 6)
                {
                    line.Source = "m6";
                    trueStat -= 6;
                } else
                {
                    line.Source = "m" + trueStat.ToString();
                    trueStat -= trueStat;
                }
                
                lines.Add(line);
                skGridArray[i].Add(line, j, 0);
            }
            result.Add(lines);
        }
        return result;
    }
    private async void OnPlusClicked(object sender, EventArgs e)
    {
        string thisSkill = ((ImageButton)sender).BindingContext as String;
        System.Reflection.PropertyInfo prop = typeof(CharacterSheet).GetProperty(thisSkill);
        int skillValue = (int)prop.GetValue(characterSheet);
        
        if (characterSheet.CharacterClass != null)
        {
            if (characterSheet.Distinction != null)
            {
                if (characterSheet.CharacterClass.Equals("Expert") & characterSheet.Distinction.Equals(thisSkill))
                {
                    if (skillValue + 4 < 126)
                    {
                        prop.SetValue(characterSheet, skillValue + 4);
                    }
                    else
                    {
                        prop.SetValue(characterSheet, 126);
                    }
                    goto breakloop;
                }
                else
                {
                    if (skillValue + 2 < 126)
                    {
                        prop.SetValue(characterSheet, skillValue + 2);
                    }
                    else
                    {
                        prop.SetValue(characterSheet, 126);
                    }
                }
            }
            if (characterSheet.SecondaryDiscipline != null)
            {
                if (characterSheet.CharacterClass.Equals("Spellweaver") & characterSheet.SecondaryDiscipline.Equals(thisSkill))
                {
                    if (skillValue + 1 < 126)
                    {
                        prop.SetValue(characterSheet, skillValue + 1);
                    }
                    else
                    {
                        prop.SetValue(characterSheet, 126);
                    }
                }
                else
                {
                    if (skillValue + 2 < 126)
                    {
                        prop.SetValue(characterSheet, skillValue + 2);
                    }
                    else
                    {
                        prop.SetValue(characterSheet, 126);
                    }
                }
            }
            else
            {
                if (skillValue + 2 < 126)
                {
                    prop.SetValue(characterSheet, skillValue + 2);
                }
                else
                {
                    prop.SetValue(characterSheet, 126);
                }
            }
        }
        else
        {
            if (skillValue + 2 < 126)
            {
                prop.SetValue(characterSheet, skillValue + 2);
            }
            else
            {
                prop.SetValue(characterSheet, 126);
            }
        }
        breakloop:
        await App.CharacterSheetRepo.UpdateCharacterSheet(characterSheet);
        getPreset();
    }
    private async void OnMinusClicked(object sender, EventArgs e)
    {
        string thisSkill = ((ImageButton)sender).BindingContext as String;
        System.Reflection.PropertyInfo prop = typeof(CharacterSheet).GetProperty(thisSkill);
        int skillValue = (int)prop.GetValue(characterSheet);

        if (characterSheet.CharacterClass != null)
        {
            if (characterSheet.Distinction != null)
            {
                if (characterSheet.CharacterClass.Equals("Expert") & characterSheet.Distinction.Equals(thisSkill))
                {
                    if (skillValue - 4 > 0)
                    {
                        prop.SetValue(characterSheet, skillValue - 4);
                    }
                    else
                    {
                        prop.SetValue(characterSheet, 0);
                    }
                    goto breakloop;
                }
                else
                {
                    if (skillValue - 2 > 0)
                    {
                        prop.SetValue(characterSheet, skillValue - 2);
                    }
                    else
                    {
                        prop.SetValue(characterSheet, 0);
                    }
                }
            }
            if (characterSheet.SecondaryDiscipline != null)
            {
                if (characterSheet.CharacterClass.Equals("Spellweaver") & characterSheet.SecondaryDiscipline.Equals(thisSkill))
                {
                    if (skillValue - 1 > 0)
                    {
                        prop.SetValue(characterSheet, skillValue - 1);
                    }
                    else
                    {
                        prop.SetValue(characterSheet, 0);
                    }
                }
                else
                {
                    if (skillValue - 2 > 0)
                    {
                        prop.SetValue(characterSheet, skillValue - 2);
                    }
                    else
                    {
                        prop.SetValue(characterSheet, 0);
                    }
                }
            }
            else
            {
                if (skillValue - 2 > 0)
                {
                    prop.SetValue(characterSheet, skillValue - 2);
                }
                else
                {
                    prop.SetValue(characterSheet, 0);
                }
            }
        }
        else
        {
            if (skillValue - 2 > 0)
            {
                prop.SetValue(characterSheet, skillValue - 2);
            }
            else
            {
                prop.SetValue(characterSheet, 0);
            }
        }

        breakloop:
        await App.CharacterSheetRepo.UpdateCharacterSheet(characterSheet);
        getPreset();
    }
    private void setUpStat(Grid plusMinusGrid, int statValue, string statName, Grid[] gridArray, Grid marksGrid)
    {
        plusMinusGrid.Clear();
        List<ImageButton> addSubtractButtons = getAddSubtract(plusMinusGrid, statValue, statName);
        addSubtractButtons[0].Clicked += OnPlusClicked;
        addSubtractButtons[0].BindingContext = statName;
        addSubtractButtons[0].HorizontalOptions = LayoutOptions.Center;
        addSubtractButtons[0].VerticalOptions = LayoutOptions.Center;
        addSubtractButtons[1].Clicked += OnMinusClicked;
        addSubtractButtons[1].BindingContext = statName;
        addSubtractButtons[1].HorizontalOptions = LayoutOptions.Center;
        addSubtractButtons[1].VerticalOptions = LayoutOptions.Center;
        foreach (Grid grid in gridArray)
        {
            grid.Clear();
        }
        List<List<Image>> images = getMarks(marksGrid, statValue, statName, gridArray);
        images.ForEach(delegate (List<Image> imageList)
        {
            for (int i = 0; i < imageList.Count; i++)
            {
                if (imageList.Count % 2 > 0)
                {
                    int half = (int)(imageList.Count / 2);
                    if (i < half)
                    {
                        imageList[i].HorizontalOptions = LayoutOptions.End;
                    }
                    else if (i == half)
                    {
                        imageList[i].HorizontalOptions = LayoutOptions.Center;
                    }
                    else
                    {
                        imageList[i].HorizontalOptions = LayoutOptions.Start;
                    }
                }
                else
                {
                    int half = imageList.Count / 2;
                    if (i < half)
                    {
                        imageList[i].HorizontalOptions = LayoutOptions.End;
                    }
                    else
                    {
                        imageList[i].HorizontalOptions = LayoutOptions.Start;
                    }
                }
            }
        });
    }
}