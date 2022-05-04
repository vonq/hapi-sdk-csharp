// <copyright file="OrderedProductsSpecModel.cs" company="APIMatic">
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
    /// OrderedProductsSpecModel.
    /// </summary>
    public class OrderedProductsSpecModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderedProductsSpecModel"/> class.
        /// </summary>
        public OrderedProductsSpecModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderedProductsSpecModel"/> class.
        /// </summary>
        /// <param name="productId">productId.</param>
        /// <param name="utm">utm.</param>
        public OrderedProductsSpecModel(
            List<string> productId,
            List<string> utm)
        {
            this.ProductId = productId;
            this.Utm = utm;
        }

        /// <summary>
        /// Gets or sets ProductId.
        /// </summary>
        [JsonProperty("productId")]
        public List<string> ProductId { get; set; }

        /// <summary>
        /// Gets or sets Utm.
        /// </summary>
        [JsonProperty("utm")]
        public List<string> Utm { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderedProductsSpecModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is OrderedProductsSpecModel other &&
                ((this.ProductId == null && other.ProductId == null) || (this.ProductId?.Equals(other.ProductId) == true)) &&
                ((this.Utm == null && other.Utm == null) || (this.Utm?.Equals(other.Utm) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ProductId = {(this.ProductId == null ? "null" : $"[{string.Join(", ", this.ProductId)} ]")}");
            toStringOutput.Add($"this.Utm = {(this.Utm == null ? "null" : $"[{string.Join(", ", this.Utm)} ]")}");

            base.ToString(toStringOutput);
        }
    }
}