// <copyright file="FacetOptionModel.cs" company="APIMatic">
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
    /// FacetOptionModel.
    /// </summary>
    public class FacetOptionModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FacetOptionModel"/> class.
        /// </summary>
        public FacetOptionModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FacetOptionModel"/> class.
        /// </summary>
        /// <param name="mDefault">default.</param>
        /// <param name="key">key.</param>
        /// <param name="label">label.</param>
        /// <param name="sort">sort.</param>
        /// <param name="show">show.</param>
        public FacetOptionModel(
            string mDefault,
            string key,
            string label,
            string sort,
            List<Models.FacetOptionShowFacetsModel> show = null)
        {
            this.MDefault = mDefault;
            this.Key = key;
            this.Label = label;
            this.Sort = sort;
            this.Show = show;
        }

        /// <summary>
        /// Whether the option should be the default choice when rendering the SELECT.
        /// </summary>
        [JsonProperty("default")]
        public string MDefault { get; set; }

        /// <summary>
        /// The value to be used when setting the value of the facet when this option is selected.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// The option's user-friendly label
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }

        /// <summary>
        /// The order of the option in the list of options. lower value means higher rank.
        /// </summary>
        [JsonProperty("sort")]
        public string Sort { get; set; }

        /// <summary>
        /// References to Facets that becomes required when this option is selected
        /// </summary>
        [JsonProperty("show", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.FacetOptionShowFacetsModel> Show { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"FacetOptionModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is FacetOptionModel other &&
                ((this.MDefault == null && other.MDefault == null) || (this.MDefault?.Equals(other.MDefault) == true)) &&
                ((this.Key == null && other.Key == null) || (this.Key?.Equals(other.Key) == true)) &&
                ((this.Label == null && other.Label == null) || (this.Label?.Equals(other.Label) == true)) &&
                ((this.Sort == null && other.Sort == null) || (this.Sort?.Equals(other.Sort) == true)) &&
                ((this.Show == null && other.Show == null) || (this.Show?.Equals(other.Show) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MDefault = {(this.MDefault == null ? "null" : this.MDefault == string.Empty ? "" : this.MDefault)}");
            toStringOutput.Add($"this.Key = {(this.Key == null ? "null" : this.Key == string.Empty ? "" : this.Key)}");
            toStringOutput.Add($"this.Label = {(this.Label == null ? "null" : this.Label == string.Empty ? "" : this.Label)}");
            toStringOutput.Add($"this.Sort = {(this.Sort == null ? "null" : this.Sort == string.Empty ? "" : this.Sort)}");
            toStringOutput.Add($"this.Show = {(this.Show == null ? "null" : $"[{string.Join(", ", this.Show)} ]")}");

            base.ToString(toStringOutput);
        }
    }
}