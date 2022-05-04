// <copyright file="TakeCampaignOfflineRequestModel.cs" company="APIMatic">
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
    /// TakeCampaignOfflineRequestModel.
    /// </summary>
    public class TakeCampaignOfflineRequestModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TakeCampaignOfflineRequestModel"/> class.
        /// </summary>
        public TakeCampaignOfflineRequestModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TakeCampaignOfflineRequestModel"/> class.
        /// </summary>
        /// <param name="campaignId">campaignId.</param>
        /// <param name="status">status.</param>
        public TakeCampaignOfflineRequestModel(
            string campaignId,
            string status)
        {
            this.CampaignId = campaignId;
            this.Status = status;
        }

        /// <summary>
        /// Gets or sets CampaignId.
        /// </summary>
        [JsonProperty("campaignId")]
        public string CampaignId { get; set; }

        /// <summary>
        /// Gets or sets Status.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TakeCampaignOfflineRequestModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is TakeCampaignOfflineRequestModel other &&
                ((this.CampaignId == null && other.CampaignId == null) || (this.CampaignId?.Equals(other.CampaignId) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CampaignId = {(this.CampaignId == null ? "null" : this.CampaignId == string.Empty ? "" : this.CampaignId)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status == string.Empty ? "" : this.Status)}");

            base.ToString(toStringOutput);
        }
    }
}