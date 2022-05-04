// <copyright file="PlaceTypeEnum.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace VONQ.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using VONQ;
    using VONQ.Utilities;

    /// <summary>
    /// PlaceTypeEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PlaceTypeEnum
    {
        /// <summary>
        /// Place.
        /// </summary>
        [EnumMember(Value = "place")]
        Place,

        /// <summary>
        /// District.
        /// </summary>
        [EnumMember(Value = "district")]
        District,

        /// <summary>
        /// Region.
        /// </summary>
        [EnumMember(Value = "region")]
        Region,

        /// <summary>
        /// Country.
        /// </summary>
        [EnumMember(Value = "country")]
        Country,

        /// <summary>
        /// Continent.
        /// </summary>
        [EnumMember(Value = "continent")]
        Continent,

        /// <summary>
        /// World.
        /// </summary>
        [EnumMember(Value = "world")]
        World
    }
}