// <copyright file="ContractsControllerTest.cs" company="APIMatic">
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
    /// ContractsControllerTest.
    /// </summary>
    [TestFixture]
    public class ContractsControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private ContractsController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.ContractsController;
        }

        /// <summary>
        /// This endpoint exposes a list of channels with support for contracts. For all of the required details for creating a contract or a campaign for each channel, please call the "Retrieve details for channel with support for contracts"..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestListChannels()
        {
            // Parameters for the API call
            string search = null;
            int? limit = null;
            int? offset = null;
            Models.AcceptLanguageEnum acceptLanguage = ApiHelper.JsonDeserialize<Models.AcceptLanguageEnum>("\"en\"");

            // Perform API call
            Models.ListChannelsResponseModel result = null;
            try
            {
                result = await this.controller.ListChannelsAsync(search, limit, offset, acceptLanguage);
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
                    TestHelper.IsJsonObjectProperSubsetOf(
                    "{\"count\":0,\"next\":\"string\",\"previous\":\"string\",\"results\":[{\"mc_enabled\":true,\"id\":0,\"name\":\"string\",\"url\":\"string\",\"type\":\"string\"}]}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}