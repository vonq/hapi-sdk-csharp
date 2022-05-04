// <copyright file="PostingDetailsErrorsModel.cs" company="APIMatic">
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
    /// PostingDetailsErrorsModel.
    /// </summary>
    public class PostingDetailsErrorsModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostingDetailsErrorsModel"/> class.
        /// </summary>
        public PostingDetailsErrorsModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostingDetailsErrorsModel"/> class.
        /// </summary>
        /// <param name="title">title.</param>
        /// <param name="description">description.</param>
        /// <param name="yearsOfExperience">yearsOfExperience.</param>
        /// <param name="employmentType">employmentType.</param>
        /// <param name="organization">organization.</param>
        /// <param name="workingLocation">workingLocation.</param>
        /// <param name="weeklyWorkingHours">weeklyWorkingHours.</param>
        /// <param name="salaryIndication">salaryIndication.</param>
        /// <param name="jobPageUrl">jobPageUrl.</param>
        /// <param name="applicationUrl">applicationUrl.</param>
        public PostingDetailsErrorsModel(
            List<string> title,
            List<string> description,
            List<string> yearsOfExperience,
            List<string> employmentType,
            Models.OrganizationModel organization,
            Models.WorkingLocationModel workingLocation,
            Models.WeeklyWorkingHoursModel weeklyWorkingHours,
            Models.SalaryIndicationModel salaryIndication,
            List<string> jobPageUrl,
            List<string> applicationUrl)
        {
            this.Title = title;
            this.Description = description;
            this.YearsOfExperience = yearsOfExperience;
            this.EmploymentType = employmentType;
            this.Organization = organization;
            this.WorkingLocation = workingLocation;
            this.WeeklyWorkingHours = weeklyWorkingHours;
            this.SalaryIndication = salaryIndication;
            this.JobPageUrl = jobPageUrl;
            this.ApplicationUrl = applicationUrl;
        }

        /// <summary>
        /// Gets or sets Title.
        /// </summary>
        [JsonProperty("title")]
        public List<string> Title { get; set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        [JsonProperty("description")]
        public List<string> Description { get; set; }

        /// <summary>
        /// Gets or sets YearsOfExperience.
        /// </summary>
        [JsonProperty("yearsOfExperience")]
        public List<string> YearsOfExperience { get; set; }

        /// <summary>
        /// Gets or sets EmploymentType.
        /// </summary>
        [JsonProperty("employmentType")]
        public List<string> EmploymentType { get; set; }

        /// <summary>
        /// Gets or sets Organization.
        /// </summary>
        [JsonProperty("organization")]
        public Models.OrganizationModel Organization { get; set; }

        /// <summary>
        /// Gets or sets WorkingLocation.
        /// </summary>
        [JsonProperty("workingLocation")]
        public Models.WorkingLocationModel WorkingLocation { get; set; }

        /// <summary>
        /// Gets or sets WeeklyWorkingHours.
        /// </summary>
        [JsonProperty("weeklyWorkingHours")]
        public Models.WeeklyWorkingHoursModel WeeklyWorkingHours { get; set; }

        /// <summary>
        /// Gets or sets SalaryIndication.
        /// </summary>
        [JsonProperty("salaryIndication")]
        public Models.SalaryIndicationModel SalaryIndication { get; set; }

        /// <summary>
        /// Gets or sets JobPageUrl.
        /// </summary>
        [JsonProperty("jobPageUrl")]
        public List<string> JobPageUrl { get; set; }

        /// <summary>
        /// Gets or sets ApplicationUrl.
        /// </summary>
        [JsonProperty("applicationUrl")]
        public List<string> ApplicationUrl { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PostingDetailsErrorsModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is PostingDetailsErrorsModel other &&
                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.YearsOfExperience == null && other.YearsOfExperience == null) || (this.YearsOfExperience?.Equals(other.YearsOfExperience) == true)) &&
                ((this.EmploymentType == null && other.EmploymentType == null) || (this.EmploymentType?.Equals(other.EmploymentType) == true)) &&
                ((this.Organization == null && other.Organization == null) || (this.Organization?.Equals(other.Organization) == true)) &&
                ((this.WorkingLocation == null && other.WorkingLocation == null) || (this.WorkingLocation?.Equals(other.WorkingLocation) == true)) &&
                ((this.WeeklyWorkingHours == null && other.WeeklyWorkingHours == null) || (this.WeeklyWorkingHours?.Equals(other.WeeklyWorkingHours) == true)) &&
                ((this.SalaryIndication == null && other.SalaryIndication == null) || (this.SalaryIndication?.Equals(other.SalaryIndication) == true)) &&
                ((this.JobPageUrl == null && other.JobPageUrl == null) || (this.JobPageUrl?.Equals(other.JobPageUrl) == true)) &&
                ((this.ApplicationUrl == null && other.ApplicationUrl == null) || (this.ApplicationUrl?.Equals(other.ApplicationUrl) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : $"[{string.Join(", ", this.Title)} ]")}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : $"[{string.Join(", ", this.Description)} ]")}");
            toStringOutput.Add($"this.YearsOfExperience = {(this.YearsOfExperience == null ? "null" : $"[{string.Join(", ", this.YearsOfExperience)} ]")}");
            toStringOutput.Add($"this.EmploymentType = {(this.EmploymentType == null ? "null" : $"[{string.Join(", ", this.EmploymentType)} ]")}");
            toStringOutput.Add($"this.Organization = {(this.Organization == null ? "null" : this.Organization.ToString())}");
            toStringOutput.Add($"this.WorkingLocation = {(this.WorkingLocation == null ? "null" : this.WorkingLocation.ToString())}");
            toStringOutput.Add($"this.WeeklyWorkingHours = {(this.WeeklyWorkingHours == null ? "null" : this.WeeklyWorkingHours.ToString())}");
            toStringOutput.Add($"this.SalaryIndication = {(this.SalaryIndication == null ? "null" : this.SalaryIndication.ToString())}");
            toStringOutput.Add($"this.JobPageUrl = {(this.JobPageUrl == null ? "null" : $"[{string.Join(", ", this.JobPageUrl)} ]")}");
            toStringOutput.Add($"this.ApplicationUrl = {(this.ApplicationUrl == null ? "null" : $"[{string.Join(", ", this.ApplicationUrl)} ]")}");

            base.ToString(toStringOutput);
        }
    }
}