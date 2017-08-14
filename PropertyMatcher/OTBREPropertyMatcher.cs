using System;
using System.Globalization;
using PropertyMatcher.Utilities;
using PropertyMatcher.DataContracts;

namespace PropertyMatcher
{
    internal class OTBREPropertyMatcher : IPropertyMatcher
    {
        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {

            // The business rule doesnt say the agency code has to match as it says for "Location Real Estate" rule, hence I am not matching with agency code
            bool match = false;

            var agencyPropertyName = agencyProperty.Name.Trim().ToLower();
            var agencyPropertyAddress = agencyProperty.Address.Trim().ToLower();
            var databasePropertyName = databaseProperty.Name.Trim().ToLower();
            var databasePropertyAddress = databaseProperty.Address.Trim().ToLower();

            //var agencyPropertyName = agencyProperty.Name.Trim().RemovePunctuation();
            //var agencyPropertyAddress = agencyProperty.Address.Trim().RemovePunctuation();
            //var databasePropertyName = databaseProperty.Name.Trim().RemovePunctuation();
            //var databasePropertyAddress = databaseProperty.Address.Trim().RemovePunctuation();

            //if (agencyPropertyName.Equals(databasePropertyName, StringComparison.OrdinalIgnoreCase) &&
            //    agencyPropertyAddress.Equals(databasePropertyAddress, StringComparison.OrdinalIgnoreCase))
            //{
            //    match = true;
            //}
            if (string.Compare(agencyPropertyName, databasePropertyName, CultureInfo.CurrentCulture, CompareOptions.IgnoreSymbols) == 0 &&
            string.Compare(agencyPropertyAddress, databasePropertyAddress, CultureInfo.CurrentCulture, CompareOptions.IgnoreSymbols) == 0)
            {
                match = true;
            }

            return match;
        }
    }
}
