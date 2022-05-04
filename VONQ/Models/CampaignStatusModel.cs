// <copyright file="CampaignStatusModel.cs" company="APIMatic">
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
    /// CampaignStatusModel.
    /// </summary>
    public class CampaignStatusModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignStatusModel"/> class.
        /// </summary>
        public CampaignStatusModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignStatusModel"/> class.
        /// </summary>
        /// <param name="campaignId">campaignId.</param>
        /// <param name="status">status.</param>
        /// <param name="orderedProductsStatuses">orderedProductsStatuses.</param>
        public CampaignStatusModel(
            string campaignId,
            Models.StatusEnum? status = null,
            List<Models.OrderedProductsStatusItemModel> orderedProductsStatuses = null)
        {
            this.CampaignId = campaignId;
            this.Status = status;
            this.OrderedProductsStatuses = orderedProductsStatuses;
        }

        /// <summary>
        /// Gets or sets CampaignId.
        /// </summary>
        [JsonProperty("campaignId")]
        public string CampaignId { get; set; }

        /// <summary>
        /// Status of the campaign. One of the following
        /// </summary>
        [JsonProperty("status", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.StatusEnum? Status { get; set; }

        /// <summary>
        /// Gets or sets OrderedProductsStatuses.
        /// </summary>
        [JsonProperty("orderedProductsStatuses", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.OrderedProductsStatusItemModel> OrderedProductsStatuses { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CampaignStatusModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is CampaignStatusModel other &&
                ((this.CampaignId == null && other.CampaignId == null) || (this.CampaignId?.Equals(other.CampaignId) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.OrderedProductsStatuses == null && other.OrderedProductsStatuses == null) || (this.OrderedProductsStatuses?.Equals(other.OrderedProductsStatuses) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CampaignId = {(this.CampaignId == null ? "null" : this.CampaignId == string.Empty ? "" : this.CampaignId)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.OrderedProductsStatuses = {(this.OrderedProductsStatuses == null ? "null" : $"[{string.Join(", ", this.OrderedProductsStatuses)} ]")}");

            base.ToString(toStringOutput);
        }
    }
}