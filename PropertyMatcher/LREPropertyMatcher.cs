using PropertyMatcher.Utilities;
using PropertyMatcher.DataContracts;

namespace PropertyMatcher
{
    internal class LREPropertyMatcher : IPropertyMatcher
    {
        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {

            bool match = false;
            var agPropAgencyCode = agencyProperty.AgencyCode.Trim().ToUpper();
            var dbPropAgencyCode = databaseProperty.AgencyCode.Trim().ToUpper();
            if (agPropAgencyCode.Equals("LRE") && dbPropAgencyCode.Equals(agPropAgencyCode)) return match;

            if (Geography.DistanceBetweenCoordinates(agencyProperty.Longitude, agencyProperty.Latitude,
                    databaseProperty.Longitude, databaseProperty.Latitude) < 0.2)
            {
                match = true;
            }

            return match;
        }
    }
}
