// <copyright file="SalaryIndicationModel.cs" company="APIMatic">
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
    /// SalaryIndicationModel.
    /// </summary>
    public class SalaryIndicationModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalaryIndicationModel"/> class.
        /// </summary>
        public SalaryIndicationModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalaryIndicationModel"/> class.
        /// </summary>
        /// <param name="period">period.</param>
        /// <param name="range">range.</param>
        public SalaryIndicationModel(
            List<string> period,
            Models.Range4Model range)
        {
            this.Period = period;
            this.Range = range;
        }

        /// <summary>
        /// Gets or sets Period.
        /// </summary>
        [JsonProperty("period")]
        public List<string> Period { get; set; }

        /// <summary>
        /// Gets or sets Range.
        /// </summary>
        [JsonProperty("range")]
        public Models.Range4Model Range { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SalaryIndicationModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is SalaryIndicationModel other &&
                ((this.Period == null && other.Period == null) || (this.Period?.Equals(other.Period) == true)) &&
                ((this.Range == null && other.Range == null) || (this.Range?.Equals(other.Range) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Period = {(this.Period == null ? "null" : $"[{string.Join(", ", this.Period)} ]")}");
            toStringOutput.Add($"this.Range = {(this.Range == null ? "null" : this.Range.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}