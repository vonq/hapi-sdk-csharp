// <copyright file="FacetOptionShowFacetsModel.cs" company="APIMatic">
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
    /// FacetOptionShowFacetsModel.
    /// </summary>
    public class FacetOptionShowFacetsModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FacetOptionShowFacetsModel"/> class.
        /// </summary>
        public FacetOptionShowFacetsModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FacetOptionShowFacetsModel"/> class.
        /// </summary>
        /// <param name="facet">facet.</param>
        public FacetOptionShowFacetsModel(
            string facet)
        {
            this.Facet = facet;
        }

        /// <summary>
        /// The facet name that becomes required when this option is chosen.
        /// </summary>
        [JsonProperty("facet")]
        public string Facet { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"FacetOptionShowFacetsModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is FacetOptionShowFacetsModel other &&
                ((this.Facet == null && other.Facet == null) || (this.Facet?.Equals(other.Facet) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Facet = {(this.Facet == null ? "null" : this.Facet == string.Empty ? "" : this.Facet)}");

            base.ToString(toStringOutput);
        }
    }
}