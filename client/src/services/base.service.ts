import { throwError } from 'rxjs';

export abstract class BaseService {

  protected readonly api = 'http://localhost:5000/api';

  protected handleError(error: any) {
    const applicationError = error.headers['Application-Error'];

    if (applicationError) {
        return throwError(applicationError);
    }

    let modelStateErrors: any = '';

    if (error.data) {
      for (const key in error.data) {
        if (error.data[key]) {
          modelStateErrors += error.data[key] + '\n';
        }
      }
    }

    modelStateErrors = modelStateErrors = '' ? null : modelStateErrors;
    return throwError(modelStateErrors || 'Server error');
  }
}
