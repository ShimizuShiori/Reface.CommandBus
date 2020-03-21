using System.Configuration;

namespace Reface.CommandBus.Configuration
{
    public class CommandBusSection : ConfigurationSection
    {
        [ConfigurationProperty("handlers")]
        public HandlerCollection Handlers
        {
            get
            {
                return (HandlerCollection)base["handlers"];
            }
        }
    }
}
