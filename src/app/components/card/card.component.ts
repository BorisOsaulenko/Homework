import { Component, Input, HostBinding } from '@angular/core';

@Component({
  selector: 'app-card',
  standalone: true,
  templateUrl: './card.component.html',
})
export class CardComponent {
  @Input() data: Record<string, string | number> = {};
  @Input() title?: string;

  get entries(): [string, string | number][] {
    return Object.entries(this.data);
  }

  formatKey(key: string): string {
    return key
      .replace(/([A-Z])/g, ' $1')
      .replace(/^./, (str) => str.toUpperCase())
      .trim();
  }
}
