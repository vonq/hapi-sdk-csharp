// <copyright file="Name3Model.cs" company="APIMatic">
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
    /// Name3Model.
    /// </summary>
    public class Name3Model : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Name3Model"/> class.
        /// </summary>
        public Name3Model()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Name3Model"/> class.
        /// </summary>
        /// <param name="languageCode">languageCode.</param>
        /// <param name="mValue">value.</param>
        public Name3Model(
            string languageCode = null,
            string mValue = null)
        {
            this.LanguageCode = languageCode;
            this.MValue = mValue;
        }

        /// <summary>
        /// ICU Locale code for the Language of the Seniority's name
        /// </summary>
        [JsonProperty("languageCode", NullValueHandling = NullValueHandling.Ignore)]
        public string LanguageCode { get; set; }

        /// <summary>
        /// Seniority name in one defined Language
        /// </summary>
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string MValue { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Name3Model : ({string.Join(", ", toStringOutput)})";
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

            return obj is Name3Model other &&
                ((this.LanguageCode == null && other.LanguageCode == null) || (this.LanguageCode?.Equals(other.LanguageCode) == true)) &&
                ((this.MValue == null && other.MValue == null) || (this.MValue?.Equals(other.MValue) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LanguageCode = {(this.LanguageCode == null ? "null" : this.LanguageCode == string.Empty ? "" : this.LanguageCode)}");
            toStringOutput.Add($"this.MValue = {(this.MValue == null ? "null" : this.MValue == string.Empty ? "" : this.MValue)}");

            base.ToString(toStringOutput);
        }
    }
}