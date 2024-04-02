namespace ApplicationCore.Interfaces
{
    public interface IUserAccountAPIService
    {
        OperrionResult GetUserOrderDetailListByUserId(string userId);
    }
}