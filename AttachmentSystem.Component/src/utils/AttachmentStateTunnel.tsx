import { h } from '@stencil/core';
import { createProviderConsumer } from '@stencil/state-tunnel';
import { AttachmentKeyModel } from './Models';
import { AttachmentBusiness } from './Services'
export interface AttachmentState {
  AttachmentKey: AttachmentKeyModel,
  AttachmentBusiness: AttachmentBusiness;
}
export default createProviderConsumer<AttachmentState>(null,
  (subscribe, child) => ( <context-consumer subscribe = { subscribe } renderer = { child } />)
);
