// <copyright file="ChannelStatusEnum.cs" company="APIMatic">
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
    /// ChannelStatusEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ChannelStatusEnum
    {
        /// <summary>
        /// Online.
        /// </summary>
        [EnumMember(Value = "online")]
        Online,

        /// <summary>
        /// Offline.
        /// </summary>
        [EnumMember(Value = "offline")]
        Offline,

        /// <summary>
        /// EnumInProgress.
        /// </summary>
        [EnumMember(Value = "in progress")]
        EnumInProgress,

        /// <summary>
        /// EnumNotProcessed.
        /// </summary>
        [EnumMember(Value = "not processed")]
        EnumNotProcessed
    }
}