import { Injectable, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ROOT_API } from "../global.consts";
import { BehaviorSubject, Observable } from "../../../node_modules/rxjs";

@Injectable()
export class LocflixService {
    urlHeirarchy = '/Heirarchy';
    rootPathSubject = new BehaviorSubject<string>('');
    constructor(private _http: HttpClient) {
    }

    getRootPathValue() {
        return this.rootPathSubject.value;
    }

    setRootPathValue(value: string) {
        this.rootPathSubject.next(value);
    }

    getFolders(path: string) {
        return this._http.get(this.getRootPathValue() + this.urlHeirarchy + '?path=' + path);
    }

    getRootPath() {
        return this._http.get('/assets/root-path.json');
    }
}