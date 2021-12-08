using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ValorantAPI.RiotClientAPI.RiotJsonStructs
{
    public class StoreFrontV2
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Item2
        {
            [JsonProperty("ItemTypeID")]
            public string ItemTypeID;

            [JsonProperty("ItemID")]
            public string ItemID;

            [JsonProperty("Amount")]
            public int Amount;
        }

        public class Item
        {
            [JsonProperty("Item")]
            public Item Itemm;

            [JsonProperty("BasePrice")]
            public int BasePrice;

            [JsonProperty("CurrencyID")]
            public string CurrencyID;

            [JsonProperty("DiscountPercent")]
            public double DiscountPercent;

            [JsonProperty("DiscountedPrice")]
            public int DiscountedPrice;

            [JsonProperty("IsPromoItem")]
            public bool IsPromoItem;
        }

        public class Bundle
        {
            [JsonProperty("ID")]
            public string ID;

            [JsonProperty("DataAssetID")]
            public string DataAssetID;

            [JsonProperty("CurrencyID")]
            public string CurrencyID;

            [JsonProperty("Items")]
            public List<Item> Items;

            [JsonProperty("DurationRemainingInSeconds")]
            public int DurationRemainingInSeconds;

            [JsonProperty("WholesaleOnly")]
            public bool WholesaleOnly;
        }

        public class Bundle2
        {
            [JsonProperty("ID")]
            public string ID;

            [JsonProperty("DataAssetID")]
            public string DataAssetID;

            [JsonProperty("CurrencyID")]
            public string CurrencyID;

            [JsonProperty("Items")]
            public List<Item> Items;

            [JsonProperty("DurationRemainingInSeconds")]
            public int DurationRemainingInSeconds;

            [JsonProperty("WholesaleOnly")]
            public bool WholesaleOnly;
        }

        public class FeaturedBundle
        {
            [JsonProperty("Bundle")]
            public Bundle Bundle;

            [JsonProperty("Bundles")]
            public List<Bundle> Bundles;

            [JsonProperty("BundleRemainingDurationInSeconds")]
            public int BundleRemainingDurationInSeconds;
        }

        public class SkinsPanelLayout
        {
            [JsonProperty("SingleItemOffers")]
            public List<string> SingleItemOffers;

            [JsonProperty("SingleItemOffersRemainingDurationInSeconds")]
            public int SingleItemOffersRemainingDurationInSeconds;
        }

        public class Root
        {
            [JsonProperty("FeaturedBundle")]
            public FeaturedBundle FeaturedBundle;

            [JsonProperty("SkinsPanelLayout")]
            public SkinsPanelLayout SkinsPanelLayout;
        }


    }
}
