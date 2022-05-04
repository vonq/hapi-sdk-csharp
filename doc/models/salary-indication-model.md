
# Salary Indication Model

## Structure

`SalaryIndicationModel`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Period` | `List<string>` | Required | - |
| `Range` | [`Models.Range4Model`](../../doc/models/range-4-model.md) | Required | - |

## Example (as JSON)

```json
{
  "period": [
    "A SalaryIndication needs a period"
  ],
  "range": {
    "to": [
      "This value should not be blank."
    ]
  }
}
```

