using System;
using System.Linq;
using PropertyMatcher.Utilities;
using PropertyMatcher.DataContracts;

namespace PropertyMatcher
{
    internal class CREPropertyMatcher : IPropertyMatcher
    {
        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            // The business rule doesnt say the agency code has to match as it says for "Location Real Estate" rule, hence I am not matching with agency code
            bool match = false;
            var agencyPropertyName = agencyProperty.Name.Trim().RemovePunctuation();
            var databasePropertyName = databaseProperty.Name.Trim().RemovePunctuation();

            if (agencyPropertyName.ReverseWords().Equals(databasePropertyName, StringComparison.OrdinalIgnoreCase))
            {
                match = true;
            }
            return match;
        }
    }
}
