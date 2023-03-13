namespace DotNet.CQRS.Sample.Core.Queries
{
    public class GetSettingsForEmployee : IScalar<Settings>
    {
        public GetSettingsForEmployee(int clientId, long employeeUid)
        {
            ClientId = clientId;
            EmployeeUid = employeeUid;
        }

        public int ClientId { get; }
        public long EmployeeUid { get; }
    }
}
