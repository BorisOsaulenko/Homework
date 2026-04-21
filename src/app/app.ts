import { Component, signal, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CardComponent } from './components/card/card.component';
import { DataService } from './services/data.service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, CardComponent],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App implements OnInit {
  protected readonly title = signal('hw2');
  cardData = signal<Record<string, string | number>>({});

  constructor(private dataService: DataService) {}

  ngOnInit() {
    this.dataService.getCardData().subscribe((data) => {
      this.cardData.set(data);
    });
  }
}
