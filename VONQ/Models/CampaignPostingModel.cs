// <copyright file="CampaignPostingModel.cs" company="APIMatic">
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
    /// CampaignPostingModel.
    /// </summary>
    public class CampaignPostingModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignPostingModel"/> class.
        /// </summary>
        public CampaignPostingModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignPostingModel"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="clicks">clicks.</param>
        public CampaignPostingModel(
            string name = null,
            double? clicks = null)
        {
            this.Name = name;
            this.Clicks = clicks;
        }

        /// <summary>
        /// The name of the Product that was bought
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Number of clicks of the mentioned posting
        /// </summary>
        [JsonProperty("clicks", NullValueHandling = NullValueHandling.Ignore)]
        public double? Clicks { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CampaignPostingModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is CampaignPostingModel other &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Clicks == null && other.Clicks == null) || (this.Clicks?.Equals(other.Clicks) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.Clicks = {(this.Clicks == null ? "null" : this.Clicks.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}