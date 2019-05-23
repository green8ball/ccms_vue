import axios from 'axios';
import { BaseService } from './base.service';

class DashboardService extends BaseService {

    nstance = DashboardService;

    constructor() {  super(); }

    get Instance() {
       // Do you need arguments? Make it a regular method instead.
       return this.instance || (this.instance = new this());
    }

    getHomeDetails() {
        return axios.get(`${this.api}/dashboard/home`);
    }
}

// export a singleton instance in the global namespace
export const dashboardService = DashboardService.Instance;