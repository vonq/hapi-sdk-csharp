// <copyright file="ListChannelsResponseModel.cs" company="APIMatic">
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
    /// ListChannelsResponseModel.
    /// </summary>
    public class ListChannelsResponseModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListChannelsResponseModel"/> class.
        /// </summary>
        public ListChannelsResponseModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListChannelsResponseModel"/> class.
        /// </summary>
        /// <param name="count">count.</param>
        /// <param name="results">results.</param>
        /// <param name="next">next.</param>
        /// <param name="previous">previous.</param>
        public ListChannelsResponseModel(
            int count,
            List<Models.ChannelLiteModel> results,
            string next = null,
            string previous = null)
        {
            this.Count = count;
            this.Next = next;
            this.Previous = previous;
            this.Results = results;
        }

        /// <summary>
        /// Gets or sets Count.
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets Next.
        /// </summary>
        [JsonProperty("next", NullValueHandling = NullValueHandling.Include)]
        public string Next { get; set; }

        /// <summary>
        /// Gets or sets Previous.
        /// </summary>
        [JsonProperty("previous", NullValueHandling = NullValueHandling.Include)]
        public string Previous { get; set; }

        /// <summary>
        /// Gets or sets Results.
        /// </summary>
        [JsonProperty("results")]
        public List<Models.ChannelLiteModel> Results { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListChannelsResponseModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is ListChannelsResponseModel other &&
                this.Count.Equals(other.Count) &&
                ((this.Next == null && other.Next == null) || (this.Next?.Equals(other.Next) == true)) &&
                ((this.Previous == null && other.Previous == null) || (this.Previous?.Equals(other.Previous) == true)) &&
                ((this.Results == null && other.Results == null) || (this.Results?.Equals(other.Results) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Count = {this.Count}");
            toStringOutput.Add($"this.Next = {(this.Next == null ? "null" : this.Next == string.Empty ? "" : this.Next)}");
            toStringOutput.Add($"this.Previous = {(this.Previous == null ? "null" : this.Previous == string.Empty ? "" : this.Previous)}");
            toStringOutput.Add($"this.Results = {(this.Results == null ? "null" : $"[{string.Join(", ", this.Results)} ]")}");

            base.ToString(toStringOutput);
        }
    }
}