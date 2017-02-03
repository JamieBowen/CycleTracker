import { IPart } from './part.model';
import { IBike } from './bike.model';

export interface IBikePart
{
    id: number;
    partId: number;
    installedDate: Date;
    installedBikeMileage: number;
    replacedDate: Date;
    replacedBikeMileage: number;
    accruedMileage: number;
    purchasePrice: number;
    purchaseRetailer: string;

    part: IPart;
    bike: IBike;
}