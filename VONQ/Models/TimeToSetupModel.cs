// <copyright file="TimeToSetupModel.cs" company="APIMatic">
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
    /// TimeToSetupModel.
    /// </summary>
    public class TimeToSetupModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeToSetupModel"/> class.
        /// </summary>
        public TimeToSetupModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeToSetupModel"/> class.
        /// </summary>
        /// <param name="range">range.</param>
        /// <param name="period">period.</param>
        public TimeToSetupModel(
            Models.Range2Enum? range = null,
            double? period = null)
        {
            this.Range = range;
            this.Period = period;
        }

        /// <summary>
        /// The range of the time to setup required by the supplier
        /// </summary>
        [JsonProperty("range", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.Range2Enum? Range { get; set; }

        /// <summary>
        /// The period of the time to setup required by the supplier
        /// </summary>
        [JsonProperty("period", NullValueHandling = NullValueHandling.Ignore)]
        public double? Period { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TimeToSetupModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is TimeToSetupModel other &&
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