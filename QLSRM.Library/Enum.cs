namespace QLSRM.Library
{
    public class Enum
    {

    }
    public enum EditMode
    {
        None = 0,
        Add = 1,
        Update = 2,
        Delete = 3,
    }
    public enum Roles
    {
        None = 0,
        Admin = 1,
        Staff = 2,
        Shipper = 3
    }
    public enum ErrorCode
    {
        NoneError = 0,
        InvalidInput = 1,
        Unknown = 2,
        NotFound = 3,
        Conflict = 4,
        DuplicateCode = 5,
        EmployeeNotFound = 6,
        InvalidParam = 7,
        PointNotFound = 8,
        InvalidActiveCode = 9,
        NotEnoughPoints = 10,
        ErrorMinPoints = 11,
        InvalidEmail = 12,
        InvalidPhone = 13,
        InvalidRole = 14,

    }
    public enum OrderStatus
    {
        None = 0,
        WaitDelivery = 1,
        Delivering = 2,
        SuccessfulDelivery = 3,
        CancelOrder = 4

    }
    public enum StatusAccount
    {
        None = 0,
        Active = 1,
        DeActivate = 2,
        WaitActive = 3
    }
}