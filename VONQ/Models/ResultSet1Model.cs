// <copyright file="ResultSet1Model.cs" company="APIMatic">
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
    /// ResultSet1Model.
    /// </summary>
    public class ResultSet1Model : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResultSet1Model"/> class.
        /// </summary>
        public ResultSet1Model()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultSet1Model"/> class.
        /// </summary>
        /// <param name="total">total.</param>
        /// <param name="limit">limit.</param>
        /// <param name="offset">offset.</param>
        /// <param name="data">data.</param>
        public ResultSet1Model(
            double? total = null,
            double? limit = null,
            double? offset = null,
            List<Models.CampaignModel> data = null)
        {
            this.Total = total;
            this.Limit = limit;
            this.Offset = offset;
            this.Data = data;
        }

        /// <summary>
        /// Number of total results
        /// </summary>
        [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
        public double? Total { get; set; }

        /// <summary>
        /// Results page size
        /// </summary>
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public double? Limit { get; set; }

        /// <summary>
        /// Initial starting index for the results
        /// </summary>
        [JsonProperty("offset", NullValueHandling = NullValueHandling.Ignore)]
        public double? Offset { get; set; }

        /// <summary>
        /// A Page of Campaign Objects
        /// </summary>
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.CampaignModel> Data { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ResultSet1Model : ({string.Join(", ", toStringOutput)})";
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

            return obj is ResultSet1Model other &&
                ((this.Total == null && other.Total == null) || (this.Total?.Equals(other.Total) == true)) &&
                ((this.Limit == null && other.Limit == null) || (this.Limit?.Equals(other.Limit) == true)) &&
                ((this.Offset == null && other.Offset == null) || (this.Offset?.Equals(other.Offset) == true)) &&
                ((this.Data == null && other.Data == null) || (this.Data?.Equals(other.Data) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Total = {(this.Total == null ? "null" : this.Total.ToString())}");
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
            toStringOutput.Add($"this.Offset = {(this.Offset == null ? "null" : this.Offset.ToString())}");
            toStringOutput.Add($"this.Data = {(this.Data == null ? "null" : $"[{string.Join(", ", this.Data)} ]")}");

            base.ToString(toStringOutput);
        }
    }
}