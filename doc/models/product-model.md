
# Product Model

## Structure

`ProductModel`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Title` | `string` | Required | - |
| `Locations` | [`List<Models.LocationModel>`](../../doc/models/location-model.md) | Required | **Constraints**: *Unique Items Required* |
| `JobFunctions` | [`List<Models.JobFunctionModel>`](../../doc/models/job-function-model.md) | Required | **Constraints**: *Unique Items Required* |
| `Industries` | [`List<Models.IndustryModel>`](../../doc/models/industry-model.md) | Required | **Constraints**: *Unique Items Required* |
| `Description` | `string` | Required | - |
| `Homepage` | `string` | Required | - |
| `LogoUrl` | `string` | Required | - |
| `LogoSquareUrl` | `string` | Required | - |
| `LogoRectangleUrl` | `string` | Required | - |
| `Duration` | `object` | Required | - |
| `TimeToProcess` | [`Models.TimeToProcessModel`](../../doc/models/time-to-process-model.md) | Required | - |
| `TimeToSetup` | [`Models.TimeToSetupModel`](../../doc/models/time-to-setup-model.md) | Required | - |
| `ProductId` | `Guid` | Required | - |
| `VonqPrice` | [`List<Models.PriceModel>`](../../doc/models/price-model.md) | Required | the price to be displayed to customers |
| `RatecardPrice` | [`List<Models.PriceModel>`](../../doc/models/price-model.md) | Required | - |
| `Type` | [`Models.ChannelTypeEnum`](../../doc/models/channel-type-enum.md) | Required | The type of a channel |
| `CrossPostings` | `List<string>` | Required | - |
| `Channel` | [`Models.ChannelModel`](../../doc/models/channel-model.md) | Required | - |
| `AudienceGroup` | [`Models.AudienceGroupEnum`](../../doc/models/audience-group-enum.md) | Required | The product's audience group (niche/generic) |
| `McEnabled` | `bool` | Required | is My Contract enabled for the channel |
| `McOnly` | `bool` | Required | is the product available only for My Contract order |
| `AllowOrders` | `bool` | Required | is the product available for order. a campaign cannot be ordered with a product having `allow_orders` set to `false`. |

## Example (as JSON)

```json
{
  "title": null,
  "locations": {
    "id": null,
    "fully_qualified_place_name": null,
    "canonical_name": null,
    "bounding_box": null,
    "area": null,
    "place_type": "place",
    "within": {
      "id": null,
      "fully_qualified_place_name": null,
      "canonical_name": null,
      "bounding_box": null,
      "area": null,
      "place_type": "place",
      "within": null
    }
  },
  "job_functions": null,
  "industries": null,
  "description": "this is a product description",
  "homepage": null,
  "logo_url": null,
  "logo_square_url": null,
  "logo_rectangle_url": null,
  "duration": null,
  "time_to_process": null,
  "time_to_setup": null,
  "product_id": null,
  "vonq_price": null,
  "ratecard_price": null,
  "type": "job board",
  "cross_postings": null,
  "channel": {
    "name": "Linkedin",
    "url": "www.linkedin.com",
    "type": "job board",
    "mc_enabled": false,
    "contract_credentials": null,
    "contract_facets": null,
    "posting_requirements": {
      "name": null,
      "label": null,
      "sort": null,
      "required": null,
      "type": "AUTOCOMPLETE",
      "options": null,
      "autocomplete": null
    },
    "manual_setup_required": null,
    "setup_instructions": null,
    "feed_url": null
  },
  "audience_group": null,
  "mc_enabled": null,
  "mc_only": null,
  "allow_orders": null
}
```

