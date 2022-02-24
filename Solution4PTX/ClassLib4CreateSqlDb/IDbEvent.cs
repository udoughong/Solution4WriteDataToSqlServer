namespace ClassLib4CreateSqlDb
{
    public interface IDbEvent
    {
        void ImplementCase(string[] columnNameArray, string connectStr, string tableName, string ptxAppId, string ptxAppKey, string ptxAppUri, string ptxApiUri);
    }
}
