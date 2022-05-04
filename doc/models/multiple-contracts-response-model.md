
# Multiple Contracts Response Model

## Structure

`MultipleContractsResponseModel`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Count` | `double?` | Optional | count of elements in results |
| `Previous` | `string` | Optional | link to get previous results |
| `Next` | `string` | Optional | link to get next results |
| `Results` | [`List<Models.ContractModel>`](../../doc/models/contract-model.md) | Optional | - |

## Example (as JSON)

```json
{
  "count": null,
  "previous": null,
  "next": null,
  "results": null
}
```

