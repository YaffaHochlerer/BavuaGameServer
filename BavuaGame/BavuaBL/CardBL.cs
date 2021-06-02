using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BavuaDAL;
namespace BavuaBL
{
    public class CardBL
    {
        DBConnection dbCon;
        public CardBL()
        {
            dbCon = new DBConnection();
        }
        //get
        public List<Cards> GetCards()
        {
            return dbCon.GetDbSet<Cards>().ToList();
        }
        //get card by code
        public Cards GetCardbycode(int code)
        {
            return dbCon.GetDbSet<Cards>().Find(c=>c.card_code==code);
        }
        //add
        public void AddCards(Cards card)
        {
            dbCon.Execute(card, DBConnection.ExecuteAction.Insert);
        }
        //update
        public void UpdateCards(Cards card)
        {
            dbCon.Execute(card, DBConnection.ExecuteAction.Update);
        }
        //delete
        public void DeleteCards(Cards card)
        {
            dbCon.Execute(card, DBConnection.ExecuteAction.Delete);
        }
        //opposit to string
        public string oppositCardToString( Cards card)
        {
            return  card.card_value_location0.ToString() +
                       card.card_value_location1.ToString() +
                       card.card_value_location2.ToString() +
                       card.card_value_location3.ToString() +
                       card.card_value_location4.ToString() +
                       card.card_value_location5.ToString() +
                       card.card_value_location6.ToString() +
                       card.card_value_location7.ToString() +
                       card.card_value_location8.ToString();
        }

    }
}
