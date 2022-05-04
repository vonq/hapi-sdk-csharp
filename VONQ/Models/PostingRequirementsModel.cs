// <copyright file="PostingRequirementsModel.cs" company="APIMatic">
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
    /// PostingRequirementsModel.
    /// </summary>
    public class PostingRequirementsModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostingRequirementsModel"/> class.
        /// </summary>
        public PostingRequirementsModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostingRequirementsModel"/> class.
        /// </summary>
        /// <param name="someText">someText.</param>
        /// <param name="multipleSelectField">multipleSelectField.</param>
        /// <param name="someIntValue">someIntValue.</param>
        public PostingRequirementsModel(
            string someText = null,
            List<string> multipleSelectField = null,
            double? someIntValue = null)
        {
            this.SomeText = someText;
            this.MultipleSelectField = multipleSelectField;
            this.SomeIntValue = someIntValue;
        }

        /// <summary>
        /// Gets or sets SomeText.
        /// </summary>
        [JsonProperty("someText", NullValueHandling = NullValueHandling.Ignore)]
        public string SomeText { get; set; }

        /// <summary>
        /// Gets or sets MultipleSelectField.
        /// </summary>
        [JsonProperty("multipleSelectField", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> MultipleSelectField { get; set; }

        /// <summary>
        /// Gets or sets SomeIntValue.
        /// </summary>
        [JsonProperty("someIntValue", NullValueHandling = NullValueHandling.Ignore)]
        public double? SomeIntValue { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PostingRequirementsModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is PostingRequirementsModel other &&
                ((this.SomeText == null && other.SomeText == null) || (this.SomeText?.Equals(other.SomeText) == true)) &&
                ((this.MultipleSelectField == null && other.MultipleSelectField == null) || (this.MultipleSelectField?.Equals(other.MultipleSelectField) == true)) &&
                ((this.SomeIntValue == null && other.SomeIntValue == null) || (this.SomeIntValue?.Equals(other.SomeIntValue) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.SomeText = {(this.SomeText == null ? "null" : this.SomeText == string.Empty ? "" : this.SomeText)}");
            toStringOutput.Add($"this.MultipleSelectField = {(this.MultipleSelectField == null ? "null" : $"[{string.Join(", ", this.MultipleSelectField)} ]")}");
            toStringOutput.Add($"this.SomeIntValue = {(this.SomeIntValue == null ? "null" : this.SomeIntValue.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}