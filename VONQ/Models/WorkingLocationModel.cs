// <copyright file="WorkingLocationModel.cs" company="APIMatic">
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
    /// WorkingLocationModel.
    /// </summary>
    public class WorkingLocationModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkingLocationModel"/> class.
        /// </summary>
        public WorkingLocationModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkingLocationModel"/> class.
        /// </summary>
        /// <param name="addressLine1">addressLine1.</param>
        /// <param name="postcode">postcode.</param>
        /// <param name="city">city.</param>
        /// <param name="country">country.</param>
        public WorkingLocationModel(
            List<string> addressLine1,
            List<string> postcode,
            List<string> city,
            List<string> country)
        {
            this.AddressLine1 = addressLine1;
            this.Postcode = postcode;
            this.City = city;
            this.Country = country;
        }

        /// <summary>
        /// Gets or sets AddressLine1.
        /// </summary>
        [JsonProperty("addressLine1")]
        public List<string> AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets Postcode.
        /// </summary>
        [JsonProperty("postcode")]
        public List<string> Postcode { get; set; }

        /// <summary>
        /// Gets or sets City.
        /// </summary>
        [JsonProperty("city")]
        public List<string> City { get; set; }

        /// <summary>
        /// Gets or sets Country.
        /// </summary>
        [JsonProperty("country")]
        public List<string> Country { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"WorkingLocationModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is WorkingLocationModel other &&
                ((this.AddressLine1 == null && other.AddressLine1 == null) || (this.AddressLine1?.Equals(other.AddressLine1) == true)) &&
                ((this.Postcode == null && other.Postcode == null) || (this.Postcode?.Equals(other.Postcode) == true)) &&
                ((this.City == null && other.City == null) || (this.City?.Equals(other.City) == true)) &&
                ((this.Country == null && other.Country == null) || (this.Country?.Equals(other.Country) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AddressLine1 = {(this.AddressLine1 == null ? "null" : $"[{string.Join(", ", this.AddressLine1)} ]")}");
            toStringOutput.Add($"this.Postcode = {(this.Postcode == null ? "null" : $"[{string.Join(", ", this.Postcode)} ]")}");
            toStringOutput.Add($"this.City = {(this.City == null ? "null" : $"[{string.Join(", ", this.City)} ]")}");
            toStringOutput.Add($"this.Country = {(this.Country == null ? "null" : $"[{string.Join(", ", this.Country)} ]")}");

            base.ToString(toStringOutput);
        }
    }
}