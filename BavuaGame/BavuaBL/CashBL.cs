using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BavuaDAL;
namespace BavuaBL
{
    public class CashBL
    {
        DBConnection dbCon;
        Cards_in_cash card_In_Cash;
        CardInCashBL cadrInCashBL=new CardInCashBL();
        
        public CashBL()
        {
            dbCon = new DBConnection();
        }
        //get
        public List<Cashes> GetCashes()
        {
            return dbCon.GetDbSet<Cashes>().ToList();
        }
        //add
        public void AddCash(Cashes cash)
        {
            dbCon.Execute(cash, DBConnection.ExecuteAction.Insert);
        }
        //update
        public void UpdateCash(Cashes cash)
        {
            dbCon.Execute(cash, DBConnection.ExecuteAction.Update);
        }
        //delete
        public void DeleteCash(Cashes cash)
        {
            dbCon.Execute(cash, DBConnection.ExecuteAction.Delete);
        }
        public int ThaNextCash()
        {
            return dbCon.GetDbSet<Cashes>().ToList().Count;
        }

        //הפעולה מחלקת כרטיסים לשתי הקופות באופן מוגרל
        internal void StartFillTheCashes(Cashes playerCashe, Cashes coputerCashe)
        {
            List<int> listOfAllTheCards = new List<int>() {  };
            List<Cards> listOfCards = dbCon.GetDbSet<Cards>().ToList();
            Random rndCard = new Random();
            int num;
            for (int i=0;i < listOfCards.Count; i++)
            {
                listOfAllTheCards.Add(i);
            }
            for (int i = 0; i < listOfCards.Count; i++)
            {
                num = rndCard.Next(0, (listOfAllTheCards.Count-1));
                card_In_Cash = new Cards_in_cash();
                card_In_Cash.cards_in_cash_code = dbCon.GetDbSet<Cards_in_cash>().ToList().Count;
                card_In_Cash.cards_in_cash_card_code = listOfAllTheCards[num];
                card_In_Cash.cards_in_cash_cash_code =(i< listOfCards.Count/2)? playerCashe.cash_code: coputerCashe.cash_code;
                card_In_Cash.cards_in_kupa_isWin = false;
                cadrInCashBL.AddCardsInCash(card_In_Cash);
                listOfAllTheCards.RemoveAt(num);
            }

        }
    }

}
