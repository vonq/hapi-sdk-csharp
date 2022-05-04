// <copyright file="FacetAutocompleteModel.cs" company="APIMatic">
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
    /// FacetAutocompleteModel.
    /// </summary>
    public class FacetAutocompleteModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FacetAutocompleteModel"/> class.
        /// </summary>
        public FacetAutocompleteModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FacetAutocompleteModel"/> class.
        /// </summary>
        /// <param name="term">term.</param>
        /// <param name="credentials">credentials.</param>
        public FacetAutocompleteModel(
            string term = null,
            object credentials = null)
        {
            this.Term = term;
            this.Credentials = credentials;
        }

        /// <summary>
        /// Gets or sets Term.
        /// </summary>
        [JsonProperty("term", NullValueHandling = NullValueHandling.Ignore)]
        public string Term { get; set; }

        /// <summary>
        /// An object with `contract_credentials` data
        /// </summary>
        [JsonProperty("credentials", NullValueHandling = NullValueHandling.Ignore)]
        public object Credentials { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"FacetAutocompleteModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is FacetAutocompleteModel other &&
                ((this.Term == null && other.Term == null) || (this.Term?.Equals(other.Term) == true)) &&
                ((this.Credentials == null && other.Credentials == null) || (this.Credentials?.Equals(other.Credentials) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Term = {(this.Term == null ? "null" : this.Term == string.Empty ? "" : this.Term)}");
            toStringOutput.Add($"Credentials = {(this.Credentials == null ? "null" : this.Credentials.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}