// <copyright file="RuleEnum.cs" company="APIMatic">
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
    /// RuleEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RuleEnum
    {
        /// <summary>
        /// Date.
        /// </summary>
        [EnumMember(Value = "date")]
        Date,

        /// <summary>
        /// Email.
        /// </summary>
        [EnumMember(Value = "email")]
        Email,

        /// <summary>
        /// Int.
        /// </summary>
        [EnumMember(Value = "int")]
        Int,

        /// <summary>
        /// Float.
        /// </summary>
        [EnumMember(Value = "float")]
        Float,

        /// <summary>
        /// Regex.
        /// </summary>
        [EnumMember(Value = "regex")]
        Regex,

        /// <summary>
        /// Lower.
        /// </summary>
        [EnumMember(Value = "lower")]
        Lower,

        /// <summary>
        /// Higher.
        /// </summary>
        [EnumMember(Value = "higher")]
        Higher,

        /// <summary>
        /// Min.
        /// </summary>
        [EnumMember(Value = "min")]
        Min,

        /// <summary>
        /// Max.
        /// </summary>
        [EnumMember(Value = "max")]
        Max,

        /// <summary>
        /// Minitems.
        /// </summary>
        [EnumMember(Value = "minitems")]
        Minitems,

        /// <summary>
        /// Maxitems.
        /// </summary>
        [EnumMember(Value = "maxitems")]
        Maxitems,

        /// <summary>
        /// Minlength.
        /// </summary>
        [EnumMember(Value = "minlength")]
        Minlength,

        /// <summary>
        /// Maxlength.
        /// </summary>
        [EnumMember(Value = "maxlength")]
        Maxlength,

        /// <summary>
        /// Before.
        /// </summary>
        [EnumMember(Value = "before")]
        Before,

        /// <summary>
        /// After.
        /// </summary>
        [EnumMember(Value = "after")]
        After,

        /// <summary>
        /// Url.
        /// </summary>
        [EnumMember(Value = "url")]
        Url,

        /// <summary>
        /// Bepc.
        /// </summary>
        [EnumMember(Value = "be-pc")]
        Bepc,

        /// <summary>
        /// Belgiumcity.
        /// </summary>
        [EnumMember(Value = "belgiumcity")]
        Belgiumcity,

        /// <summary>
        /// Decity.
        /// </summary>
        [EnumMember(Value = "de-city")]
        Decity,

        /// <summary>
        /// Dutchcity.
        /// </summary>
        [EnumMember(Value = "dutchcity")]
        Dutchcity,

        /// <summary>
        /// Isodateoptionaltie.
        /// </summary>
        [EnumMember(Value = "isodateoptionaltie")]
        Isodateoptionaltie,

        /// <summary>
        /// Maxlengthcombined.
        /// </summary>
        [EnumMember(Value = "maxlengthcombined")]
        Maxlengthcombined,

        /// <summary>
        /// Maxlevels.
        /// </summary>
        [EnumMember(Value = "maxlevels")]
        Maxlevels,

        /// <summary>
        /// Nlpc.
        /// </summary>
        [EnumMember(Value = "nl-pc")]
        Nlpc,

        /// <summary>
        /// Nlpcstraat.
        /// </summary>
        [EnumMember(Value = "nl-pc-straat")]
        Nlpcstraat,

        /// <summary>
        /// Notequal.
        /// </summary>
        [EnumMember(Value = "notequal")]
        Notequal,

        /// <summary>
        /// PropertyId.
        /// </summary>
        [EnumMember(Value = "propertyId")]
        PropertyId,

        /// <summary>
        /// Pushvalue.
        /// </summary>
        [EnumMember(Value = "pushvalue")]
        Pushvalue,

        /// <summary>
        /// Separator.
        /// </summary>
        [EnumMember(Value = "separator")]
        Separator,

        /// <summary>
        /// Ukpc.
        /// </summary>
        [EnumMember(Value = "uk-pc")]
        Ukpc,

        /// <summary>
        /// EnumValidatorcheckKeywords.
        /// </summary>
        [EnumMember(Value = "validator:checkKeywords")]
        EnumValidatorcheckKeywords,

        /// <summary>
        /// EnumValidatorinRange.
        /// </summary>
        [EnumMember(Value = "validator:inRange")]
        EnumValidatorinRange,

        /// <summary>
        /// EnumValidatorkruispunt.
        /// </summary>
        [EnumMember(Value = "validator:kruispunt")]
        EnumValidatorkruispunt,

        /// <summary>
        /// EnumValidatornotEmptyIf.
        /// </summary>
        [EnumMember(Value = "validator:notEmptyIf")]
        EnumValidatornotEmptyIf
    }
}