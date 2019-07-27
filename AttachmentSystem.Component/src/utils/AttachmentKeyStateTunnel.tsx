import { h } from '@stencil/core';
import { createProviderConsumer } from '@stencil/state-tunnel';
import { AttachmentKeyModel } from './Models';
export interface AttachmentState {
  AttachmentKey: AttachmentKeyModel,
}
export default createProviderConsumer<AttachmentState>(null,
  (subscribe, child) => ( <context-consumer subscribe = { subscribe } renderer = { child } />)
);
