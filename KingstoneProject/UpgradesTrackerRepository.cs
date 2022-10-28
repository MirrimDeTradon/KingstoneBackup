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
    public class UpgradesTrackerRepository
    {
        string _dbPath;
        private SQLiteAsyncConnection conn;
        public string StatusMessage { get; set; }
        public int currentSheetId { get; set; }
        private async Task Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteAsyncConnection(_dbPath);

            await conn.CreateTableAsync<UpgradesTracker>();
        }

        public UpgradesTrackerRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddNewUpgradesTracker(int characterId, SQLiteConnection conn2)
        {
            int result = 0;
            try
            {

                result = conn2.Insert(new UpgradesTracker {CharacterId = characterId, s2 = -1, s4 = -1, e3 = -1, e5 = -1, a3 = -1, a5 = -1, aw1 = -1, aw2 = -1, aw4 = -1, aw6 = -1, c2 = -1, c3 = -1, c5 = -1, d1 = -1, d2 = -1, k1 = -1, k3 = -1, k5 = -1, k6 = -1, p2 = -1, p3 = -1, p4 = -1, r1 = -1, r2 = -1, r5 = -1, re1 = -1, t1 = -1, t2 = -1, t3 = -1});


            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add. {0}", ex.Message);
            }

        }

        public async Task<UpgradesTracker> GetUpgradesTracker(int id)
        {
            try
            {
                await Init();
                return await conn.Table<UpgradesTracker>().Where(v => v.CharacterId.Equals(id)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new UpgradesTracker();
        }

        public async Task RemoveUpgradesTracker(UpgradesTracker upgradestracker)
        {
            try
            {
                await Init();
                await conn.DeleteAsync(upgradestracker);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to find. {0}", ex.Message);
            }
        }

        public async Task UpdateUpgradesTracker(UpgradesTracker upgradestracker)
        {
            int result = 0;
            try
            {
                await Init();

                result = await conn.UpdateAsync(upgradestracker);

            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to update. {0}", ex.Message);
            }
        }
    }
}
