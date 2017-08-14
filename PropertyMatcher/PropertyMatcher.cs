using System;
using System.Linq;
using PropertyMatcher.Utilities;
using PropertyMatcher.DataContracts;

namespace PropertyMatcher
{
    //ignore this class, I first wrote this and then refactored. This class is only for reference
    public class PropertyMatcher : IPropertyMatcher
    {
        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {

            bool match = false;
            var agencyCode = agencyProperty.AgencyCode.Trim().ToUpper();
            var agencyPropertyName = agencyProperty.Name.Trim().RemovePunctuation();
            var agencyPropertyAddress = agencyProperty.Address.Trim().RemovePunctuation();
            var databasePropertyName = databaseProperty.Name.Trim().RemovePunctuation();
            var databasePropertyAddress = databaseProperty.Address.Trim().RemovePunctuation();
            switch (agencyCode)
            {
                case "OTBRE":
                    if (agencyPropertyName.Equals(databasePropertyName, StringComparison.OrdinalIgnoreCase) &&
                        agencyPropertyAddress.Equals(databasePropertyAddress, StringComparison.OrdinalIgnoreCase))
                    {
                        match = true;
                    }
                    break;
                case "LRE":
                    if (Geography.DistanceBetweenCoordinates(agencyProperty.Longitude, agencyProperty.Latitude,
                        databaseProperty.Longitude, databaseProperty.Latitude) < 0.2)
                    {
                        match = true;
                    }
                    break;
                case "CRE":
                    if (agencyPropertyName.Reverse().ToString().Equals(databasePropertyName, StringComparison.OrdinalIgnoreCase))
                    {
                        match = true;
                    }
                    break;
            }

            return match;
        }
    }
}
