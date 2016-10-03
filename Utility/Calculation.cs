using E_AvropArbetsProv.Model;
using System.Collections.Generic;
using System.Linq;

namespace E_AvropArbetsProv.Utility
{
    public class Calculation
    {
        public static double GetBalance(IEnumerable<DataModel> dataObj)
        {
            var transactions = from transaction in dataObj
                               select transaction.Transaction;

            return transactions.Sum();
        }
    }
}
