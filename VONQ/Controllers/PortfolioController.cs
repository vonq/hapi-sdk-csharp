// <copyright file="PortfolioController.cs" company="APIMatic">
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
    using VONQ.Exceptions;
    using VONQ.Http.Client;
    using VONQ.Http.Request;
    using VONQ.Http.Request.Configuration;
    using VONQ.Http.Response;
    using VONQ.Utilities;

    /// <summary>
    /// PortfolioController.
    /// </summary>
    public class PortfolioController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PortfolioController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal PortfolioController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// For a detailed tutorial on how to get started with portfolio search v2, check out our [Quickstart Tutorial](https://pkb.stoplight.io/docs/search/docs/Tutorial.md).
        /// For an implementation demo of the product search experience, check out our [Developer Portal](http://vonq.io/pkb).
        /// This endpoint exposes a list of Products with the options to search by Location, Job Title, Job Function and Industry.
        /// Products are ranked by their relevancy to the search terms.
        /// Optionally, products can filtered by Location.
        /// Values for each parameter can be fetched by calling the other endpoints in this section.
        /// Calling this endpoint will guarantee that the Products you see are configured for you as our Partner.
        /// Besides the default English, German and Dutch result translations can be requested by specifying an `Accept-Language: [de|nl]` header.
        /// </summary>
        /// <param name="limit">Optional parameter: Number of results to return per page..</param>
        /// <param name="offset">Optional parameter: The initial index from which to return the results..</param>
        /// <param name="includeLocationId">Optional parameter: Id for a Location to search products against. If no exact matches exist, search will be expanded to the Location's region and country. Optionally, a (comma-separated) array of values can be passed. Passing multiple values increases the number of search results..</param>
        /// <param name="exactLocationId">Optional parameter: Match only products specifically assigned to a Location..</param>
        /// <param name="jobFunctionId">Optional parameter: Job Function id. Not to be used in conjunction with a Job Title id..</param>
        /// <param name="jobTitleId">Optional parameter: Job title id.</param>
        /// <param name="industryId">Optional parameter: Industry Id.</param>
        /// <param name="durationFrom">Optional parameter: Match only products with a duration more or equal than a certain number of days.</param>
        /// <param name="durationTo">Optional parameter: Match only products with a duration up to a certain number of days.</param>
        /// <param name="name">Optional parameter: Search text for a product name.</param>
        /// <param name="currency">Optional parameter: ISO-4217 code for a currency.</param>
        /// <param name="sortBy">Optional parameter: Which products to show first. Defaults to 'relevant'.</param>
        /// <param name="recommended">Optional parameter: Whether to display a list of recommended products for the search parameters. If true, returns a limited list of products for the types: Job board, social media, publication and community..</param>
        /// <param name="mcEnabled">Optional parameter: Can be used to filter for products that are linked to a channel enabled for My Contracts orders.</param>
        /// <param name="acceptLanguage">Optional parameter: Example: .</param>
        /// <param name="excludeRecommended">Optional parameter: Exclude recommended products from search results. Cannot be used in combination with 'recommended'..</param>
        /// <returns>Returns the List of Models.ProductModel response from the API call.</returns>
        public List<Models.ProductModel> SearchProducts(
                int? limit = null,
                int? offset = null,
                List<string> includeLocationId = null,
                string exactLocationId = null,
                string jobFunctionId = null,
                string jobTitleId = null,
                List<string> industryId = null,
                string durationFrom = null,
                string durationTo = null,
                string name = null,
                string currency = null,
                Models.SortByEnum? sortBy = Models.SortByEnum.Relevant,
                bool? recommended = null,
                bool? mcEnabled = null,
                Models.AcceptLanguageEnum? acceptLanguage = null,
                bool? excludeRecommended = false)
        {
            Task<List<Models.ProductModel>> t = this.SearchProductsAsync(limit, offset, includeLocationId, exactLocationId, jobFunctionId, jobTitleId, industryId, durationFrom, durationTo, name, currency, sortBy, recommended, mcEnabled, acceptLanguage, excludeRecommended);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// For a detailed tutorial on how to get started with portfolio search v2, check out our [Quickstart Tutorial](https://pkb.stoplight.io/docs/search/docs/Tutorial.md).
        /// For an implementation demo of the product search experience, check out our [Developer Portal](http://vonq.io/pkb).
        /// This endpoint exposes a list of Products with the options to search by Location, Job Title, Job Function and Industry.
        /// Products are ranked by their relevancy to the search terms.
        /// Optionally, products can filtered by Location.
        /// Values for each parameter can be fetched by calling the other endpoints in this section.
        /// Calling this endpoint will guarantee that the Products you see are configured for you as our Partner.
        /// Besides the default English, German and Dutch result translations can be requested by specifying an `Accept-Language: [de|nl]` header.
        /// </summary>
        /// <param name="limit">Optional parameter: Number of results to return per page..</param>
        /// <param name="offset">Optional parameter: The initial index from which to return the results..</param>
        /// <param name="includeLocationId">Optional parameter: Id for a Location to search products against. If no exact matches exist, search will be expanded to the Location's region and country. Optionally, a (comma-separated) array of values can be passed. Passing multiple values increases the number of search results..</param>
        /// <param name="exactLocationId">Optional parameter: Match only products specifically assigned to a Location..</param>
        /// <param name="jobFunctionId">Optional parameter: Job Function id. Not to be used in conjunction with a Job Title id..</param>
        /// <param name="jobTitleId">Optional parameter: Job title id.</param>
        /// <param name="industryId">Optional parameter: Industry Id.</param>
        /// <param name="durationFrom">Optional parameter: Match only products with a duration more or equal than a certain number of days.</param>
        /// <param name="durationTo">Optional parameter: Match only products with a duration up to a certain number of days.</param>
        /// <param name="name">Optional parameter: Search text for a product name.</param>
        /// <param name="currency">Optional parameter: ISO-4217 code for a currency.</param>
        /// <param name="sortBy">Optional parameter: Which products to show first. Defaults to 'relevant'.</param>
        /// <param name="recommended">Optional parameter: Whether to display a list of recommended products for the search parameters. If true, returns a limited list of products for the types: Job board, social media, publication and community..</param>
        /// <param name="mcEnabled">Optional parameter: Can be used to filter for products that are linked to a channel enabled for My Contracts orders.</param>
        /// <param name="acceptLanguage">Optional parameter: Example: .</param>
        /// <param name="excludeRecommended">Optional parameter: Exclude recommended products from search results. Cannot be used in combination with 'recommended'..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Models.ProductModel response from the API call.</returns>
        public async Task<List<Models.ProductModel>> SearchProductsAsync(
                int? limit = null,
                int? offset = null,
                List<string> includeLocationId = null,
                string exactLocationId = null,
                string jobFunctionId = null,
                string jobTitleId = null,
                List<string> industryId = null,
                string durationFrom = null,
                string durationTo = null,
                string name = null,
                string currency = null,
                Models.SortByEnum? sortBy = Models.SortByEnum.Relevant,
                bool? recommended = null,
                bool? mcEnabled = null,
                Models.AcceptLanguageEnum? acceptLanguage = null,
                bool? excludeRecommended = false,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/products/search/");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "limit", limit },
                { "offset", offset },
                { "includeLocationId", includeLocationId },
                { "exactLocationId", exactLocationId },
                { "jobFunctionId", jobFunctionId },
                { "jobTitleId", jobTitleId },
                { "industryId", industryId },
                { "durationFrom", durationFrom },
                { "durationTo", durationTo },
                { "name", name },
                { "currency", currency },
                { "sortBy", (sortBy.HasValue) ? ApiHelper.JsonSerialize(sortBy.Value).Trim('\"') : "relevant" },
                { "recommended", recommended },
                { "mcEnabled", mcEnabled },
                { "excludeRecommended", (excludeRecommended != null) ? excludeRecommended : false },
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

            if (response.StatusCode == 400)
            {
                throw new ApiException("", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<List<Models.ProductModel>>(response.Body);
        }

        /// <summary>
        /// Sometimes you already have access to the Identification code of any particular Product and you want to retrieve the most up-to-date information about it.
        /// Besides the default English, German and Dutch result translations can be requested by specifying an `Accept-Language: [de|nl]` header.
        /// </summary>
        /// <param name="productId">Required parameter: Example: .</param>
        /// <param name="acceptLanguage">Optional parameter: Example: .</param>
        /// <returns>Returns the Models.ProductModel response from the API call.</returns>
        public Models.ProductModel RetrieveSingleProduct(
                string productId,
                Models.AcceptLanguageEnum? acceptLanguage = null)
        {
            Task<Models.ProductModel> t = this.RetrieveSingleProductAsync(productId, acceptLanguage);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Sometimes you already have access to the Identification code of any particular Product and you want to retrieve the most up-to-date information about it.
        /// Besides the default English, German and Dutch result translations can be requested by specifying an `Accept-Language: [de|nl]` header.
        /// </summary>
        /// <param name="productId">Required parameter: Example: .</param>
        /// <param name="acceptLanguage">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ProductModel response from the API call.</returns>
        public async Task<Models.ProductModel> RetrieveSingleProductAsync(
                string productId,
                Models.AcceptLanguageEnum? acceptLanguage = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/products/single/{product_id}/");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "product_id", productId },
            });

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

            return ApiHelper.JsonDeserialize<Models.ProductModel>(response.Body);
        }

        /// <summary>
        /// Sometimes you already have access to the Identification codes of more than one Product and you want to retrieve the most up-to-date information about them.
        /// Besides the default English, German and Dutch result translations can be requested by specifying an `Accept-Language: [de|nl]` header.
        /// </summary>
        /// <param name="productsIds">Required parameter: Example: .</param>
        /// <param name="acceptLanguage">Optional parameter: Example: .</param>
        /// <returns>Returns the List of Models.ProductModel response from the API call.</returns>
        public List<Models.ProductModel> RetrieveMultipleProducts(
                List<string> productsIds,
                Models.AcceptLanguageEnum? acceptLanguage = null)
        {
            Task<List<Models.ProductModel>> t = this.RetrieveMultipleProductsAsync(productsIds, acceptLanguage);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Sometimes you already have access to the Identification codes of more than one Product and you want to retrieve the most up-to-date information about them.
        /// Besides the default English, German and Dutch result translations can be requested by specifying an `Accept-Language: [de|nl]` header.
        /// </summary>
        /// <param name="productsIds">Required parameter: Example: .</param>
        /// <param name="acceptLanguage">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Models.ProductModel response from the API call.</returns>
        public async Task<List<Models.ProductModel>> RetrieveMultipleProductsAsync(
                List<string> productsIds,
                Models.AcceptLanguageEnum? acceptLanguage = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/products/multiple/{products_ids}/");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "products_ids", productsIds },
            });

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

            return ApiHelper.JsonDeserialize<List<Models.ProductModel>>(response.Body);
        }

        /// <summary>
        /// This endpoint calculates total number of days to process and setup a campaign containing a list of Products, given a comma-separated list of their ids.
        /// </summary>
        /// <param name="productsIds">Required parameter: Example: .</param>
        /// <returns>Returns the List of Models.ProductsDeliveryTimeModel response from the API call.</returns>
        public List<Models.ProductsDeliveryTimeModel> CalculateOrderDeliveryTime(
                List<string> productsIds)
        {
            Task<List<Models.ProductsDeliveryTimeModel>> t = this.CalculateOrderDeliveryTimeAsync(productsIds);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// This endpoint calculates total number of days to process and setup a campaign containing a list of Products, given a comma-separated list of their ids.
        /// </summary>
        /// <param name="productsIds">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Models.ProductsDeliveryTimeModel response from the API call.</returns>
        public async Task<List<Models.ProductsDeliveryTimeModel>> CalculateOrderDeliveryTimeAsync(
                List<string> productsIds,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/products/delivery-time/{products_ids}/");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "products_ids", productsIds },
            });

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

            return ApiHelper.JsonDeserialize<List<Models.ProductsDeliveryTimeModel>>(response.Body);
        }
    }
}