using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BavuaDAL;
namespace BavuaBL
{
    public class SaveGameBL
    {
        DBConnection dbCon;
        public SaveGameBL()
        {
            dbCon = new DBConnection();
        }
        //get
        public List<Save_games> GetSaveGames()
        {
            return dbCon.GetDbSet<Save_games>().ToList();
        }
        //add
        public void AddSaveGame(Save_games saveGame)
        {
            dbCon.Execute(saveGame, DBConnection.ExecuteAction.Insert);
        }
        //update
        public void UpdateSaveGame(Save_games saveGame)
        {
            dbCon.Execute(saveGame, DBConnection.ExecuteAction.Update);
        }
        //delete
        public void DeleteSaveGame(Save_games saveGame)
        {
            dbCon.Execute(saveGame, DBConnection.ExecuteAction.Delete);
        }

    }
}
