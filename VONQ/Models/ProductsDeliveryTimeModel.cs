// <copyright file="ProductsDeliveryTimeModel.cs" company="APIMatic">
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
    /// ProductsDeliveryTimeModel.
    /// </summary>
    public class ProductsDeliveryTimeModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsDeliveryTimeModel"/> class.
        /// </summary>
        public ProductsDeliveryTimeModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsDeliveryTimeModel"/> class.
        /// </summary>
        /// <param name="daysToProcess">days_to_process.</param>
        /// <param name="daysToSetup">days_to_setup.</param>
        /// <param name="totalDays">total_days.</param>
        public ProductsDeliveryTimeModel(
            double? daysToProcess = null,
            double? daysToSetup = null,
            double? totalDays = null)
        {
            this.DaysToProcess = daysToProcess;
            this.DaysToSetup = daysToSetup;
            this.TotalDays = totalDays;
        }

        /// <summary>
        /// Gets or sets DaysToProcess.
        /// </summary>
        [JsonProperty("days_to_process", NullValueHandling = NullValueHandling.Ignore)]
        public double? DaysToProcess { get; set; }

        /// <summary>
        /// Gets or sets DaysToSetup.
        /// </summary>
        [JsonProperty("days_to_setup", NullValueHandling = NullValueHandling.Ignore)]
        public double? DaysToSetup { get; set; }

        /// <summary>
        /// Gets or sets TotalDays.
        /// </summary>
        [JsonProperty("total_days", NullValueHandling = NullValueHandling.Ignore)]
        public double? TotalDays { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ProductsDeliveryTimeModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is ProductsDeliveryTimeModel other &&
                ((this.DaysToProcess == null && other.DaysToProcess == null) || (this.DaysToProcess?.Equals(other.DaysToProcess) == true)) &&
                ((this.DaysToSetup == null && other.DaysToSetup == null) || (this.DaysToSetup?.Equals(other.DaysToSetup) == true)) &&
                ((this.TotalDays == null && other.TotalDays == null) || (this.TotalDays?.Equals(other.TotalDays) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.DaysToProcess = {(this.DaysToProcess == null ? "null" : this.DaysToProcess.ToString())}");
            toStringOutput.Add($"this.DaysToSetup = {(this.DaysToSetup == null ? "null" : this.DaysToSetup.ToString())}");
            toStringOutput.Add($"this.TotalDays = {(this.TotalDays == null ? "null" : this.TotalDays.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}