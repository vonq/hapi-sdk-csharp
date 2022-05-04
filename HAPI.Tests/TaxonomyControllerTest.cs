// <copyright file="TaxonomyControllerTest.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace VONQ
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Converters;
    using NUnit.Framework;
    using VONQ;
    using VONQ.Controllers;
    using VONQ.Exceptions;
    using VONQ.Helpers;
    using VONQ.Http.Client;
    using VONQ.Http.Response;
    using VONQ.Utilities;

    /// <summary>
    /// TaxonomyControllerTest.
    /// </summary>
    [TestFixture]
    public class TaxonomyControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private TaxonomyController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.TaxonomyController;
        }

        /// <summary>
        /// This endpoint returns a tree-like structure of supported Job Functions that can be used to search for Products.
        ///Use the `id` key of any Job Function in the response to search for a Product.
        ///Each Job Function is associated with [**`Job Titles`**](b3A6MzM0NDA3MzY-job-titles) in a one-to-many fashion.
        ///Besides the default English, German and Dutch result translations can be requested by specifying an `Accept-Language: [de|nl]` header..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestRetrieveJobFunctionsTree()
        {
            // Parameters for the API call
            Models.AcceptLanguageEnum acceptLanguage = ApiHelper.JsonDeserialize<Models.AcceptLanguageEnum>("\"en\"");

            // Perform API call
            List<Models.JobFunctionModel> result = null;
            try
            {
                result = await this.controller.RetrieveJobFunctionsTreeAsync(acceptLanguage);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.IsTrue(
                    TestHelper.IsArrayOfJsonObjectsProperSubsetOf(
                    "[{\"id\":8,\"name\":\"Education\",\"children\":[{\"id\":5,\"name\":\"Teaching\",\"children\":[]}]}]",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// This endpoint returns a list of supported industry names that can be used to search for products. Results are ordered alphabetically.
        ///Use the `id` key of any Industry in the response to search for a product.
        ///Besides the default English, German and Dutch result translations can be requested by specifying an `Accept-Language: [de|nl]` header..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestListIndustries()
        {
            // Parameters for the API call
            double? limit = null;
            double? offset = null;
            Models.AcceptLanguageEnum acceptLanguage = ApiHelper.JsonDeserialize<Models.AcceptLanguageEnum>("\"en\"");

            // Perform API call
            List<Models.IndustryModel> result = null;
            try
            {
                result = await this.controller.ListIndustriesAsync(limit, offset, acceptLanguage);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");
        }

        /// <summary>
        /// Retrieve all Education Level possible values..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestRetrieveEducationLevels()
        {
            // Perform API call
            List<Models.EducationLevelModel> result = null;
            try
            {
                result = await this.controller.RetrieveEducationLevelsAsync();
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.IsTrue(
                    TestHelper.IsArrayOfJsonObjectsProperSubsetOf(
                    "[{\"id\":1,\"name\":[{\"languageCode\":\"nl_NL\",\"value\":\"Master / Postdoctoraal\"}]}]",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Retrieve all Seniority possible values..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestRetrieveSeniorities()
        {
            // Perform API call
            List<Models.SeniorityModel> result = null;
            try
            {
                result = await this.controller.RetrieveSenioritiesAsync();
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.IsTrue(
                    TestHelper.IsArrayOfJsonObjectsProperSubsetOf(
                    "[{\"id\":3,\"name\":[{\"languageCode\":\"en_GB\",\"value\":\"Manager\"}]}]",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}