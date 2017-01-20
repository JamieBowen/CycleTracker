export interface IBikePart
{
    id: number;
    bikeId: number;
    partId: number;
    installedDate: Date;
    installedBikeMileage: number;
    replacedDate: Date;
    replacedBikeMileage: number;
    accruedMileage: number;
    purchasePrice: number;
    purchaseRetailer: string;
}