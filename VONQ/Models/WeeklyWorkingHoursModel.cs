// <copyright file="WeeklyWorkingHoursModel.cs" company="APIMatic">
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
    /// WeeklyWorkingHoursModel.
    /// </summary>
    public class WeeklyWorkingHoursModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeeklyWorkingHoursModel"/> class.
        /// </summary>
        public WeeklyWorkingHoursModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeeklyWorkingHoursModel"/> class.
        /// </summary>
        /// <param name="to">to.</param>
        public WeeklyWorkingHoursModel(
            List<string> to)
        {
            this.To = to;
        }

        /// <summary>
        /// Gets or sets To.
        /// </summary>
        [JsonProperty("to")]
        public List<string> To { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"WeeklyWorkingHoursModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is WeeklyWorkingHoursModel other &&
                ((this.To == null && other.To == null) || (this.To?.Equals(other.To) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.To = {(this.To == null ? "null" : $"[{string.Join(", ", this.To)} ]")}");

            base.ToString(toStringOutput);
        }
    }
}