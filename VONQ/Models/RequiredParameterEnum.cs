// <copyright file="RequiredParameterEnum.cs" company="APIMatic">
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
    /// RequiredParameterEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RequiredParameterEnum
    {
        /// <summary>
        /// Term.
        /// </summary>
        [EnumMember(Value = "term")]
        Term,

        /// <summary>
        /// Credentials.
        /// </summary>
        [EnumMember(Value = "credentials")]
        Credentials
    }
}