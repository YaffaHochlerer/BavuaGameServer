using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BavuaDAL;
namespace BavuaBL
{
    public class CardInCashBL
    {
        DBConnection dbCon;
        public CardInCashBL()
        {
            dbCon = new DBConnection();
        }
        //get
        public List<Cards_in_cash> GetCardInCashs()
        {
            return dbCon.GetDbSet<Cards_in_cash>().ToList();
        }

        //add
        public void AddCardsInCash(Cards_in_cash cardInCash)
        {
            dbCon.Execute(cardInCash, DBConnection.ExecuteAction.Insert);
        }
        //update
        public void UpdateCardsInCash(Cards_in_cash cardInCash)
        {
            dbCon.Execute(cardInCash, DBConnection.ExecuteAction.Update);
        }
        //delete
        public void DeleteCardsInCash(Cards_in_cash cardInCash)
        {
            dbCon.Execute(cardInCash, DBConnection.ExecuteAction.Delete);
        }
        //get cardInCash by card code
        public Cards_in_cash GetCardInCashbycode(int code)
        {
            return dbCon.GetDbSet<Cards_in_cash>().Find(c => c.cards_in_cash_card_code == code);
        }
    }
}
