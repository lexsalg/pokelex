import { Injectable } from '@angular/core';

import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class CommonService {

    private _notifications = new BehaviorSubject<[]>([]);

    private _loading = new BehaviorSubject<boolean>(false);

    /*****REACTIVO****************************************** */
    get isLoading(): boolean {
        return this._loading.value;
    }

    get loading(): Observable<boolean> {
        return this._loading.asObservable();
    }

    setLoading(loading: boolean) {
        this._loading.next(loading);
    }

    /***************************************************************************** */


    get ntfs(): [] {
        return this._notifications.value;
    }

    getNtfs(): Observable<[]> {
        return this._notifications.asObservable();
    }

    setNtfs(notification: []) {
        this._notifications.next(notification);
        if (document.getElementById('ntf-global'))
            document.getElementById('ntf-global').scrollIntoView({ behavior: 'smooth' })
    }

}