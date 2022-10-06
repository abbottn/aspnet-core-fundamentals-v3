import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, of } from 'rxjs';
import { Customer } from './customer.model';
import { CustomerService } from './customer.service';

@Injectable()
export class CustomerMockService extends CustomerService {
  customers: Customer[] = [];

  constructor(http: HttpClient) {
    super(http);
    const localCustomers = localStorage.getItem('customers');
    if (localCustomers) {
      this.customers = JSON.parse(localCustomers);
    } else {
      //  initialize to a new array of customers, Hint: use customers.push(...)
      //
      this.customers = [
        {
          customerId: 1,
          firstName: 'John',
          lastName: 'Smith',
          phoneNumber: '314-555-1234',
          emailAddress: 'john@nexulacademy.com',
          statusCode: 'Prospect',
          preferredContactMethod: 'phone',
          lastContactDate: new Date().toISOString()
        },
        {
          customerId: 2,
          firstName: 'Tory',
          lastName: 'Amos',
          phoneNumber: '314-555-9873',
          emailAddress: 'tory@example.com',
          statusCode: 'Prospect',
          preferredContactMethod: 'email',
          lastContactDate: new Date().toISOString()
        }
      ];
    }
  }

  override search(term: string): Observable<Customer[]> {
    const searchResults = this.customers
        .filter(x => x.firstName.indexOf(term) >= 0 ||
          x.lastName.indexOf(term) >= 0 ||
          x.phoneNumber.indexOf(term) >= 0 ||
          x.emailAddress.indexOf(term) >= 0);
    return of(searchResults);
  }

  override insert(customer: Customer): Observable<Customer> {
    customer.customerId = Math.max(...this.customers.map(x => x.customerId)) + 1;
    this.customers = [...this.customers, customer];
    localStorage.setItem('customers', JSON.stringify(this.customers));
    // convert a result instance into an observable of the array to meet the function signature
    return of(customer);
  }

  override update(customer: Customer): Observable<Customer> {
    const match = this.customers.find(x => x.customerId === customer.customerId);
    if (match) {
      this.customers = this.customers
        .map(x => x.customerId === customer.customerId ? customer : x);
      localStorage.setItem('customers', JSON.stringify(this.customers));
    }
    return of(customer);
  }
}
