# attachment-input



<!-- Auto Generated Below -->


## Properties

| Property      | Attribute     | Description | Type     | Default     |
| ------------- | ------------- | ----------- | -------- | ----------- |
| `EntityId`    | `entity-id`   |             | `string` | `undefined` |
| `EntityName`  | `entity-name` |             | `string` | `undefined` |
| `FieldName`   | `field-name`  |             | `string` | `undefined` |
| `Placeholder` | `placeholder` |             | `string` | `undefined` |


## Dependencies

### Depends on

- [attachment-icon](..\Icon)
- [attachment-modal](..\Modal)
- context-consumer

### Graph
```mermaid
graph TD;
  attachment-input --> attachment-icon
  attachment-input --> attachment-modal
  attachment-input --> context-consumer
  attachment-modal --> attachment-icon
  attachment-modal --> attachment-popup
  attachment-modal --> attachment-table
  attachment-modal --> context-consumer
  attachment-table --> attachment-icon
  attachment-table --> attachment-create
  attachment-table --> delete-comfirmation
  attachment-table --> info-dialog
  attachment-table --> context-consumer
  attachment-create --> attachment-icon
  attachment-create --> context-consumer
  delete-comfirmation --> attachment-icon
  delete-comfirmation --> attachment-popup
  info-dialog --> attachment-icon
  info-dialog --> attachment-popup
  style attachment-input fill:#f9f,stroke:#333,stroke-width:4px
```

----------------------------------------------

*Built with [StencilJS](https://stenciljs.com/)*
