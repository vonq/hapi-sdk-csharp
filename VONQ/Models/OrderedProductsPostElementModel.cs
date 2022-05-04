// <copyright file="OrderedProductsPostElementModel.cs" company="APIMatic">
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
    /// OrderedProductsPostElementModel.
    /// </summary>
    public class OrderedProductsPostElementModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderedProductsPostElementModel"/> class.
        /// </summary>
        public OrderedProductsPostElementModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderedProductsPostElementModel"/> class.
        /// </summary>
        /// <param name="productId">productId.</param>
        /// <param name="utm">utm.</param>
        /// <param name="contractId">contractId.</param>
        /// <param name="postingRequirements">postingRequirements.</param>
        public OrderedProductsPostElementModel(
            string productId = null,
            string utm = null,
            string contractId = null,
            Models.PostingRequirementsModel postingRequirements = null)
        {
            this.ProductId = productId;
            this.Utm = utm;
            this.ContractId = contractId;
            this.PostingRequirements = postingRequirements;
        }

        /// <summary>
        /// Product Identification
        /// </summary>
        [JsonProperty("productId", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductId { get; set; }

        /// <summary>
        /// Query string for UTM parameters
        /// **Pattern:** `/^([%.-_!*a-zA-Z0-9]{1,}=[%.-_!*+,;$()a-zA-Z0-9]{1,}[&]{0,}){1,}$/`
        /// </summary>
        [JsonProperty("utm", NullValueHandling = NullValueHandling.Ignore)]
        public string Utm { get; set; }

        /// <summary>
        /// Contract Identifier needed for My Contracts product
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

            return $"OrderedProductsPostElementModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is OrderedProductsPostElementModel other &&
                ((this.ProductId == null && other.ProductId == null) || (this.ProductId?.Equals(other.ProductId) == true)) &&
                ((this.Utm == null && other.Utm == null) || (this.Utm?.Equals(other.Utm) == true)) &&
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
            toStringOutput.Add($"this.Utm = {(this.Utm == null ? "null" : this.Utm == string.Empty ? "" : this.Utm)}");
            toStringOutput.Add($"this.ContractId = {(this.ContractId == null ? "null" : this.ContractId == string.Empty ? "" : this.ContractId)}");
            toStringOutput.Add($"this.PostingRequirements = {(this.PostingRequirements == null ? "null" : this.PostingRequirements.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}