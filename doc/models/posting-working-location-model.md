
# Posting Working Location Model

## Structure

`PostingWorkingLocationModel`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AddressLine1` | `string` | Required | - |
| `AddressLine2` | `string` | Optional | - |
| `Postcode` | `string` | Required | - |
| `City` | `string` | Required | - |
| `Country` | `string` | Required | - |
| `AllowsRemoteWork` | `double?` | Optional | Optional parameter allowing remote work, possible values are 0 and 1, defaults to 0 |

## Example (as JSON)

```json
{
  "addressLine1": "Westblaak 175",
  "postcode": "3012 KJ",
  "city": "Rotterdam",
  "country": "The Netherlands"
}
```

