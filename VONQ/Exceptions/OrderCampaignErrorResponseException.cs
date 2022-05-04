// <copyright file="OrderCampaignErrorResponseException.cs" company="APIMatic">
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
    /// OrderCampaignErrorResponseException.
    /// </summary>
    public class OrderCampaignErrorResponseException : ApiException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderCampaignErrorResponseException"/> class.
        /// </summary>
        /// <param name="reason"> The reason for throwing exception.</param>
        /// <param name="context"> The HTTP context that encapsulates request and response objects.</param>
        public OrderCampaignErrorResponseException(string reason, HttpContext context)
            : base(reason, context)
        {
        }

        /// <summary>
        /// Gets or sets CompanyId.
        /// </summary>
        [JsonProperty("companyId")]
        public List<string> CompanyId { get; set; }

        /// <summary>
        /// Gets or sets PostingDetails.
        /// </summary>
        [JsonProperty("postingDetails")]
        public Models.PostingDetailsErrorsModel PostingDetails { get; set; }

        /// <summary>
        /// Gets or sets TargetGroup.
        /// </summary>
        [JsonProperty("targetGroup")]
        public List<string> TargetGroup { get; set; }

        /// <summary>
        /// Gets or sets RecruiterInfo.
        /// </summary>
        [JsonProperty("recruiterInfo")]
        public Models.RecruiterInfoErrorsModel RecruiterInfo { get; set; }

        /// <summary>
        /// Gets or sets OrderedProducts.
        /// </summary>
        [JsonProperty("orderedProducts")]
        public List<string> OrderedProducts { get; set; }

        /// <summary>
        /// Gets or sets OrderedProductsSpecs.
        /// </summary>
        [JsonProperty("orderedProductsSpecs")]
        public List<Models.OrderedProductsSpecModel> OrderedProductsSpecs { get; set; }
    }
}