# info-dialog



<!-- Auto Generated Below -->


## Methods

### `close() => Promise<void>`



#### Returns

Type: `Promise<void>`



### `open(attachmentItem: AttachmentItem) => Promise<void>`



#### Returns

Type: `Promise<void>`




## Dependencies

### Used by

 - [attachment-table](..\Table)

### Depends on

- [attachment-popup](..\Popup)

### Graph
```mermaid
graph TD;
  info-dialog --> attachment-popup
  attachment-table --> info-dialog
  style info-dialog fill:#f9f,stroke:#333,stroke-width:4px
```

----------------------------------------------

*Built with [StencilJS](https://stenciljs.com/)*
