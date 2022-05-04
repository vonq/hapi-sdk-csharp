// <copyright file="ChannelTypeEnum.cs" company="APIMatic">
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
    /// ChannelTypeEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ChannelTypeEnum
    {
        /// <summary>
        /// EnumJobBoard.
        /// </summary>
        [EnumMember(Value = "job board")]
        EnumJobBoard,

        /// <summary>
        /// EnumSocialMedia.
        /// </summary>
        [EnumMember(Value = "social media")]
        EnumSocialMedia,

        /// <summary>
        /// Community.
        /// </summary>
        [EnumMember(Value = "community")]
        Community,

        /// <summary>
        /// Publication.
        /// </summary>
        [EnumMember(Value = "publication")]
        Publication,

        /// <summary>
        /// Aggregator.
        /// </summary>
        [EnumMember(Value = "aggregator")]
        Aggregator
    }
}