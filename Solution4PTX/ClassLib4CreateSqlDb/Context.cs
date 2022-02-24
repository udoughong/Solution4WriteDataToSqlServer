using System.Collections.Generic;

namespace ClassLib4CreateSqlDb
{
    public class Context
    {
        private static readonly Dictionary<int, IDbEvent> strategiesDictionary
          = new Dictionary<int, IDbEvent>();

        static Context()
        {
            strategiesDictionary.Add(0, new DbEvent4TraTrainStation());
            strategiesDictionary.Add(1, new DbEvent4TraTrainLine());
            strategiesDictionary.Add(2, new DbEvent4TraTrainLineSteps());
            strategiesDictionary.Add(3, new DbEvent4TraTrainTimeTable());
            strategiesDictionary.Add(4, new DbEvent4TraTrainTicketPrice());
        }

        public static void ImplementCase(int i, string[] newArray, string connectStr, string tableName, string ptxAppId, string ptxAppKey, string ptxAppUri, string ptxApiUri)
        {
            strategiesDictionary[i].ImplementCase(newArray, connectStr, tableName, ptxAppId, ptxAppKey, ptxAppUri, ptxApiUri);
        }
    }
}
