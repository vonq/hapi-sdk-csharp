// <copyright file="PostContractModel.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace VONQ.Models
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
    using VONQ.Utilities;

    /// <summary>
    /// PostContractModel.
    /// </summary>
    public class PostContractModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostContractModel"/> class.
        /// </summary>
        public PostContractModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostContractModel"/> class.
        /// </summary>
        /// <param name="channelId">channel_id.</param>
        /// <param name="credentials">credentials.</param>
        /// <param name="facets">facets.</param>
        /// <param name="followedInstructions">followed_instructions.</param>
        /// <param name="expiryDate">expiry_date.</param>
        /// <param name="credits">credits.</param>
        /// <param name="purchasePrice">purchase_price.</param>
        public PostContractModel(
            double channelId,
            object credentials,
            object facets = null,
            bool? followedInstructions = null,
            DateTime? expiryDate = null,
            double? credits = null,
            Models.ContractPurchasePriceModel purchasePrice = null)
        {
            this.ChannelId = channelId;
            this.Credentials = credentials;
            this.Facets = facets;
            this.FollowedInstructions = followedInstructions;
            this.ExpiryDate = expiryDate;
            this.Credits = credits;
            this.PurchasePrice = purchasePrice;
        }

        /// <summary>
        /// Gets or sets ChannelId.
        /// </summary>
        [JsonProperty("channel_id")]
        public double ChannelId { get; set; }

        /// <summary>
        /// An object with credentials data
        /// </summary>
        [JsonProperty("credentials")]
        public object Credentials { get; set; }

        /// <summary>
        /// An object with product parameters
        /// </summary>
        [JsonProperty("facets", NullValueHandling = NullValueHandling.Ignore)]
        public object Facets { get; set; }

        /// <summary>
        /// When creating contracts for Channels that require the end-user to follow instructions (based on the `manual_setup_required` key in the response body for the [Retrieve details for channel with support for contracts](https://vonq.stoplight.io/docs/hapi/b3A6NTUxMjYwODI-retrieve-details-for-channel-with-support-for-contracts) endpoint), set this value to `true` to confirm the user has done so. For quality purposes, setting this field to `true` for Channels that don't require following instructions will result in a 400 Bad Request.
        /// </summary>
        [JsonProperty("followed_instructions", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FollowedInstructions { get; set; }

        /// <summary>
        /// Gets or sets ExpiryDate.
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("expiry_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ExpiryDate { get; set; }

        /// <summary>
        /// Gets or sets Credits.
        /// </summary>
        [JsonProperty("credits", NullValueHandling = NullValueHandling.Ignore)]
        public double? Credits { get; set; }

        /// <summary>
        /// Gets or sets PurchasePrice.
        /// </summary>
        [JsonProperty("purchase_price", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ContractPurchasePriceModel PurchasePrice { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PostContractModel : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is PostContractModel other &&
                this.ChannelId.Equals(other.ChannelId) &&
                ((this.Credentials == null && other.Credentials == null) || (this.Credentials?.Equals(other.Credentials) == true)) &&
                ((this.Facets == null && other.Facets == null) || (this.Facets?.Equals(other.Facets) == true)) &&
                ((this.FollowedInstructions == null && other.FollowedInstructions == null) || (this.FollowedInstructions?.Equals(other.FollowedInstructions) == true)) &&
                ((this.ExpiryDate == null && other.ExpiryDate == null) || (this.ExpiryDate?.Equals(other.ExpiryDate) == true)) &&
                ((this.Credits == null && other.Credits == null) || (this.Credits?.Equals(other.Credits) == true)) &&
                ((this.PurchasePrice == null && other.PurchasePrice == null) || (this.PurchasePrice?.Equals(other.PurchasePrice) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ChannelId = {this.ChannelId}");
            toStringOutput.Add($"Credentials = {(this.Credentials == null ? "null" : this.Credentials.ToString())}");
            toStringOutput.Add($"Facets = {(this.Facets == null ? "null" : this.Facets.ToString())}");
            toStringOutput.Add($"this.FollowedInstructions = {(this.FollowedInstructions == null ? "null" : this.FollowedInstructions.ToString())}");
            toStringOutput.Add($"this.ExpiryDate = {(this.ExpiryDate == null ? "null" : this.ExpiryDate.ToString())}");
            toStringOutput.Add($"this.Credits = {(this.Credits == null ? "null" : this.Credits.ToString())}");
            toStringOutput.Add($"this.PurchasePrice = {(this.PurchasePrice == null ? "null" : this.PurchasePrice.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}