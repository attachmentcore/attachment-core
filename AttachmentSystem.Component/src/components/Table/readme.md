# attachment-table



<!-- Auto Generated Below -->


## Properties

| Property        | Attribute | Description | Type                 | Default     |
| --------------- | --------- | ----------- | -------------------- | ----------- |
| `AttachmentKey` | --        |             | `AttachmentKeyModel` | `undefined` |


## Events

| Event            | Description | Type               |
| ---------------- | ----------- | ------------------ |
| `onEndLoading`   |             | `CustomEvent<any>` |
| `onStartLoading` |             | `CustomEvent<any>` |


## Methods

### `Load(pageIndex: number, pageSize: number) => Promise<AttachmentItemPagedList>`



#### Returns

Type: `Promise<AttachmentItemPagedList>`



### `Refresh() => Promise<AttachmentItemPagedList>`



#### Returns

Type: `Promise<AttachmentItemPagedList>`




## Dependencies

### Used by

 - [attachment-modal](..\Modal)

### Depends on

- [attachment-icon](..\Icon)
- [attachment-create](..\Forms)
- [delete-comfirmation](..\Forms)
- [info-dialog](..\Forms)
- context-consumer

### Graph
```mermaid
graph TD;
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
  attachment-modal --> attachment-table
  style attachment-table fill:#f9f,stroke:#333,stroke-width:4px
```

----------------------------------------------

*Built with [StencilJS](https://stenciljs.com/)*
