import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DataService {
  getCardData(): Observable<Record<string, string | number>> {
    // Example data - replace with actual API call if needed
    return of({
      name: 'John Doe',
      email: 'john@example.com',
      age: 28,
      location: 'San Francisco',
      role: 'Software Engineer',
      status: 'Active',
    });
  }
}
