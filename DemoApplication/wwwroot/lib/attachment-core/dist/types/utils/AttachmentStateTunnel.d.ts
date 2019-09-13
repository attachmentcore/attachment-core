import { AttachmentKeyModel } from './Models';
import { AttachmentBusiness } from './Services';
export interface AttachmentState {
    AttachmentKey: AttachmentKeyModel;
    AttachmentBusiness: AttachmentBusiness;
}
declare const _default: {
    Provider: import("@stencil/state-tunnel/dist/types/stencil.core").FunctionalComponent<{
        state: AttachmentState;
    }>;
    Consumer: import("@stencil/state-tunnel/dist/types/stencil.core").FunctionalComponent<{}>;
    injectProps: (Cstr: any, fieldList: import("@stencil/state-tunnel/dist/types/declarations").PropList<AttachmentState>) => void;
};
export default _default;
