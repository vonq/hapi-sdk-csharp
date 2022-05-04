
# Ordered Products Status Item Model

## Structure

`OrderedProductsStatusItemModel`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ProductId` | `string` | Optional | - |
| `Status` | [`Models.ChannelStatusEnum?`](../../doc/models/channel-status-enum.md) | Optional | Status of the product. One of the following |
| `StatusDescription` | `string` | Optional | Additional information about product status |

## Example (as JSON)

```json
{
  "productId": null,
  "status": null,
  "statusDescription": null
}
```

