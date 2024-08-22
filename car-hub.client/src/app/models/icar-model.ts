export interface ICarModel {
  id?: number;
  brand: CarBrand | null;
  class: CarClass;
  modelName: string;
  modelCode: string;
  description: string;
  features: string;
  price: number;
  dateOfManufacturing: Date| null;
  active: boolean;
  sortOrder: number;
  imageUrls?: string[];
}
export enum CarBrand {
  None = '',
  Audi = 'Audi',
  Jaguar = 'Jaguar',
  LandRover = 'Land Rover',
  Renault = 'Renault'
}

export enum CarClass {
  None = '',
  AClass = 'A-Class',
  BClass = 'B-Class',
  CClass = 'C-Class'
}
