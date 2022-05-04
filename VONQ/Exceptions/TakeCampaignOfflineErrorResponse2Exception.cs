// <copyright file="TakeCampaignOfflineErrorResponse2Exception.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace VONQ.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using VONQ;
    using VONQ.Http.Client;
    using VONQ.Models;
    using VONQ.Utilities;

    /// <summary>
    /// TakeCampaignOfflineErrorResponse2Exception.
    /// </summary>
    public class TakeCampaignOfflineErrorResponse2Exception : ApiException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TakeCampaignOfflineErrorResponse2Exception"/> class.
        /// </summary>
        /// <param name="reason"> The reason for throwing exception.</param>
        /// <param name="context"> The HTTP context that encapsulates request and response objects.</param>
        public TakeCampaignOfflineErrorResponse2Exception(string reason, HttpContext context)
            : base(reason, context)
        {
        }

        /// <summary>
        /// Gets or sets CampaignId.
        /// </summary>
        [JsonProperty("campaignId")]
        public List<string> CampaignId { get; set; }

        /// <summary>
        /// Gets or sets Status.
        /// </summary>
        [JsonProperty("status")]
        public List<string> Status { get; set; }
    }
}