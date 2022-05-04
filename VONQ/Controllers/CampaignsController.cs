// <copyright file="CampaignsController.cs" company="APIMatic">
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
    /// CampaignsController.
    /// </summary>
    public class CampaignsController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignsController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal CampaignsController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Once your Customer has decided on a list of Channels they would like to buy, you can send the list along with.
        /// publishing information as a `POST` request in order to create a `Campaign`. In return, you'll receive.
        /// the id of the newly created `Campaign` along with the URL where you can access that Campaign information.
        /// For "My Contracts" type of Products, there is no expiration. The vacancy can be taken offline either by the job board or manually, by calling the "[Take a campaign offline](https://vonq.stoplight.io/docs/hapi/b3A6MzM0NDA3MzQ-take-a-campaign-offline)" endpoint.
        /// #### Target group.
        /// You should use the following endpoints for the target group information:.
        /// - [**`Industry`**](b3A6MzM0NDA3Mzg-industry-names).
        /// - [**`Job Function`**](b3A6MzM0NDA3MzU-job-functions).
        /// - [**`Education Level`**](b3A6MzM0NDA3Mzk-retrieve-education-level-taxonomy).
        /// - [**`Seniority`**](b3A6MzM0NDA3NDA-retrieve-seniority-taxonomy).
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="companyId">Optional parameter: Example: .</param>
        /// <param name="limit">Optional parameter: Example: .</param>
        /// <param name="offset">Optional parameter: Example: .</param>
        /// <param name="xCustomerId">Optional parameter: The ID of the end-user creating the order. Only required if you are using HAPI Job Post and creating orders with contracts..</param>
        /// <returns>Returns the Models.OrderCampaignSuccessResponseModel response from the API call.</returns>
        public Models.OrderCampaignSuccessResponseModel OrderCampaign(
                Models.CampaignOrderModel body,
                string companyId = null,
                string limit = null,
                string offset = null,
                string xCustomerId = null)
        {
            Task<Models.OrderCampaignSuccessResponseModel> t = this.OrderCampaignAsync(body, companyId, limit, offset, xCustomerId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Once your Customer has decided on a list of Channels they would like to buy, you can send the list along with.
        /// publishing information as a `POST` request in order to create a `Campaign`. In return, you'll receive.
        /// the id of the newly created `Campaign` along with the URL where you can access that Campaign information.
        /// For "My Contracts" type of Products, there is no expiration. The vacancy can be taken offline either by the job board or manually, by calling the "[Take a campaign offline](https://vonq.stoplight.io/docs/hapi/b3A6MzM0NDA3MzQ-take-a-campaign-offline)" endpoint.
        /// #### Target group.
        /// You should use the following endpoints for the target group information:.
        /// - [**`Industry`**](b3A6MzM0NDA3Mzg-industry-names).
        /// - [**`Job Function`**](b3A6MzM0NDA3MzU-job-functions).
        /// - [**`Education Level`**](b3A6MzM0NDA3Mzk-retrieve-education-level-taxonomy).
        /// - [**`Seniority`**](b3A6MzM0NDA3NDA-retrieve-seniority-taxonomy).
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="companyId">Optional parameter: Example: .</param>
        /// <param name="limit">Optional parameter: Example: .</param>
        /// <param name="offset">Optional parameter: Example: .</param>
        /// <param name="xCustomerId">Optional parameter: The ID of the end-user creating the order. Only required if you are using HAPI Job Post and creating orders with contracts..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.OrderCampaignSuccessResponseModel response from the API call.</returns>
        public async Task<Models.OrderCampaignSuccessResponseModel> OrderCampaignAsync(
                Models.CampaignOrderModel body,
                string companyId = null,
                string limit = null,
                string offset = null,
                string xCustomerId = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/campaigns/order");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "companyId", companyId },
                { "limit", limit },
                { "offset", offset },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "X-Customer-Id", xCustomerId },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText, queryParameters: queryParams);

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
                throw new OrderCampaignErrorResponseException("", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.OrderCampaignSuccessResponseModel>(response.Body);
        }

        /// <summary>
        /// Displays all the existing Campaigns already ordered for this Partner is as simple as executing a `GET`.
        /// request against the endpoint `/campaigns`.
        /// </summary>
        /// <param name="companyId">Required parameter: CompanyId to filter the results on.</param>
        /// <param name="limit">Optional parameter: Amount of products returned.</param>
        /// <param name="offset">Optional parameter: Starting point.</param>
        /// <returns>Returns the Models.ResultSet1Model response from the API call.</returns>
        public Models.ResultSet1Model ListCampaigns(
                string companyId,
                double? limit = null,
                double? offset = null)
        {
            Task<Models.ResultSet1Model> t = this.ListCampaignsAsync(companyId, limit, offset);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Displays all the existing Campaigns already ordered for this Partner is as simple as executing a `GET`.
        /// request against the endpoint `/campaigns`.
        /// </summary>
        /// <param name="companyId">Required parameter: CompanyId to filter the results on.</param>
        /// <param name="limit">Optional parameter: Amount of products returned.</param>
        /// <param name="offset">Optional parameter: Starting point.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ResultSet1Model response from the API call.</returns>
        public async Task<Models.ResultSet1Model> ListCampaignsAsync(
                string companyId,
                double? limit = null,
                double? offset = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/campaings");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "companyId", companyId },
                { "limit", limit },
                { "offset", offset },
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

            return ApiHelper.JsonDeserialize<Models.ResultSet1Model>(response.Body);
        }

        /// <summary>
        /// Retrieve the details of a specific Campaign. Only Campaigns created by the calling Partner can be.
        /// retrieved.
        /// </summary>
        /// <param name="campaignId">Required parameter: Id of the Campaign that you want to retrieve.</param>
        /// <returns>Returns the Models.ListCampaignResponseModel response from the API call.</returns>
        public Models.ListCampaignResponseModel RetrieveCampaign(
                Guid campaignId)
        {
            Task<Models.ListCampaignResponseModel> t = this.RetrieveCampaignAsync(campaignId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieve the details of a specific Campaign. Only Campaigns created by the calling Partner can be.
        /// retrieved.
        /// </summary>
        /// <param name="campaignId">Required parameter: Id of the Campaign that you want to retrieve.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListCampaignResponseModel response from the API call.</returns>
        public async Task<Models.ListCampaignResponseModel> RetrieveCampaignAsync(
                Guid campaignId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/campaigns/{campaignId}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "campaignId", campaignId },
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

            return ApiHelper.JsonDeserialize<Models.ListCampaignResponseModel>(response.Body);
        }

        /// <summary>
        /// This is a specialized endpoint for Campaign statuses only. Although the Campaign Details endpoint also returns the.
        /// status of a campaign, if you only need to get the specific status of a Campaign, this endpoint is.
        /// optimized for that.
        /// </summary>
        /// <param name="campaignId">Required parameter: Id of the Campaign you want the status of.</param>
        /// <returns>Returns the Models.CheckCampaignStatusresponseModel response from the API call.</returns>
        public Models.CheckCampaignStatusresponseModel CheckCampaignStatus(
                Guid campaignId)
        {
            Task<Models.CheckCampaignStatusresponseModel> t = this.CheckCampaignStatusAsync(campaignId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// This is a specialized endpoint for Campaign statuses only. Although the Campaign Details endpoint also returns the.
        /// status of a campaign, if you only need to get the specific status of a Campaign, this endpoint is.
        /// optimized for that.
        /// </summary>
        /// <param name="campaignId">Required parameter: Id of the Campaign you want the status of.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CheckCampaignStatusresponseModel response from the API call.</returns>
        public async Task<Models.CheckCampaignStatusresponseModel> CheckCampaignStatusAsync(
                Guid campaignId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/campaigns/{campaignId}/status");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "campaignId", campaignId },
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

            return ApiHelper.JsonDeserialize<Models.CheckCampaignStatusresponseModel>(response.Body);
        }

        /// <summary>
        /// Specific endpoint to take a campaign offline. Keep in mind that processing this might.
        /// take some time and it only has an effect if the campaign's status is "online".
        /// </summary>
        /// <param name="campaignId">Required parameter: Id of the Campaign you want to take offline.</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.TakeCampaignOfflineResponseModel response from the API call.</returns>
        public Models.TakeCampaignOfflineResponseModel TakeCampaignOffline(
                Guid campaignId,
                Models.TakeCampaignOfflineRequestModel body)
        {
            Task<Models.TakeCampaignOfflineResponseModel> t = this.TakeCampaignOfflineAsync(campaignId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Specific endpoint to take a campaign offline. Keep in mind that processing this might.
        /// take some time and it only has an effect if the campaign's status is "online".
        /// </summary>
        /// <param name="campaignId">Required parameter: Id of the Campaign you want to take offline.</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.TakeCampaignOfflineResponseModel response from the API call.</returns>
        public async Task<Models.TakeCampaignOfflineResponseModel> TakeCampaignOfflineAsync(
                Guid campaignId,
                Models.TakeCampaignOfflineRequestModel body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/campaigns/{campaignId}/cancellation");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "campaignId", campaignId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PutBody(queryBuilder.ToString(), headers, bodyText);

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
                throw new TakeCampaignOfflineErrorResponse2Exception("", context);
            }

            if (response.StatusCode == 404)
            {
                throw new TakeCampaignOfflineErrorResponseException("", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.TakeCampaignOfflineResponseModel>(response.Body);
        }
    }
}