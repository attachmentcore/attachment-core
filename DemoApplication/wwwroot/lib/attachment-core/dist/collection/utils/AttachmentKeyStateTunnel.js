import { h } from '@stencil/core';
import { createProviderConsumer } from '@stencil/state-tunnel';
export default createProviderConsumer(null, (subscribe, child) => (h("context-consumer", { subscribe: subscribe, renderer: child })));
