// <copyright file="PeriodEnum.cs" company="APIMatic">
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
    /// PeriodEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PeriodEnum
    {
        /// <summary>
        /// Yearly.
        /// </summary>
        [EnumMember(Value = "yearly")]
        Yearly,

        /// <summary>
        /// Monthly.
        /// </summary>
        [EnumMember(Value = "monthly")]
        Monthly
    }
}