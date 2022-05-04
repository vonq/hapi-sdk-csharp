// <copyright file="TaxonomyController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace VONQ.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Converters;
    using VONQ;
    using VONQ.Authentication;
    using VONQ.Http.Client;
    using VONQ.Http.Request;
    using VONQ.Http.Request.Configuration;
    using VONQ.Http.Response;
    using VONQ.Utilities;

    /// <summary>
    /// TaxonomyController.
    /// </summary>
    public class TaxonomyController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaxonomyController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal TaxonomyController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// This endpoint returns a tree-like structure of supported Job Functions that can be used to search for Products.
        /// Use the `id` key of any Job Function in the response to search for a Product.
        /// Each Job Function is associated with [**`Job Titles`**](b3A6MzM0NDA3MzY-job-titles) in a one-to-many fashion.
        /// Besides the default English, German and Dutch result translations can be requested by specifying an `Accept-Language: [de|nl]` header.
        /// </summary>
        /// <param name="acceptLanguage">Optional parameter: Example: .</param>
        /// <returns>Returns the List of Models.JobFunctionModel response from the API call.</returns>
        public List<Models.JobFunctionModel> RetrieveJobFunctionsTree(
                Models.AcceptLanguageEnum? acceptLanguage = null)
        {
            Task<List<Models.JobFunctionModel>> t = this.RetrieveJobFunctionsTreeAsync(acceptLanguage);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// This endpoint returns a tree-like structure of supported Job Functions that can be used to search for Products.
        /// Use the `id` key of any Job Function in the response to search for a Product.
        /// Each Job Function is associated with [**`Job Titles`**](b3A6MzM0NDA3MzY-job-titles) in a one-to-many fashion.
        /// Besides the default English, German and Dutch result translations can be requested by specifying an `Accept-Language: [de|nl]` header.
        /// </summary>
        /// <param name="acceptLanguage">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Models.JobFunctionModel response from the API call.</returns>
        public async Task<List<Models.JobFunctionModel>> RetrieveJobFunctionsTreeAsync(
                Models.AcceptLanguageEnum? acceptLanguage = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/products/job-functions/");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Accept-Language", (acceptLanguage.HasValue) ? ApiHelper.JsonSerialize(acceptLanguage.Value).Trim('\"') : null },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<List<Models.JobFunctionModel>>(response.Body);
        }

        /// <summary>
        /// This endpoint takes any text as input and returns a list of supported Job Titles matching the query, ordered by popularity.
        /// Use the `id` key of each object in the response to search for a Product.
        /// Currently, we support 4,000 job titles for each of the following languages: English, Dutch and German.
        /// Each Job Title is associated with a [**`Job Function`**](b3A6MzM0NDA3MzU-job-functions) in a many-to-one fashion.
        /// Besides the default English, German and Dutch result translations can be requested by specifying an `Accept-Language: [de|nl]` header.
        /// </summary>
        /// <param name="text">Required parameter: Search text for a job title name.</param>
        /// <param name="limit">Optional parameter: Number of results to return per page..</param>
        /// <param name="offset">Optional parameter: The initial index from which to return the results..</param>
        /// <param name="acceptLanguage">Optional parameter: Example: .</param>
        /// <returns>Returns the List of Models.JobTitleModel response from the API call.</returns>
        public List<Models.JobTitleModel> SearchJobTitles(
                string text,
                double? limit = null,
                double? offset = null,
                Models.AcceptLanguageEnum? acceptLanguage = null)
        {
            Task<List<Models.JobTitleModel>> t = this.SearchJobTitlesAsync(text, limit, offset, acceptLanguage);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// This endpoint takes any text as input and returns a list of supported Job Titles matching the query, ordered by popularity.
        /// Use the `id` key of each object in the response to search for a Product.
        /// Currently, we support 4,000 job titles for each of the following languages: English, Dutch and German.
        /// Each Job Title is associated with a [**`Job Function`**](b3A6MzM0NDA3MzU-job-functions) in a many-to-one fashion.
        /// Besides the default English, German and Dutch result translations can be requested by specifying an `Accept-Language: [de|nl]` header.
        /// </summary>
        /// <param name="text">Required parameter: Search text for a job title name.</param>
        /// <param name="limit">Optional parameter: Number of results to return per page..</param>
        /// <param name="offset">Optional parameter: The initial index from which to return the results..</param>
        /// <param name="acceptLanguage">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Models.JobTitleModel response from the API call.</returns>
        public async Task<List<Models.JobTitleModel>> SearchJobTitlesAsync(
                string text,
                double? limit = null,
                double? offset = null,
                Models.AcceptLanguageEnum? acceptLanguage = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/products/job-titles/");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "text", text },
                { "limit", limit },
                { "offset", offset },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Accept-Language", (acceptLanguage.HasValue) ? ApiHelper.JsonSerialize(acceptLanguage.Value).Trim('\"') : null },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<List<Models.JobTitleModel>>(response.Body);
        }

        /// <summary>
        /// This endpoint takes any text as input and returns a list of Locations matching the query, ordered by popularity.
        /// Each response will include the entire world as a Location, even no Locations match the text query.
        /// Use the `id` key of each object in the response to search for a Product.
        /// Supports text input in English, Dutch and German.
        /// </summary>
        /// <param name="text">Required parameter: Search text for a location name in either English, Dutch, German, French and Italian. Partial recognition of 20 other languages..</param>
        /// <returns>Returns the List of Models.LocationModel response from the API call.</returns>
        public List<Models.LocationModel> SearchLocations(
                string text)
        {
            Task<List<Models.LocationModel>> t = this.SearchLocationsAsync(text);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// This endpoint takes any text as input and returns a list of Locations matching the query, ordered by popularity.
        /// Each response will include the entire world as a Location, even no Locations match the text query.
        /// Use the `id` key of each object in the response to search for a Product.
        /// Supports text input in English, Dutch and German.
        /// </summary>
        /// <param name="text">Required parameter: Search text for a location name in either English, Dutch, German, French and Italian. Partial recognition of 20 other languages..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Models.LocationModel response from the API call.</returns>
        public async Task<List<Models.LocationModel>> SearchLocationsAsync(
                string text,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/products/location/search/");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "text", text },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<List<Models.LocationModel>>(response.Body);
        }

        /// <summary>
        /// This endpoint returns a list of supported industry names that can be used to search for products. Results are ordered alphabetically.
        /// Use the `id` key of any Industry in the response to search for a product.
        /// Besides the default English, German and Dutch result translations can be requested by specifying an `Accept-Language: [de|nl]` header.
        /// </summary>
        /// <param name="limit">Optional parameter: Number of results to return per page..</param>
        /// <param name="offset">Optional parameter: The initial index from which to return the results..</param>
        /// <param name="acceptLanguage">Optional parameter: Example: .</param>
        /// <returns>Returns the List of Models.IndustryModel response from the API call.</returns>
        public List<Models.IndustryModel> ListIndustries(
                double? limit = null,
                double? offset = null,
                Models.AcceptLanguageEnum? acceptLanguage = null)
        {
            Task<List<Models.IndustryModel>> t = this.ListIndustriesAsync(limit, offset, acceptLanguage);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// This endpoint returns a list of supported industry names that can be used to search for products. Results are ordered alphabetically.
        /// Use the `id` key of any Industry in the response to search for a product.
        /// Besides the default English, German and Dutch result translations can be requested by specifying an `Accept-Language: [de|nl]` header.
        /// </summary>
        /// <param name="limit">Optional parameter: Number of results to return per page..</param>
        /// <param name="offset">Optional parameter: The initial index from which to return the results..</param>
        /// <param name="acceptLanguage">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Models.IndustryModel response from the API call.</returns>
        public async Task<List<Models.IndustryModel>> ListIndustriesAsync(
                double? limit = null,
                double? offset = null,
                Models.AcceptLanguageEnum? acceptLanguage = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/products/industries/");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "limit", limit },
                { "offset", offset },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Accept-Language", (acceptLanguage.HasValue) ? ApiHelper.JsonSerialize(acceptLanguage.Value).Trim('\"') : null },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<List<Models.IndustryModel>>(response.Body);
        }

        /// <summary>
        /// Retrieve all Education Level possible values.
        /// </summary>
        /// <returns>Returns the List of Models.EducationLevelModel response from the API call.</returns>
        public List<Models.EducationLevelModel> RetrieveEducationLevels()
        {
            Task<List<Models.EducationLevelModel>> t = this.RetrieveEducationLevelsAsync();
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieve all Education Level possible values.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Models.EducationLevelModel response from the API call.</returns>
        public async Task<List<Models.EducationLevelModel>> RetrieveEducationLevelsAsync(CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/taxonomy/education-levels");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<List<Models.EducationLevelModel>>(response.Body);
        }

        /// <summary>
        /// Retrieve all Seniority possible values.
        /// </summary>
        /// <returns>Returns the List of Models.SeniorityModel response from the API call.</returns>
        public List<Models.SeniorityModel> RetrieveSeniorities()
        {
            Task<List<Models.SeniorityModel>> t = this.RetrieveSenioritiesAsync();
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieve all Seniority possible values.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Models.SeniorityModel response from the API call.</returns>
        public async Task<List<Models.SeniorityModel>> RetrieveSenioritiesAsync(CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/taxonomy/seniority");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<List<Models.SeniorityModel>>(response.Body);
        }
    }
}