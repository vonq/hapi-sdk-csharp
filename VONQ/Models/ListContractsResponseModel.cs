// <copyright file="ListContractsResponseModel.cs" company="APIMatic">
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
    /// ListContractsResponseModel.
    /// </summary>
    public class ListContractsResponseModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListContractsResponseModel"/> class.
        /// </summary>
        public ListContractsResponseModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListContractsResponseModel"/> class.
        /// </summary>
        /// <param name="count">count.</param>
        /// <param name="previous">previous.</param>
        /// <param name="next">next.</param>
        /// <param name="results">results.</param>
        public ListContractsResponseModel(
            double? count = null,
            string previous = null,
            string next = null,
            List<Models.ContractModel> results = null)
        {
            this.Count = count;
            this.Previous = previous;
            this.Next = next;
            this.Results = results;
        }

        /// <summary>
        /// count of elements in results
        /// </summary>
        [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
        public double? Count { get; set; }

        /// <summary>
        /// link to get previous results
        /// </summary>
        [JsonProperty("previous", NullValueHandling = NullValueHandling.Ignore)]
        public string Previous { get; set; }

        /// <summary>
        /// link to get next results
        /// </summary>
        [JsonProperty("next", NullValueHandling = NullValueHandling.Ignore)]
        public string Next { get; set; }

        /// <summary>
        /// Gets or sets Results.
        /// </summary>
        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.ContractModel> Results { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListContractsResponseModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is ListContractsResponseModel other &&
                ((this.Count == null && other.Count == null) || (this.Count?.Equals(other.Count) == true)) &&
                ((this.Previous == null && other.Previous == null) || (this.Previous?.Equals(other.Previous) == true)) &&
                ((this.Next == null && other.Next == null) || (this.Next?.Equals(other.Next) == true)) &&
                ((this.Results == null && other.Results == null) || (this.Results?.Equals(other.Results) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Count = {(this.Count == null ? "null" : this.Count.ToString())}");
            toStringOutput.Add($"this.Previous = {(this.Previous == null ? "null" : this.Previous == string.Empty ? "" : this.Previous)}");
            toStringOutput.Add($"this.Next = {(this.Next == null ? "null" : this.Next == string.Empty ? "" : this.Next)}");
            toStringOutput.Add($"this.Results = {(this.Results == null ? "null" : $"[{string.Join(", ", this.Results)} ]")}");

            base.ToString(toStringOutput);
        }
    }
}