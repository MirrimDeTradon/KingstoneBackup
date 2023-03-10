using KingstoneProject.Models;

namespace KingstoneProject;

public partial class UpgradesPage : ContentPage
{
    CharacterSheet characterSheet = new();
    UpgradesTracker upgradesTracker = new();
    Boolean tapped = false;
    public UpgradesPage()
    {
        InitializeComponent();
    }
    public async void GetPreset()
    {
        if ((App.CharacterSheetRepo != null) && (App.UpgradesTrackerRepository != null))
        {
            characterSheet = await App.CharacterSheetRepo.GetCharacterSheet(App.CharacterSheetRepo.currentSheetId);
            upgradesTracker = await App.UpgradesTrackerRepository.GetUpgradesTracker(App.CharacterSheetRepo.currentSheetId);
        }
        if ((characterSheet != null) && (upgradesTracker != null))
        {
            var tapGestureRecogniser = new TapGestureRecognizer();
            tapGestureRecogniser.Tapped += (s, e) =>
            {
                if (!this.tapped)
                {
                    tapped = true;
                    NewSession();
                }
            };
            Frame.GestureRecognizers.Add(tapGestureRecogniser);

            List<Tuple<String, String, Boolean>> strengthUpgrades = new List<Tuple<String, String, Boolean>> { Tuple.Create("You can use weapon skills", "s1", false), Tuple.Create("1/S\n+1 effect to a Str roll", "s2", false), Tuple.Create("Work with the GM to make a new NPC that's as strong as you", "s3", false), Tuple.Create("1/S\nReroll 1d6 on any roll you make", "s4", false), Tuple.Create("Roll an extra 1d6 on Str rolls", "s5", false), Tuple.Create("Once per Str roll, reroll on of the dice if you want to", "s6", false) };
            GetGrid(strengthGrid, strengthCirclesGrid, characterSheet.Strength, "Strength", strengthUpgrades);

            List<Tuple<String, String, Boolean>> enduranceUpgrades = new List<Tuple<String, String, Boolean>> { Tuple.Create("+1 effect for rolls to resist poison, including alcohol", "e1", false), Tuple.Create("Gain one harm slot", "e2", false), Tuple.Create("End/S\nRoll End + Pow vs 12 to heal one harm. On a fail, it festers", "e3", true), Tuple.Create("Non magical temperature doesn't effect you", "e4", false), Tuple.Create("End/S\nChoose to take harm instead of an ally", "e5", true), Tuple.Create("Gain two harm slots", "e6", false) };
            GetGrid(enduranceGrid, enduranceCirclesGrid, characterSheet.Endurance, "Endurance", enduranceUpgrades);

            List<Tuple<String, String, Boolean>> readyUpgrades = new List<Tuple<String, String, Boolean>> { Tuple.Create("1/S\nRoll 1d6 + Ready vs 7 to get a free roll of any skill", "r1", false), Tuple.Create("1/S\nRoll Ready + Pow vs 9 to avoid harm", "r2", false), Tuple.Create("Gain 6 marks in Prof\nChoose one small item to never run out of, e.g cigarettes", "r3", false), Tuple.Create("Every turn choose to move yourself up or down one in the turn order", "r4", false), Tuple.Create("1/S\nPull something useful for the scenario out of your pocket, within reason", "r5", false), Tuple.Create("Roll 2d6 for initiative rolls and take either", "r6", false) };
            GetGrid(readyGrid, readyCirclesGrid, characterSheet.Ready, "Ready", readyUpgrades);

            List<Tuple<String, String, Boolean>> agilityUpgrades = new List<Tuple<String, String, Boolean>> { Tuple.Create("You can use weapon skills", "a1", false), Tuple.Create("+1 effect for rolls to hide", "a2", false), Tuple.Create("1/S\nFully reroll any roll you just made", "a3", false), Tuple.Create("Gain 6 marks in Cha or Prof\nA side hustle becomes available to you, discuss woth the GM", "a4", false), Tuple.Create("Agi/S\nAny skill roll other than Agi gains effect", "a5", true), Tuple.Create("Once per Agi roll, reroll one of the dice if you want to", "a6", false) };
            GetGrid(agilityGrid, agilityCirclesGrid, characterSheet.Agility, "Agility", agilityUpgrades);

            List<Tuple<String, String, Boolean>> knowledgeUpgrades = new List<Tuple<String, String, Boolean>> { Tuple.Create("1/S\nGet one more mark in any skill after a roll", "k1", false), Tuple.Create("Gain 3 marks in Awa\nIf you don't know something, you know where to look to find out", "k2", false), Tuple.Create("1/S\nGive another player 3 marks in a skill you are better at", "k3", false), Tuple.Create("Gain 6 marks in Cha\nYou can read all languages", "k4", false), Tuple.Create("1/S\nGive another player 6 marks in a skill you are better at", "k5", false), Tuple.Create("1/S\nAsk the GM any question, they must answer honestly", "k6", false) };
            GetGrid(knowledgeGrid, knowledgeCirclesGrid, characterSheet.Knowledge, "Knowledge", knowledgeUpgrades);

            List<Tuple<String, String, Boolean>> proficiencyUpgrades = new List<Tuple<String, String, Boolean>> { Tuple.Create("Every time you roll Prof, roll it again (no marks for the second roll) vs 14 to double your effect", "p1", false), Tuple.Create("1/S\nRolls made with any one weapon have a +1 to hit for the rest of the session", "p2", false), Tuple.Create("1/S\nGive anyone, even yourself, +1 to a PAW stat for the rest of the session", "p3", false), Tuple.Create("Prof/S\nReroll an allies 1d6", "p4", true), Tuple.Create("You invent something that gets the worlds attention, discuss with the GM", "p5", false), Tuple.Create("Every time you take harm, deal one harm in return", "p6", false) };
            GetGrid(proficiencyGrid, proficiencyCirclesGrid, characterSheet.Proficiency, "Proficiency", proficiencyUpgrades);

            List<Tuple<String, String, Boolean>> charismaUpgrades = new List<Tuple<String, String, Boolean>> { Tuple.Create("Gain 3 marks in Prof\n+1 effect to Prof rolls to perform", "c1", false), Tuple.Create("Cha/S\nGive a player +1 to a roll", "c2", true), Tuple.Create("1/S\nGive an ally a free turn", "c3", false), Tuple.Create("A troupe starts to form around you, discuss with the GM", "c4", false), Tuple.Create("1/S\nSubtract two from a target's A/C, permanently", "c5", false), Tuple.Create("1/Campaign\nPersuade someone of anything", "c6", false) };
            GetGrid(charismaGrid, charismaCirclesGrid, characterSheet.Charisma, "Charisma", charismaUpgrades);

            List<Tuple<String, String, Boolean>> awarenessUpgrades = new List<Tuple<String, String, Boolean>> { Tuple.Create("Awa/S\nImmediately detect any enemies within the area", "aw1", true), Tuple.Create("1/S\nGive yourself +1 Acuity or Power for the rest of the session", "aw2", false), Tuple.Create("You can never be blinded, even by magic", "aw3", false), Tuple.Create("1/S\nGive everyone +3 to roll against a target until the start of your next turn", "aw4", false), Tuple.Create("Pick any background, gain +1 to hit vs them, and always know how many are in your area", "aw5", false), Tuple.Create("Awa/S\nRoll Awa + Will vs A/C, if you succeed, they lose 2 A/C for the rest of the session", "aw6", true) };
            GetGrid(awarenessGrid, awarenessCirclesGrid, characterSheet.Awareness, "Awareness", awarenessUpgrades);

            List<Tuple<String, String, Boolean>> destructionUpgrades = new List<Tuple<String, String, Boolean>> { Tuple.Create("1/S\n+1 to a Dest roll", "d1", false), Tuple.Create("1/S\nChoose a weapon that does one harm, it now does two for the rest of the session", "d2", false), Tuple.Create("Your attacks can target 2 enemies, roll against the highest A/C", "d3", false), Tuple.Create("Gain 6 marks in Cha\nSome part of your body is altered by the Dest magic", "d4", false), Tuple.Create("Your attacks can target up to 4 enemies, roll against the highest A/C", "d5", false), Tuple.Create("Gain 12 marks in Know\nEach life to take heals you for 2 harm", "d6", false) };
            GetGrid(destructionGrid, destructionCirclesGrid, characterSheet.Destruction, "Destruction", destructionUpgrades);

            List<Tuple<String, String, Boolean>> transmutationUpgrades = new List<Tuple<String, String, Boolean>> { Tuple.Create("1/S\nGive an ally +1 on a Str, Agi or Cha roll", "t1", false), Tuple.Create("Tran/S\nReduce the negative effect of anyone's roll by 1", "t2", true), Tuple.Create("1/S\nRoll Tran, but cast a Dest or Rest spell", "t3", false), Tuple.Create("Long range doesn't effect your Tran rolls", "t4", false), Tuple.Create("You get wings, or another suitable mutation", "t5", false), Tuple.Create("Put two PAW points anywhere", "t6", false) };
            GetGrid(transmutationGrid, transmutationCirclesGrid, characterSheet.Transmutation, "Transmutation", transmutationUpgrades);

            List<Tuple<String, String, Boolean>> restorationUpgrades = new List<Tuple<String, String, Boolean>> { Tuple.Create("1/S\nReduce how much harm an ally takes by Rest", "re1", false), Tuple.Create("Gain 3 marks in End\nYou no longer age", "re2", false), Tuple.Create("Your spells now heal your Rest in harm", "re3", false), Tuple.Create("Gain 6 marks in Str or Know\nA church is built in your honour", "re4", false), Tuple.Create("You regain 1 harm at the end of every turn", "re5", false), Tuple.Create("If you die, you reform in 24 hours, unless something happens, discuss that something with the GM", "re6", false) };
            GetGrid(restorationGrid, restorationCirclesGrid, characterSheet.Restoration, "Restoration", restorationUpgrades);

            destMain.SetValue(IsVisibleProperty, false);
            destructionGrid.SetValue(IsVisibleProperty, false);
            transMain.SetValue(IsVisibleProperty, false);
            transmutationGrid.SetValue(IsVisibleProperty, false);
            restMain.SetValue(IsVisibleProperty, false);
            restorationGrid.SetValue(IsVisibleProperty, false);

            if (characterSheet.PrimaryDiscipline != null)
            {
                if (characterSheet.CharacterClass != null)
                {
                    if (characterSheet.CharacterClass.Equals("Spellweaver") || characterSheet.CharacterClass.Equals("Spellsword"))
                    {
                        if (characterSheet.PrimaryDiscipline.Equals("Destruction"))
                        {
                            destMain.SetValue(IsVisibleProperty, true);
                            destructionGrid.SetValue(IsVisibleProperty, true);
                        }
                        else if (characterSheet.PrimaryDiscipline.Equals("Transmutation"))
                        {
                            transMain.SetValue(IsVisibleProperty, true);
                            transmutationGrid.SetValue(IsVisibleProperty, true);
                        }
                        else if (characterSheet.PrimaryDiscipline.Equals("Restoration"))
                        {
                            restMain.SetValue(IsVisibleProperty, true);
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
                            destMain.SetValue(IsVisibleProperty, true);
                            destructionGrid.SetValue(IsVisibleProperty, true);
                        }
                        else if (characterSheet.SecondaryDiscipline.Equals("Transmutation"))
                        {
                            transMain.SetValue(IsVisibleProperty, true);
                            transmutationGrid.SetValue(IsVisibleProperty, true);
                        }
                        else if (characterSheet.SecondaryDiscipline.Equals("Restoration"))
                        {
                            restMain.SetValue(IsVisibleProperty, true);
                            restorationGrid.SetValue(IsVisibleProperty, true);
                        }
                    }
                }
            }
        } else
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
        GetPreset();
    }
    public async void GetGrid(Grid grid, Grid circlesGrid, int stat, string statName, List<Tuple<String, String, Boolean>> upgradeInfos)
    {
        grid.Clear();
        circlesGrid.Clear();
        int[] pointMarks = new int[] { 6, 18, 36, 60, 90, 126 };
        String[] sessionlyUpgrades = { "s2", "s4", "e3", "e5", "r1", "r2", "r5", "a3", "a5", "k1", "k3", "k5", "k6", "p2", "p3", "p4", "c2", "c3", "c5", "aw1", "aw2", "aw4", "aw6", "d1", "d2", "t1", "t2", "t3", "re1" };
        List<ImageButton> result = new();
        System.Reflection.PropertyInfo prop;
        int remainingUses = 0;
        int maxUses = 0;
        int trueStat = GetTrueStat(stat, statName);

        for (int i = 0; i < pointMarks.Length; i++)
        {
            if (trueStat >= pointMarks[i])
            {
                circlesGrid.AddColumnDefinition(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                Image circle = new() { Source = "harmcirclefilled.png" };
                circlesGrid.Add(circle, i);
            }
        }

        int row;
        int column;
        for (int i = 0; i < upgradeInfos.Count; i++)
        {
            row = (i / 2);

            if (i % 2 > 0)
            {
                column = 1;
            }
            else
            {
                column = 0;
            }
            Image baseBG = new Image { Source = "lockedcolour.png" };
            baseBG.HorizontalOptions = LayoutOptions.Fill;
            baseBG.VerticalOptions = LayoutOptions.Fill;
            baseBG.Aspect = Aspect.AspectFill;
            if (trueStat >= pointMarks[i])
            {
                baseBG.Source = "unlockedcolour.png";
            }
            grid.Add(baseBG, column, row);
            Label index = new Label { TextColor = Color.FromArgb("331940"), Text = (i + 1).ToString(), Margin = 5, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Start };
            grid.Add(index, column, row);
            Label description = new Label { TextColor = Color.FromArgb("331940"), Text = upgradeInfos[i].Item1, Margin = new Thickness(10, 0, 10, 0), HorizontalTextAlignment = TextAlignment.Center, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
            grid.Add(description, column, row);
            for (int b = 0; b < sessionlyUpgrades.Count(); b++)
            {
                if (upgradeInfos[i].Item2.Equals(sessionlyUpgrades[b]))
                {
                    prop = typeof(UpgradesTracker).GetProperty(upgradeInfos[i].Item2);
                    remainingUses = (int)prop.GetValue(upgradesTracker);
                    maxUses = 1;
                    if ((remainingUses != -1) && (trueStat < pointMarks[i]))
                    {
                        prop.SetValue(upgradesTracker, -1);
                        await App.UpgradesTrackerRepository.UpdateUpgradesTracker(upgradesTracker);
                    }
                    if (upgradeInfos[i].Item3)
                    {
                        maxUses = 0;
                        for (int c = 0; c < pointMarks.Length; c++)
                        {
                            if (trueStat >= pointMarks[c])
                            {
                                maxUses++;
                            }
                        }
                    }
                    if ((remainingUses == -1) && (trueStat >= pointMarks[i]))
                    {
                        remainingUses = maxUses;
                        prop.SetValue(upgradesTracker, maxUses);
                        await App.UpgradesTrackerRepository.UpdateUpgradesTracker(upgradesTracker);
                    }
                    Label max = new Label { TextColor = Color.FromArgb("331940"), Text = maxUses.ToString(), Margin = 5, HorizontalOptions = LayoutOptions.End, VerticalOptions = LayoutOptions.Start };
                    grid.Add(max, column, row);
                    if (remainingUses > 0)
                    {
                        var tapGestureRecogniser = new TapGestureRecognizer();
                        description.BindingContext = upgradeInfos[i].Item2;
                        tapGestureRecogniser.Tapped += async (s, e) =>
                        {
                            System.Reflection.PropertyInfo prop2 = typeof(UpgradesTracker).GetProperty(((Label)s).BindingContext as String);
                            prop2.SetValue(upgradesTracker, (int)prop2.GetValue(upgradesTracker) - 1);
                            await App.UpgradesTrackerRepository.UpdateUpgradesTracker(upgradesTracker);
                            GetPreset();
                        };
                        description.GestureRecognizers.Add(tapGestureRecogniser);
                        grid.Remove(description);
                        grid.Add(description, column, row);
                    }

                    if (trueStat >= pointMarks[i])
                    {
                        Grid usesGrid = new Grid
                        {
                            RowDefinitions =
                        {
                            new RowDefinition(),
                        },
                            ColumnDefinitions =
                        {
                            new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) }
                        }
                        };
                        for (int a = 1; a < maxUses; a++)
                        {
                            usesGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
                        }
                        baseBG.Source = "lockedcolour.png";
                        Image bg = new Image { Source = "unlockedcolour.png" };
                        bg.HorizontalOptions = LayoutOptions.Fill;
                        bg.VerticalOptions = LayoutOptions.Fill;
                        bg.Aspect = Aspect.AspectFill;
                        usesGrid.Add(bg, 0, 0);
                        if (remainingUses > 0)
                        {
                            usesGrid.SetColumnSpan(bg, remainingUses);
                            grid.Add(usesGrid, column, row);
                        }
                        grid.Remove(max);
                        grid.Remove(index);
                        grid.Remove(description);
                        grid.Add(max, column, row);
                        grid.Add(index, column, row);
                        grid.Add(description, column, row);
                    }
                    else
                    {
                        prop.SetValue(upgradesTracker, -1);
                        await App.UpgradesTrackerRepository.UpdateUpgradesTracker(upgradesTracker);
                    }

                }
            }
        }
    }
    private int GetTrueStat(int trueStat, string statName)
    {
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
        return trueStat;
    }

    public async void NewSession()
    {
        int trueStat;
        System.Reflection.PropertyInfo prop;
        System.Reflection.PropertyInfo prop2;
        int stat;
        int[] pointMarks = new int[] { 6, 18, 36, 60, 90, 126 };
        List<Tuple<String, Boolean, String>> sessionlyUpgrades = new List<Tuple<String, Boolean, String>> { Tuple.Create("s2", false, "Strength"), Tuple.Create("s4", false, "Strength"), Tuple.Create("e3", true, "Endurance"), Tuple.Create("e5", true, "Endurance"), Tuple.Create("r1", false, "Ready"), Tuple.Create("r2", false, "Ready"), Tuple.Create("r5", false, "Ready"), Tuple.Create("a3", false, "Agility"), Tuple.Create("a5", true, "Agility"), Tuple.Create("k1", false, "Knowledge"), Tuple.Create("k3", false, "Knowledge"), Tuple.Create("k5", false, "Knowledge"), Tuple.Create("k6", false, "Knowledge"), Tuple.Create("p2", false, "Proficiency"), Tuple.Create("p3", false, "Proficiency"), Tuple.Create("p4", true, "Proficiency"), Tuple.Create("c2", true, "Charisma"), Tuple.Create("c3", false, "Charisma"), Tuple.Create("c5", false, "Charisma"), Tuple.Create("aw1", true, "Awareness"), Tuple.Create("aw2", false, "Awareness"), Tuple.Create("aw4", false, "Awareness"), Tuple.Create("aw6", true, "Awareness"), Tuple.Create("d1", false, "Destruction"), Tuple.Create("d2", false, "Destruction"), Tuple.Create("t1", false, "Transmutation"), Tuple.Create("t2", true, "Transmutation"), Tuple.Create("t3", false, "Transmutation"), Tuple.Create("re1", false, "Restoration")};
        foreach (Tuple<String, Boolean, String> s in sessionlyUpgrades)
        {
            prop = typeof(CharacterSheet).GetProperty(s.Item3);
            stat = (int)prop.GetValue(characterSheet);
            trueStat = GetTrueStat(stat, s.Item3);
            int count = 0;
            for (int i = 0; i < pointMarks.Length; i++)
            {
                if (trueStat >= pointMarks[i])
                {
                    count++;
                    prop2 = typeof(UpgradesTracker).GetProperty(s.Item1);
                    if (s.Item2)
                    {
                        prop2.SetValue(upgradesTracker, count);
                    } else
                    {
                        prop2.SetValue(upgradesTracker, 1);
                    }
                }
            }
        }
        await App.UpgradesTrackerRepository.UpdateUpgradesTracker(upgradesTracker);
        tapped = false;
        GetPreset();
    }
}