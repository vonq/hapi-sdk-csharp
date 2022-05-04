// <copyright file="PostingOrganizationModel.cs" company="APIMatic">
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
    /// PostingOrganizationModel.
    /// </summary>
    public class PostingOrganizationModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostingOrganizationModel"/> class.
        /// </summary>
        public PostingOrganizationModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostingOrganizationModel"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="companyLogo">companyLogo.</param>
        public PostingOrganizationModel(
            string name,
            string companyLogo)
        {
            this.Name = name;
            this.CompanyLogo = companyLogo;
        }

        /// <summary>
        /// Name of the Company
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The company Logo that wants to be used on the posting. It has to be publicly available so it's picked up
        /// and used for the different publishing platforms
        /// </summary>
        [JsonProperty("companyLogo")]
        public string CompanyLogo { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PostingOrganizationModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is PostingOrganizationModel other &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.CompanyLogo == null && other.CompanyLogo == null) || (this.CompanyLogo?.Equals(other.CompanyLogo) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.CompanyLogo = {(this.CompanyLogo == null ? "null" : this.CompanyLogo == string.Empty ? "" : this.CompanyLogo)}");

            base.ToString(toStringOutput);
        }
    }
}