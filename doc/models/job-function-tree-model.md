
# Job Function Tree Model

## Structure

`JobFunctionTreeModel`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `double` | Required | - |
| `Name` | `string` | Required | - |
| `Children` | [`List<Models.JobFunctionTreeModel>`](../../doc/models/job-function-tree-model.md) | Required | - |

## Example (as JSON)

```json
{
  "id": 60.0,
  "name": "name0",
  "children": [
    {
      "id": 128.74,
      "name": "name4",
      "children": {
        "id": 128.74,
        "name": "name4",
        "children": null
      }
    },
    {
      "id": 128.75,
      "name": "name5",
      "children": {
        "id": 128.73,
        "name": "name3",
        "children": null
      }
    }
  ]
}
```

