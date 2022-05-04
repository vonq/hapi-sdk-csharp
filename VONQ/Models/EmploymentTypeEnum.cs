// <copyright file="EmploymentTypeEnum.cs" company="APIMatic">
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
    /// EmploymentTypeEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EmploymentTypeEnum
    {
        /// <summary>
        /// Permanent.
        /// </summary>
        [EnumMember(Value = "permanent")]
        Permanent,

        /// <summary>
        /// Temporary.
        /// </summary>
        [EnumMember(Value = "temporary")]
        Temporary,

        /// <summary>
        /// FixedTerm.
        /// </summary>
        [EnumMember(Value = "fixed_term")]
        FixedTerm,

        /// <summary>
        /// FixedTermWithOptionForPermanent.
        /// </summary>
        [EnumMember(Value = "fixed_term_with_option_for_permanent")]
        FixedTermWithOptionForPermanent,

        /// <summary>
        /// Freelance.
        /// </summary>
        [EnumMember(Value = "freelance")]
        Freelance,

        /// <summary>
        /// Traineeship.
        /// </summary>
        [EnumMember(Value = "traineeship")]
        Traineeship,

        /// <summary>
        /// Internship.
        /// </summary>
        [EnumMember(Value = "internship")]
        Internship
    }
}