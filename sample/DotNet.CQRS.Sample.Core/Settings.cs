using System.Collections.Generic;

namespace DotNet.CQRS.Sample.Core
{
    public class Settings
    {
        public Settings()
        {
            Widgets = new List<string>();
        }

        public int ClientId { get; set; }
        public long EmployeeUid { get; set; }
        public List<string> Widgets { get; set; }
    }
}
