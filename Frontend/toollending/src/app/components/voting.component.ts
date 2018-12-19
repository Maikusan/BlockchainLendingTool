import {Component, Inject, OnInit} from '@angular/core';
import { Voting } from '../classes/voting';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-votings',
  templateUrl: './votings.component.html',
  styles: []
})

export class VotingComponent implements OnInit {

  ngOnInit(): void {
    this.AddVoting = new Voting;
  }

  AddVoting: Voting;

  Voting: Voting[] = new Array();

  constructor() {

  }
}
 


