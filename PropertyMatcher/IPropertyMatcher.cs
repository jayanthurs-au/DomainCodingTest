using PropertyMatcher.DataContracts;

namespace PropertyMatcher
{
    public interface IPropertyMatcher
    {
        bool IsMatch(Property agencyProperty, Property databaseProperty);
    }
}
