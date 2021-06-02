using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BavuaDAL;
namespace BavuaBL
{
    public class UserBL
    {
        DBConnection dbCon;
        List<Users> listOfUsers;
        public UserBL()
        {
            dbCon = new DBConnection();
        }
        //get
        public List<Users> GetUsers()
        {
            return dbCon.GetDbSet<Users>().ToList();
        }
        //add
        public void AddUser(Users user)
        {
            dbCon.Execute(user, DBConnection.ExecuteAction.Insert);
        }
        //update
        public void UpdateUser(Users user)
        {
            dbCon.Execute(user, DBConnection.ExecuteAction.Update);
        }
        //delete
        public void DeleteUser(Users user)
        {
            dbCon.Execute(user, DBConnection.ExecuteAction.Delete);
        }
        //get the nent
        public int ThaNextUser()
        {
           return dbCon.GetDbSet<Users>().ToList().Count;
        }
        public int InsertUser(Users user)
        {
            if (listOfUsers.First(u=>u.user_password==user.user_password)==null)
                try
                {
                    dbCon.Execute<Users>(user, DBConnection.ExecuteAction.Insert);
                    listOfUsers = dbCon.GetDbSet<Users>().ToList();
                    return listOfUsers.Find(u => u.user_password == user.user_password).user_password;
                }
                catch
                {
                    return 0;
                }
            else
            {
                return listOfUsers.Find(u => u.user_password == user.user_password).user_password;
            }

        }
    }
}
