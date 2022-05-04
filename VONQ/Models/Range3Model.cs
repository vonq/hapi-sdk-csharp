// <copyright file="Range3Model.cs" company="APIMatic">
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
    /// Range3Model.
    /// </summary>
    public class Range3Model : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Range3Model"/> class.
        /// </summary>
        public Range3Model()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Range3Model"/> class.
        /// </summary>
        /// <param name="to">to.</param>
        /// <param name="from">from.</param>
        /// <param name="currency">currency.</param>
        public Range3Model(
            double to,
            double? from = null,
            string currency = null)
        {
            this.From = from;
            this.To = to;
            this.Currency = currency;
        }

        /// <summary>
        /// Minimum salary indication of the indicated period, if given, cannot be greater
        /// than 'to', but equal to 'to' is allowed. This integer value should be specified in units (not cents).
        /// </summary>
        [JsonProperty("from", NullValueHandling = NullValueHandling.Ignore)]
        public double? From { get; set; }

        /// <summary>
        /// Maximum salary indication of the indicated period. This integer value should be specified in units (not cents).
        /// </summary>
        [JsonProperty("to")]
        public double To { get; set; }

        /// <summary>
        /// The currency in which the range amount is expressed. Must be a valid ISO-4217 value.
        /// </summary>
        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        public string Currency { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Range3Model : ({string.Join(", ", toStringOutput)})";
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

            return obj is Range3Model other &&
                ((this.From == null && other.From == null) || (this.From?.Equals(other.From) == true)) &&
                this.To.Equals(other.To) &&
                ((this.Currency == null && other.Currency == null) || (this.Currency?.Equals(other.Currency) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.From = {(this.From == null ? "null" : this.From.ToString())}");
            toStringOutput.Add($"this.To = {this.To}");
            toStringOutput.Add($"this.Currency = {(this.Currency == null ? "null" : this.Currency == string.Empty ? "" : this.Currency)}");

            base.ToString(toStringOutput);
        }
    }
}