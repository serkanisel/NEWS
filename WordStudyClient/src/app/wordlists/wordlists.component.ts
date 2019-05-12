import { Component, OnInit } from '@angular/core';
import { WrdList } from '../_models/WrdList';
import { WrdlistService } from '../_services/wrdlist.service';
import { AlertifyService } from '../_services/Alertify.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-wordlists',
  templateUrl: './wordlists.component.html',
  styleUrls: ['./wordlists.component.css']
})
export class WordlistsComponent implements OnInit {
 WrdLists: WrdList[];

  constructor(private wordListService: WrdlistService, private alertifyService: AlertifyService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.WrdLists = data['wordlists'];
    });
  }

}
