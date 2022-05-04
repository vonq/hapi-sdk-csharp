// <copyright file="TypeEnum.cs" company="APIMatic">
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
    /// TypeEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TypeEnum
    {
        /// <summary>
        /// AUTOCOMPLETE.
        /// </summary>
        [EnumMember(Value = "AUTOCOMPLETE")]
        AUTOCOMPLETE,

        /// <summary>
        /// DATE.
        /// </summary>
        [EnumMember(Value = "DATE")]
        DATE,

        /// <summary>
        /// SELECT.
        /// </summary>
        [EnumMember(Value = "SELECT")]
        SELECT,

        /// <summary>
        /// TEXT.
        /// </summary>
        [EnumMember(Value = "TEXT")]
        TEXT,

        /// <summary>
        /// TEXTAREA.
        /// </summary>
        [EnumMember(Value = "TEXTAREA")]
        TEXTAREA,

        /// <summary>
        /// TEXTEXPAND.
        /// </summary>
        [EnumMember(Value = "TEXTEXPAND")]
        TEXTEXPAND,

        /// <summary>
        /// AREACOUNT.
        /// </summary>
        [EnumMember(Value = "AREACOUNT")]
        AREACOUNT,

        /// <summary>
        /// HIER.
        /// </summary>
        [EnumMember(Value = "HIER")]
        HIER,

        /// <summary>
        /// STATISCH.
        /// </summary>
        [EnumMember(Value = "STATISCH")]
        STATISCH,

        /// <summary>
        /// MULTIPLE.
        /// </summary>
        [EnumMember(Value = "MULTIPLE")]
        MULTIPLE,

        /// <summary>
        /// SELECTMAPONLY.
        /// </summary>
        [EnumMember(Value = "SELECT-MAP_ONLY")]
        SELECTMAPONLY
    }
}