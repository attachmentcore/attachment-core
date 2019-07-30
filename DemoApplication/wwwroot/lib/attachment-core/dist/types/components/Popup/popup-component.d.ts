import { EventEmitter } from '../../stencil.core';
export declare class PopupComponent {
    el: HTMLElement;
    wrapper: HTMLDivElement;
    componentDidLoad(): void;
    onOpen: EventEmitter;
    onClose: EventEmitter;
    opened: boolean;
    open(): Promise<void>;
    close(): Promise<void>;
    render(): any[];
}
