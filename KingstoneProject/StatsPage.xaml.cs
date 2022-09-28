using Javax.Net.Ssl;
using KingstoneProject.Models;
using Microsoft.Maui.Controls;


namespace KingstoneProject;

public partial class StatsPage : ContentPage
{
    CharacterSheet characterSheet = new();
    public StatsPage()
    {
        InitializeComponent();
        getPreset();
    }
    public async void getPreset()
    {
        characterSheet = await App.CharacterSheetRepo.GetCharacterSheet(App.CharacterSheetRepo.currentSheetId);
        if(characterSheet.Paw != null)
        {
            Power.Text = characterSheet.Paw.Substring(0, 1);
            Acuity.Text = characterSheet.Paw.Substring(2, 1);
            Will.Text = characterSheet.Paw.Substring(4, 1);

            if (characterSheet.Background != null)
            {
                if(characterSheet.Background.Equals("Nature's Keepers")){
                    Acuity.Text = (int.Parse(characterSheet.Paw.Substring(2, 1)) + 1).ToString();
                } 
                else if(characterSheet.Background.Equals("the Awoken"))
                {
                    Power.Text = (int.Parse(characterSheet.Paw.Substring(0, 1)) + 1).ToString();
                } 
                else if (characterSheet.Background.Equals("Worldbearers"))
                {
                    Will.Text = (int.Parse(characterSheet.Paw.Substring(4, 1)) + 1).ToString();
                }
            }
            if (characterSheet.SubBackground != null)
            {
                if (characterSheet.SubBackground.Equals("Skill at Crafting") || characterSheet.SubBackground.Equals("Greed") || characterSheet.SubBackground.Equals("Adroit"))
                {
                    Acuity.Text = (int.Parse(characterSheet.Paw.Substring(2, 1)) + 1).ToString();
                }
                else if (characterSheet.SubBackground.Equals("Warrior's Resilience") || characterSheet.SubBackground.Equals("Anger") || characterSheet.SubBackground.Equals("Force"))
                {
                    Power.Text = (int.Parse(characterSheet.Paw.Substring(0, 1)) + 1).ToString();
                }
                else if (characterSheet.SubBackground.Equals("Character Strength") || characterSheet.SubBackground.Equals("Mania") || characterSheet.SubBackground.Equals("Guile"))
                {
                    Will.Text = (int.Parse(characterSheet.Paw.Substring(4, 1)) + 1).ToString();
                }
            }
        } else
        {
            Power.Text = "0";
            Acuity.Text = "0";
            Will.Text = "0";
        }
        strengthGrid.Clear();
        List<ImageButton> strengthButtons = getStat(strengthGrid, characterSheet.Strength, "Strength");
        strengthButtons.ForEach(delegate (ImageButton imageButton) {
            imageButton.Clicked += OnSkillClicked;
            imageButton.BindingContext = "Strength";
        });
        enduranceGrid.Clear();
        List<ImageButton> enduranceButtons = getStat(enduranceGrid, characterSheet.Endurance, "Endurance");
        enduranceButtons.ForEach(delegate (ImageButton imageButton) {
            imageButton.Clicked += OnSkillClicked;
            imageButton.BindingContext = "Endurance";
        });
        readyGrid.Clear();
        List<ImageButton> readyButtons = getStat(readyGrid, characterSheet.Ready, "Ready");
        readyButtons.ForEach(delegate (ImageButton imageButton) {
            imageButton.Clicked += OnSkillClicked;
            imageButton.BindingContext = "Ready";
        });
        agilityGrid.Clear();
        List<ImageButton> agilityButtons = getStat(agilityGrid, characterSheet.Agility, "Agility");
        agilityButtons.ForEach(delegate (ImageButton imageButton) {
            imageButton.Clicked += OnSkillClicked;
            imageButton.BindingContext = "Agility";
        });
        knowledgeGrid.Clear();
        List<ImageButton> knowledgeButtons = getStat(knowledgeGrid, characterSheet.Knowledge, "Knowledge");
        knowledgeButtons.ForEach(delegate (ImageButton imageButton) {
            imageButton.Clicked += OnSkillClicked;
            imageButton.BindingContext = "Knowledge";
        });
        proficiencyGrid.Clear();
        List<ImageButton> proficiencyButtons = getStat(proficiencyGrid, characterSheet.Proficiency, "Proficiency");
        proficiencyButtons.ForEach(delegate (ImageButton imageButton) {
            imageButton.Clicked += OnSkillClicked;
            imageButton.BindingContext = "Proficiency";
        });
        charismaGrid.Clear();
        List<ImageButton> charismaButtons = getStat(charismaGrid, characterSheet.Charisma, "Charisma");
        charismaButtons.ForEach(delegate (ImageButton imageButton) {
            imageButton.Clicked += OnSkillClicked;
            imageButton.BindingContext = "Charisma";
        });
        awarenessGrid.Clear();
        List<ImageButton> awarenessButtons = getStat(awarenessGrid, characterSheet.Awareness, "Awareness");
        awarenessButtons.ForEach(delegate (ImageButton imageButton) {
            imageButton.Clicked += OnSkillClicked;
            imageButton.BindingContext = "Awareness";
        });
        destructionGrid.Clear();
        List<ImageButton> destructionButtons = getStat(destructionGrid, characterSheet.Destruction, "Destruction");
        destructionButtons.ForEach(delegate (ImageButton imageButton) {
            imageButton.Clicked += OnSkillClicked;
            imageButton.BindingContext = "Destruction";
        });
        transmutationGrid.Clear();
        List<ImageButton> transmutationButtons = getStat(transmutationGrid, characterSheet.Transmutation, "Transmutation");
        transmutationButtons.ForEach(delegate (ImageButton imageButton) {
            imageButton.Clicked += OnSkillClicked;
            imageButton.BindingContext = "Transmutation";
        });
        restorationGrid.Clear();
        List<ImageButton> restorationButtons = getStat(restorationGrid, characterSheet.Restoration, "Restoration");
        restorationButtons.ForEach(delegate (ImageButton imageButton) {
            imageButton.Clicked += OnSkillClicked;
            imageButton.BindingContext = "Restoration";
        });
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
    public List<ImageButton> getStat(Grid grid, int stat, string statName)
    {
        int[] pointMarks = new int[] {6, 18, 36, 60, 90, 126};
        List<ImageButton> result = new();

        int trueStat = stat;

        if (characterSheet.Background != null)
        {
            if (characterSheet.Background.Equals("the Edified") & statName.Equals("Strength"))
            {
                trueStat += 6;
            }
            else if (characterSheet.Background.Equals("the Awoken"))
            {
                Power.Text = (int.Parse(characterSheet.Paw.Substring(0, 1)) + 1).ToString();
            }
            else if (characterSheet.Background.Equals("Worldbearers"))
            {
                Will.Text = (int.Parse(characterSheet.Paw.Substring(4, 1)) + 1).ToString();
            }
        }
        if (characterSheet.SubBackground != null)
        {
            if (characterSheet.SubBackground.Equals("Skill at Crafting") || characterSheet.SubBackground.Equals("Greed") || characterSheet.SubBackground.Equals("Adroit"))
            {
                Acuity.Text = (int.Parse(characterSheet.Paw.Substring(2, 1)) + 1).ToString();
            }
            else if (characterSheet.SubBackground.Equals("Warrior's Resilience") || characterSheet.SubBackground.Equals("Anger") || characterSheet.SubBackground.Equals("Force"))
            {
                Power.Text = (int.Parse(characterSheet.Paw.Substring(0, 1)) + 1).ToString();
            }
            else if (characterSheet.SubBackground.Equals("Character Strength") || characterSheet.SubBackground.Equals("Mania") || characterSheet.SubBackground.Equals("Guile"))
            {
                Will.Text = (int.Parse(characterSheet.Paw.Substring(4, 1)) + 1).ToString();
            }
        }

        for (int i = 0; i < pointMarks.Length; i++)
        {
            if(trueStat >= pointMarks[i])
            {
                ImageButton imageButton = new ImageButton();
                imageButton.Source = "harmcirclefilled";
                result.Add(imageButton);
                grid.Add(imageButton, i, 0);
            } else
            {
                ImageButton imageButton = new ImageButton();
                imageButton.Source = "harmcircle";
                result.Add(imageButton);
                grid.Add(imageButton, i, 0);
            }
        }
        trueStat = 0;
        return result;
    }
    private async void OnSkillClicked(object sender, EventArgs e)
    {
        int[] pointMarks = new int[] { 6, 18, 36, 60, 90, 126 };
        int skill = 0;
        string thisSkill = "";
        string thisPAW = "";
        string thisPAWName = "";
        System.Reflection.PropertyInfo prop;
        int skillValue;
        if (sender.GetType().Name.Equals("ImageButton"))
        {
            thisSkill = ((ImageButton)sender).BindingContext as String;
        } else
        {
            thisSkill = ((Label)sender).BindingContext as String;
        }

        if (characterSheet.Paw != null)
        {
            if (thisSkill.Equals("Strength") || thisSkill.Equals("Endurance") || thisSkill.Equals("Ready"))
            {
                thisPAW = characterSheet.Paw.Substring(0, 1);
                thisPAWName = "Power";
            }
            else if (thisSkill.Equals("Agility") || thisSkill.Equals("Knowledge") || thisSkill.Equals("Proficiency"))
            {
                thisPAW = characterSheet.Paw.Substring(2, 1);
                thisPAWName = "Acuity";
            }
            else if (thisSkill.Equals("Charisma") || thisSkill.Equals("Awareness") || thisSkill.Equals("Destruction") || thisSkill.Equals("Transmutation") || thisSkill.Equals("Restoration"))
            {
                thisPAW = characterSheet.Paw.Substring(4, 1);
                thisPAWName = "Will";
            }


            prop = typeof(CharacterSheet).GetProperty(thisSkill);
            skillValue = (int)prop.GetValue(characterSheet);
            //Someone told me C# was far too strongly-typed. After a little reflection, I decided it wasn't all that bad.

            for (int i = 0; i < pointMarks.Length; i++)
            {
                if (skillValue >= pointMarks[i])
                {
                    skill++;
                }
                else { break; }
            }
            string question = "Your " + thisPAWName + " is " + thisPAW + ", your " + thisSkill + " is " + skill.ToString() + ".\n\n    What's the DC?";
            string DC = await DisplayPromptAsync(thisSkill + " Roll", question, initialValue: "10", maxLength: 2, keyboard: Keyboard.Numeric);
            if(DC != null)
            {
                Random random = new Random();
                int result = random.Next(1, 7) + random.Next(1, 7);
                int total = result + int.Parse(thisPAW) + skill;
                if(total >= int.Parse(DC))
                {
                    int difference = total - int.Parse(DC);
                    int degrees = 0;
                    if (difference % 2 == 0)
                    {
                        degrees = (difference + 2) / 2;
                    } else
                    {
                        degrees = (difference + 1) / 2;
                    }
                    string alert;
                    int bonuses = int.Parse(thisPAW) + skill;
                        
                    if (degrees > 1)
                    {
                        alert = "Against a DC of " + DC + " you rolled " + result + " + " + bonuses + " for a total of " + total + ".\n\nYou succeeded with " + degrees + " Degrees of Success.";
                    } else
                    {
                        alert = "Against a DC of " + DC + " you rolled " + result + " + " + bonuses + " for a total of " + total + ".\n\nYou succeeded with " + degrees + " Degree of Success.";
                    }
                    await DisplayAlert("Success!", alert, "OK");
                }
                else
                {
                    int difference = int.Parse(DC) - total;
                    int degrees = 0;
                    if (difference % 2 == 0)
                    {
                        degrees = (difference + 2) / 2;
                    }
                    else
                    {
                        degrees = (difference + 1) / 2;
                    }
                    string alert;
                    int bonuses = int.Parse(thisPAW) + skill;

                    if (degrees > 1)
                    {
                        alert = "Against a DC of " + DC + " you rolled " + result + " + " + bonuses + " for a total of " + total + ".\n\nYou failed with " + degrees + " Degrees of Failure.";
                    }
                    else
                    {
                        alert = "Against a DC of " + DC + " you rolled " + result + " + " + bonuses + " for a total of " + total + ".\n\nYou failed with " + degrees + " Degree of Failure.";
                    }
                    await DisplayAlert("Failure.", alert, "OK");
                }
                if(characterSheet.CharacterClass != null)
                {
                    if(characterSheet.Distinction != null)
                    {
                        if(characterSheet.CharacterClass.Equals("Expert") & characterSheet.Distinction.Equals(thisSkill))
                        {
                            prop.SetValue(characterSheet, skillValue + 4);
                        }
                        else
                        {
                            prop.SetValue(characterSheet, skillValue + 2);
                        }
                    } else if (characterSheet.SecondaryDiscipline != null)
                    {
                        if (characterSheet.CharacterClass.Equals("Spellweaver") & characterSheet.SecondaryDiscipline.Equals(thisSkill))
                        {
                            prop.SetValue(characterSheet, skillValue + 1);
                        }
                        else
                        {
                            prop.SetValue(characterSheet, skillValue + 2);
                        }
                    } else
                    {
                        prop.SetValue(characterSheet, skillValue + 2);
                    }
                } else
                {
                    prop.SetValue(characterSheet, skillValue + 2);
                }

                await App.CharacterSheetRepo.UpdateCharacterSheet(characterSheet);
                getPreset();
            }
        } else
        {
            await DisplayAlert("No PAW Detected", "Go set your PAW on the Character Page!", "Sorry, my bad.");
        }
    }
}