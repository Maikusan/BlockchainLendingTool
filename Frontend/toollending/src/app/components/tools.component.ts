import {Component, Inject, OnInit} from '@angular/core';
import { ToolService } from '../service/tool.service';
import { Tool } from '../classes/tool';
import { Observable } from 'rxjs';


export interface Categorie {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-tools',
  templateUrl: './tools.component.html',
  styles: []
})

export class ToolsComponent implements OnInit {

  ownerCategories: Categorie[] = [
    {value: 'all', viewValue: 'All'},
    {value: 'myself', viewValue: 'Myself'},
    {value: 'others', viewValue: 'Only Others'}
  ];

  toolCategories: Categorie[] = [
    {value: 'All', viewValue: 'All'},
    {value: 'bohrmaschine', viewValue: 'Bohrmaschine'},
    {value: 'saege', viewValue: 'Saege'},
    {value: 'hammer', viewValue: 'Hammer'}
  ];

  ngOnInit(): void {
    this.AddTool = new Tool;
  }

  AddTool: Tool;

  Tools: Tool[] = new Array();

  onAddClick(): void {
    this.toolService.postData(this.AddTool);
    alert("Hallo " + this.AddTool.name);
  }

  constructor(private toolService: ToolService) {
    this.toolService.getData()
    .subscribe(sTool => {
        let jesusTool: Tool[] = new Array();
        for (let count = 0; count < sTool.length; count++) {
                
            const curentTool = sTool[count];
            jesusTool.push(curentTool);                      
                            
        }
        this.Tools = jesusTool;
        },
        error => alert(error));    
  }
}
 


