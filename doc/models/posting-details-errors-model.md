
# Posting Details Errors Model

## Structure

`PostingDetailsErrorsModel`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Title` | `List<string>` | Required | - |
| `Description` | `List<string>` | Required | - |
| `YearsOfExperience` | `List<string>` | Required | - |
| `EmploymentType` | `List<string>` | Required | - |
| `Organization` | [`Models.OrganizationModel`](../../doc/models/organization-model.md) | Required | - |
| `WorkingLocation` | [`Models.WorkingLocationModel`](../../doc/models/working-location-model.md) | Required | - |
| `WeeklyWorkingHours` | [`Models.WeeklyWorkingHoursModel`](../../doc/models/weekly-working-hours-model.md) | Required | - |
| `SalaryIndication` | [`Models.SalaryIndicationModel`](../../doc/models/salary-indication-model.md) | Required | - |
| `JobPageUrl` | `List<string>` | Required | - |
| `ApplicationUrl` | `List<string>` | Required | - |

## Example (as JSON)

```json
{
  "title": [
    "A Title of the Posting is required"
  ],
  "description": [
    "A Description of the Posting is required"
  ],
  "yearsOfExperience": [
    "This value should not be blank."
  ],
  "employmentType": [
    "A Posting needs a type of employment"
  ],
  "organization": {
    "name": [
      "This value should not be blank."
    ],
    "companyLogo": [
      "This value should not be blank."
    ]
  },
  "workingLocation": {
    "addressLine1": [
      "This value should not be blank."
    ],
    "postcode": [
      "This value should not be blank."
    ],
    "city": [
      "This value should not be blank."
    ],
    "country": [
      "This value should not be blank."
    ]
  },
  "weeklyWorkingHours": {
    "to": [
      "This value should not be blank."
    ]
  },
  "salaryIndication": {
    "period": [
      "A SalaryIndication needs a period"
    ],
    "range": {
      "to": [
        "This value should not be blank."
      ]
    }
  },
  "jobPageUrl": [
    "This value should not be blank."
  ],
  "applicationUrl": [
    "This value should not be blank."
  ]
}
```

