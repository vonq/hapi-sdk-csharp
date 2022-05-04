// <copyright file="AutocompleteModel.cs" company="APIMatic">
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
    /// AutocompleteModel.
    /// </summary>
    public class AutocompleteModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutocompleteModel"/> class.
        /// </summary>
        public AutocompleteModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutocompleteModel"/> class.
        /// </summary>
        /// <param name="requiredParameters">required_parameters.</param>
        public AutocompleteModel(
            List<Models.RequiredParameterEnum> requiredParameters)
        {
            this.RequiredParameters = requiredParameters;
        }

        /// <summary>
        /// List of keys to pass to  the body of the request calling the [List autocomplete values for posting requirements](https://vonq.stoplight.io/docs/hapi/b3A6MzM2MDEzODk-list-autocomplete-values-for-posting-requirement) endpoint.
        /// </summary>
        [JsonProperty("required_parameters", ItemConverterType = typeof(StringEnumConverter))]
        public List<Models.RequiredParameterEnum> RequiredParameters { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"AutocompleteModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is AutocompleteModel other &&
                ((this.RequiredParameters == null && other.RequiredParameters == null) || (this.RequiredParameters?.Equals(other.RequiredParameters) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.RequiredParameters = {(this.RequiredParameters == null ? "null" : $"[{string.Join(", ", this.RequiredParameters)} ]")}");

            base.ToString(toStringOutput);
        }
    }
}