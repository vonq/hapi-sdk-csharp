// <copyright file="ContractsController.cs" company="APIMatic">
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
    /// ContractsController.
    /// </summary>
    public class ContractsController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContractsController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal ContractsController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// This endpoint exposes a list of channels with support for contracts. For all of the required details for creating a contract or a campaign for each channel, please call the "Retrieve details for channel with support for contracts".
        /// </summary>
        /// <param name="search">Optional parameter: A search term..</param>
        /// <param name="limit">Optional parameter: Number of results to return per page..</param>
        /// <param name="offset">Optional parameter: The initial index from which to return the results..</param>
        /// <param name="acceptLanguage">Optional parameter: The language the client prefers..</param>
        /// <returns>Returns the Models.ListChannelsResponseModel response from the API call.</returns>
        public Models.ListChannelsResponseModel ListChannels(
                string search = null,
                int? limit = null,
                int? offset = null,
                Models.AcceptLanguageEnum? acceptLanguage = null)
        {
            Task<Models.ListChannelsResponseModel> t = this.ListChannelsAsync(search, limit, offset, acceptLanguage);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// This endpoint exposes a list of channels with support for contracts. For all of the required details for creating a contract or a campaign for each channel, please call the "Retrieve details for channel with support for contracts".
        /// </summary>
        /// <param name="search">Optional parameter: A search term..</param>
        /// <param name="limit">Optional parameter: Number of results to return per page..</param>
        /// <param name="offset">Optional parameter: The initial index from which to return the results..</param>
        /// <param name="acceptLanguage">Optional parameter: The language the client prefers..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListChannelsResponseModel response from the API call.</returns>
        public async Task<Models.ListChannelsResponseModel> ListChannelsAsync(
                string search = null,
                int? limit = null,
                int? offset = null,
                Models.AcceptLanguageEnum? acceptLanguage = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/products/channels/mocs/");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "search", search },
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

            return ApiHelper.JsonDeserialize<Models.ListChannelsResponseModel>(response.Body);
        }

        /// <summary>
        /// This endpoint exposes the details of a channel with support for contracts,as well as all the required details for creating a contract or a campaign for each channel.
        /// </summary>
        /// <param name="channelId">Required parameter: ID of the channel.</param>
        /// <param name="acceptLanguage">Optional parameter: The language the client prefers..</param>
        /// <returns>Returns the Models.ChannelModel response from the API call.</returns>
        public Models.ChannelModel RetrieveChannel(
                string channelId,
                Models.AcceptLanguageEnum? acceptLanguage = null)
        {
            Task<Models.ChannelModel> t = this.RetrieveChannelAsync(channelId, acceptLanguage);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// This endpoint exposes the details of a channel with support for contracts,as well as all the required details for creating a contract or a campaign for each channel.
        /// </summary>
        /// <param name="channelId">Required parameter: ID of the channel.</param>
        /// <param name="acceptLanguage">Optional parameter: The language the client prefers..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ChannelModel response from the API call.</returns>
        public async Task<Models.ChannelModel> RetrieveChannelAsync(
                string channelId,
                Models.AcceptLanguageEnum? acceptLanguage = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/products/channels/mocs/{channel_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "channel_id", channelId },
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

            return ApiHelper.JsonDeserialize<Models.ChannelModel>(response.Body);
        }

        /// <summary>
        /// This endpoint exposes a list of contract available to a particular customer.
        /// </summary>
        /// <param name="xCustomerId">Required parameter: An identifier for the remote customer.</param>
        /// <param name="limit">Optional parameter: Amount of contracts returned.</param>
        /// <param name="offset">Optional parameter: Starting point.</param>
        /// <returns>Returns the Models.ListContractsResponseModel response from the API call.</returns>
        public Models.ListContractsResponseModel ListContracts(
                string xCustomerId,
                double? limit = null,
                double? offset = null)
        {
            Task<Models.ListContractsResponseModel> t = this.ListContractsAsync(xCustomerId, limit, offset);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// This endpoint exposes a list of contract available to a particular customer.
        /// </summary>
        /// <param name="xCustomerId">Required parameter: An identifier for the remote customer.</param>
        /// <param name="limit">Optional parameter: Amount of contracts returned.</param>
        /// <param name="offset">Optional parameter: Starting point.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListContractsResponseModel response from the API call.</returns>
        public async Task<Models.ListContractsResponseModel> ListContractsAsync(
                string xCustomerId,
                double? limit = null,
                double? offset = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/contracts/");

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
                { "X-Customer-Id", xCustomerId },
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

            return ApiHelper.JsonDeserialize<Models.ListContractsResponseModel>(response.Body);
        }

        /// <summary>
        /// This endpoint creates a new customer contract. It requires a reference to a channel, a credential payload, and the facets set for the contracted product.
        /// HAPI doesn't support contract editing, because job boards require the same credentials to be able to delete already posted jobs via that contract at a later moment. Otherwise, deleting jobs would not be possible. To edit contract credentials, the credentials need to be deleted first, and then recreated. When deleted, all corresponding jobs can't be deleted anymore.
        /// </summary>
        /// <param name="xCustomerId">Required parameter: An identifier for the remote customer.</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.CreateContractResponseModel response from the API call.</returns>
        public Models.CreateContractResponseModel CreateContract(
                string xCustomerId,
                Models.PostContractModel body)
        {
            Task<Models.CreateContractResponseModel> t = this.CreateContractAsync(xCustomerId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// This endpoint creates a new customer contract. It requires a reference to a channel, a credential payload, and the facets set for the contracted product.
        /// HAPI doesn't support contract editing, because job boards require the same credentials to be able to delete already posted jobs via that contract at a later moment. Otherwise, deleting jobs would not be possible. To edit contract credentials, the credentials need to be deleted first, and then recreated. When deleted, all corresponding jobs can't be deleted anymore.
        /// </summary>
        /// <param name="xCustomerId">Required parameter: An identifier for the remote customer.</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateContractResponseModel response from the API call.</returns>
        public async Task<Models.CreateContractResponseModel> CreateContractAsync(
                string xCustomerId,
                Models.PostContractModel body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/contracts/");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "X-Customer-Id", xCustomerId },
                { "Content-Type", "application/json" },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

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

            return ApiHelper.JsonDeserialize<Models.CreateContractResponseModel>(response.Body);
        }

        /// <summary>
        /// This endpoint deletes a contract. .
        ///  HAPI doesn't support contract editing, because job boards require the same credentials to be able to delete already posted jobs via that contract at a later moment. Otherwise, deleting jobs would not be possible. To edit contract credentials, the credentials need to be deleted first, and then recreated. When deleted, all corresponding jobs can't be deleted anymore.
        /// </summary>
        /// <param name="contractId">Required parameter: Example: .</param>
        /// <param name="xCustomerId">Required parameter: An identifier for the remote customer.</param>
        public void DeleteContract(
                string contractId,
                string xCustomerId)
        {
            Task t = this.DeleteContractAsync(contractId, xCustomerId);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// This endpoint deletes a contract. .
        ///  HAPI doesn't support contract editing, because job boards require the same credentials to be able to delete already posted jobs via that contract at a later moment. Otherwise, deleting jobs would not be possible. To edit contract credentials, the credentials need to be deleted first, and then recreated. When deleted, all corresponding jobs can't be deleted anymore.
        /// </summary>
        /// <param name="contractId">Required parameter: Example: .</param>
        /// <param name="xCustomerId">Required parameter: An identifier for the remote customer.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task DeleteContractAsync(
                string contractId,
                string xCustomerId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/contracts/{contract_id}/");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "contract_id", contractId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "X-Customer-Id", xCustomerId },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Delete(queryBuilder.ToString(), headers, null);

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
        }

        /// <summary>
        /// This endpoint retrieves the detail for a customer contract. It contains a reference to a channel, an (encrypted) credential payload, and the facets set for the My Contracts product.
        /// </summary>
        /// <param name="contractId">Required parameter: Example: .</param>
        /// <param name="xCustomerId">Required parameter: An identifier for the remote customer.</param>
        /// <returns>Returns the Models.ContractModel response from the API call.</returns>
        public Models.ContractModel RetrieveContract(
                string contractId,
                string xCustomerId)
        {
            Task<Models.ContractModel> t = this.RetrieveContractAsync(contractId, xCustomerId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// This endpoint retrieves the detail for a customer contract. It contains a reference to a channel, an (encrypted) credential payload, and the facets set for the My Contracts product.
        /// </summary>
        /// <param name="contractId">Required parameter: Example: .</param>
        /// <param name="xCustomerId">Required parameter: An identifier for the remote customer.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ContractModel response from the API call.</returns>
        public async Task<Models.ContractModel> RetrieveContractAsync(
                string contractId,
                string xCustomerId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/contracts/single/{contract_id}/");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "contract_id", contractId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "X-Customer-Id", xCustomerId },
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

            return ApiHelper.JsonDeserialize<Models.ContractModel>(response.Body);
        }

        /// <summary>
        /// This endpoint exposes a list of multiple contracts, if available to a specific customer.
        /// </summary>
        /// <param name="contractsIds">Required parameter: Example: .</param>
        /// <param name="limit">Optional parameter: Amount of contracts returned.</param>
        /// <param name="offset">Optional parameter: Starting point.</param>
        /// <returns>Returns the Models.MultipleContractsResponseModel response from the API call.</returns>
        public Models.MultipleContractsResponseModel RetrieveMultipleContracts(
                List<string> contractsIds,
                double? limit = null,
                double? offset = null)
        {
            Task<Models.MultipleContractsResponseModel> t = this.RetrieveMultipleContractsAsync(contractsIds, limit, offset);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// This endpoint exposes a list of multiple contracts, if available to a specific customer.
        /// </summary>
        /// <param name="contractsIds">Required parameter: Example: .</param>
        /// <param name="limit">Optional parameter: Amount of contracts returned.</param>
        /// <param name="offset">Optional parameter: Starting point.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.MultipleContractsResponseModel response from the API call.</returns>
        public async Task<Models.MultipleContractsResponseModel> RetrieveMultipleContractsAsync(
                List<string> contractsIds,
                double? limit = null,
                double? offset = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/contracts/multiple/{contracts_ids}/");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "contracts_ids", contractsIds },
            });

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

            return ApiHelper.JsonDeserialize<Models.MultipleContractsResponseModel>(response.Body);
        }

        /// <summary>
        /// This endpoint exposes autocomplete items given a `channel_id` and a posting requirement name.
        /// </summary>
        /// <param name="channelId">Required parameter: channel_id (number, required).</param>
        /// <param name="postingRequirementName">Required parameter: Example: .</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the List of Models.AutocompleteValuesResponseModel response from the API call.</returns>
        public List<Models.AutocompleteValuesResponseModel> ListAutocompleteValues(
                double channelId,
                string postingRequirementName,
                Models.FacetAutocompleteModel body)
        {
            Task<List<Models.AutocompleteValuesResponseModel>> t = this.ListAutocompleteValuesAsync(channelId, postingRequirementName, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// This endpoint exposes autocomplete items given a `channel_id` and a posting requirement name.
        /// </summary>
        /// <param name="channelId">Required parameter: channel_id (number, required).</param>
        /// <param name="postingRequirementName">Required parameter: Example: .</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Models.AutocompleteValuesResponseModel response from the API call.</returns>
        public async Task<List<Models.AutocompleteValuesResponseModel>> ListAutocompleteValuesAsync(
                double channelId,
                string postingRequirementName,
                Models.FacetAutocompleteModel body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/contracts/posting-requirements/{channel_id}/{posting-requirement-name}/");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "channel_id", channelId },
                { "posting-requirement-name", postingRequirementName },
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
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

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

            return ApiHelper.JsonDeserialize<List<Models.AutocompleteValuesResponseModel>>(response.Body);
        }
    }
}