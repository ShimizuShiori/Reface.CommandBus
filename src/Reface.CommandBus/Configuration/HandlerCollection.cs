using System.Configuration;

namespace Reface.CommandBus.Configuration
{
    [ConfigurationCollection(typeof(Handler))]
    public class HandlerCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new Handler();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as Handler).Type;
        }

        new Handler this[string name]
        {
            get
            {
                return (Handler)base.BaseGet(name);
            }
        }
    }
}
