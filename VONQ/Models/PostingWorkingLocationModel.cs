// <copyright file="PostingWorkingLocationModel.cs" company="APIMatic">
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
    /// PostingWorkingLocationModel.
    /// </summary>
    public class PostingWorkingLocationModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostingWorkingLocationModel"/> class.
        /// </summary>
        public PostingWorkingLocationModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostingWorkingLocationModel"/> class.
        /// </summary>
        /// <param name="addressLine1">addressLine1.</param>
        /// <param name="postcode">postcode.</param>
        /// <param name="city">city.</param>
        /// <param name="country">country.</param>
        /// <param name="addressLine2">addressLine2.</param>
        /// <param name="allowsRemoteWork">allowsRemoteWork.</param>
        public PostingWorkingLocationModel(
            string addressLine1,
            string postcode,
            string city,
            string country,
            string addressLine2 = null,
            double? allowsRemoteWork = null)
        {
            this.AddressLine1 = addressLine1;
            this.AddressLine2 = addressLine2;
            this.Postcode = postcode;
            this.City = city;
            this.Country = country;
            this.AllowsRemoteWork = allowsRemoteWork;
        }

        /// <summary>
        /// Gets or sets AddressLine1.
        /// </summary>
        [JsonProperty("addressLine1")]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets AddressLine2.
        /// </summary>
        [JsonProperty("addressLine2", NullValueHandling = NullValueHandling.Ignore)]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets Postcode.
        /// </summary>
        [JsonProperty("postcode")]
        public string Postcode { get; set; }

        /// <summary>
        /// Gets or sets City.
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets Country.
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// Optional parameter allowing remote work, possible values are 0 and 1, defaults to 0
        /// </summary>
        [JsonProperty("allowsRemoteWork", NullValueHandling = NullValueHandling.Ignore)]
        public double? AllowsRemoteWork { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PostingWorkingLocationModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is PostingWorkingLocationModel other &&
                ((this.AddressLine1 == null && other.AddressLine1 == null) || (this.AddressLine1?.Equals(other.AddressLine1) == true)) &&
                ((this.AddressLine2 == null && other.AddressLine2 == null) || (this.AddressLine2?.Equals(other.AddressLine2) == true)) &&
                ((this.Postcode == null && other.Postcode == null) || (this.Postcode?.Equals(other.Postcode) == true)) &&
                ((this.City == null && other.City == null) || (this.City?.Equals(other.City) == true)) &&
                ((this.Country == null && other.Country == null) || (this.Country?.Equals(other.Country) == true)) &&
                ((this.AllowsRemoteWork == null && other.AllowsRemoteWork == null) || (this.AllowsRemoteWork?.Equals(other.AllowsRemoteWork) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AddressLine1 = {(this.AddressLine1 == null ? "null" : this.AddressLine1 == string.Empty ? "" : this.AddressLine1)}");
            toStringOutput.Add($"this.AddressLine2 = {(this.AddressLine2 == null ? "null" : this.AddressLine2 == string.Empty ? "" : this.AddressLine2)}");
            toStringOutput.Add($"this.Postcode = {(this.Postcode == null ? "null" : this.Postcode == string.Empty ? "" : this.Postcode)}");
            toStringOutput.Add($"this.City = {(this.City == null ? "null" : this.City == string.Empty ? "" : this.City)}");
            toStringOutput.Add($"this.Country = {(this.Country == null ? "null" : this.Country == string.Empty ? "" : this.Country)}");
            toStringOutput.Add($"this.AllowsRemoteWork = {(this.AllowsRemoteWork == null ? "null" : this.AllowsRemoteWork.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}