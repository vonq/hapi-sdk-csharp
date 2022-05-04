// <copyright file="RecruiterInfoErrorsModel.cs" company="APIMatic">
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
    /// RecruiterInfoErrorsModel.
    /// </summary>
    public class RecruiterInfoErrorsModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecruiterInfoErrorsModel"/> class.
        /// </summary>
        public RecruiterInfoErrorsModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecruiterInfoErrorsModel"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        public RecruiterInfoErrorsModel(
            List<string> name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [JsonProperty("name")]
        public List<string> Name { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RecruiterInfoErrorsModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is RecruiterInfoErrorsModel other &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : $"[{string.Join(", ", this.Name)} ]")}");

            base.ToString(toStringOutput);
        }
    }
}