
# Create Contract Response Model

## Structure

`CreateContractResponseModel`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `CustomerId` | `string` | Required | - |
| `ContractId` | `string` | Required | - |
| `ChannelId` | `int` | Required | - |
| `Credentials` | `string` | Required | - |
| `ClassName` | `string` | Required | - |
| `Facets` | `object` | Required | - |
| `Product` | [`Models.ProductLiteModel`](../../doc/models/product-lite-model.md) | Required | - |
| `PostingRequirements` | `string` | Required | - |
| `ExpiryDate` | `DateTime?` | Optional | - |
| `Credits` | `int?` | Optional | - |
| `PurchasePrice` | [`Models.PurchasePriceModel`](../../doc/models/purchase-price-model.md) | Optional | - |

## Example (as JSON)

```json
{
  "customer_id": "76e124d4-ae69-4753-bede-259d505258b7",
  "contract_id": "3a283b8f-1670-404b-b804-92f67e66b71c",
  "channel_id": 13,
  "credentials": "",
  "class_name": "",
  "facets": {},
  "product": {
    "product_id": "2e8c3c17-179b-4db1-9e2b-d48369b5e409",
    "title": "product title"
  },
  "posting_requirements": ""
}
```

