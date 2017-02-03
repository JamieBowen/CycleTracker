import { IBikePart } from './bikePart.model';

export interface IBike {
    id: number;
    make: string;
    model: string;
    year: number;
    trim: string;
    colors: string;
    mileage: number;
    bikeParts: IBikePart[];
};