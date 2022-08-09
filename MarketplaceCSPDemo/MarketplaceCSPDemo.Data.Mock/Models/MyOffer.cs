using Microsoft.Store.PartnerCenter.Models.Invoices;
using Microsoft.Store.PartnerCenter.Models.Offers;

namespace MarketplaceCSPDemo.Data.Mock.Models
{
    public class MyOffer
    {
        //
        // Summary:
        //     Gets or sets the offer identifier.
        public string Id;

        //
        // Summary:
        //     Gets or sets the offer name.
        public string Name;

        //
        // Summary:
        //     Gets or sets the offer description.
        public string Description;

        //
        // Summary:
        //     Gets or sets the minimum quantity available.
        public int MinimumQuantity;

        //
        // Summary:
        //     Gets or sets the maximum quantity available.
        public int MaximumQuantity;

        //
        // Summary:
        //     Gets or sets the locale to which the offer applies.
        public string Locale;

        //
        // Summary:
        //     Gets or sets the country where the offer applies.
        public string Country;

        //
        // Summary:
        //     Gets or sets the offer category.
        public OfferCategory Category;

        //
        // Summary:
        //     Gets or sets the type of the unit.
        public string UnitType;

        //
        // Summary:
        //     Gets or sets the final price for end user
        public double FinalPrice;

        public MyOffer(Offer offer)
        {
            Id = offer.Id;
            Name = offer.Name;
            Description = offer.Description;
            MinimumQuantity = offer.MinimumQuantity;
            MaximumQuantity = offer.MaximumQuantity;
            Locale = offer.Locale;
            Country = offer.Country;
            Category = offer.Category;
            UnitType = offer.UnitType;
            FinalPrice = 0;
        }
    }
}