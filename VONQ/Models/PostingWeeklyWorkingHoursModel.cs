// <copyright file="PostingWeeklyWorkingHoursModel.cs" company="APIMatic">
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
    /// PostingWeeklyWorkingHoursModel.
    /// </summary>
    public class PostingWeeklyWorkingHoursModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostingWeeklyWorkingHoursModel"/> class.
        /// </summary>
        public PostingWeeklyWorkingHoursModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostingWeeklyWorkingHoursModel"/> class.
        /// </summary>
        /// <param name="to">to.</param>
        /// <param name="from">from.</param>
        public PostingWeeklyWorkingHoursModel(
            double to,
            double? from = null)
        {
            this.From = from;
            this.To = to;
        }

        /// <summary>
        /// Gets or sets From.
        /// </summary>
        [JsonProperty("from", NullValueHandling = NullValueHandling.Ignore)]
        public double? From { get; set; }

        /// <summary>
        /// This value needs to be an positive integer
        /// </summary>
        [JsonProperty("to")]
        public double To { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PostingWeeklyWorkingHoursModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is PostingWeeklyWorkingHoursModel other &&
                ((this.From == null && other.From == null) || (this.From?.Equals(other.From) == true)) &&
                this.To.Equals(other.To);
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.From = {(this.From == null ? "null" : this.From.ToString())}");
            toStringOutput.Add($"this.To = {this.To}");

            base.ToString(toStringOutput);
        }
    }
}