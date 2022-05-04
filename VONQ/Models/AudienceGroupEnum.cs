// <copyright file="AudienceGroupEnum.cs" company="APIMatic">
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
    /// AudienceGroupEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AudienceGroupEnum
    {
        /// <summary>
        /// Generic.
        /// </summary>
        [EnumMember(Value = "generic")]
        Generic,

        /// <summary>
        /// Niche.
        /// </summary>
        [EnumMember(Value = "niche")]
        Niche
    }
}