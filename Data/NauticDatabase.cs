using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParcNautic.Models;
using System.Collections;

namespace ParcNautic.Data
{
    public class NauticPlanDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public NauticPlanDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<NauticPlan>().Wait();
            _database.CreateTableAsync<NauticZq>().Wait();

        }
        public Task<List<NauticPlan>> GetNauticPlanAsync()
        {
            return _database.Table<NauticPlan>().ToListAsync();
        }
        public Task<NauticPlan> GetNauticPlanAsync(int id)
        {
            return _database.Table<NauticPlan>()
            .Where(i => i.Id == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveNauticPlanAsync(NauticPlan slist)
        {
            if (slist.Id != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteNauticPlanAsync(NauticPlan slist)
        {
            return _database.DeleteAsync(slist);
        }
       

        public Task<List<NauticZq>> GetNauticZqsAsync()
        {
            return _database.Table<NauticZq>().ToListAsync();
        }
        public Task<int> SaveNauticZqAsync(NauticZq NauticZq)
        {
            if (NauticZq.Id != 0)
            {
                return _database.UpdateAsync(NauticZq);
            }
            else
            {
                return _database.InsertAsync(NauticZq);
            }
        }
        public Task DeleteNauticZqAsync(NauticZq NauticZq)
        {
            return _database.DeleteAsync(NauticZq);
        }



    }
}

    

