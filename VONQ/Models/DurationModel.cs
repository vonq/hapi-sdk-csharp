// <copyright file="DurationModel.cs" company="APIMatic">
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
    /// DurationModel.
    /// </summary>
    public class DurationModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DurationModel"/> class.
        /// </summary>
        public DurationModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DurationModel"/> class.
        /// </summary>
        /// <param name="range">range.</param>
        /// <param name="period">period.</param>
        public DurationModel(
            Models.RangeEnum? range = null,
            double? period = null)
        {
            this.Range = range;
            this.Period = period;
        }

        /// <summary>
        /// The range of the duration
        /// </summary>
        [JsonProperty("range", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.RangeEnum? Range { get; set; }

        /// <summary>
        /// The duration a vacancy is actively listed on a channel
        /// </summary>
        [JsonProperty("period", NullValueHandling = NullValueHandling.Ignore)]
        public double? Period { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DurationModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is DurationModel other &&
                ((this.Range == null && other.Range == null) || (this.Range?.Equals(other.Range) == true)) &&
                ((this.Period == null && other.Period == null) || (this.Period?.Equals(other.Period) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Range = {(this.Range == null ? "null" : this.Range.ToString())}");
            toStringOutput.Add($"this.Period = {(this.Period == null ? "null" : this.Period.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}