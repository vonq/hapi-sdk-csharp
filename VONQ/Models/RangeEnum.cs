// <copyright file="RangeEnum.cs" company="APIMatic">
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
    /// RangeEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RangeEnum
    {
        /// <summary>
        /// Days.
        /// </summary>
        [EnumMember(Value = "days")]
        Days,

        /// <summary>
        /// Months.
        /// </summary>
        [EnumMember(Value = "months")]
        Months,

        /// <summary>
        /// Years.
        /// </summary>
        [EnumMember(Value = "years")]
        Years
    }
}