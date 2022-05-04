// <copyright file="LocationModel.cs" company="APIMatic">
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
    /// LocationModel.
    /// </summary>
    public class LocationModel : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocationModel"/> class.
        /// </summary>
        public LocationModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationModel"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="fullyQualifiedPlaceName">fully_qualified_place_name.</param>
        /// <param name="canonicalName">canonical_name.</param>
        /// <param name="boundingBox">bounding_box.</param>
        /// <param name="area">area.</param>
        /// <param name="placeType">place_type.</param>
        /// <param name="within">within.</param>
        public LocationModel(
            double id,
            string fullyQualifiedPlaceName,
            string canonicalName,
            List<double> boundingBox,
            double area,
            Models.PlaceTypeEnum placeType,
            Models.LocationModel within)
        {
            this.Id = id;
            this.FullyQualifiedPlaceName = fullyQualifiedPlaceName;
            this.CanonicalName = canonicalName;
            this.BoundingBox = boundingBox;
            this.Area = area;
            this.PlaceType = placeType;
            this.Within = within;
        }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        [JsonProperty("id")]
        public double Id { get; set; }

        /// <summary>
        /// Gets or sets FullyQualifiedPlaceName.
        /// </summary>
        [JsonProperty("fully_qualified_place_name")]
        public string FullyQualifiedPlaceName { get; set; }

        /// <summary>
        /// Gets or sets CanonicalName.
        /// </summary>
        [JsonProperty("canonical_name")]
        public string CanonicalName { get; set; }

        /// <summary>
        /// Gets or sets BoundingBox.
        /// </summary>
        [JsonProperty("bounding_box")]
        public List<double> BoundingBox { get; set; }

        /// <summary>
        /// Gets or sets Area.
        /// </summary>
        [JsonProperty("area")]
        public double Area { get; set; }

        /// <summary>
        /// Gets or sets PlaceType.
        /// </summary>
        [JsonProperty("place_type", ItemConverterType = typeof(StringEnumConverter))]
        public Models.PlaceTypeEnum PlaceType { get; set; }

        /// <summary>
        /// Gets or sets Within.
        /// </summary>
        [JsonProperty("within")]
        public Models.LocationModel Within { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LocationModel : ({string.Join(", ", toStringOutput)})";
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

            return obj is LocationModel other &&
                this.Id.Equals(other.Id) &&
                ((this.FullyQualifiedPlaceName == null && other.FullyQualifiedPlaceName == null) || (this.FullyQualifiedPlaceName?.Equals(other.FullyQualifiedPlaceName) == true)) &&
                ((this.CanonicalName == null && other.CanonicalName == null) || (this.CanonicalName?.Equals(other.CanonicalName) == true)) &&
                ((this.BoundingBox == null && other.BoundingBox == null) || (this.BoundingBox?.Equals(other.BoundingBox) == true)) &&
                this.Area.Equals(other.Area) &&
                this.PlaceType.Equals(other.PlaceType) &&
                ((this.Within == null && other.Within == null) || (this.Within?.Equals(other.Within) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {this.Id}");
            toStringOutput.Add($"this.FullyQualifiedPlaceName = {(this.FullyQualifiedPlaceName == null ? "null" : this.FullyQualifiedPlaceName == string.Empty ? "" : this.FullyQualifiedPlaceName)}");
            toStringOutput.Add($"this.CanonicalName = {(this.CanonicalName == null ? "null" : this.CanonicalName == string.Empty ? "" : this.CanonicalName)}");
            toStringOutput.Add($"this.BoundingBox = {(this.BoundingBox == null ? "null" : $"[{string.Join(", ", this.BoundingBox)} ]")}");
            toStringOutput.Add($"this.Area = {this.Area}");
            toStringOutput.Add($"this.PlaceType = {this.PlaceType}");
            toStringOutput.Add($"this.Within = {(this.Within == null ? "null" : this.Within.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}