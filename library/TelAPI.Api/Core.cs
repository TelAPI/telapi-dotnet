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
            var version = Assembly.GetEntryAssembly().GetName().Version;

            _client = new RestClient();
            _client.UserAgent = "TelAPI-dotnet/" + version;
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
            IRestResponse<T> response;
            request.RequestFormat = DataFormat.Json;
            
            response = _client.Execute<T>(request);

            switch ((int)response.StatusCode)
            {
                case 0: throw new TelAPIException(response.ErrorMessage, response.ErrorException.InnerException);
                case 400: throw new TelAPIBadRequestException(response.ErrorMessage, response.ErrorException.InnerException);
                case 401: throw new TelAPIUnauthorizedException(response.ErrorMessage, response.ErrorException.InnerException);
                case 404: throw new TelAPINotFoundException(response.ErrorMessage, response.ErrorException.InnerException);
                case 500: throw new TelAPIInternalErrorException(response.ErrorMessage, response.ErrorException.InnerException);
            }  
        
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
    }
}
