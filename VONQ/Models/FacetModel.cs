// <copyright file="FacetModel.cs" company="APIMatic">
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
    /// FacetModel.
    /// </summary>
    public class FacetModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FacetModel"/> class.
        /// </summary>
        public FacetModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FacetModel"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="label">label.</param>
        /// <param name="sort">sort.</param>
        /// <param name="required">required.</param>
        /// <param name="type">type.</param>
        /// <param name="options">options.</param>
        /// <param name="rules">rules.</param>
        /// <param name="autocomplete">autocomplete.</param>
        public FacetModel(
            string name,
            string label,
            string sort,
            bool required,
            Models.TypeEnum type,
            List<Models.FacetOptionModel> options,
            List<Models.FacetRuleModel> rules = null,
            Models.AutocompleteModel autocomplete = null)
        {
            this.Name = name;
            this.Label = label;
            this.Sort = sort;
            this.Required = required;
            this.Type = type;
            this.Options = options;
            this.Rules = rules;
            this.Autocomplete = autocomplete;
        }

        /// <summary>
        /// The name of the Facet. To be used as a key when ordering a Campaign, under the `orderedProductsSpecs.postingRequirements` key.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The user facing label
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }

        /// <summary>
        /// The order in the list of vacancy fields to be displayed to the user when posting. Facets with lower `sort` values should be displayed first.
        /// </summary>
        [JsonProperty("sort")]
        public string Sort { get; set; }

        /// <summary>
        /// Whether the Facet is required when ordering a Campaign.
        /// </summary>
        [JsonProperty("required")]
        public bool Required { get; set; }

        /// <summary>
        /// The type of UI and data structure to be used to input and store values for this Facet.
        /// </summary>
        [JsonProperty("type", ItemConverterType = typeof(StringEnumConverter))]
        public Models.TypeEnum Type { get; set; }

        /// <summary>
        /// list of choices for this Facet's value.
        /// </summary>
        [JsonProperty("options")]
        public List<Models.FacetOptionModel> Options { get; set; }

        /// <summary>
        /// special validation rules that apply for this Facet's value
        /// </summary>
        [JsonProperty("rules", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.FacetRuleModel> Rules { get; set; }

        /// <summary>
        /// Used for Facets whose value choices need to be fetched through an additional call to the [List autocomplete values for posting requirements](https://vonq.stoplight.io/docs/hapi/b3A6MzM2MDEzODk-list-autocomplete-values-for-posting-requirement) endpoint.
        /// </summary>
        [JsonProperty("autocomplete", NullValueHandling = NullValueHandling.Include)]
        public Models.AutocompleteModel Autocomplete { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"FacetModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is FacetModel other &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Label == null && other.Label == null) || (this.Label?.Equals(other.Label) == true)) &&
                ((this.Sort == null && other.Sort == null) || (this.Sort?.Equals(other.Sort) == true)) &&
                this.Required.Equals(other.Required) &&
                this.Type.Equals(other.Type) &&
                ((this.Options == null && other.Options == null) || (this.Options?.Equals(other.Options) == true)) &&
                ((this.Rules == null && other.Rules == null) || (this.Rules?.Equals(other.Rules) == true)) &&
                ((this.Autocomplete == null && other.Autocomplete == null) || (this.Autocomplete?.Equals(other.Autocomplete) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.Label = {(this.Label == null ? "null" : this.Label == string.Empty ? "" : this.Label)}");
            toStringOutput.Add($"this.Sort = {(this.Sort == null ? "null" : this.Sort == string.Empty ? "" : this.Sort)}");
            toStringOutput.Add($"this.Required = {this.Required}");
            toStringOutput.Add($"this.Type = {this.Type}");
            toStringOutput.Add($"this.Options = {(this.Options == null ? "null" : $"[{string.Join(", ", this.Options)} ]")}");
            toStringOutput.Add($"this.Rules = {(this.Rules == null ? "null" : $"[{string.Join(", ", this.Rules)} ]")}");
            toStringOutput.Add($"this.Autocomplete = {(this.Autocomplete == null ? "null" : this.Autocomplete.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}