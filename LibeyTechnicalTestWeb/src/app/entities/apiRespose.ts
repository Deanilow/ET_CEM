import { IDocumentType } from "./DocumentType";
import { LibeyUser } from "./libeyuser";
import { Province } from "./Province";
import { Region } from "./Region";
import { Ubigeo } from "./Ubigeo";

export interface ApiResponse<T> {
  data: T;
  message: string;
  status: boolean;
}


export type LibeyUsersApiResponse = ApiResponse<LibeyUser[]>;
export type LibeyUserApiResponse = ApiResponse<LibeyUser>;
export type DeleteApiResponse = ApiResponse<Boolean>;

export type DocumentTypesApiResponse = ApiResponse<IDocumentType[]>;
export type RegionsApiResponse = ApiResponse<Region[]>;
export type ProvincesApiResponse = ApiResponse<Province[]>;
export type UbigeosApiResponse = ApiResponse<Ubigeo[]>;

