// <copyright file="ContentTypeEnum.cs" company="APIMatic">
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
    /// ContentTypeEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ContentTypeEnum
    {
        /// <summary>
        /// EnumApplicationjson.
        /// </summary>
        [EnumMember(Value = "application/json")]
        EnumApplicationjson
    }
}