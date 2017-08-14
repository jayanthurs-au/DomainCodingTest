using System.Collections.Generic;
using PropertyMatcher.DataContracts;

namespace PropertyMatcher.Persister
{
    public class PropertyPersister
    {
        private static List<Property> _properties = new List<Property>();
        public void Add(Property property)
        {
            _properties.Add(property);
        }

        public List<Property> GetProperties()
        {
            return _properties;
        }
    }
}
