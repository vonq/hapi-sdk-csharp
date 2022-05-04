
# Result Set 1 Model

## Structure

`ResultSet1Model`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Total` | `double?` | Optional | Number of total results |
| `Limit` | `double?` | Optional | Results page size |
| `Offset` | `double?` | Optional | Initial starting index for the results |
| `Data` | [`List<Models.CampaignModel>`](../../doc/models/campaign-model.md) | Optional | A Page of Campaign Objects |

## Example (as JSON)

```json
{
  "total": null,
  "limit": null,
  "offset": null,
  "data": null
}
```

