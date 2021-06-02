using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BavuaBL
{
    public class KeepCheakingCard
    {
       public int numCard { get; set; }
       public List<int> indexes { get; set; }
       public List<int> indexesInCarcNotInBoard { get; set; }

        public KeepCheakingCard() { }
        public KeepCheakingCard(int numCard, List<int> indexes, List<int> indexesInCarcNotInBoard)
        {
            this.numCard = numCard;
            this.indexes = indexes;
            this.indexesInCarcNotInBoard = indexesInCarcNotInBoard;
        }

    }
}
