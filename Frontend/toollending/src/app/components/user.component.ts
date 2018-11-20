import { Component, OnInit } from '@angular/core';
import { UserService } from '../service/user.service';
import { User } from '../classes/user';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styles: [],
  
})
export class UserComponent implements OnInit {

  constructor(private userService: UserService) { }
  public currentUser:User = new User();
  
   
  GetUser() {
    this.userService.getData().subscribe(user => this.selectCurrentUser(user));
  }
    
  selectCurrentUser(userBase : any[])
  {
    this.currentUser = userBase.filter(x => x.Vorname == "Michael")[0]
  }

  ngOnInit() {
    this.GetUser();
  }

}
