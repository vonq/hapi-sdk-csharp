// <copyright file="ChannelLiteModel.cs" company="APIMatic">
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
    /// ChannelLiteModel.
    /// </summary>
    public class ChannelLiteModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelLiteModel"/> class.
        /// </summary>
        public ChannelLiteModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelLiteModel"/> class.
        /// </summary>
        /// <param name="mcEnabled">mc_enabled.</param>
        /// <param name="id">id.</param>
        /// <param name="name">name.</param>
        /// <param name="url">url.</param>
        /// <param name="type">type.</param>
        public ChannelLiteModel(
            bool mcEnabled,
            int id,
            string name,
            string url,
            string type)
        {
            this.McEnabled = mcEnabled;
            this.Id = id;
            this.Name = name;
            this.Url = url;
            this.Type = type;
        }

        /// <summary>
        /// Gets or sets McEnabled.
        /// </summary>
        [JsonProperty("mc_enabled")]
        public bool McEnabled { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Url.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets Type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ChannelLiteModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is ChannelLiteModel other &&
                this.McEnabled.Equals(other.McEnabled) &&
                this.Id.Equals(other.Id) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Url == null && other.Url == null) || (this.Url?.Equals(other.Url) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.McEnabled = {this.McEnabled}");
            toStringOutput.Add($"this.Id = {this.Id}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.Url = {(this.Url == null ? "null" : this.Url == string.Empty ? "" : this.Url)}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type == string.Empty ? "" : this.Type)}");

            base.ToString(toStringOutput);
        }
    }
}