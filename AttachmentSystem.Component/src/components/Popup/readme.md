# attachment-popup



<!-- Auto Generated Below -->


## Events

| Event     | Description | Type               |
| --------- | ----------- | ------------------ |
| `onClose` |             | `CustomEvent<any>` |
| `onOpen`  |             | `CustomEvent<any>` |


## Methods

### `close() => Promise<void>`



#### Returns

Type: `Promise<void>`



### `open() => Promise<void>`



#### Returns

Type: `Promise<void>`




## Dependencies

### Used by

 - [attachment-modal](..\Modal)
 - [delete-comfirmation](..\Forms)
 - [info-dialog](..\Forms)

### Graph
```mermaid
graph TD;
  attachment-modal --> attachment-popup
  delete-comfirmation --> attachment-popup
  info-dialog --> attachment-popup
  style attachment-popup fill:#f9f,stroke:#333,stroke-width:4px
```

----------------------------------------------

*Built with [StencilJS](https://stenciljs.com/)*
