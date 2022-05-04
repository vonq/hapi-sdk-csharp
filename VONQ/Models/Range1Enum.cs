// <copyright file="Range1Enum.cs" company="APIMatic">
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
    /// Range1Enum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Range1Enum
    {
        /// <summary>
        /// Hours.
        /// </summary>
        [EnumMember(Value = "hours")]
        Hours
    }
}