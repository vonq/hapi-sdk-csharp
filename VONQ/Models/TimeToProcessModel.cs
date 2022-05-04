// <copyright file="TimeToProcessModel.cs" company="APIMatic">
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
    /// TimeToProcessModel.
    /// </summary>
    public class TimeToProcessModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeToProcessModel"/> class.
        /// </summary>
        public TimeToProcessModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeToProcessModel"/> class.
        /// </summary>
        /// <param name="range">range.</param>
        /// <param name="period">period.</param>
        public TimeToProcessModel(
            Models.Range1Enum? range = null,
            double? period = null)
        {
            this.Range = range;
            this.Period = period;
        }

        /// <summary>
        /// The range of the time to process
        /// </summary>
        [JsonProperty("range", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.Range1Enum? Range { get; set; }

        /// <summary>
        /// The period of the time to process
        /// </summary>
        [JsonProperty("period", NullValueHandling = NullValueHandling.Ignore)]
        public double? Period { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TimeToProcessModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is TimeToProcessModel other &&
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