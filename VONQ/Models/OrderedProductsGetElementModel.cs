// <copyright file="OrderedProductsGetElementModel.cs" company="APIMatic">
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
    /// OrderedProductsGetElementModel.
    /// </summary>
    public class OrderedProductsGetElementModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderedProductsGetElementModel"/> class.
        /// </summary>
        public OrderedProductsGetElementModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderedProductsGetElementModel"/> class.
        /// </summary>
        /// <param name="productId">productId.</param>
        /// <param name="status">status.</param>
        /// <param name="statusDescription">statusDescription.</param>
        /// <param name="deliveredOn">deliveredOn.</param>
        /// <param name="duration">duration.</param>
        /// <param name="durationPeriod">durationPeriod.</param>
        /// <param name="utm">utm.</param>
        /// <param name="jobBoardLink">jobBoardLink.</param>
        /// <param name="contractId">contractId.</param>
        /// <param name="postingRequirements">postingRequirements.</param>
        public OrderedProductsGetElementModel(
            string productId = null,
            string status = null,
            string statusDescription = null,
            string deliveredOn = null,
            string duration = null,
            Models.DurationModel durationPeriod = null,
            string utm = null,
            string jobBoardLink = null,
            string contractId = null,
            Models.PostingRequirementsModel postingRequirements = null)
        {
            this.ProductId = productId;
            this.Status = status;
            this.StatusDescription = statusDescription;
            this.DeliveredOn = deliveredOn;
            this.Duration = duration;
            this.DurationPeriod = durationPeriod;
            this.Utm = utm;
            this.JobBoardLink = jobBoardLink;
            this.ContractId = contractId;
            this.PostingRequirements = postingRequirements;
        }

        /// <summary>
        /// Product Identification
        /// </summary>
        [JsonProperty("productId", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductId { get; set; }

        /// <summary>
        /// Status per product
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        /// <summary>
        /// Status description, additional status information
        /// </summary>
        [JsonProperty("statusDescription", NullValueHandling = NullValueHandling.Ignore)]
        public string StatusDescription { get; set; }

        /// <summary>
        /// Date when the channel went online
        /// </summary>
        [JsonProperty("deliveredOn", NullValueHandling = NullValueHandling.Ignore)]
        public string DeliveredOn { get; set; }

        /// <summary>
        /// How long will the `Product` be online. [DEPRECATED] please instead use the `durationPeriod`
        /// </summary>
        [JsonProperty("duration", NullValueHandling = NullValueHandling.Ignore)]
        public string Duration { get; set; }

        /// <summary>
        /// Gets or sets DurationPeriod.
        /// </summary>
        [JsonProperty("durationPeriod", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DurationModel DurationPeriod { get; set; }

        /// <summary>
        /// Tracking codes
        /// </summary>
        [JsonProperty("utm", NullValueHandling = NullValueHandling.Ignore)]
        public string Utm { get; set; }

        /// <summary>
        /// Link to the job ad on the channel. Sometimes this link is not available from a job board, then the product homepage is returned.
        /// </summary>
        [JsonProperty("jobBoardLink", NullValueHandling = NullValueHandling.Ignore)]
        public string JobBoardLink { get; set; }

        /// <summary>
        /// Contract Identifier for My Contracts product
        /// </summary>
        [JsonProperty("contractId", NullValueHandling = NullValueHandling.Ignore)]
        public string ContractId { get; set; }

        /// <summary>
        /// Gets or sets PostingRequirements.
        /// </summary>
        [JsonProperty("postingRequirements", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PostingRequirementsModel PostingRequirements { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderedProductsGetElementModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is OrderedProductsGetElementModel other &&
                ((this.ProductId == null && other.ProductId == null) || (this.ProductId?.Equals(other.ProductId) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.StatusDescription == null && other.StatusDescription == null) || (this.StatusDescription?.Equals(other.StatusDescription) == true)) &&
                ((this.DeliveredOn == null && other.DeliveredOn == null) || (this.DeliveredOn?.Equals(other.DeliveredOn) == true)) &&
                ((this.Duration == null && other.Duration == null) || (this.Duration?.Equals(other.Duration) == true)) &&
                ((this.DurationPeriod == null && other.DurationPeriod == null) || (this.DurationPeriod?.Equals(other.DurationPeriod) == true)) &&
                ((this.Utm == null && other.Utm == null) || (this.Utm?.Equals(other.Utm) == true)) &&
                ((this.JobBoardLink == null && other.JobBoardLink == null) || (this.JobBoardLink?.Equals(other.JobBoardLink) == true)) &&
                ((this.ContractId == null && other.ContractId == null) || (this.ContractId?.Equals(other.ContractId) == true)) &&
                ((this.PostingRequirements == null && other.PostingRequirements == null) || (this.PostingRequirements?.Equals(other.PostingRequirements) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ProductId = {(this.ProductId == null ? "null" : this.ProductId == string.Empty ? "" : this.ProductId)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status == string.Empty ? "" : this.Status)}");
            toStringOutput.Add($"this.StatusDescription = {(this.StatusDescription == null ? "null" : this.StatusDescription == string.Empty ? "" : this.StatusDescription)}");
            toStringOutput.Add($"this.DeliveredOn = {(this.DeliveredOn == null ? "null" : this.DeliveredOn == string.Empty ? "" : this.DeliveredOn)}");
            toStringOutput.Add($"this.Duration = {(this.Duration == null ? "null" : this.Duration == string.Empty ? "" : this.Duration)}");
            toStringOutput.Add($"this.DurationPeriod = {(this.DurationPeriod == null ? "null" : this.DurationPeriod.ToString())}");
            toStringOutput.Add($"this.Utm = {(this.Utm == null ? "null" : this.Utm == string.Empty ? "" : this.Utm)}");
            toStringOutput.Add($"this.JobBoardLink = {(this.JobBoardLink == null ? "null" : this.JobBoardLink == string.Empty ? "" : this.JobBoardLink)}");
            toStringOutput.Add($"this.ContractId = {(this.ContractId == null ? "null" : this.ContractId == string.Empty ? "" : this.ContractId)}");
            toStringOutput.Add($"this.PostingRequirements = {(this.PostingRequirements == null ? "null" : this.PostingRequirements.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}