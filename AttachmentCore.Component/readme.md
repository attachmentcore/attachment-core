# Attachment Core

This is a collection of webcomponents for working with attachment core. these components can be used in javascript, Angular 2+, React and Vue frameworks.
## Getting Started

To start using this component you have two options :
 
1. ##### install

```bash
npm i attachment-core 
```
2. ##### download
```bash
npm pack attachment-core
```

### Using in Javascript

you can use it in your html without any framework:

```bash
<html lang="en">
<head>
  <script src="~/node_modules/attachment-core/dist/attachmentsystem.js"></script>
  <!-- or you can use -->
  <script src="https://unpkg.com/attachment-core/dist/attachmentsystem.js"></script>

</head>
<body>
  <attachment-input entity-name="entity name" field-name="field name" entity-id="entity id"></attachment-input>
</body>
</html>
```

Also you can put dist folder in your static file holder and reference to it.


### Using in Angular
Including the CUSTOM_ELEMENTS_SCHEMA in the module allows the use of the web components in the HTML markup without the compiler producing errors this code should be added into the AppModule and in every other modules that use attachment component.
Here is an example of adding it to AppModule:
```javascript
import { BrowserModule } from '@angular/platform-browser';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';

@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule, FormsModule],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule {}
```
The CUSTOM_ELEMENTS_SCHEMA needs to be included in any module that uses custom elements.
import function that called defineCustomElements() and it needs to be called once during the bootstrapping of your application. One convenient place to do this is in main.ts as such:
```javascript
import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';


import { defineCustomElements } from 'attachment-core/loader';

if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.log(err));
defineCustomElements(window);
```
### Using in React
With an application built using the create-react-app script the easiest way to include the component library is to call defineCustomElements(window) from the index.js file.
```javascript
import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import registerServiceWorker from './registerServiceWorker';

import { applyPolyfills, defineCustomElements } from 'attachment-core/loader';

ReactDOM.render(<App />, document.getElementById('root'));
registerServiceWorker();

applyPolyfills().then(() => {
  defineCustomElements(window);
});
```
Following the steps above will enable your web components to be used in React, however there are some additional complexities that must also be considered. https://custom-elements-everywhere.com/ describes them well.
### Using in Vue
In order to use the custom element library within the Vue app, the application must be modified to define the custom elements and to inform the Vue compiler which elements to ignore during compilation. This can all be done within the main.js file.
```javascript
import Vue from 'vue';
import App from './App.vue';
//importing the node module
import { applyPolyfills, defineCustomElements } from 'attachment-core/loader';

Vue.config.productionTip = false;

//telling Vue to ignore the custom element tags 
Vue.config.ignoredElements = [/attachment-\w*/];

// Bind the custom elements to the window object
applyPolyfills().then(() => {
  defineCustomElements(window);
});

new Vue({
  render: h => h(App)
}).$mount('#app');
```
The components should then be available in any of the Vue components
```javascript
render() {
  return (
    <div>
      <attachment-input entity-name="entity name" field-name="field name" entity-id="entity id"></attachment-input>
    </div>
  )
}
```


