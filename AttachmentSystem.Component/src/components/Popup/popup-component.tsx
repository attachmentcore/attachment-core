import { Component, h, Method, Element, Event, EventEmitter, State } from '@stencil/core';

@Component({
  tag: 'attachment-popup',
  styleUrl: 'popup-component.scss',
  shadow: false
})
export class PopupComponent {
 
  @Element() el: HTMLElement;
  wrapper: HTMLDivElement;
  componentDidLoad() {
    
  }

  @Event() onOpen: EventEmitter;
  @Event() onClose: EventEmitter;
  @State() opened: boolean;

  @Method()
  async open() {
    this.onOpen.emit({});
    this.wrapper.classList.add("is-active");
    this.render()
  }
  @Method()
  async close() {
    this.onClose.emit({});
    this.wrapper.classList.remove("is-active");
  }
  
  render() {
    return [
      <div class="modal" ref={el => this.wrapper = el}>
        <div class="modal-background" onClick={() => this.close()}></div>
        <slot />
      </div>
    ];
  }
}
