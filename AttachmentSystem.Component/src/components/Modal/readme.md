# attachment-modal



<!-- Auto Generated Below -->


## Properties

| Property        | Attribute | Description | Type                 | Default     |
| --------------- | --------- | ----------- | -------------------- | ----------- |
| `AttachmentKey` | --        |             | `AttachmentKeyModel` | `undefined` |


## Methods

### `close() => Promise<void>`



#### Returns

Type: `Promise<void>`



### `open() => Promise<void>`



#### Returns

Type: `Promise<void>`




## Dependencies

### Used by

 - [attachment-input](..\Input)

### Depends on

- [attachment-popup](..\Popup)
- [attachment-table](..\Table)
- context-consumer

### Graph
```mermaid
graph TD;
  attachment-modal --> attachment-popup
  attachment-modal --> attachment-table
  attachment-modal --> context-consumer
  attachment-table --> attachment-create
  attachment-table --> delete-comfirmation
  attachment-table --> info-dialog
  attachment-table --> context-consumer
  attachment-create --> context-consumer
  delete-comfirmation --> attachment-popup
  info-dialog --> attachment-popup
  attachment-input --> attachment-modal
  style attachment-modal fill:#f9f,stroke:#333,stroke-width:4px
```

----------------------------------------------

*Built with [StencilJS](https://stenciljs.com/)*
