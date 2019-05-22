import axios from 'axios';
import { BaseService } from './base.service';
import { Observable } from 'rxjs/Rx';

class AuthService extends BaseService {

    instance = AuthService;

    constructor() {  super(); }

    get Instance() {
        return this.instance || (this.instance = new this());
    }

    login(credentials) {
        return Observable.fromPromise(axios.post(`{$this.api}/auth/login`, credentials))
        .map(res => res.data.auth_token)
        .catch(error => this.handleError(error.response));
    }
}

export const authService = AuthService.Instance;