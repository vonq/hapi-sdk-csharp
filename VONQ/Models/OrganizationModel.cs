// <copyright file="OrganizationModel.cs" company="APIMatic">
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
    /// OrganizationModel.
    /// </summary>
    public class OrganizationModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationModel"/> class.
        /// </summary>
        public OrganizationModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationModel"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="companyLogo">companyLogo.</param>
        public OrganizationModel(
            List<string> name,
            List<string> companyLogo)
        {
            this.Name = name;
            this.CompanyLogo = companyLogo;
        }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [JsonProperty("name")]
        public List<string> Name { get; set; }

        /// <summary>
        /// Gets or sets CompanyLogo.
        /// </summary>
        [JsonProperty("companyLogo")]
        public List<string> CompanyLogo { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrganizationModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is OrganizationModel other &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.CompanyLogo == null && other.CompanyLogo == null) || (this.CompanyLogo?.Equals(other.CompanyLogo) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : $"[{string.Join(", ", this.Name)} ]")}");
            toStringOutput.Add($"this.CompanyLogo = {(this.CompanyLogo == null ? "null" : $"[{string.Join(", ", this.CompanyLogo)} ]")}");

            base.ToString(toStringOutput);
        }
    }
}