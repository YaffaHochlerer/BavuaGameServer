using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BavuaDAL;
namespace BavuaBL
{
    public class CashInGameBL
    {

        DBConnection dbCon;
        public CashInGameBL()
        {
            dbCon = new DBConnection();
        }
        //get
        public List<Cashes_in_game> GetCashesInGame()
        {
            return dbCon.GetDbSet<Cashes_in_game>().ToList();
        }
        //add
        public void AddCashInGame(Cashes_in_game cashInGame)
        {
            dbCon.Execute(cashInGame, DBConnection.ExecuteAction.Insert);
        }
        //update
        public void UpdateCashInGame(Cashes_in_game cashInGame)
        {
            dbCon.Execute(cashInGame, DBConnection.ExecuteAction.Update);
        }
        //delete
        public void DeleteCashInGame(Cashes_in_game cashInGame)
        {
            dbCon.Execute(cashInGame, DBConnection.ExecuteAction.Delete);
        }
    }
}
