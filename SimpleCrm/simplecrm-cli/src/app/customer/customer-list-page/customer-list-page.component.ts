import { Component, OnInit } from '@angular/core';
  import { Customer } from '../customer.model';
  import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { CustomerService } from '../customer.service';
import { Observable } from 'rxjs';

  @Component({
    selector: 'crm-customer-list-page',
    templateUrl: './customer-list-page.component.html',
    styleUrls: ['./customer-list-page.component.scss']
  })
  export class CustomerListPageComponent implements OnInit {
    customers$!: Observable<Customer[]>;

    // dataSource!: MatTableDataSource<Customer>; // The ! tells Angular you know it may be used before it is set.  Try it without to see the error
    // @ViewChild(MatSort, {static: true}) sort: MatSort;
    displayColumns = ['name', 'phoneNumber', 'emailAddress', 'status'];
    // the above column names must match the matColumnDef names in the html

    constructor(private customerService: CustomerService) {
      this.customers$ = customerService.search('');
     }

    ngOnInit(): void {
      // this.dataSource = new MatTableDataSource(this.customers$);
      // this.dataSource.sort = this.sort;
    }
  }
