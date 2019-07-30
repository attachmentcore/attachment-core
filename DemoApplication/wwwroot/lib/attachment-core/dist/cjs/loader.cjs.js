'use strict';

Object.defineProperty(exports, '__esModule', { value: true });

const __chunk_1 = require('./attachmentsystem-da3179ad.js');

const defineCustomElements = (win, options) => {
  return __chunk_1.patchEsm().then(() => {
    __chunk_1.bootstrapLazy([["attachment-create_9.cjs",[[1,"attachment-input",{"EntityName":[1,"entity-name"],"FieldName":[1,"field-name"],"EntityId":[1,"entity-id"],"Placeholder":[1,"placeholder"],"Attachment":[32],"loading":[32],"error":[32]}],[0,"attachment-modal",{"AttachmentKey":[16],"loading":[32],"opened":[32],"pageItems":[32],"open":[64],"close":[64]}],[0,"attachment-table",{"AttachmentKey":[16],"pageItems":[32],"Load":[64],"Refresh":[64]}],[0,"attachment-create",{"AttachmentKey":[16],"files":[32],"description":[32]}],[0,"delete-comfirmation",{"attachmentItem":[32],"open":[64],"close":[64]}],[0,"info-dialog",{"attachmentItem":[32],"open":[64],"close":[64]}],[0,"context-consumer",{"context":[16],"renderer":[16],"subscribe":[16],"unsubscribe":[32]}],[4,"attachment-popup",{"opened":[32],"open":[64],"close":[64]}],[0,"attachment-icon",{"IconName":[1,"icon-name"]}]]]], options);
  });
};

exports.defineCustomElements = defineCustomElements;
