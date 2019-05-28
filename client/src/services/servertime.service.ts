import axios from 'axios';
import { BaseService } from './base.service';

const auth = {headers: { Authorization: 'bearer ' + localStorage.getItem('auth-token')}};
class ServerTimeService extends BaseService {

    private static instance: ServerTimeService;

    private constructor() {  super(); }

    public static get Instance() {
       // Do you need arguments? Make it a regular method instead.
       return this.instance || (this.instance = new this());
    }

    public get(): Promise<any> {
        return axios.get(`${this.api}/servertime/get`, auth);
    }
}

// export a singleton instance in the global namespace
export const serverTimeService = ServerTimeService.Instance;
