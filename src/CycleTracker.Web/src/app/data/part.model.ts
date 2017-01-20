import { PartType } from './enums';

export interface IPart
{
    id: number;
    manufacturer: string;
    model: string;
    description: string;
    price: number;
    upcCode: string;
    partType: PartType;
}