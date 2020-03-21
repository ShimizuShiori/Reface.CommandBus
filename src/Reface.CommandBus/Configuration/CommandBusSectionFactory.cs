using System;

namespace Reface.CommandBus.Configuration
{
    class CommandBusSectionFactory
    {
        public static CommandBusSection Get(string sectionName)
        {
            return (CommandBusSection)System.Configuration.ConfigurationManager.GetSection(sectionName);
        }
    }
}
