/* tslint:disable */
/**
 * This is an autogenerated file created by the Stencil compiler.
 * It contains typing information for all components that exist in this project.
 */


import { HTMLStencilElement, JSXBase } from '@stencil/core/internal';
import {
  AttachmentItem,
  AttachmentItemPagedList,
  AttachmentKeyModel,
} from './utils/Models';


export namespace Components {
  interface AttachmentCreate {
    'AttachmentKey': AttachmentKeyModel;
  }
  interface AttachmentIcon {
    'IconName': string;
  }
  interface AttachmentInput {
    'EntityId': string;
    'EntityName': string;
    'FieldName': string;
    'Placeholder': string;
  }
  interface AttachmentModal {
    'AttachmentKey': AttachmentKeyModel;
    'close': () => Promise<void>;
    'open': () => Promise<void>;
  }
  interface AttachmentPopup {
    'close': () => Promise<void>;
    'open': () => Promise<void>;
  }
  interface AttachmentTable {
    'AttachmentKey': AttachmentKeyModel;
    'Load': (pageIndex: number, pageSize: number) => Promise<AttachmentItemPagedList>;
    'Refresh': () => Promise<AttachmentItemPagedList>;
  }
  interface DeleteComfirmation {
    'close': () => Promise<void>;
    'open': (attachmentItem: AttachmentItem) => Promise<void>;
  }
  interface InfoDialog {
    'close': () => Promise<void>;
    'open': (attachmentItem: AttachmentItem) => Promise<void>;
  }
}

declare global {


  interface HTMLAttachmentCreateElement extends Components.AttachmentCreate, HTMLStencilElement {}
  var HTMLAttachmentCreateElement: {
    prototype: HTMLAttachmentCreateElement;
    new (): HTMLAttachmentCreateElement;
  };

  interface HTMLAttachmentIconElement extends Components.AttachmentIcon, HTMLStencilElement {}
  var HTMLAttachmentIconElement: {
    prototype: HTMLAttachmentIconElement;
    new (): HTMLAttachmentIconElement;
  };

  interface HTMLAttachmentInputElement extends Components.AttachmentInput, HTMLStencilElement {}
  var HTMLAttachmentInputElement: {
    prototype: HTMLAttachmentInputElement;
    new (): HTMLAttachmentInputElement;
  };

  interface HTMLAttachmentModalElement extends Components.AttachmentModal, HTMLStencilElement {}
  var HTMLAttachmentModalElement: {
    prototype: HTMLAttachmentModalElement;
    new (): HTMLAttachmentModalElement;
  };

  interface HTMLAttachmentPopupElement extends Components.AttachmentPopup, HTMLStencilElement {}
  var HTMLAttachmentPopupElement: {
    prototype: HTMLAttachmentPopupElement;
    new (): HTMLAttachmentPopupElement;
  };

  interface HTMLAttachmentTableElement extends Components.AttachmentTable, HTMLStencilElement {}
  var HTMLAttachmentTableElement: {
    prototype: HTMLAttachmentTableElement;
    new (): HTMLAttachmentTableElement;
  };

  interface HTMLDeleteComfirmationElement extends Components.DeleteComfirmation, HTMLStencilElement {}
  var HTMLDeleteComfirmationElement: {
    prototype: HTMLDeleteComfirmationElement;
    new (): HTMLDeleteComfirmationElement;
  };

  interface HTMLInfoDialogElement extends Components.InfoDialog, HTMLStencilElement {}
  var HTMLInfoDialogElement: {
    prototype: HTMLInfoDialogElement;
    new (): HTMLInfoDialogElement;
  };
  interface HTMLElementTagNameMap {
    'attachment-create': HTMLAttachmentCreateElement;
    'attachment-icon': HTMLAttachmentIconElement;
    'attachment-input': HTMLAttachmentInputElement;
    'attachment-modal': HTMLAttachmentModalElement;
    'attachment-popup': HTMLAttachmentPopupElement;
    'attachment-table': HTMLAttachmentTableElement;
    'delete-comfirmation': HTMLDeleteComfirmationElement;
    'info-dialog': HTMLInfoDialogElement;
  }
}

declare namespace LocalJSX {
  interface AttachmentCreate extends JSXBase.HTMLAttributes<HTMLAttachmentCreateElement> {
    'AttachmentKey'?: AttachmentKeyModel;
    'onOnCreate'?: (event: CustomEvent<any>) => void;
    'onOnRequest'?: (event: CustomEvent<any>) => void;
  }
  interface AttachmentIcon extends JSXBase.HTMLAttributes<HTMLAttachmentIconElement> {
    'IconName'?: string;
  }
  interface AttachmentInput extends JSXBase.HTMLAttributes<HTMLAttachmentInputElement> {
    'EntityId'?: string;
    'EntityName'?: string;
    'FieldName'?: string;
    'Placeholder'?: string;
  }
  interface AttachmentModal extends JSXBase.HTMLAttributes<HTMLAttachmentModalElement> {
    'AttachmentKey'?: AttachmentKeyModel;
  }
  interface AttachmentPopup extends JSXBase.HTMLAttributes<HTMLAttachmentPopupElement> {
    'onOnClose'?: (event: CustomEvent<any>) => void;
    'onOnOpen'?: (event: CustomEvent<any>) => void;
  }
  interface AttachmentTable extends JSXBase.HTMLAttributes<HTMLAttachmentTableElement> {
    'AttachmentKey'?: AttachmentKeyModel;
    'onOnEndLoading'?: (event: CustomEvent<any>) => void;
    'onOnStartLoading'?: (event: CustomEvent<any>) => void;
  }
  interface DeleteComfirmation extends JSXBase.HTMLAttributes<HTMLDeleteComfirmationElement> {
    'onOnAccept'?: (event: CustomEvent<any>) => void;
    'onOnCancel'?: (event: CustomEvent<any>) => void;
  }
  interface InfoDialog extends JSXBase.HTMLAttributes<HTMLInfoDialogElement> {}

  interface IntrinsicElements {
    'attachment-create': AttachmentCreate;
    'attachment-icon': AttachmentIcon;
    'attachment-input': AttachmentInput;
    'attachment-modal': AttachmentModal;
    'attachment-popup': AttachmentPopup;
    'attachment-table': AttachmentTable;
    'delete-comfirmation': DeleteComfirmation;
    'info-dialog': InfoDialog;
  }
}

export { LocalJSX as JSX };


declare module "@stencil/core" {
  export namespace JSX {
    interface IntrinsicElements extends LocalJSX.IntrinsicElements {}
  }
}


