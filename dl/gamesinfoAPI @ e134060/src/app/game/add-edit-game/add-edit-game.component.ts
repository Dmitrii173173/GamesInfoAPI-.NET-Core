import { Component,Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { GameApiService } from 'src/app/game-api.service';
@Component({
  selector: 'app-add-edit-game',
  templateUrl: './add-edit-game.component.html',
  styleUrls: ['./add-edit-game.component.css']
})
export class AddEditGameComponent implements OnInit {

  gameList$!:Observable<any[]>;
  gameCategoryList$!:Observable<any[]>;
  gameStudioList$!:Observable<any[]>;

  constructor(private service:GameApiService) { }

 
  @Input() game:any;
  id: number = 0;
  gameName:string = "";
  gameDescription:string = "";
  gameCategoryId!:number;
  gameStudioId!:number;

  ngOnInit(): void {
    this.id = this.game.id;
    this.gameName = this.game.gameName;
    this.gameDescription = this.game.gameDescription;
    this.gameCategoryId = this.game.gameCategoryId;
    this.gameStudioId = this.game.gameStudioId;
    this.gameStudioList$ = this.service.getStudioList();
    this.gameCategoryList$ = this.service.getCategoryList();
    this.gameList$ = this.service.getGamesList();
  }

  addGame(){
    var game = {
      gameName:this.gameName,
      gameDescription:this.gameDescription,
      gameCategoryId:this.gameCategoryId,
      gameStudioId:this.gameStudioId
    }
    this.service.addGames(game).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-modal-close');
      if(closeModalBtn){
        closeModalBtn.click();
      }

      var showAddSuccess = document.getElementById('add-success-alert');
      if(showAddSuccess){
        showAddSuccess.style.display = "block";
      }
      setTimeout(function(){
        if(showAddSuccess){
          showAddSuccess.style.display = "none"
        }
      },4000);
    })
  }
  
  updateGames(){
    var game = {
      id:this.id,
      gameName:this.gameName,
      gameDescription:this.gameDescription,
      gameCategoryId:this.gameCategoryId,
      gameStudioId:this.gameStudioId
    }
    var id:number = this.id;
    this.service.updateGames(id, game).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-modal-close');
      if(closeModalBtn){
        closeModalBtn.click();
      }

      var showUpdateSuccess = document.getElementById('update-success-alert');
      if(showUpdateSuccess){
        showUpdateSuccess.style.display = "block";
      }
      setTimeout(function(){
        if(showUpdateSuccess){
          showUpdateSuccess.style.display = "none"
        }
      },4000);
    })
  }
}
