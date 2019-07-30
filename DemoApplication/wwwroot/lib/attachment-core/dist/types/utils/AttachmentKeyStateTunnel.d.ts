import { AttachmentKeyModel } from './Models';
export interface AttachmentState {
    AttachmentKey: AttachmentKeyModel;
}
declare const _default: {
    Provider: import("@stencil/state-tunnel/dist/types/stencil.core").FunctionalComponent<{
        state: AttachmentState;
    }>;
    Consumer: import("@stencil/state-tunnel/dist/types/stencil.core").FunctionalComponent<{}>;
    injectProps: (Cstr: any, fieldList: import("@stencil/state-tunnel/dist/types/declarations").PropList<AttachmentState>) => void;
};
export default _default;
