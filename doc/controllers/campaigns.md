# Campaigns

```csharp
CampaignsController campaignsController = client.CampaignsController;
```

## Class Name

`CampaignsController`

## Methods

* [Check Campaign Status](../../doc/controllers/campaigns.md#check-campaign-status)
* [List Campaigns](../../doc/controllers/campaigns.md#list-campaigns)
* [Order Campaign](../../doc/controllers/campaigns.md#order-campaign)
* [Retrieve Campaign](../../doc/controllers/campaigns.md#retrieve-campaign)
* [Take Campaign Offline](../../doc/controllers/campaigns.md#take-campaign-offline)


# Check Campaign Status

This is a specialized endpoint for Campaign statuses only. Although the Campaign Details endpoint also returns the
status of a campaign, if you only need to get the specific status of a Campaign, this endpoint is
optimized for that.

```csharp
CheckCampaignStatusAsync(
    Guid campaignId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `campaignId` | `Guid` | Template, Required | Id of the Campaign you want the status of |

## Response Type

[`Task<Models.CheckCampaignStatusresponseModel>`](../../doc/models/check-campaign-statusresponse-model.md)

## Example Usage

```csharp
Guid campaignId = new Guid("000026a2-0000-0000-0000-000000000000");

try
{
    CheckCampaignStatusresponseModel result = await campaignsController.CheckCampaignStatusAsync(campaignId);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "data": {
    "campaignId": "ffb37e76-d4fe-5ad6-8441-b02c1b15aa4c",
    "status": "online",
    "orderedProductsStatuses": [
      {
        "productId": "8eefb7a1-c5f3-5739-9fe6-cea17e2ee742",
        "status": "online",
        "statusDescription": "null"
      }
    ]
  }
}
```


# List Campaigns

Displays all the existing Campaigns already ordered for this Partner is as simple as executing a `GET`
request against the endpoint `/campaigns`

```csharp
ListCampaignsAsync(
    string companyId,
    double? limit = null,
    double? offset = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `companyId` | `string` | Query, Required | CompanyId to filter the results on |
| `limit` | `double?` | Query, Optional | Amount of products returned |
| `offset` | `double?` | Query, Optional | Starting point |

## Response Type

[`Task<Models.ResultSet1Model>`](../../doc/models/result-set-1-model.md)

## Example Usage

```csharp
string companyId = "companyId0";

try
{
    ResultSet1Model result = await campaignsController.ListCampaignsAsync(companyId, null, null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "total": 1337,
  "limit": 50,
  "offset": 0,
  "data": [
    {
      "companyId": "dd1c5be0-b0e1-41c8-ba92-e876da16c38b",
      "orderReference": "PO_567_2019",
      "recruiterInfo": {
        "id": "af78ce39-94a8-45dc-8c68-35f4d684fa5f",
        "name": "John Doe",
        "emailAddress": "john.doe@vonq.com"
      },
      "campaignName": "Software Development Manager",
      "postingDetails": {
        "title": "Come work for us, we're looking for amazing Software Developers",
        "description": "Are you a LEADER and a BUILDER?  Global is looking for individuals who are dynamic, sales-oriented, and who want to control their destiny.  With a full training programme and consistent support, Global will provide you with the tools to excel in this very lucrative business.",
        "organization": {
          "name": "Vonq",
          "companyLogo": "http://static.ats.com/public/vonq-company-logo.png"
        },
        "workingLocation": {
          "addressLine1": "Westblaak 175",
          "postcode": "3012 KJ",
          "city": "Rotterdam",
          "country": "The Netherlands",
          "allowsRemoteWork": 0
        },
        "contactInfo": {
          "name": "Janet Doe",
          "phoneNumber": "+31 6 5555 5555",
          "emailAddress": "janet.doe@vonq.com"
        },
        "yearsOfExperience": 5,
        "employmentType": "permanent",
        "weeklyWorkingHours": {
          "from": 32,
          "to": 40
        },
        "salaryIndication": {
          "period": "yearly",
          "range": {
            "from": 56000,
            "to": 60000,
            "currency": "EUR"
          }
        },
        "jobPageUrl": "http://amadeus-hospitality-it-careers.com/vacancy/software-development-manager-breda",
        "applicationUrl": "http://amadeus-hospitality-it-careers.com/vacancy/software-development-manager-breda/apply"
      },
      "targetGroup": {
        "educationLevel": [
          {
            "description": "Vendor-specific value",
            "vonqId": "23"
          }
        ],
        "seniority": [
          {
            "description": "Vendor-specific value",
            "vonqId": "23"
          }
        ],
        "industry": [
          {
            "description": "Vendor-specific value",
            "vonqId": "23"
          }
        ],
        "jobCategory": [
          {
            "description": "Vendor-specific value",
            "vonqId": "23"
          }
        ]
      },
      "orderedProducts": [
        "89",
        "889",
        "2cbad29e-a510-52fc-bbdf-e873320e89f5"
      ],
      "orderedProductsSpecs": [
        {
          "productId": "2cbad29e-a510-52fc-bbdf-e873320e89f5",
          "status": "online",
          "statusDescription": "",
          "deliveredOn": "2020-11-30T11:00:15+0000",
          "duration": "20 days",
          "durationPeriod": {
            "range": "days",
            "period": 30
          },
          "utm": "utm_medium=social&utm_source=facebook&utm_campaign=example",
          "jobBoardLink": "http://job.ad.com/software-developer",
          "contractId": "06a8f6f0-5e0e-4614-869e-ab95a8530633",
          "postingRequirements": {
            "someText": "example",
            "multipleSelectField": [
              "123",
              "234"
            ],
            "someIntValue": 22
          }
        }
      ],
      "postings": [
        {
          "name": "Linkedin.com 30 days",
          "clicks": 14
        }
      ]
    }
  ]
}
```


# Order Campaign

Once your Customer has decided on a list of Channels they would like to buy, you can send the list along with
publishing information as a `POST` request in order to create a `Campaign`. In return, you'll receive
the id of the newly created `Campaign` along with the URL where you can access that Campaign information.
For "My Contracts" type of Products, there is no expiration. The vacancy can be taken offline either by the job board or manually, by calling the "[Take a campaign offline](https://vonq.stoplight.io/docs/hapi/b3A6MzM0NDA3MzQ-take-a-campaign-offline)" endpoint.

#### Target group

You should use the following endpoints for the target group information:

- [**`Industry`**](b3A6MzM0NDA3Mzg-industry-names)

- [**`Job Function`**](b3A6MzM0NDA3MzU-job-functions)

- [**`Education Level`**](b3A6MzM0NDA3Mzk-retrieve-education-level-taxonomy)

- [**`Seniority`**](b3A6MzM0NDA3NDA-retrieve-seniority-taxonomy)

```csharp
OrderCampaignAsync(
    Models.CampaignOrderModel body,
    string companyId = null,
    string limit = null,
    string offset = null,
    string xCustomerId = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CampaignOrderModel`](../../doc/models/campaign-order-model.md) | Body, Required | - |
| `companyId` | `string` | Query, Optional | - |
| `limit` | `string` | Query, Optional | - |
| `offset` | `string` | Query, Optional | - |
| `xCustomerId` | `string` | Header, Optional | The ID of the end-user creating the order. Only required if you are using HAPI Job Post and creating orders with contracts. |

## Response Type

[`Task<Models.OrderCampaignSuccessResponseModel>`](../../doc/models/order-campaign-success-response-model.md)

## Example Usage

```csharp
var body = new CampaignOrder();
body.CompanyId = "dd1c5be0-b0e1-41c8-ba92-e876da16c38b";
body.RecruiterInfo = new RecruiterInfo();
body.RecruiterInfo.Name = "John Doe";
body.PostingDetails = new PostingDetails();
body.PostingDetails.Title = "Come work for us, we're looking for amazing Software Developers";
body.PostingDetails.Description = "Are you a LEADER and a BUILDER?  Global is looking for individuals who are dynamic, sales-oriented, and who want to control their destiny.  With a full training programme and consistent support, Global will provide you with the tools to excel in this very lucrative business.";
body.PostingDetails.Organization = new PostingOrganization();
body.PostingDetails.Organization.Name = "Vonq";
body.PostingDetails.Organization.CompanyLogo = "http://static.ats.com/public/vonq-company-logo.png";
body.PostingDetails.WorkingLocation = new PostingWorkingLocation();
body.PostingDetails.WorkingLocation.AddressLine1 = "Westblaak 175";
body.PostingDetails.WorkingLocation.Postcode = "3012 KJ";
body.PostingDetails.WorkingLocation.City = "Rotterdam";
body.PostingDetails.WorkingLocation.Country = "The Netherlands";
body.PostingDetails.YearsOfExperience = 220.92;
body.PostingDetails.EmploymentType = EmploymentTypeEnum.Permanent;
body.PostingDetails.WeeklyWorkingHours = new PostingWeeklyWorkingHours();
body.PostingDetails.WeeklyWorkingHours.To = 69.94;
body.PostingDetails.SalaryIndication = new PostingSalaryIndication();
body.PostingDetails.SalaryIndication.Period = PeriodEnum.Yearly;
body.PostingDetails.SalaryIndication.Range = new Range3();
body.PostingDetails.SalaryIndication.Range.To = 22.8;
body.PostingDetails.JobPageUrl = "http://amadeus-hospitality-it-careers.com/vacancy/software-development-manager-breda";
body.PostingDetails.ApplicationUrl = "http://amadeus-hospitality-it-careers.com/vacancy/software-development-manager-breda/apply";
body.TargetGroup = new TargetGroup();
body.TargetGroup.EducationLevel = new List<TargetGroupElement>();

var bodyTargetGroupEducationLevel0 = new TargetGroupElement();
bodyTargetGroupEducationLevel0.Description = "Element name";
bodyTargetGroupEducationLevel0.VonqId = "23";
body.TargetGroup.EducationLevel.Add(bodyTargetGroupEducationLevel0);

var bodyTargetGroupEducationLevel1 = new TargetGroupElement();
bodyTargetGroupEducationLevel1.Description = "Element name";
bodyTargetGroupEducationLevel1.VonqId = "23";
body.TargetGroup.EducationLevel.Add(bodyTargetGroupEducationLevel1);

body.TargetGroup.Seniority = new List<TargetGroupElement>();

var bodyTargetGroupSeniority0 = new TargetGroupElement();
bodyTargetGroupSeniority0.Description = "Element name";
bodyTargetGroupSeniority0.VonqId = "23";
body.TargetGroup.Seniority.Add(bodyTargetGroupSeniority0);

var bodyTargetGroupSeniority1 = new TargetGroupElement();
bodyTargetGroupSeniority1.Description = "Element name";
bodyTargetGroupSeniority1.VonqId = "23";
body.TargetGroup.Seniority.Add(bodyTargetGroupSeniority1);

var bodyTargetGroupSeniority2 = new TargetGroupElement();
bodyTargetGroupSeniority2.Description = "Element name";
bodyTargetGroupSeniority2.VonqId = "23";
body.TargetGroup.Seniority.Add(bodyTargetGroupSeniority2);

body.TargetGroup.Industry = new List<TargetGroupElement>();

var bodyTargetGroupIndustry0 = new TargetGroupElement();
bodyTargetGroupIndustry0.Description = "Element name";
bodyTargetGroupIndustry0.VonqId = "23";
body.TargetGroup.Industry.Add(bodyTargetGroupIndustry0);

var bodyTargetGroupIndustry1 = new TargetGroupElement();
bodyTargetGroupIndustry1.Description = "Element name";
bodyTargetGroupIndustry1.VonqId = "23";
body.TargetGroup.Industry.Add(bodyTargetGroupIndustry1);

var bodyTargetGroupIndustry2 = new TargetGroupElement();
bodyTargetGroupIndustry2.Description = "Element name";
bodyTargetGroupIndustry2.VonqId = "23";
body.TargetGroup.Industry.Add(bodyTargetGroupIndustry2);

body.TargetGroup.JobCategory = new List<TargetGroupElement>();

var bodyTargetGroupJobCategory0 = new TargetGroupElement();
bodyTargetGroupJobCategory0.Description = "Element name";
bodyTargetGroupJobCategory0.VonqId = "23";
body.TargetGroup.JobCategory.Add(bodyTargetGroupJobCategory0);

var bodyTargetGroupJobCategory1 = new TargetGroupElement();
bodyTargetGroupJobCategory1.Description = "Element name";
bodyTargetGroupJobCategory1.VonqId = "23";
body.TargetGroup.JobCategory.Add(bodyTargetGroupJobCategory1);

body.OrderedProducts = new List<string>();
body.OrderedProducts.Add("orderedProducts2");

try
{
    OrderCampaignSuccessResponseModel result = await campaignsController.OrderCampaignAsync(body, null, null, null, null);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "campaignId": "ffb37e76-d4fe-5ad6-8441-b02c1b15aa4c"
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | - | [`OrderCampaignErrorResponseException`](../../doc/models/order-campaign-error-response-exception.md) |


# Retrieve Campaign

Retrieve the details of a specific Campaign. Only Campaigns created by the calling Partner can be
retrieved.

```csharp
RetrieveCampaignAsync(
    Guid campaignId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `campaignId` | `Guid` | Template, Required | Id of the Campaign that you want to retrieve |

## Response Type

[`Task<Models.ListCampaignResponseModel>`](../../doc/models/list-campaign-response-model.md)

## Example Usage

```csharp
Guid campaignId = new Guid("000026a2-0000-0000-0000-000000000000");

try
{
    ListCampaignResponseModel result = await campaignsController.RetrieveCampaignAsync(campaignId);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "data": {
    "companyId": "dd1c5be0-b0e1-41c8-ba92-e876da16c38b",
    "orderReference": "PO_567_2019",
    "recruiterInfo": {
      "id": "af78ce39-94a8-45dc-8c68-35f4d684fa5f",
      "name": "John Doe",
      "emailAddress": "john.doe@vonq.com"
    },
    "campaignName": "Software Development Manager",
    "postingDetails": {
      "title": "Come work for us, we're looking for amazing Software Developers",
      "description": "Are you a LEADER and a BUILDER?  Global is looking for individuals who are dynamic, sales-oriented, and who want to control their destiny.  With a full training programme and consistent support, Global will provide you with the tools to excel in this very lucrative business.",
      "organization": {
        "name": "Vonq",
        "companyLogo": "http://static.ats.com/public/vonq-company-logo.png"
      },
      "workingLocation": {
        "addressLine1": "Westblaak 175",
        "postcode": "3012 KJ",
        "city": "Rotterdam",
        "country": "The Netherlands",
        "allowsRemoteWork": 0
      },
      "contactInfo": {
        "name": "Janet Doe",
        "phoneNumber": "+31 6 5555 5555",
        "emailAddress": "janet.doe@vonq.com"
      },
      "yearsOfExperience": 5,
      "employmentType": "permanent",
      "weeklyWorkingHours": {
        "from": 32,
        "to": 40
      },
      "salaryIndication": {
        "period": "yearly",
        "range": {
          "from": 56000,
          "to": 60000,
          "currency": "EUR"
        }
      },
      "jobPageUrl": "http://amadeus-hospitality-it-careers.com/vacancy/software-development-manager-breda",
      "applicationUrl": "http://amadeus-hospitality-it-careers.com/vacancy/software-development-manager-breda/apply"
    },
    "targetGroup": {
      "educationLevel": [
        {
          "description": "Vendor-specific value",
          "vonqId": "23"
        }
      ],
      "seniority": [
        {
          "description": "Vendor-specific value",
          "vonqId": "23"
        }
      ],
      "industry": [
        {
          "description": "Vendor-specific value",
          "vonqId": "23"
        }
      ],
      "jobCategory": [
        {
          "description": "Vendor-specific value",
          "vonqId": "23"
        }
      ]
    },
    "orderedProducts": [
      "89",
      "889",
      "2cbad29e-a510-52fc-bbdf-e873320e89f5"
    ],
    "orderedProductsSpecs": [
      {
        "productId": "2cbad29e-a510-52fc-bbdf-e873320e89f5",
        "status": "online",
        "statusDescription": "",
        "deliveredOn": "2020-11-30T11:00:15+0000",
        "duration": "20 days",
        "durationPeriod": {
          "range": "days",
          "period": 30
        },
        "utm": "utm_medium=social&utm_source=facebook&utm_campaign=example",
        "jobBoardLink": "http://job.ad.com/software-developer",
        "contractId": "06a8f6f0-5e0e-4614-869e-ab95a8530633",
        "postingRequirements": {
          "someText": "example",
          "multipleSelectField": [
            "123",
            "234"
          ],
          "someIntValue": 22
        }
      }
    ],
    "postings": [
      {
        "name": "Linkedin.com 30 days",
        "clicks": 14
      }
    ]
  }
}
```


# Take Campaign Offline

Specific endpoint to take a campaign offline. Keep in mind that processing this might
take some time and it only has an effect if the campaign's status is "online".

```csharp
TakeCampaignOfflineAsync(
    Guid campaignId,
    Models.TakeCampaignOfflineRequestModel body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `campaignId` | `Guid` | Template, Required | Id of the Campaign you want to take offline |
| `body` | [`Models.TakeCampaignOfflineRequestModel`](../../doc/models/take-campaign-offline-request-model.md) | Body, Required | - |

## Response Type

[`Task<Models.TakeCampaignOfflineResponseModel>`](../../doc/models/take-campaign-offline-response-model.md)

## Example Usage

```csharp
Guid campaignId = new Guid("000026a2-0000-0000-0000-000000000000");
var body = new TakeCampaignOfflineRequest();
body.CampaignId = "ffb37e76-d4fe-5ad6-8441-b02c1b15aa4c";
body.Status = "offline";

try
{
    TakeCampaignOfflineResponseModel result = await campaignsController.TakeCampaignOfflineAsync(campaignId, body);
}
catch (ApiException e){};
```

## Example Response *(as JSON)*

```json
{
  "campaignId": "ffb37e76-d4fe-5ad6-8441-b02c1b15aa4c"
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | - | [`TakeCampaignOfflineErrorResponse2Exception`](../../doc/models/take-campaign-offline-error-response-2-exception.md) |
| 404 | - | [`TakeCampaignOfflineErrorResponseException`](../../doc/models/take-campaign-offline-error-response-exception.md) |

