using Entregable.Model;
using Entregable.ViewModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entregable.Bd
{
    public class DataBase
    {

        readonly SQLiteAsyncConnection _database;

        public DataBase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<UserModel>().Wait();
            _database.CreateTableAsync<ServicioModel>().Wait();
            _database.CreateTableAsync<RepuestoModel>().Wait();
        }

        #region Crud

        public Task<int> SaveUserModel(UserModel _usermodel)
        {
            return _database.InsertAsync(_usermodel);
        }

        public Task<UserModel> GetUsermodel(string usr , string pass)
        {
            return _database.Table<UserModel>().Where(x=> x.Usuario  == usr && x.Contra  == pass).FirstOrDefaultAsync();
        }

        public Task<int> SaveModelAsync<T>(T model, bool isInsert) where T : new()
        {
            if(isInsert != true)
            {
                return _database.UpdateAsync(model);
            }
            else
            {
                return _database.InsertAsync(model);
            }
          
        }

        public Task<List<T>> GetModel<T>() where T : new()
        {
            return _database.Table<T>().ToListAsync();

        }

        public Task<List<UserModel>> QueryUserModel(string query)
        {
            return _database.QueryAsync<UserModel>(query);
        }


        #endregion

    }
}
