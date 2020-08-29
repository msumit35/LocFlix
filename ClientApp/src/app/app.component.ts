import { Component } from '@angular/core';
import { LocflixService } from './services/locflix.service';
import { ROOT_API } from './global.consts';
import { MatDialog } from '../../node_modules/@angular/material/dialog';
import { VideoDialog } from './video-dialog/video.dialog';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  folders = [];
  files = [];
  currentPath = '/';

  constructor(private locFlixService: LocflixService, private dialog: MatDialog) {
    this.locFlixService.getRootPath()
    .subscribe((res: any) => {
      this.locFlixService.setRootPathValue(res.RootPath);
      this.getFolders();
    });
  }

  folderClick(path: string) {
    this.currentPath = path;
    this.getFolders();
  }

  getFolders() {
    this.locFlixService.getFolders(this.currentPath)
    .subscribe((res: any) => {
        this.folders = res.Folders;
        this.files = res.Files;
    }, (err) => {
        console.log(err);
    });
  }

  openVideoDialog(path: string): void {
    const dialogRef = this.dialog.open(VideoDialog, {
      data: path
    });
  }
}
