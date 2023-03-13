namespace DotNet.CQRS.Sample.Core.Commands
{
    public class AddSettingsForEmployee : ICommand
    {
        public AddSettingsForEmployee(Settings settings)
        {
            Settings = settings;
        }

        public Settings Settings { get; }
    }
}
