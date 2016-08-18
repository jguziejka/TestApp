using System.Xml;
using System.Xml.Serialization;
using TestApp.Services;

namespace TestApp.Models
{
    public class SearchResultsModel
    {        
        public request request { get; set; }
        public message message { get; set; }
        public response response { get; set; }

        public SearchResultsModel(string xml)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            var xRequest = xmlDoc.GetElementsByTagName("request");
            if (xRequest.Count > 0)
            {
                request = XmlHelper.ConvertNode<request>(xRequest[0]);
            }
            var xMessage = xmlDoc.GetElementsByTagName("message");
            if (xMessage.Count > 0)
            {
                message = XmlHelper.ConvertNode<message>(xMessage[0]);
            }
            var xResponse = xmlDoc.GetElementsByTagName("response");
            if (xResponse.Count > 0)
            {
                response = XmlHelper.ConvertNode<response>(xResponse[0]);
            }
        }
    }
    public class request
    {
        public string address { get; set; }
        public string citystatezip { get; set; }
    }
    public class message
    {
        public string text { get; set; }
        public int code { get; set; }
    }
    public class response
    {
        public responseResults results { get; set; }
    }
    public class responseResults
    {
        public responseResultsResult result { get; set; }
    }
    public class responseResultsResult
    {
        public int zpid { get; set; }
        public responseResultsResultLinks links { get; set; }
        public responseResultsResultAddress address { get; set; }
        public responseResultsResultZestimate zestimate { get; set; }
        public responseResultsResultRentZestimate rentzestimate { get; set; }
        public responseResultsResultLocalRealEstate localRealEstate { get; set; }
    }
    public class responseResultsResultLinks
    {
        public string homedetails { get; set; }
        public string graphsanddata { get; set; }
        public string mapthishome { get; set; }
        public string comparables { get; set; }
    }
    public class responseResultsResultAddress
    {
        public string street { get; set; }
        public string zipcode { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
    }
    public class responseResultsResultZestimate
    {
        public responseResultsResultZestimateAmount amount { get; set; }
        public string lastupdated { get; set; }
        public responseResultsResultZestimateOneWeekChange oneWeekChange { get; set; }
        public responseResultsResultZestimateValueChange valueChange { get; set; }
        public responseResultsResultZestimateValuationRange valuationRange { get; set; }
        public int percentile { get; set; }
    }
    public class responseResultsResultRentZestimate
    {
        public responseResultsResultZestimateAmount amount { get; set; }
        public string lastupdated { get; set; }
        public responseResultsResultZestimateOneWeekChange oneWeekChange { get; set; }
        public responseResultsResultZestimateValueChange valueChange { get; set; }
        public responseResultsResultZestimateValuationRange valuationRange { get; set; }
    }
    public class responseResultsResultZestimateAmount
    {
        [XmlAttribute()]
        public string currency { get; set; }
        [XmlText()]
        public int Value { get; set; }
    }
    public class responseResultsResultZestimateOneWeekChange
    {
        public bool deprecated { get; set; }
    }
    public class responseResultsResultZestimateValueChange
    {
        public byte duration { get; set; }
        public string currency { get; set; }
        public int Value { get; set; }
    }
    public class responseResultsResultZestimateValuationRange
    {
        public responseResultsResultZestimateValuationRangeLow low { get; set; }
        public responseResultsResultZestimateValuationRangeHigh high { get; set; }
    }
    public class responseResultsResultZestimateValuationRangeLow
    {
        public string currency { get; set; }
        public int Value { get; set; }
    }
    public class responseResultsResultZestimateValuationRangeHigh
    {
        public string currency { get; set; }
        public int Value { get; set; }
    }
    public class responseResultsResultLocalRealEstate
    {
        public responseResultsResultLocalRealEstateRegion region { get; set; }
    }
    public class responseResultsResultLocalRealEstateRegion
    {
        public string zindexValue { get; set; }
        public responseResultsResultLocalRealEstateRegionLinks links { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public string type { get; set; }
    }
    public class responseResultsResultLocalRealEstateRegionLinks
    {
        public string overview { get; set; }
        public string forSaleByOwner { get; set; }
        public string forSale { get; set; }
    }
        
}
