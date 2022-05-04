
# Ordered Products Get Element Model

## Structure

`OrderedProductsGetElementModel`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ProductId` | `string` | Optional | Product Identification |
| `Status` | `string` | Optional | Status per product |
| `StatusDescription` | `string` | Optional | Status description, additional status information |
| `DeliveredOn` | `string` | Optional | Date when the channel went online |
| `Duration` | `string` | Optional | How long will the `Product` be online. [DEPRECATED] please instead use the `durationPeriod` |
| `DurationPeriod` | [`Models.DurationModel`](../../doc/models/duration-model.md) | Optional | - |
| `Utm` | `string` | Optional | Tracking codes |
| `JobBoardLink` | `string` | Optional | Link to the job ad on the channel. Sometimes this link is not available from a job board, then the product homepage is returned. |
| `ContractId` | `string` | Optional | Contract Identifier for My Contracts product |
| `PostingRequirements` | [`Models.PostingRequirementsModel`](../../doc/models/posting-requirements-model.md) | Optional | - |

## Example (as JSON)

```json
{
  "productId": null,
  "status": null,
  "statusDescription": null,
  "deliveredOn": null,
  "duration": null,
  "durationPeriod": null,
  "utm": null,
  "jobBoardLink": null,
  "contractId": null,
  "postingRequirements": null
}
```

