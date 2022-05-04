// <copyright file="ProductLiteModel.cs" company="APIMatic">
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
    /// ProductLiteModel.
    /// </summary>
    public class ProductLiteModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductLiteModel"/> class.
        /// </summary>
        public ProductLiteModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductLiteModel"/> class.
        /// </summary>
        /// <param name="productId">product_id.</param>
        /// <param name="title">title.</param>
        public ProductLiteModel(
            string productId,
            string title)
        {
            this.ProductId = productId;
            this.Title = title;
        }

        /// <summary>
        /// Gets or sets ProductId.
        /// </summary>
        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets Title.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ProductLiteModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is ProductLiteModel other &&
                ((this.ProductId == null && other.ProductId == null) || (this.ProductId?.Equals(other.ProductId) == true)) &&
                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ProductId = {(this.ProductId == null ? "null" : this.ProductId == string.Empty ? "" : this.ProductId)}");
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title == string.Empty ? "" : this.Title)}");

            base.ToString(toStringOutput);
        }
    }
}