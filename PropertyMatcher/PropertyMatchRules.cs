using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyMatcher.DataContracts;

namespace PropertyMatcher
{

    public class PropertyMatchRules : IPropertyMatcher
    {
        readonly List<IPropertyMatcher> _rules = new List<IPropertyMatcher>();

        public PropertyMatchRules()
        {
            _rules.Add(new CREPropertyMatcher());
            _rules.Add(new LREPropertyMatcher());
            _rules.Add(new OTBREPropertyMatcher());
        }

        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            return _rules.Any(rule => rule.IsMatch(agencyProperty, databaseProperty));
        }
    }
}
