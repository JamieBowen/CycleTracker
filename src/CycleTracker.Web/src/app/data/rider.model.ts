import { IBike } from './bike.model';

export interface IRider {
    id: number;
    email: string;
    lastName: string;
    firstName: string;
    
    bikes: IBike[];
}