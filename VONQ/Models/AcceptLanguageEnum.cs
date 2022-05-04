// <copyright file="AcceptLanguageEnum.cs" company="APIMatic">
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
    /// AcceptLanguageEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AcceptLanguageEnum
    {
        /// <summary>
        /// En.
        /// </summary>
        [EnumMember(Value = "en")]
        En,

        /// <summary>
        /// Nl.
        /// </summary>
        [EnumMember(Value = "nl")]
        Nl,

        /// <summary>
        /// De.
        /// </summary>
        [EnumMember(Value = "de")]
        De
    }
}