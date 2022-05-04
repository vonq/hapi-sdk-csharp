// <copyright file="OrderedProductsStatusItemModel.cs" company="APIMatic">
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
    /// OrderedProductsStatusItemModel.
    /// </summary>
    public class OrderedProductsStatusItemModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderedProductsStatusItemModel"/> class.
        /// </summary>
        public OrderedProductsStatusItemModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderedProductsStatusItemModel"/> class.
        /// </summary>
        /// <param name="productId">productId.</param>
        /// <param name="status">status.</param>
        /// <param name="statusDescription">statusDescription.</param>
        public OrderedProductsStatusItemModel(
            string productId = null,
            Models.ChannelStatusEnum? status = null,
            string statusDescription = null)
        {
            this.ProductId = productId;
            this.Status = status;
            this.StatusDescription = statusDescription;
        }

        /// <summary>
        /// Gets or sets ProductId.
        /// </summary>
        [JsonProperty("productId", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductId { get; set; }

        /// <summary>
        /// Status of the product. One of the following
        /// </summary>
        [JsonProperty("status", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.ChannelStatusEnum? Status { get; set; }

        /// <summary>
        /// Additional information about product status
        /// </summary>
        [JsonProperty("statusDescription", NullValueHandling = NullValueHandling.Ignore)]
        public string StatusDescription { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderedProductsStatusItemModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is OrderedProductsStatusItemModel other &&
                ((this.ProductId == null && other.ProductId == null) || (this.ProductId?.Equals(other.ProductId) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.StatusDescription == null && other.StatusDescription == null) || (this.StatusDescription?.Equals(other.StatusDescription) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ProductId = {(this.ProductId == null ? "null" : this.ProductId == string.Empty ? "" : this.ProductId)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.StatusDescription = {(this.StatusDescription == null ? "null" : this.StatusDescription == string.Empty ? "" : this.StatusDescription)}");

            base.ToString(toStringOutput);
        }
    }
}