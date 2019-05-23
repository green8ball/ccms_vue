import axios from 'axios';
import { BaseService } from '/base.service';
import { Observable } from 'rxjs/Rx';

class ProfileService extends BaseService {
    
    instance = ProfileService;

    constructor() {  super(); }

    get Instance() {
        return this.instance || (this.instance = new this());
    }

    get() {
        return Observable.fromPromise(axios.get(`${this.api}/profile/me`))
        .map(res => res.data)
        .catch(error => this.handleError(error.response));
    }
}

export const ProfileService = ProfileService.Instance;