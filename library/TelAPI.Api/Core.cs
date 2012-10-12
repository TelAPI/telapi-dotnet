using System;
using System.Text;
using RestSharp;
using System.Reflection;

namespace TelAPI
{
    /// <summary>
    /// TelAPI REST API wrapper.
    /// </summary>
    public partial class TelAPIRestClient
    {
        /// <summary>
        /// TelAPI API version to use when making requests
        /// </summary>
        public string ApiVersion { get; set; }

        /// <summary>
        /// Base URL of Rest Service
        /// </summary>
        public string BaseUrl { get; set; }

        private string AccountSid { get; set; }
        private string AuthToken { get; set; }
        
        private RestClient _client { get; set; }

        /// <summary>
        /// Initializes a new REST client with credentials
        /// </summary>
        /// <param name="accountSid">The AccountSid to authenticate with</param>
        /// <param name="authToken">The AuthToken to authenticate with</param>
        public TelAPIRestClient(string accountSid, string authToken)
        {
            ApiVersion = "2011-07-01";
            BaseUrl = "https://api.telapi.com/";
            AccountSid = accountSid;
            AuthToken = authToken;

            this.Connect();
        }

        /// <summary>
        /// Initializes a new REST client with credentials
        /// </summary>
        /// <param name="configuration">TelAPIConfiguration</param>
        public TelAPIRestClient(ITelAPIConfiguration configuration)
        {
            ApiVersion = configuration.ApiVersion;
            BaseUrl = configuration.BaseUrl;
            AccountSid = configuration.AccountSid;
            AuthToken = configuration.AuthToken;

            this.Connect();
        }

        /// <summary>
        /// Authenticate and connect to Rest service with credentials
        /// </summary>
        public void Connect()
        {
            //turned off because of testing purpose
            //var version = Assembly.GetEntryAssembly().GetName().Version;

            _client = new RestClient();
            _client.UserAgent = "TelAPI-dotnet/" + "1.0";
            _client.Authenticator = new HttpBasicAuthenticator(AccountSid, AuthToken);
            _client.BaseUrl = string.Format("{0}{1}", BaseUrl, ApiVersion);

            _client.AddDefaultUrlSegment("AccountSid", AccountSid);
        }

		/// <summary>
		/// Execute REST request
		/// </summary>
		/// <typeparam name="T">The type of object to create and populate with data</typeparam>
		/// <param name="request">The RestRequest to execute</param>
		/// <returns></returns>
        public T Execute<T>(RestRequest request) where T : new()
		{
            request.RequestFormat = DataFormat.Json;

            /*
            foreach (var p in request.Parameters)
            {
                System.Diagnostics.Debug.WriteLine(String.Format("{0} {1} {2}", p.Name, p.Type, p.Value));
            }
            */

            IRestResponse<T> response;
            response = _client.Execute<T>(request);            

            switch ((int)response.StatusCode)
            {
                case 0: throw new TelAPIException(response.ErrorMessage, response.ErrorException.InnerException);
                case 400: throw new TelAPIBadRequestException(response.ErrorMessage, response.ErrorException.InnerException);
                case 401: throw new TelAPIUnauthorizedException(response.ErrorMessage, response.ErrorException.InnerException);
                case 404: throw new TelAPINotFoundException(response.ErrorMessage, response.ErrorException.InnerException);
                case 500: throw new TelAPIInternalErrorException(response.ErrorMessage, response.ErrorException.InnerException);
            }  

            //print out JSON response for testing purpose
            //System.Diagnostics.Debug.WriteLine(response.Content);
        
            return response.Data;
		}
        	
	    /// <summary>
	    /// Execute a REST request
	    /// </summary>
	    /// <param name="request">The RestRequest to execute</param>
	    /// <returns></returns>
		public IRestResponse Execute(IRestRequest request)
		{
			return _client.Execute(request);
		}

        /// <summary>
        /// Helper for adding inequalities for DateTime parameters
        /// </summary>
        /// <param name="comparisonType">Comparasion type (less or greater)</param>
        /// <param name="parameterName">DateTime parameter name</param>
        /// <returns></returns>
        private string GetParameterNameWithEquality(ComparisonType? comparisonType, string parameterName)
        {
            if (comparisonType.HasValue)
            {
                switch (comparisonType)
                {
                    case ComparisonType.GreaterThanOrEqualTo:
                        parameterName += ">";
                        break;
                    case ComparisonType.LessThanOrEqualTo:
                        parameterName += "<";
                        break;
                }
            }

            return parameterName;
        }
    }
}
