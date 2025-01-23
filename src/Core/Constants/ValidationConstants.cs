namespace QuickCart.Core.Constants;

public static class ValidationConstants
{
    public const int MinPasswordLength = 8;
    public const int MaxPasswordLength = 50;
    public const int MaxEmailLength = 100;
    public const int MaxNameLength = 100;
    public const int MaxPhoneLength = 15;
    public const decimal MinProductPrice = 0.01M;
    public const decimal MaxProductPrice = 999999.99M;
    public const int MinStockQuantity = 0;
    public const int MaxStockQuantity = 99999;
    
    public const int DiscountPercentageMinValue = 1;
    public const int DiscountPercentageMaxValue = 100;
    
    public const int MinAddressLineLength = 5;
    public const int MaxAddressLineLength = 100;
    public const int MinCityLength = 2;
    public const int MaxCityLength = 50;
    public const int MinStateLength = 2;
    public const int MaxStateLength = 50;
    public const int MinPostalCodeLength = 5;
    public const int MaxPostalCodeLength = 10;
    
}