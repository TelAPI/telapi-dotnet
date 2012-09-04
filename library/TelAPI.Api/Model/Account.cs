using System;
using System.Collections.Generic;

namespace TelAPI
{
    /// <summary>
    /// An account resource provides information about a single TelAPI account.
    /// </summary>
    public class Account : TelAPIBase
    {
        /// <summary>
        /// An alphanumeric string identifying the account.
        /// </summary>
        public string Sid { get; set; }

        /// <summary>
        /// This is an alias that can be created for TelAPI accounts. By default, it is the email used to create the account but a custom name can be used as long as it is shorter than 64 characters.
        /// </summary>      
        public string FriendlyName { get; set; }

        /// <summary>
        /// This is the status of the TelAPI account being requested. The state of the status can be either active, suspended, or closed.
        /// </summary>
        public AccountStatus Status { get; set; }

        /// <summary>
        /// The current balance of an account.
        /// </summary>
        public string AccountBalance { get; set; }

        /// <summary>
        /// Date of account creation. Dates are returned in UTC format.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Date of most recent account update. Dates are returned in UTC format.
        /// </summary>
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// The type of account being requested. If the account is not yet funded Type is Trial. Otherwise, Type for upgraded accounts is Full.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The name of an accounts timezone.
        /// </summary>
        public string TimeZone { get; set; }
    }
}
