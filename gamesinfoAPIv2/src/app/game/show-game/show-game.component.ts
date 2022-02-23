import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { GameApiService } from 'src/app/game-api.service';
@Component({
  selector: 'app-show-game',
  templateUrl: './show-game.component.html',
  styleUrls: ['./show-game.component.css']
})
export class ShowGameComponent implements OnInit {
  searchText:any;
  gameList$!:Observable<any[]>;
  gameCategoryList$!:Observable<any[]>;
  gameCategoryList:any=[];

  gameStudioList$!:Observable<any[]>;
  gameStudioList:any=[];
  //map to display data associate with foreign key
  gameCategoryMap:Map<number, string> = new Map()
  gameStudioMap:Map<number, string> = new Map()

  constructor(private service:GameApiService) { }

  ngOnInit(): void {
    this.gameList$ = this.service.getGamesList();
    this.gameCategoryList$ = this.service.getCategoryList();
    this.gameStudioList$ = this.service.getStudioList();
    this.refreshGameCategoryMap();
    this.refreshGameStudioMap();
  }

// Variables (properties)
modalTitle: string = '';
activateAddEditGameComponent:boolean = false;
game:any;

modalAdd(){
  this.game = {
    id:0,
    name:null,
    description:null,
    gameCategoryId:null,
    gameStudioId:null
  }
  this.modalTitle = "Add Game";
  this.activateAddEditGameComponent = true;
}

modalEdit(item:any){
  this.game = item;
  this.modalTitle = "Edit Game";
  this.activateAddEditGameComponent = true;
}

modalDelete(item:any){
  if(confirm(`Are you sure you want to detele game ${item.id}`)){
    this.service.deleteGames(item.id).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-modal-close');
      if(closeModalBtn){
        closeModalBtn.click();
      }

      var showDeleteSuccess = document.getElementById('delete-success-alert');
      if(showDeleteSuccess){
        showDeleteSuccess.style.display = "block";
      }
      setTimeout(function(){
        if(showDeleteSuccess){
          showDeleteSuccess.style.display = "none"
        }
      },4000);
      this.gameList$ = this.service.getGamesList();
    })
  }
}

modalClose(){
  this.activateAddEditGameComponent = false;
  this.gameList$ = this.service.getGamesList();
}

  refreshGameCategoryMap(){
    this.service.getCategoryList().subscribe(data => {
      this.gameCategoryList = data;
      for(let i = 0; i < data.length; i++){
        this.gameCategoryMap.set(this.gameCategoryList[i].id, this.gameCategoryList[i].categoryName);
      }
    })
  }


  refreshGameStudioMap(){
    this.service.getStudioList().subscribe(data => {
      this.gameStudioList = data;
      for(let i = 0; i < data.length; i++){
        this.gameStudioMap.set(this.gameStudioList[i].id, this.gameStudioList[i].studioName);
      }
    })
  }
  

}
