import { c as patchEsm, b as bootstrapLazy } from './attachmentsystem-1c042d9f.js';

const defineCustomElements = (win, options) => {
  return patchEsm().then(() => {
    bootstrapLazy([["attachment-create_9",[[1,"attachment-input",{"EntityName":[1,"entity-name"],"FieldName":[1,"field-name"],"EntityId":[1,"entity-id"],"Placeholder":[1,"placeholder"],"BaseUrl":[1,"base-url"],"Attachment":[32],"loading":[32],"error":[32]}],[0,"attachment-modal",{"AttachmentKey":[16],"loading":[32],"opened":[32],"pageItems":[32],"open":[64],"close":[64]}],[0,"attachment-table",{"AttachmentKey":[16],"AttachmentBusiness":[16],"pageItems":[32],"Load":[64],"Refresh":[64]}],[0,"attachment-create",{"AttachmentKey":[16],"AttachmentBusiness":[16],"files":[32],"description":[32]}],[0,"delete-comfirmation",{"attachmentItem":[32],"open":[64],"close":[64]}],[0,"info-dialog",{"attachmentItem":[32],"open":[64],"close":[64]}],[0,"context-consumer",{"context":[16],"renderer":[16],"subscribe":[16],"unsubscribe":[32]}],[4,"attachment-popup",{"opened":[32],"open":[64],"close":[64]}],[0,"attachment-icon",{"IconName":[1,"icon-name"]}]]]], options);
  });
};

export { defineCustomElements };
