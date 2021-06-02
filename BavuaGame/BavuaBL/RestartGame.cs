using BavuaDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace BavuaBL
{
    public class RestartGame
    {
        Users user;
        Cashes playerCashe;
        Cashes coputerCashe;
        UserBL userbl = new UserBL();
        CashBL cashbl = new CashBL();
        //מחלקה שמכילה פונקציות למהלך המשחק- Toplay עצם מסוג
        ToPlay toplay = new ToPlay();
        
        //to start new game whith computer
        public void startGame(int openOrNew, string userName,int userPassword)
        {
            if(openOrNew!=1)
            {
                
                //שמירת המשתמש
                user = new Users();
                user.user_code = userbl.ThaNextUser();
                user.user_Fname = userName;
                user.user_password = userPassword;
                userbl.AddUser(user);
                //פתיחת קופה לשחקן
                playerCashe = new Cashes();
                playerCashe.cash_code = cashbl.ThaNextCash();
                playerCashe.cash_Is_my_queue = true;
                playerCashe.cash_number_clues = 0;
                playerCashe.cash_user_code = user.user_code;
                cashbl.AddCash(playerCashe);
                //פתיחת קופה למחשב
                coputerCashe = new Cashes();
                coputerCashe.cash_code=cashbl.ThaNextCash();
                coputerCashe.cash_Is_my_queue = true;
                coputerCashe.cash_number_clues = 0;
                coputerCashe.cash_user_code = 0;
                cashbl.AddCash(playerCashe);
                //פעולה שממלאה את הקופות בקלפים
                cashbl.StartFillTheCashes(playerCashe, coputerCashe);
                //הגדרת רשימות לשני השחקנים, המכילות את 5 הכרטיסים  הפתוחים כעת
                List<Cards> PlayerOpenCardsList = toplay.OpenCardsToPlayerOrComputer(playerCashe);
                List<Cards> ComputerOpenCardsList = toplay.OpenCardsToPlayerOrComputer(coputerCashe);
            }
        }

    }

}
