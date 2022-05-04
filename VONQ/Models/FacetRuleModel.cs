// <copyright file="FacetRuleModel.cs" company="APIMatic">
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
    /// FacetRuleModel.
    /// </summary>
    public class FacetRuleModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FacetRuleModel"/> class.
        /// </summary>
        public FacetRuleModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FacetRuleModel"/> class.
        /// </summary>
        /// <param name="rule">rule.</param>
        /// <param name="data">data.</param>
        public FacetRuleModel(
            Models.RuleEnum rule,
            string data)
        {
            this.Rule = rule;
            this.Data = data;
        }

        /// <summary>
        /// Gets or sets Rule.
        /// </summary>
        [JsonProperty("rule", ItemConverterType = typeof(StringEnumConverter))]
        public Models.RuleEnum Rule { get; set; }

        /// <summary>
        /// the value used for the rule
        /// </summary>
        [JsonProperty("data")]
        public string Data { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"FacetRuleModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is FacetRuleModel other &&
                this.Rule.Equals(other.Rule) &&
                ((this.Data == null && other.Data == null) || (this.Data?.Equals(other.Data) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Rule = {this.Rule}");
            toStringOutput.Add($"this.Data = {(this.Data == null ? "null" : this.Data == string.Empty ? "" : this.Data)}");

            base.ToString(toStringOutput);
        }
    }
}