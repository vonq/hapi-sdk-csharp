// <copyright file="PortfolioControllerTest.cs" company="APIMatic">
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
    /// PortfolioControllerTest.
    /// </summary>
    [TestFixture]
    public class PortfolioControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private PortfolioController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.PortfolioController;
        }

        /// <summary>
        /// For a detailed tutorial on how to get started with portfolio search v2, check out our [Quickstart Tutorial](https://pkb.stoplight.io/docs/search/docs/Tutorial.md).
        ///For an implementation demo of the product search experience, check out our [Developer Portal](http://vonq.io/pkb).
        ///This endpoint exposes a list of Products with the options to search by Location, Job Title, Job Function and Industry.
        ///Products are ranked by their relevancy to the search terms.
        ///Optionally, products can filtered by Location.
        ///Values for each parameter can be fetched by calling the other endpoints in this section.
        ///Calling this endpoint will guarantee that the Products you see are configured for you as our Partner.
        ///Besides the default English, German and Dutch result translations can be requested by specifying an `Accept-Language: [de|nl]` header..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestSearchProducts()
        {
            // Parameters for the API call
            int? limit = null;
            int? offset = null;
            List<string> includeLocationId = null;
            string exactLocationId = null;
            string jobFunctionId = null;
            string jobTitleId = null;
            List<string> industryId = null;
            string durationFrom = null;
            string durationTo = null;
            string name = null;
            string currency = null;
            Models.SortByEnum sortBy = ApiHelper.JsonDeserialize<Models.SortByEnum>("\"relevant\"");
            bool? recommended = null;
            bool? mcEnabled = null;
            Models.AcceptLanguageEnum acceptLanguage = ApiHelper.JsonDeserialize<Models.AcceptLanguageEnum>("\"en\"");
            bool? excludeRecommended = false;

            // Perform API call
            List<Models.ProductModel> result = null;
            try
            {
                result = await this.controller.SearchProductsAsync(limit, offset, includeLocationId, exactLocationId, jobFunctionId, jobTitleId, industryId, durationFrom, durationTo, name, currency, sortBy, recommended, mcEnabled, acceptLanguage, excludeRecommended);
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
    }
}