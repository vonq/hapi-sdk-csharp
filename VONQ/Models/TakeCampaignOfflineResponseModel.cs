// <copyright file="TakeCampaignOfflineResponseModel.cs" company="APIMatic">
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
    /// TakeCampaignOfflineResponseModel.
    /// </summary>
    public class TakeCampaignOfflineResponseModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TakeCampaignOfflineResponseModel"/> class.
        /// </summary>
        public TakeCampaignOfflineResponseModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TakeCampaignOfflineResponseModel"/> class.
        /// </summary>
        /// <param name="campaignId">campaignId.</param>
        public TakeCampaignOfflineResponseModel(
            string campaignId = null)
        {
            this.CampaignId = campaignId;
        }

        /// <summary>
        /// Gets or sets CampaignId.
        /// </summary>
        [JsonProperty("campaignId", NullValueHandling = NullValueHandling.Ignore)]
        public string CampaignId { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TakeCampaignOfflineResponseModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is TakeCampaignOfflineResponseModel other &&
                ((this.CampaignId == null && other.CampaignId == null) || (this.CampaignId?.Equals(other.CampaignId) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CampaignId = {(this.CampaignId == null ? "null" : this.CampaignId == string.Empty ? "" : this.CampaignId)}");

            base.ToString(toStringOutput);
        }
    }
}