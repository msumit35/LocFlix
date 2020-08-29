import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ROOT_API } from '../global.consts';
import { LocflixService } from '../services/locflix.service';

@Component({
  selector: 'app-video-dialog',
  templateUrl: 'video.dialog.html',
  styleUrls: ['video.dialog.css']
})
export class VideoDialog implements OnInit {
  fullPath = this.locflixService.getRootPathValue() + '/media/play?f=';
  filePath: string;
  type: string;

  constructor(
    public dialogRef: MatDialogRef<VideoDialog>,
    @Inject(MAT_DIALOG_DATA) public data: any, private locflixService: LocflixService) {
    
      this.filePath = this.fullPath + data;
      this.type = 'video/' + data.split('.')[1];

      dialogRef.beforeClosed().subscribe(result => {
          console.log('video dialog closed', result);
            document.getElementById('mainPlayer').setAttribute('src', '');
        });
  }

  ngOnInit(){
    document.getElementById('mainPlayer').requestFullscreen();
  }

  // closeConn(videoMedia) {
  //   console.log('Video Media', videoMedia);
  //   videoMedia.setAttribute('src', '');
  // }

  closeDialog(data: any = null) {
    this.dialogRef.close(data);
  }

}