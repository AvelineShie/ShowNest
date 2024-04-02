namespace ApplicationCore.Interfaces
{
    public interface IUserAccountAPIService
    {
        OperationResult GetUserOrderDetailListByUserId(string userId);
    }
}