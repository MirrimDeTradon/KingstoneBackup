using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using KingstoneProject.Models;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace KingstoneProject
{
    public class CharacterSheetRepository
    {
        string _dbPath;
        private SQLiteAsyncConnection conn;
        private SQLiteConnection conn2;
        public string StatusMessage { get; set; }
        public int currentSheetId { get; set; }
        private async Task Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteAsyncConnection(_dbPath);

            await conn.CreateTableAsync<CharacterSheet>();
        }
        private void Init2()
        {
            if (conn2 != null)
                return;

            conn2 = new SQLiteConnection(_dbPath);

            conn2.CreateTable<CharacterSheet>();
        }

        public CharacterSheetRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddNewCharacterSheet(string name, string background, string player, string characterClass, string foibles, string distinction, string primaryDiscipline, string secondaryDiscipline, int harmTaken, int harmFestered, string leftHandName, string leftHandImage, string rightHandName, string rightHandImage, string specials, string characterImage, string paw, int strength, int endurance, int ready, int agility, int knowledge, int proficiency, int charisma, int awareness, int destruction, int transmutation, int restoration)
        {
            int result = 0;
            try
            {
                Init2();

                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                result = conn2.Insert(new CharacterSheet { Name = name, Background = background, Player = player, CharacterClass = characterClass, Foibles = foibles, Distinction = distinction, PrimaryDiscipline = primaryDiscipline, SecondaryDiscipline = secondaryDiscipline, HarmTaken = harmTaken, HarmFestered = harmFestered, LeftHandName = leftHandName, LeftHandImage = leftHandImage, RightHandImage = rightHandImage, RightHandName = rightHandName, Specials = specials, CharacterImage = "sheetspagefavicon.png", Paw = paw, Strength = strength, Endurance = endurance, Ready = ready, Agility = agility, Knowledge = knowledge, Proficiency = proficiency, Charisma = charisma, Awareness = awareness, Destruction = destruction, Transmutation = transmutation, Restoration = restoration});

                SQLiteCommand cmd = conn2.CreateCommand("select last_insert_rowid()");

                Int64 LastRowID64 = cmd.ExecuteScalar<Int64>();

                int LastRowID = (int)LastRowID64;

                App.UpgradesTrackerRepository.AddNewUpgradesTracker(LastRowID, conn2);

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }

        }

        public async Task<ObservableCollection<CharacterSheet>> GetAllCharacterSheets()
        {
            try
            {
                await Init();
                ObservableCollection<CharacterSheet> result = new ObservableCollection<CharacterSheet>(await conn.Table<CharacterSheet>().ToListAsync());
                return result;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new ObservableCollection<CharacterSheet>();
        }

        public async Task<CharacterSheet> GetCharacterSheet(int id)
        {
            try
            {
                await Init();
                return await conn.Table<CharacterSheet>().Where(v => v.Id.Equals(id)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new CharacterSheet();
        }

        public async Task RemoveCharacterSheet(CharacterSheet charactersheet)
        {
            try
            {
                await Init();
                await conn.DeleteAsync(charactersheet);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to find {0}. Error: {1}", charactersheet.Name, ex.Message);
            }
        }

        public async Task UpdateCharacterSheet(CharacterSheet charactersheet)
        {
            int result = 0;
            try
            {
                await Init();

                result = await conn.UpdateAsync(charactersheet);
                
                StatusMessage = string.Format("{0} record(s) updated (Name: {1})", result, charactersheet.Name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to update {0}. Error: {1}", charactersheet.Name, ex.Message);
            }
        }
    }
}
