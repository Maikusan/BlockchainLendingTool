import {Component, Inject, OnInit} from '@angular/core';
import { ToolService } from '../service/tool.service';
import { Tool } from '../classes/tool';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-tools',
  templateUrl: './tools.component.html',
  styles: []
})

export class ToolsComponent implements OnInit {

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
            let test: Tool = { id: curentTool.Id, name: curentTool.Id, ownerId: "Hallo", lendingPrice: curentTool.lendingPrice, depoPrice: curentTool.depoPrice, descriptipon: curentTool.descriptipon, availible: true }
            jesusTool.push(test);                      
                            
        }
        this.Tools = jesusTool;
        },
        error => alert(error));    
  }
}
 


