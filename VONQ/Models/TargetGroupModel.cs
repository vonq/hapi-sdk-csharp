// <copyright file="TargetGroupModel.cs" company="APIMatic">
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
    /// TargetGroupModel.
    /// </summary>
    public class TargetGroupModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TargetGroupModel"/> class.
        /// </summary>
        public TargetGroupModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TargetGroupModel"/> class.
        /// </summary>
        /// <param name="educationLevel">educationLevel.</param>
        /// <param name="seniority">seniority.</param>
        /// <param name="industry">industry.</param>
        /// <param name="jobCategory">jobCategory.</param>
        public TargetGroupModel(
            List<Models.TargetGroupElementModel> educationLevel,
            List<Models.TargetGroupElementModel> seniority,
            List<Models.TargetGroupElementModel> industry,
            List<Models.TargetGroupElementModel> jobCategory)
        {
            this.EducationLevel = educationLevel;
            this.Seniority = seniority;
            this.Industry = industry;
            this.JobCategory = jobCategory;
        }

        /// <summary>
        /// Education Level required by the Candidate. You can specify only one value.
        /// </summary>
        [JsonProperty("educationLevel")]
        public List<Models.TargetGroupElementModel> EducationLevel { get; set; }

        /// <summary>
        /// Seniority Level expected by the Candidate. You can specify only one value.
        /// </summary>
        [JsonProperty("seniority")]
        public List<Models.TargetGroupElementModel> Seniority { get; set; }

        /// <summary>
        /// The Industry related to the Position open. You can specify only one value.
        /// </summary>
        [JsonProperty("industry")]
        public List<Models.TargetGroupElementModel> Industry { get; set; }

        /// <summary>
        /// Job Category indicates the type of Position that's open. You can specify only one value.
        /// </summary>
        [JsonProperty("jobCategory")]
        public List<Models.TargetGroupElementModel> JobCategory { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TargetGroupModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is TargetGroupModel other &&
                ((this.EducationLevel == null && other.EducationLevel == null) || (this.EducationLevel?.Equals(other.EducationLevel) == true)) &&
                ((this.Seniority == null && other.Seniority == null) || (this.Seniority?.Equals(other.Seniority) == true)) &&
                ((this.Industry == null && other.Industry == null) || (this.Industry?.Equals(other.Industry) == true)) &&
                ((this.JobCategory == null && other.JobCategory == null) || (this.JobCategory?.Equals(other.JobCategory) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.EducationLevel = {(this.EducationLevel == null ? "null" : $"[{string.Join(", ", this.EducationLevel)} ]")}");
            toStringOutput.Add($"this.Seniority = {(this.Seniority == null ? "null" : $"[{string.Join(", ", this.Seniority)} ]")}");
            toStringOutput.Add($"this.Industry = {(this.Industry == null ? "null" : $"[{string.Join(", ", this.Industry)} ]")}");
            toStringOutput.Add($"this.JobCategory = {(this.JobCategory == null ? "null" : $"[{string.Join(", ", this.JobCategory)} ]")}");

            base.ToString(toStringOutput);
        }
    }
}