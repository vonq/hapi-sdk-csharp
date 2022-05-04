// <copyright file="AutocompleteValuesResponseModel.cs" company="APIMatic">
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
    /// AutocompleteValuesResponseModel.
    /// </summary>
    public class AutocompleteValuesResponseModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutocompleteValuesResponseModel"/> class.
        /// </summary>
        public AutocompleteValuesResponseModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutocompleteValuesResponseModel"/> class.
        /// </summary>
        /// <param name="key">key.</param>
        /// <param name="label">label.</param>
        public AutocompleteValuesResponseModel(
            string key,
            string label)
        {
            this.Key = key;
            this.Label = label;
        }

        /// <summary>
        /// Gets or sets Key.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets Label.
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"AutocompleteValuesResponseModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is AutocompleteValuesResponseModel other &&
                ((this.Key == null && other.Key == null) || (this.Key?.Equals(other.Key) == true)) &&
                ((this.Label == null && other.Label == null) || (this.Label?.Equals(other.Label) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Key = {(this.Key == null ? "null" : this.Key == string.Empty ? "" : this.Key)}");
            toStringOutput.Add($"this.Label = {(this.Label == null ? "null" : this.Label == string.Empty ? "" : this.Label)}");

            base.ToString(toStringOutput);
        }
    }
}