using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BavuaDAL;
namespace BavuaBL
{
    public class SummitBL
    {
        DBConnection dbCon;
        public SummitBL()
        {
            dbCon = new DBConnection();
        }
        //get
        public List<Summits> GetSammits()
        {
            return dbCon.GetDbSet<Summits>().ToList();
        }
        //add
        public void AddSummit(Summits summit)
        {
            dbCon.Execute(summit, DBConnection.ExecuteAction.Insert);
        }
        //update
        public void UpdateSummit(Summits summit)
        {
            dbCon.Execute(summit, DBConnection.ExecuteAction.Update);
        }
        //delete
        public void DeleteSummit(Summits summit)
        {
            dbCon.Execute(summit, DBConnection.ExecuteAction.Delete);
        }
    }
}
