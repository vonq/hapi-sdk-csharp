// <copyright file="ContractModel.cs" company="APIMatic">
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
    /// ContractModel.
    /// </summary>
    public class ContractModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContractModel"/> class.
        /// </summary>
        public ContractModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContractModel"/> class.
        /// </summary>
        /// <param name="contractId">contract_id.</param>
        /// <param name="customerId">customer_id.</param>
        /// <param name="channelId">channel_id.</param>
        /// <param name="credentials">credentials.</param>
        /// <param name="className">class_name.</param>
        /// <param name="facets">facets.</param>
        /// <param name="product">product.</param>
        /// <param name="postingRequirements">posting_requirements.</param>
        /// <param name="expiryDate">expiry_date.</param>
        /// <param name="credits">credits.</param>
        /// <param name="purchasePrice">purchase_price.</param>
        public ContractModel(
            string contractId,
            string customerId,
            double channelId,
            object credentials,
            string className,
            object facets,
            Models.ContractProductModel product,
            List<Models.FacetModel> postingRequirements,
            DateTime? expiryDate = null,
            double? credits = null,
            Models.ContractPurchasePriceModel purchasePrice = null)
        {
            this.ContractId = contractId;
            this.CustomerId = customerId;
            this.ChannelId = channelId;
            this.Credentials = credentials;
            this.ClassName = className;
            this.Facets = facets;
            this.Product = product;
            this.PostingRequirements = postingRequirements;
            this.ExpiryDate = expiryDate;
            this.Credits = credits;
            this.PurchasePrice = purchasePrice;
        }

        /// <summary>
        /// The identifier of the Contract. To be used when creating a Campaign
        /// </summary>
        [JsonProperty("contract_id")]
        public string ContractId { get; set; }

        /// <summary>
        /// The customer_id this contract belongs to. Based on the original `X-Customer-Id` header used when the contract was created.
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        /// <summary>
        /// The Channel (job board) the contract is to be used for
        /// </summary>
        [JsonProperty("channel_id")]
        public double ChannelId { get; set; }

        /// <summary>
        /// AES Encrypted credentials
        /// </summary>
        [JsonProperty("credentials")]
        public object Credentials { get; set; }

        /// <summary>
        /// Channel slug
        /// </summary>
        [JsonProperty("class_name")]
        public string ClassName { get; set; }

        /// <summary>
        /// An object with contract parameters
        /// </summary>
        [JsonProperty("facets")]
        public object Facets { get; set; }

        /// <summary>
        /// The Product to be used in combination with the Contract when ordering a Campaign.
        /// </summary>
        [JsonProperty("product")]
        public Models.ContractProductModel Product { get; set; }

        /// <summary>
        /// A list of the Contract Channel's Facets
        /// </summary>
        [JsonProperty("posting_requirements")]
        public List<Models.FacetModel> PostingRequirements { get; set; }

        /// <summary>
        /// Gets or sets ExpiryDate.
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("expiry_date", NullValueHandling = NullValueHandling.Include)]
        public DateTime? ExpiryDate { get; set; }

        /// <summary>
        /// Gets or sets Credits.
        /// </summary>
        [JsonProperty("credits", NullValueHandling = NullValueHandling.Include)]
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

            return $"ContractModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is ContractModel other &&
                ((this.ContractId == null && other.ContractId == null) || (this.ContractId?.Equals(other.ContractId) == true)) &&
                ((this.CustomerId == null && other.CustomerId == null) || (this.CustomerId?.Equals(other.CustomerId) == true)) &&
                this.ChannelId.Equals(other.ChannelId) &&
                ((this.Credentials == null && other.Credentials == null) || (this.Credentials?.Equals(other.Credentials) == true)) &&
                ((this.ClassName == null && other.ClassName == null) || (this.ClassName?.Equals(other.ClassName) == true)) &&
                ((this.Facets == null && other.Facets == null) || (this.Facets?.Equals(other.Facets) == true)) &&
                ((this.Product == null && other.Product == null) || (this.Product?.Equals(other.Product) == true)) &&
                ((this.PostingRequirements == null && other.PostingRequirements == null) || (this.PostingRequirements?.Equals(other.PostingRequirements) == true)) &&
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
            toStringOutput.Add($"this.ContractId = {(this.ContractId == null ? "null" : this.ContractId == string.Empty ? "" : this.ContractId)}");
            toStringOutput.Add($"this.CustomerId = {(this.CustomerId == null ? "null" : this.CustomerId == string.Empty ? "" : this.CustomerId)}");
            toStringOutput.Add($"this.ChannelId = {this.ChannelId}");
            toStringOutput.Add($"Credentials = {(this.Credentials == null ? "null" : this.Credentials.ToString())}");
            toStringOutput.Add($"this.ClassName = {(this.ClassName == null ? "null" : this.ClassName == string.Empty ? "" : this.ClassName)}");
            toStringOutput.Add($"Facets = {(this.Facets == null ? "null" : this.Facets.ToString())}");
            toStringOutput.Add($"this.Product = {(this.Product == null ? "null" : this.Product.ToString())}");
            toStringOutput.Add($"this.PostingRequirements = {(this.PostingRequirements == null ? "null" : $"[{string.Join(", ", this.PostingRequirements)} ]")}");
            toStringOutput.Add($"this.ExpiryDate = {(this.ExpiryDate == null ? "null" : this.ExpiryDate.ToString())}");
            toStringOutput.Add($"this.Credits = {(this.Credits == null ? "null" : this.Credits.ToString())}");
            toStringOutput.Add($"this.PurchasePrice = {(this.PurchasePrice == null ? "null" : this.PurchasePrice.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}