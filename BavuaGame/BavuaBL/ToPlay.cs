using BavuaDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using BavuaDAL;

namespace BavuaBL
{
    public class ToPlay
    {
        DBConnection dbCon;
        List<Cards_in_cash> listOfPlayerCardsInCash;
        List<Cards> OpenCards = new List<Cards>();
        CardBL cardBL = new CardBL();
        CardInCashBL cardInCashBL = new CardInCashBL();
        GameBordBL gameBordBL = new GameBordBL();
        public ToPlay()
        {
            dbCon = new DBConnection();
        }
        //פעולה שפותחת מתוך קופה של  שחקן את 5 הכרטיסים שבשימוש כעת
        public List<Cards> OpenCardsToPlayerOrComputer(Cashes playerCashe)
        {
            //ממלאים את הרשימה בכרטיסים של השחקן שעדין לא נפתחו
            //('לשנות שיביא את מי שעדין לא נפתח ולא את מי שעוד לא נוצח (צריך להוסיף את התכונה ב'דתהבייס 
            listOfPlayerCardsInCash = dbCon.GetDbSet<Cards_in_cash>().Where(cic => cic.cards_in_cash_cash_code == playerCashe.cash_code && cic.cards_in_kupa_isWin == false).ToList();
            int i = 0;
            if (listOfPlayerCardsInCash.Count == 0)
            {
                //הסתימו הקלפים בקופה==ניצחון!!

            }
            else
            {
                while (listOfPlayerCardsInCash.Count != 0 && i < 5)
                {
                    OpenCards.Add(cardBL.GetCardbycode(listOfPlayerCardsInCash[0].cards_in_cash_card_code));
                    listOfPlayerCardsInCash.RemoveAt(0);
                    i++;
                }
            }
            return OpenCards;
        }
        //פעולה שקוראת בעת לחיצה של השחקן על חייל
        //הפעולה מקבלת: לוח, רשימת הכרטיסים של השחקן
        public List<Cards> Checkthestep(Game_board board, List<Cards> listCards, int codeCash)
        {

            //לפנות את החייל ממקומו
            //להעביר אותו למקום הריק
            /////////////////////////
            //הפיכת מקומי הלוח למחרוזת
            string boardString = gameBordBL.oppositBoardToString(2, board), card;

            for (int i = 0; i < listCards.Count; i++)
            {
                //הפיכת מיקומי הכרטיס למחרוזת
                card = cardBL.oppositCardToString(listCards[i]);
                if (card == boardString || ToRoundCard(card, 1) == boardString || ToRoundCard(card, 2) == boardString || ToRoundCard(card, 3) == boardString)
                {
                    //מציאת הקלף שנוצח בקופת השחקן וסימונו כמנוצח
                    Cards_in_cash cards_in_cash = cardInCashBL.GetCardInCashbycode(listCards[i].card_code);
                    cards_in_cash.cards_in_kupa_isWin = true;
                    cardInCashBL.UpdateCardsInCash(cards_in_cash);
                    //מחיקת הכרטיס שנוצח מהרשימה
                    listCards.RemoveAt(i);
                    return listCards;
                }
            }
            return listCards;
        }
        //פעולה שמקבלת כרטיס ומספר, ומסובבת את כרטיס כמספר הפעמים
        public string ToRoundCard(string card, int numberOfrRounds)
        {
            while (numberOfrRounds > 0)
            {
                card = card[6].ToString() + card[3].ToString() + card[0].ToString() + card[7].ToString() + card[4].ToString() +
                    card[1].ToString() + card[8].ToString() + card[5].ToString() + card[2].ToString();
                numberOfrRounds--;
            }
            return card;
        }
        //פעולה שמשמשת לבדיקת צעד אופטימאלי, עבור המחשב או בבקשת רמז
        //מקבלת:צעד מחשב או רמז(1,2,3)?, לוח,קופה, רשימת כרטיסים פתוחים
        //אם יש 0- צעד של המחשב, 1- בקשת רמז על כרטיס 2- בקשת רמז על חייל
        //מחזירה: אינדקס- או של מיקום חייל על הלוח להזזה או של כרטיס ברשימת הכרטיסים הפתוחים
        public int ComputerStepOrClue(int compStepOrClue, Game_board board, Cashes cash, List<Cards> openCardsList)
        {

            int empty = gameBordBL.EmptyPlace(board), mone = 0, compOrClue = (compStepOrClue == 0) ? 1 : 2, max = 0, ind = 0;
            string stringBoard = gameBordBL.oppositBoardToString(compOrClue, board), stringCard;
            //מקומות של חיילים שיש בלוח ואין בכרטיס
            List<int> indexes = new List<int>();
            //מקומות של חיילים שיש בכרטיס ואין בלוח
            List<int> indexesInCarcNotInBoard = new List<int>();
            //רשימות של כרטיסים אופצוינאליים, אם חייל אחד לא במקום שנים או שלושה
            List<KeepCheakingCard> listOfBestCards1 = new List<KeepCheakingCard>();
            List<KeepCheakingCard> listOfBestCards2 = new List<KeepCheakingCard>();
            List<KeepCheakingCard> listOfBestCards3 = new List<KeepCheakingCard>();
            //רשימה של אינדקסים של כרטיסים שיש בהם 4 חיילים לא מתאימים
            List<KeepCheakingCard> listOfBadCards4 = new List<KeepCheakingCard>();
            List<KeepCheakingCard> l;

            //עצם מסוג הכרטיס שנבדוק ולא יודעים אם הוא הכי טוב, אז הודקים את הבדיקה שלו
            //מערך מונים איזה חייל הכי טוב להזיז
            int[] arraytheBestep = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            KeepCheakingCard keepCheakingCard;
            for (int i = 0; i < openCardsList.Count; i++)
            {
                stringCard = cardBL.oppositCardToString(openCardsList[i]);
                for (int j = 0; j < 9; j++)
                {
                    if (stringBoard[j] == '1')
                    {
                        if (stringCard[j] == '1')
                            mone++;
                        else
                            indexes.Add(j);

                    }
                    else
                    {
                        if (stringCard[j] == '1')
                            indexesInCarcNotInBoard.Add(j);

                    }
                }
                if (mone == 3)//מה שאומר שרק חייל אחד לא במקום
                {
                    if (indexes[0] == empty)//בודקים אם החייל שחסר צריך להיות בשקע הריק
                    {
                        if (compStepOrClue == 0 || compStepOrClue == 2)
                            return indexesInCarcNotInBoard[0];
                        else
                            return i;
                    }
                    else
                    {
                        //אם החייל שחסר להשלמת הכרטיס אינו במקום של השקע, שומרים את הכרטיס הזה וממשיכים לבדוק
                        keepCheakingCard = new KeepCheakingCard(i, indexes, indexesInCarcNotInBoard);
                        listOfBestCards1.Add(keepCheakingCard);
                    }
                }
                else
                {
                    if (mone == 2)//מה שאומר שישנם שני חיילים שאינם במקום
                    {
                        if (listOfBestCards1.Count == 0)
                        {
                            keepCheakingCard = new KeepCheakingCard(i, indexes, indexesInCarcNotInBoard);
                            listOfBestCards2.Add(keepCheakingCard);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (mone == 1)// מה שאומר שישנם שלושה חיילים שאינם במקום
                        {
                            if (listOfBestCards1.Count == 0 && listOfBestCards2.Count == 0)
                            {
                                keepCheakingCard = new KeepCheakingCard(i, indexes, indexesInCarcNotInBoard);
                                listOfBestCards3.Add(keepCheakingCard);
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else//שום חייל לא במקום
                        {
                            listOfBadCards4.Add(new KeepCheakingCard(i, indexes, indexesInCarcNotInBoard));
                        }
                    }
                }
            }
            //אם הגיעו לכאן ז"א שאי אפשר כעת לנצח במהלך אחד, לכן כעת מכל ה אפשרויות אנחנו מחפשים את האופטימאלי
            // מכניסים ב l את
            l = (listOfBestCards1.Count > 0) ? listOfBestCards1 : (listOfBestCards2.Count > 0) ? listOfBestCards2 : (listOfBestCards3.Count > 0) ? listOfBestCards3 : listOfBadCards4;
//עוברים על רשימת הכרטיסים הבדוקים
            for (int i = 0; i < l.Count; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (listOfBestCards1[i].indexesInCarcNotInBoard.Contains(j))
                    {
                        arraytheBestep[j]++;
                    }
                }
                for (int k = 0; k < 9; k++)
                {
                    if (arraytheBestep[k] > max)
                    {
                        max = arraytheBestep[k];
                        ind = k;
                    }
                }
            }
            if (compStepOrClue == 0 || compStepOrClue == 2)
                return ind;
            else
                return listOfBestCards1[0].numCard;

        }
    }
}


