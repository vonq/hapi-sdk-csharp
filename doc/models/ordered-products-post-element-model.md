
# Ordered Products Post Element Model

## Structure

`OrderedProductsPostElementModel`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ProductId` | `string` | Optional | Product Identification |
| `Utm` | `string` | Optional | Query string for UTM parameters<br><br>**Pattern:** `/^([%.-_!*a-zA-Z0-9]{1,}=[%.-_!*+,;$()a-zA-Z0-9]{1,}[&]{0,}){1,}$/` |
| `ContractId` | `string` | Optional | Contract Identifier needed for My Contracts product |
| `PostingRequirements` | [`Models.PostingRequirementsModel`](../../doc/models/posting-requirements-model.md) | Optional | - |

## Example (as JSON)

```json
{
  "productId": null,
  "utm": null,
  "contractId": null,
  "postingRequirements": null
}
```

