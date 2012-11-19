using System;
using Newtonsoft.Json;

namespace TelAPI
{
    public class BNALookup : TelAPIBase
    {
        /// <summary>
        /// The Api Version being used when the BNA lookup was made.
        /// </summary>
        public string ApiVersion { get; set; }
        
        /// <summary>
        /// An alphanumeric string used for identification of the BNA lookup resource.
        /// </summary>
        [JsonProperty(PropertyName = "sid")]
        public string Sid { get; set; }
        
        /// <summary>
        /// An alphanumeric string identifying the account this lookup occurred through.
        /// </summary>
        [JsonProperty(PropertyName = "account_sid")]
        public string AccountSid { get; set; }
        
        /// <summary>
        /// Date the BNA lookup resource was created.
        /// </summary>
        [JsonProperty(PropertyName = "date_created")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DateCreated { get; set; }
        
        /// <summary>
        /// Date the BNA lookup resource was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "date_updated")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DateUpdated { get; set; }
        
        /// <summary>
        /// The phone number the lookup was performed on.
        /// </summary>
        [JsonProperty(PropertyName = "phone_number")]
        public string PhoneNumber { get; set; }
        
        /// <summary>
        /// The first name of the individual associated with this phone number.
        /// </summary>
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }
        
        /// <summary>
        /// The last name of the individual associated with this phone number.
        /// </summary>
        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }
        
        /// <summary>
        /// The address associated with this phone number.
        /// </summary>
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }
        
        /// <summary>
        /// The city associated with this phone number.
        /// </summary>
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }
        
        /// <summary>
        /// The US state associated with this phone number.
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }
        
        /// <summary>
        /// The zipcode associated with this phone number.
        /// </summary>
        [JsonProperty(PropertyName = "zip_code")]
        public string ZipCode { get; set; }
        
        /// <summary>
        /// The country code associated with this phone number. (BNA lookups are currently only available in US)
        /// </summary>
        [JsonProperty(PropertyName = "country_code")]
        public string CountryCode { get; set; }
        
        /// <summary>
        /// The price to perform the lookup. If only the city and state of the number are looked up, you are charged $.01. If a full address lookup is successful you are charged $.15.
        /// </summary>
        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }
    }
}
