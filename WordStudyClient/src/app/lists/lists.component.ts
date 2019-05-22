import { Component, OnInit } from '@angular/core';
import { ListService } from './../_services/list.service';
import { AlertifyService } from 'src/app/_services/Alertify.service';
import { List } from '../_models/List';

@Component({
  selector: 'app-lists',
  templateUrl: './lists.component.html',
  styleUrls: ['./lists.component.css']
})
export class ListsComponent implements OnInit {
  lists: List[];

  a: any;

constructor(private alertifyService: AlertifyService, private listService: ListService ) { }

  ngOnInit() {
    this.loadUsers();

  }


  loadUsers() {
    this.listService.getLists().subscribe((_lists: List[]) => {
      this.lists = _lists;
      console.log(this.lists);
    },
    error => {
      this.alertifyService.error(error);
    });
  }


}
