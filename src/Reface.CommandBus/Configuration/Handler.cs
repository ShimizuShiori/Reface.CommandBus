using System;
using System.Configuration;

namespace Reface.CommandBus.Configuration
{
    public class Handler : ConfigurationElement
    {

        private Type _type;

        [ConfigurationProperty("type")]
        public String Type
        {
            get
            {
                return base["type"].ToString();
            }
            set
            {
                base["type"] = value;
            }
        }

        public Type RealType
        {
            get
            {
                if (_type == null)
                    _type = System.Type.GetType(this.Type);
                return _type;
            }
        }
    }
}
