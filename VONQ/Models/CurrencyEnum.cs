// <copyright file="CurrencyEnum.cs" company="APIMatic">
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
    /// CurrencyEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CurrencyEnum
    {
        /// <summary>
        /// EUR.
        /// </summary>
        [EnumMember(Value = "EUR")]
        EUR,

        /// <summary>
        /// USD.
        /// </summary>
        [EnumMember(Value = "USD")]
        USD,

        /// <summary>
        /// GBP.
        /// </summary>
        [EnumMember(Value = "GBP")]
        GBP
    }
}