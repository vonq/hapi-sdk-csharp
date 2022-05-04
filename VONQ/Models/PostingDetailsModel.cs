// <copyright file="PostingDetailsModel.cs" company="APIMatic">
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
    /// PostingDetailsModel.
    /// </summary>
    public class PostingDetailsModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostingDetailsModel"/> class.
        /// </summary>
        public PostingDetailsModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostingDetailsModel"/> class.
        /// </summary>
        /// <param name="title">title.</param>
        /// <param name="description">description.</param>
        /// <param name="organization">organization.</param>
        /// <param name="workingLocation">workingLocation.</param>
        /// <param name="yearsOfExperience">yearsOfExperience.</param>
        /// <param name="employmentType">employmentType.</param>
        /// <param name="weeklyWorkingHours">weeklyWorkingHours.</param>
        /// <param name="salaryIndication">salaryIndication.</param>
        /// <param name="jobPageUrl">jobPageUrl.</param>
        /// <param name="applicationUrl">applicationUrl.</param>
        /// <param name="contactInfo">contactInfo.</param>
        public PostingDetailsModel(
            string title,
            string description,
            Models.PostingOrganizationModel organization,
            Models.PostingWorkingLocationModel workingLocation,
            double yearsOfExperience,
            Models.EmploymentTypeEnum employmentType,
            Models.PostingWeeklyWorkingHoursModel weeklyWorkingHours,
            Models.PostingSalaryIndicationModel salaryIndication,
            string jobPageUrl,
            string applicationUrl,
            Models.PostingContactInfoModel contactInfo = null)
        {
            this.Title = title;
            this.Description = description;
            this.Organization = organization;
            this.WorkingLocation = workingLocation;
            this.ContactInfo = contactInfo;
            this.YearsOfExperience = yearsOfExperience;
            this.EmploymentType = employmentType;
            this.WeeklyWorkingHours = weeklyWorkingHours;
            this.SalaryIndication = salaryIndication;
            this.JobPageUrl = jobPageUrl;
            this.ApplicationUrl = applicationUrl;
        }

        /// <summary>
        /// The title of the posting across the different Channels where the posting is going to be published.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Full description of the job posting, including all possible sections
        /// **Allowed tags:** `a[href|target], em, b, br, strong, i, li, ol, p, ul`
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets Organization.
        /// </summary>
        [JsonProperty("organization")]
        public Models.PostingOrganizationModel Organization { get; set; }

        /// <summary>
        /// Gets or sets WorkingLocation.
        /// </summary>
        [JsonProperty("workingLocation")]
        public Models.PostingWorkingLocationModel WorkingLocation { get; set; }

        /// <summary>
        /// Contact is whom to contact about the job. This may be part of the posting info for candidates to know whom they can reach out to learn more about the vacancy.
        /// </summary>
        [JsonProperty("contactInfo", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PostingContactInfoModel ContactInfo { get; set; }

        /// <summary>
        /// Numbers of years of experience required for this position
        /// </summary>
        [JsonProperty("yearsOfExperience")]
        public double YearsOfExperience { get; set; }

        /// <summary>
        /// The type of employment of the posting, whether it's a permanent position or a fixed time position
        /// </summary>
        [JsonProperty("employmentType", ItemConverterType = typeof(StringEnumConverter))]
        public Models.EmploymentTypeEnum EmploymentType { get; set; }

        /// <summary>
        /// Gets or sets WeeklyWorkingHours.
        /// </summary>
        [JsonProperty("weeklyWorkingHours")]
        public Models.PostingWeeklyWorkingHoursModel WeeklyWorkingHours { get; set; }

        /// <summary>
        /// Gets or sets SalaryIndication.
        /// </summary>
        [JsonProperty("salaryIndication")]
        public Models.PostingSalaryIndicationModel SalaryIndication { get; set; }

        /// <summary>
        /// Link to the page with the description of the job
        /// </summary>
        [JsonProperty("jobPageUrl")]
        public string JobPageUrl { get; set; }

        /// <summary>
        /// Link to the page where the candidate needs to be directed when applying for a position
        /// </summary>
        [JsonProperty("applicationUrl")]
        public string ApplicationUrl { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PostingDetailsModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is PostingDetailsModel other &&
                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.Organization == null && other.Organization == null) || (this.Organization?.Equals(other.Organization) == true)) &&
                ((this.WorkingLocation == null && other.WorkingLocation == null) || (this.WorkingLocation?.Equals(other.WorkingLocation) == true)) &&
                ((this.ContactInfo == null && other.ContactInfo == null) || (this.ContactInfo?.Equals(other.ContactInfo) == true)) &&
                this.YearsOfExperience.Equals(other.YearsOfExperience) &&
                this.EmploymentType.Equals(other.EmploymentType) &&
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
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title == string.Empty ? "" : this.Title)}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description == string.Empty ? "" : this.Description)}");
            toStringOutput.Add($"this.Organization = {(this.Organization == null ? "null" : this.Organization.ToString())}");
            toStringOutput.Add($"this.WorkingLocation = {(this.WorkingLocation == null ? "null" : this.WorkingLocation.ToString())}");
            toStringOutput.Add($"this.ContactInfo = {(this.ContactInfo == null ? "null" : this.ContactInfo.ToString())}");
            toStringOutput.Add($"this.YearsOfExperience = {this.YearsOfExperience}");
            toStringOutput.Add($"this.EmploymentType = {this.EmploymentType}");
            toStringOutput.Add($"this.WeeklyWorkingHours = {(this.WeeklyWorkingHours == null ? "null" : this.WeeklyWorkingHours.ToString())}");
            toStringOutput.Add($"this.SalaryIndication = {(this.SalaryIndication == null ? "null" : this.SalaryIndication.ToString())}");
            toStringOutput.Add($"this.JobPageUrl = {(this.JobPageUrl == null ? "null" : this.JobPageUrl == string.Empty ? "" : this.JobPageUrl)}");
            toStringOutput.Add($"this.ApplicationUrl = {(this.ApplicationUrl == null ? "null" : this.ApplicationUrl == string.Empty ? "" : this.ApplicationUrl)}");

            base.ToString(toStringOutput);
        }
    }
}