// <copyright file="ChannelModel.cs" company="APIMatic">
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
    /// ChannelModel.
    /// </summary>
    public class ChannelModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelModel"/> class.
        /// </summary>
        public ChannelModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelModel"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="url">url.</param>
        /// <param name="type">type.</param>
        /// <param name="mcEnabled">mc_enabled.</param>
        /// <param name="contractCredentials">contract_credentials.</param>
        /// <param name="contractFacets">contract_facets.</param>
        /// <param name="postingRequirements">posting_requirements.</param>
        /// <param name="manualSetupRequired">manual_setup_required.</param>
        /// <param name="setupInstructions">setup_instructions.</param>
        /// <param name="feedUrl">feed_url.</param>
        public ChannelModel(
            string name,
            string url,
            Models.ChannelTypeEnum type,
            bool mcEnabled,
            List<Models.ContractCredentialModel> contractCredentials,
            object contractFacets,
            List<Models.FacetModel> postingRequirements,
            bool manualSetupRequired,
            string setupInstructions = null,
            string feedUrl = null)
        {
            this.Name = name;
            this.Url = url;
            this.Type = type;
            this.McEnabled = mcEnabled;
            this.ContractCredentials = contractCredentials;
            this.ContractFacets = contractFacets;
            this.PostingRequirements = postingRequirements;
            this.ManualSetupRequired = manualSetupRequired;
            this.SetupInstructions = setupInstructions;
            this.FeedUrl = feedUrl;
        }

        /// <summary>
        /// The name of a channel
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The url of a channel
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// The type of a channel
        /// </summary>
        [JsonProperty("type", ItemConverterType = typeof(StringEnumConverter))]
        public Models.ChannelTypeEnum Type { get; set; }

        /// <summary>
        /// Does a channel support My Contracts
        /// </summary>
        [JsonProperty("mc_enabled")]
        public bool McEnabled { get; set; }

        /// <summary>
        /// Gets or sets ContractCredentials.
        /// </summary>
        [JsonProperty("contract_credentials")]
        public List<Models.ContractCredentialModel> ContractCredentials { get; set; }

        /// <summary>
        /// Gets or sets ContractFacets.
        /// </summary>
        [JsonProperty("contract_facets")]
        public object ContractFacets { get; set; }

        /// <summary>
        /// Dynamic posting requirements for MC products, used to provide additional data with vacancies
        /// </summary>
        [JsonProperty("posting_requirements")]
        public List<Models.FacetModel> PostingRequirements { get; set; }

        /// <summary>
        /// Some Channels require manual setup done by the end-user. In most such cases, `setup_instructions` should contain HTML
        /// </summary>
        [JsonProperty("manual_setup_required")]
        public bool ManualSetupRequired { get; set; }

        /// <summary>
        /// Additional setup instructions required to post on the Channel
        /// </summary>
        [JsonProperty("setup_instructions", NullValueHandling = NullValueHandling.Include)]
        public string SetupInstructions { get; set; }

        /// <summary>
        /// Some channels like apec.fr require the user to send the job board an XML url. If not null, this value should be displayed to the user, along with the `setup_instructions`
        /// </summary>
        [JsonProperty("feed_url", NullValueHandling = NullValueHandling.Include)]
        public string FeedUrl { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ChannelModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is ChannelModel other &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Url == null && other.Url == null) || (this.Url?.Equals(other.Url) == true)) &&
                this.Type.Equals(other.Type) &&
                this.McEnabled.Equals(other.McEnabled) &&
                ((this.ContractCredentials == null && other.ContractCredentials == null) || (this.ContractCredentials?.Equals(other.ContractCredentials) == true)) &&
                ((this.ContractFacets == null && other.ContractFacets == null) || (this.ContractFacets?.Equals(other.ContractFacets) == true)) &&
                ((this.PostingRequirements == null && other.PostingRequirements == null) || (this.PostingRequirements?.Equals(other.PostingRequirements) == true)) &&
                this.ManualSetupRequired.Equals(other.ManualSetupRequired) &&
                ((this.SetupInstructions == null && other.SetupInstructions == null) || (this.SetupInstructions?.Equals(other.SetupInstructions) == true)) &&
                ((this.FeedUrl == null && other.FeedUrl == null) || (this.FeedUrl?.Equals(other.FeedUrl) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.Url = {(this.Url == null ? "null" : this.Url == string.Empty ? "" : this.Url)}");
            toStringOutput.Add($"this.Type = {this.Type}");
            toStringOutput.Add($"this.McEnabled = {this.McEnabled}");
            toStringOutput.Add($"this.ContractCredentials = {(this.ContractCredentials == null ? "null" : $"[{string.Join(", ", this.ContractCredentials)} ]")}");
            toStringOutput.Add($"ContractFacets = {(this.ContractFacets == null ? "null" : this.ContractFacets.ToString())}");
            toStringOutput.Add($"this.PostingRequirements = {(this.PostingRequirements == null ? "null" : $"[{string.Join(", ", this.PostingRequirements)} ]")}");
            toStringOutput.Add($"this.ManualSetupRequired = {this.ManualSetupRequired}");
            toStringOutput.Add($"this.SetupInstructions = {(this.SetupInstructions == null ? "null" : this.SetupInstructions == string.Empty ? "" : this.SetupInstructions)}");
            toStringOutput.Add($"this.FeedUrl = {(this.FeedUrl == null ? "null" : this.FeedUrl == string.Empty ? "" : this.FeedUrl)}");

            base.ToString(toStringOutput);
        }
    }
}