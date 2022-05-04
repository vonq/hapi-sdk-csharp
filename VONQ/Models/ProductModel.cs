// <copyright file="ProductModel.cs" company="APIMatic">
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
    /// ProductModel.
    /// </summary>
    public class ProductModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductModel"/> class.
        /// </summary>
        public ProductModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductModel"/> class.
        /// </summary>
        /// <param name="title">title.</param>
        /// <param name="locations">locations.</param>
        /// <param name="jobFunctions">job_functions.</param>
        /// <param name="industries">industries.</param>
        /// <param name="timeToProcess">time_to_process.</param>
        /// <param name="timeToSetup">time_to_setup.</param>
        /// <param name="productId">product_id.</param>
        /// <param name="vonqPrice">vonq_price.</param>
        /// <param name="ratecardPrice">ratecard_price.</param>
        /// <param name="type">type.</param>
        /// <param name="crossPostings">cross_postings.</param>
        /// <param name="channel">channel.</param>
        /// <param name="audienceGroup">audience_group.</param>
        /// <param name="mcEnabled">mc_enabled.</param>
        /// <param name="mcOnly">mc_only.</param>
        /// <param name="allowOrders">allow_orders.</param>
        /// <param name="description">description.</param>
        /// <param name="homepage">homepage.</param>
        /// <param name="logoUrl">logo_url.</param>
        /// <param name="logoSquareUrl">logo_square_url.</param>
        /// <param name="logoRectangleUrl">logo_rectangle_url.</param>
        /// <param name="duration">duration.</param>
        public ProductModel(
            string title,
            List<Models.LocationModel> locations,
            List<Models.JobFunctionModel> jobFunctions,
            List<Models.IndustryModel> industries,
            Models.TimeToProcessModel timeToProcess,
            Models.TimeToSetupModel timeToSetup,
            Guid productId,
            List<Models.PriceModel> vonqPrice,
            List<Models.PriceModel> ratecardPrice,
            Models.ChannelTypeEnum type,
            List<string> crossPostings,
            Models.ChannelModel channel,
            Models.AudienceGroupEnum audienceGroup,
            bool mcEnabled,
            bool mcOnly,
            bool allowOrders,
            string description = null,
            string homepage = null,
            string logoUrl = null,
            string logoSquareUrl = null,
            string logoRectangleUrl = null,
            object duration = null)
        {
            this.Title = title;
            this.Locations = locations;
            this.JobFunctions = jobFunctions;
            this.Industries = industries;
            this.Description = description;
            this.Homepage = homepage;
            this.LogoUrl = logoUrl;
            this.LogoSquareUrl = logoSquareUrl;
            this.LogoRectangleUrl = logoRectangleUrl;
            this.Duration = duration;
            this.TimeToProcess = timeToProcess;
            this.TimeToSetup = timeToSetup;
            this.ProductId = productId;
            this.VonqPrice = vonqPrice;
            this.RatecardPrice = ratecardPrice;
            this.Type = type;
            this.CrossPostings = crossPostings;
            this.Channel = channel;
            this.AudienceGroup = audienceGroup;
            this.McEnabled = mcEnabled;
            this.McOnly = mcOnly;
            this.AllowOrders = allowOrders;
        }

        /// <summary>
        /// Gets or sets Title.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets Locations.
        /// </summary>
        [JsonProperty("locations")]
        public List<Models.LocationModel> Locations { get; set; }

        /// <summary>
        /// Gets or sets JobFunctions.
        /// </summary>
        [JsonProperty("job_functions")]
        public List<Models.JobFunctionModel> JobFunctions { get; set; }

        /// <summary>
        /// Gets or sets Industries.
        /// </summary>
        [JsonProperty("industries")]
        public List<Models.IndustryModel> Industries { get; set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Include)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets Homepage.
        /// </summary>
        [JsonProperty("homepage", NullValueHandling = NullValueHandling.Include)]
        public string Homepage { get; set; }

        /// <summary>
        /// Gets or sets LogoUrl.
        /// </summary>
        [JsonProperty("logo_url", NullValueHandling = NullValueHandling.Include)]
        public string LogoUrl { get; set; }

        /// <summary>
        /// Gets or sets LogoSquareUrl.
        /// </summary>
        [JsonProperty("logo_square_url", NullValueHandling = NullValueHandling.Include)]
        public string LogoSquareUrl { get; set; }

        /// <summary>
        /// Gets or sets LogoRectangleUrl.
        /// </summary>
        [JsonProperty("logo_rectangle_url", NullValueHandling = NullValueHandling.Include)]
        public string LogoRectangleUrl { get; set; }

        /// <summary>
        /// Gets or sets Duration.
        /// </summary>
        [JsonProperty("duration", NullValueHandling = NullValueHandling.Include)]
        public object Duration { get; set; }

        /// <summary>
        /// Gets or sets TimeToProcess.
        /// </summary>
        [JsonProperty("time_to_process")]
        public Models.TimeToProcessModel TimeToProcess { get; set; }

        /// <summary>
        /// Gets or sets TimeToSetup.
        /// </summary>
        [JsonProperty("time_to_setup")]
        public Models.TimeToSetupModel TimeToSetup { get; set; }

        /// <summary>
        /// Gets or sets ProductId.
        /// </summary>
        [JsonProperty("product_id")]
        public Guid ProductId { get; set; }

        /// <summary>
        /// the price to be displayed to customers
        /// </summary>
        [JsonProperty("vonq_price")]
        public List<Models.PriceModel> VonqPrice { get; set; }

        /// <summary>
        /// Gets or sets RatecardPrice.
        /// </summary>
        [JsonProperty("ratecard_price")]
        public List<Models.PriceModel> RatecardPrice { get; set; }

        /// <summary>
        /// The type of a channel
        /// </summary>
        [JsonProperty("type", ItemConverterType = typeof(StringEnumConverter))]
        public Models.ChannelTypeEnum Type { get; set; }

        /// <summary>
        /// Gets or sets CrossPostings.
        /// </summary>
        [JsonProperty("cross_postings")]
        public List<string> CrossPostings { get; set; }

        /// <summary>
        /// Gets or sets Channel.
        /// </summary>
        [JsonProperty("channel")]
        public Models.ChannelModel Channel { get; set; }

        /// <summary>
        /// The product's audience group (niche/generic)
        /// </summary>
        [JsonProperty("audience_group", ItemConverterType = typeof(StringEnumConverter))]
        public Models.AudienceGroupEnum AudienceGroup { get; set; }

        /// <summary>
        /// is My Contract enabled for the channel
        /// </summary>
        [JsonProperty("mc_enabled")]
        public bool McEnabled { get; set; }

        /// <summary>
        /// is the product available only for My Contract order
        /// </summary>
        [JsonProperty("mc_only")]
        public bool McOnly { get; set; }

        /// <summary>
        /// is the product available for order. a campaign cannot be ordered with a product having `allow_orders` set to `false`.
        /// </summary>
        [JsonProperty("allow_orders")]
        public bool AllowOrders { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ProductModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is ProductModel other &&
                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.Locations == null && other.Locations == null) || (this.Locations?.Equals(other.Locations) == true)) &&
                ((this.JobFunctions == null && other.JobFunctions == null) || (this.JobFunctions?.Equals(other.JobFunctions) == true)) &&
                ((this.Industries == null && other.Industries == null) || (this.Industries?.Equals(other.Industries) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.Homepage == null && other.Homepage == null) || (this.Homepage?.Equals(other.Homepage) == true)) &&
                ((this.LogoUrl == null && other.LogoUrl == null) || (this.LogoUrl?.Equals(other.LogoUrl) == true)) &&
                ((this.LogoSquareUrl == null && other.LogoSquareUrl == null) || (this.LogoSquareUrl?.Equals(other.LogoSquareUrl) == true)) &&
                ((this.LogoRectangleUrl == null && other.LogoRectangleUrl == null) || (this.LogoRectangleUrl?.Equals(other.LogoRectangleUrl) == true)) &&
                ((this.Duration == null && other.Duration == null) || (this.Duration?.Equals(other.Duration) == true)) &&
                ((this.TimeToProcess == null && other.TimeToProcess == null) || (this.TimeToProcess?.Equals(other.TimeToProcess) == true)) &&
                ((this.TimeToSetup == null && other.TimeToSetup == null) || (this.TimeToSetup?.Equals(other.TimeToSetup) == true)) &&
                this.ProductId.Equals(other.ProductId) &&
                ((this.VonqPrice == null && other.VonqPrice == null) || (this.VonqPrice?.Equals(other.VonqPrice) == true)) &&
                ((this.RatecardPrice == null && other.RatecardPrice == null) || (this.RatecardPrice?.Equals(other.RatecardPrice) == true)) &&
                this.Type.Equals(other.Type) &&
                ((this.CrossPostings == null && other.CrossPostings == null) || (this.CrossPostings?.Equals(other.CrossPostings) == true)) &&
                ((this.Channel == null && other.Channel == null) || (this.Channel?.Equals(other.Channel) == true)) &&
                this.AudienceGroup.Equals(other.AudienceGroup) &&
                this.McEnabled.Equals(other.McEnabled) &&
                this.McOnly.Equals(other.McOnly) &&
                this.AllowOrders.Equals(other.AllowOrders);
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title == string.Empty ? "" : this.Title)}");
            toStringOutput.Add($"this.Locations = {(this.Locations == null ? "null" : $"[{string.Join(", ", this.Locations)} ]")}");
            toStringOutput.Add($"this.JobFunctions = {(this.JobFunctions == null ? "null" : $"[{string.Join(", ", this.JobFunctions)} ]")}");
            toStringOutput.Add($"this.Industries = {(this.Industries == null ? "null" : $"[{string.Join(", ", this.Industries)} ]")}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description == string.Empty ? "" : this.Description)}");
            toStringOutput.Add($"this.Homepage = {(this.Homepage == null ? "null" : this.Homepage == string.Empty ? "" : this.Homepage)}");
            toStringOutput.Add($"this.LogoUrl = {(this.LogoUrl == null ? "null" : this.LogoUrl == string.Empty ? "" : this.LogoUrl)}");
            toStringOutput.Add($"this.LogoSquareUrl = {(this.LogoSquareUrl == null ? "null" : this.LogoSquareUrl == string.Empty ? "" : this.LogoSquareUrl)}");
            toStringOutput.Add($"this.LogoRectangleUrl = {(this.LogoRectangleUrl == null ? "null" : this.LogoRectangleUrl == string.Empty ? "" : this.LogoRectangleUrl)}");
            toStringOutput.Add($"Duration = {(this.Duration == null ? "null" : this.Duration.ToString())}");
            toStringOutput.Add($"this.TimeToProcess = {(this.TimeToProcess == null ? "null" : this.TimeToProcess.ToString())}");
            toStringOutput.Add($"this.TimeToSetup = {(this.TimeToSetup == null ? "null" : this.TimeToSetup.ToString())}");
            toStringOutput.Add($"this.ProductId = {this.ProductId}");
            toStringOutput.Add($"this.VonqPrice = {(this.VonqPrice == null ? "null" : $"[{string.Join(", ", this.VonqPrice)} ]")}");
            toStringOutput.Add($"this.RatecardPrice = {(this.RatecardPrice == null ? "null" : $"[{string.Join(", ", this.RatecardPrice)} ]")}");
            toStringOutput.Add($"this.Type = {this.Type}");
            toStringOutput.Add($"this.CrossPostings = {(this.CrossPostings == null ? "null" : $"[{string.Join(", ", this.CrossPostings)} ]")}");
            toStringOutput.Add($"this.Channel = {(this.Channel == null ? "null" : this.Channel.ToString())}");
            toStringOutput.Add($"this.AudienceGroup = {this.AudienceGroup}");
            toStringOutput.Add($"this.McEnabled = {this.McEnabled}");
            toStringOutput.Add($"this.McOnly = {this.McOnly}");
            toStringOutput.Add($"this.AllowOrders = {this.AllowOrders}");

            base.ToString(toStringOutput);
        }
    }
}