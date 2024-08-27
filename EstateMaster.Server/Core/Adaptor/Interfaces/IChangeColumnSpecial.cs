namespace EstateMaster.Server.Adaptor.Interfaces
{
    public interface IChangeColumnSpecial
    {
        string GetTableName();
        string GetOldName();
        string GetDefault();
        string GetIsNull();
    }
}
