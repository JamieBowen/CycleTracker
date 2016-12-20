export interface IPart
{
    partId: number;
    bikeId: number;
    partName: string;
    partDescription: string;
    installedOn: Date;
    installedMileage: number;
    replacedOn: Date;
    replacedMileage: number;
    accruedMileage: number;
    retailer: string;
}