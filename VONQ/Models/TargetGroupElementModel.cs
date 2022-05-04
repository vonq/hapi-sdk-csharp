// <copyright file="TargetGroupElementModel.cs" company="APIMatic">
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
    /// TargetGroupElementModel.
    /// </summary>
    public class TargetGroupElementModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TargetGroupElementModel"/> class.
        /// </summary>
        public TargetGroupElementModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TargetGroupElementModel"/> class.
        /// </summary>
        /// <param name="description">description.</param>
        /// <param name="vonqId">vonqId.</param>
        public TargetGroupElementModel(
            string description,
            string vonqId)
        {
            this.Description = description;
            this.VonqId = vonqId;
        }

        /// <summary>
        /// The vonq name for this target group element
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The Vonq ID representing this concept, as indicated in the [**`Taxonomy Endpoints`**](#reference/experimental-products-search)
        /// </summary>
        [JsonProperty("vonqId")]
        public string VonqId { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TargetGroupElementModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is TargetGroupElementModel other &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.VonqId == null && other.VonqId == null) || (this.VonqId?.Equals(other.VonqId) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description == string.Empty ? "" : this.Description)}");
            toStringOutput.Add($"this.VonqId = {(this.VonqId == null ? "null" : this.VonqId == string.Empty ? "" : this.VonqId)}");

            base.ToString(toStringOutput);
        }
    }
}