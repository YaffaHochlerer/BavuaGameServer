using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BavuaDAL;
namespace BavuaBL
{
    public class GameBordBL
    {
        DBConnection dbCon;
        public GameBordBL()
        {
            dbCon = new DBConnection();
        }
        //get
        public List<Game_board> GetGameBords()
        {
            return dbCon.GetDbSet<Game_board>().ToList();
        }
        //add
        public void AddGameBord(Game_board board)
        {
            dbCon.Execute(board, DBConnection.ExecuteAction.Insert);
        }
        //update
        public void UpdateGameBord(Game_board board)
        {
            dbCon.Execute(board, DBConnection.ExecuteAction.Update);
        }
        //delete
        public void DeleteGameBord(Game_board board)
        {
            dbCon.Execute(board, DBConnection.ExecuteAction.Delete);
        }

        public int EmptyPlace(Game_board board)
        {
            return (board.game_board_value_location0 == 0) ? 0 :
                   (board.game_board_value_location1 == 0) ? 1 :
                   (board.game_board_value_location2 == 0) ? 2 :
                   (board.game_board_value_location3 == 0) ? 3 :
                   (board.game_board_value_location4 == 0) ? 4 :
                   (board.game_board_value_location5 == 0) ? 5 :
                   (board.game_board_value_location6 == 0) ? 6 :
                   (board.game_board_value_location7 == 0) ? 7 : 8;

        }
        //פעולה שמחזירה את הלוח במחרוזת ללא המקום הריק, למחשב ולשחקן
        public string oppositBoardToString(int playerOrComp,Game_board board)
        {
            string s0, s1, s2, s3, s4, s5, s6, s7, s8 ,theString;
            if(playerOrComp==1)
            {
                s0 = (board.game_board_value_location0 == 1) ? "1" : "0";
                s1 = (board.game_board_value_location1 == 1) ? "1" : "0";
                s2 = (board.game_board_value_location2 == 1) ? "1" : "0";
                s3 = (board.game_board_value_location3 == 1) ? "1" : "0";
                s4 = (board.game_board_value_location4 == 1) ? "1" : "0";
                s5 = (board.game_board_value_location5 == 1) ? "1" : "0";
                s6 = (board.game_board_value_location6 == 1) ? "1" : "0";
                s7 = (board.game_board_value_location7 == 1) ? "1" : "0";
                s8 = (board.game_board_value_location8 == 1) ? "1" : "0";
            }
            else
            {
                s0 = (board.game_board_value_location0 == 2) ? "1" : "0";
                s1 = (board.game_board_value_location1 == 2) ? "1" : "0";
                s2 = (board.game_board_value_location2 == 2) ? "1" : "0";
                s3 = (board.game_board_value_location3 == 2) ? "1" : "0";
                s4 = (board.game_board_value_location4 == 2) ? "1" : "0";
                s5 = (board.game_board_value_location5 == 2) ? "1" : "0";
                s6 = (board.game_board_value_location6 == 2) ? "1" : "0";
                s7 = (board.game_board_value_location7 == 2) ? "1" : "0";
                s8 = (board.game_board_value_location8 == 2) ? "1" : "0";
            }
            theString = s0 + s1 + s2 + s3 + s4 + s5 + s6 + s7 + s8;
            return theString;
        }
    }
}
