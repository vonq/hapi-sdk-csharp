// <copyright file="SortByEnum.cs" company="APIMatic">
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
    /// SortByEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SortByEnum
    {
        /// <summary>
        /// Relevant.
        /// </summary>
        [EnumMember(Value = "relevant")]
        Relevant,

        /// <summary>
        /// Recent.
        /// </summary>
        [EnumMember(Value = "recent")]
        Recent,

        /// <summary>
        /// EnumOrderFrequencydesc.
        /// </summary>
        [EnumMember(Value = "order_frequency.desc")]
        EnumOrderFrequencydesc,

        /// <summary>
        /// EnumOrderFrequencyasc.
        /// </summary>
        [EnumMember(Value = "order_frequency.asc")]
        EnumOrderFrequencyasc,

        /// <summary>
        /// EnumCreateddesc.
        /// </summary>
        [EnumMember(Value = "created.desc")]
        EnumCreateddesc,

        /// <summary>
        /// EnumCreatedasc.
        /// </summary>
        [EnumMember(Value = "created.asc")]
        EnumCreatedasc,

        /// <summary>
        /// EnumListPricedesc.
        /// </summary>
        [EnumMember(Value = "list_price.desc")]
        EnumListPricedesc,

        /// <summary>
        /// EnumListPriceasc.
        /// </summary>
        [EnumMember(Value = "list_price.asc")]
        EnumListPriceasc
    }
}