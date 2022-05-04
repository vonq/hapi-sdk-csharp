// <copyright file="CampaignModel.cs" company="APIMatic">
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
    /// CampaignModel.
    /// </summary>
    public class CampaignModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignModel"/> class.
        /// </summary>
        public CampaignModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignModel"/> class.
        /// </summary>
        /// <param name="companyId">companyId.</param>
        /// <param name="recruiterInfo">recruiterInfo.</param>
        /// <param name="postingDetails">postingDetails.</param>
        /// <param name="targetGroup">targetGroup.</param>
        /// <param name="orderedProducts">orderedProducts.</param>
        /// <param name="orderReference">orderReference.</param>
        /// <param name="campaignName">campaignName.</param>
        /// <param name="orderedProductsSpecs">orderedProductsSpecs.</param>
        /// <param name="postings">postings.</param>
        public CampaignModel(
            string companyId,
            Models.RecruiterInfoModel recruiterInfo,
            Models.PostingDetailsModel postingDetails,
            Models.TargetGroupModel targetGroup,
            List<string> orderedProducts,
            string orderReference = null,
            string campaignName = null,
            List<Models.OrderedProductsGetElementModel> orderedProductsSpecs = null,
            List<Models.CampaignPostingModel> postings = null)
        {
            this.CompanyId = companyId;
            this.OrderReference = orderReference;
            this.RecruiterInfo = recruiterInfo;
            this.CampaignName = campaignName;
            this.PostingDetails = postingDetails;
            this.TargetGroup = targetGroup;
            this.OrderedProducts = orderedProducts;
            this.OrderedProductsSpecs = orderedProductsSpecs;
            this.Postings = postings;
        }

        /// <summary>
        /// A vendor-related unique identification for the Company that's making the order. Doesn't affect the
        /// order process at all, but provides a method for later filtering by this identification. It's also
        /// used when creating a unified report of Campaign orders made in a period of time.
        /// </summary>
        [JsonProperty("companyId")]
        public string CompanyId { get; set; }

        /// <summary>
        /// A vendor-related Reference number for the order. This could be a PO number or an Invoice number.
        /// Doesn't affect the order process at all, but provides a way for the ATS to identify the specific
        /// order for their internal billing process
        /// Maximum length of this field is 80 symbols
        /// </summary>
        [JsonProperty("orderReference", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderReference { get; set; }

        /// <summary>
        /// Recruiter is the user creating the campaign and you may want to use this to provide filtering by recruiter for groups sharing an account.
        /// </summary>
        [JsonProperty("recruiterInfo")]
        public Models.RecruiterInfoModel RecruiterInfo { get; set; }

        /// <summary>
        /// Campaign name as it's going to be listed. Doesn't have to resemble the Posting Title.
        /// For example, the Campaign name could be **Software Development Manager** while the Posting
        /// title could be **Want to lead a Team of Software Developers? Join us**
        /// </summary>
        [JsonProperty("campaignName", NullValueHandling = NullValueHandling.Ignore)]
        public string CampaignName { get; set; }

        /// <summary>
        /// Gets or sets PostingDetails.
        /// </summary>
        [JsonProperty("postingDetails")]
        public Models.PostingDetailsModel PostingDetails { get; set; }

        /// <summary>
        /// Gets or sets TargetGroup.
        /// </summary>
        [JsonProperty("targetGroup")]
        public Models.TargetGroupModel TargetGroup { get; set; }

        /// <summary>
        /// A list of the Products selected by the user.
        /// </summary>
        [JsonProperty("orderedProducts")]
        public List<string> OrderedProducts { get; set; }

        /// <summary>
        /// This part contains information of the ordered products.
        /// </summary>
        [JsonProperty("orderedProductsSpecs", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.OrderedProductsGetElementModel> OrderedProductsSpecs { get; set; }

        /// <summary>
        /// Gets or sets Postings.
        /// </summary>
        [JsonProperty("postings", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.CampaignPostingModel> Postings { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CampaignModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is CampaignModel other &&
                ((this.CompanyId == null && other.CompanyId == null) || (this.CompanyId?.Equals(other.CompanyId) == true)) &&
                ((this.OrderReference == null && other.OrderReference == null) || (this.OrderReference?.Equals(other.OrderReference) == true)) &&
                ((this.RecruiterInfo == null && other.RecruiterInfo == null) || (this.RecruiterInfo?.Equals(other.RecruiterInfo) == true)) &&
                ((this.CampaignName == null && other.CampaignName == null) || (this.CampaignName?.Equals(other.CampaignName) == true)) &&
                ((this.PostingDetails == null && other.PostingDetails == null) || (this.PostingDetails?.Equals(other.PostingDetails) == true)) &&
                ((this.TargetGroup == null && other.TargetGroup == null) || (this.TargetGroup?.Equals(other.TargetGroup) == true)) &&
                ((this.OrderedProducts == null && other.OrderedProducts == null) || (this.OrderedProducts?.Equals(other.OrderedProducts) == true)) &&
                ((this.OrderedProductsSpecs == null && other.OrderedProductsSpecs == null) || (this.OrderedProductsSpecs?.Equals(other.OrderedProductsSpecs) == true)) &&
                ((this.Postings == null && other.Postings == null) || (this.Postings?.Equals(other.Postings) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CompanyId = {(this.CompanyId == null ? "null" : this.CompanyId == string.Empty ? "" : this.CompanyId)}");
            toStringOutput.Add($"this.OrderReference = {(this.OrderReference == null ? "null" : this.OrderReference == string.Empty ? "" : this.OrderReference)}");
            toStringOutput.Add($"this.RecruiterInfo = {(this.RecruiterInfo == null ? "null" : this.RecruiterInfo.ToString())}");
            toStringOutput.Add($"this.CampaignName = {(this.CampaignName == null ? "null" : this.CampaignName == string.Empty ? "" : this.CampaignName)}");
            toStringOutput.Add($"this.PostingDetails = {(this.PostingDetails == null ? "null" : this.PostingDetails.ToString())}");
            toStringOutput.Add($"this.TargetGroup = {(this.TargetGroup == null ? "null" : this.TargetGroup.ToString())}");
            toStringOutput.Add($"this.OrderedProducts = {(this.OrderedProducts == null ? "null" : $"[{string.Join(", ", this.OrderedProducts)} ]")}");
            toStringOutput.Add($"this.OrderedProductsSpecs = {(this.OrderedProductsSpecs == null ? "null" : $"[{string.Join(", ", this.OrderedProductsSpecs)} ]")}");
            toStringOutput.Add($"this.Postings = {(this.Postings == null ? "null" : $"[{string.Join(", ", this.Postings)} ]")}");

            base.ToString(toStringOutput);
        }
    }
}