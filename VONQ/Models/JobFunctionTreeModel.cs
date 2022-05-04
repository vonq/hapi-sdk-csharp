// <copyright file="JobFunctionTreeModel.cs" company="APIMatic">
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
    /// JobFunctionTreeModel.
    /// </summary>
    public class JobFunctionTreeModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JobFunctionTreeModel"/> class.
        /// </summary>
        public JobFunctionTreeModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobFunctionTreeModel"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="name">name.</param>
        /// <param name="children">children.</param>
        public JobFunctionTreeModel(
            double id,
            string name,
            List<Models.JobFunctionTreeModel> children)
        {
            this.Id = id;
            this.Name = name;
            this.Children = children;
        }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        [JsonProperty("id")]
        public double Id { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Children.
        /// </summary>
        [JsonProperty("children")]
        public List<Models.JobFunctionTreeModel> Children { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"JobFunctionTreeModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is JobFunctionTreeModel other &&
                this.Id.Equals(other.Id) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Children == null && other.Children == null) || (this.Children?.Equals(other.Children) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {this.Id}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.Children = {(this.Children == null ? "null" : $"[{string.Join(", ", this.Children)} ]")}");

            base.ToString(toStringOutput);
        }
    }
}