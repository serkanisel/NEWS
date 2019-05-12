import { Photo } from './photo';

export interface User {
  Id: number;
  username: string;
  name: string;
  knowns: string;
  age: number;
  gender: string;
  created: Date;
  lastActive: Date;
  photoUrl: string;
  city: string;
  country: string;
  Interests?: string;
  Introduction?: string;
  lookingFor?: string;
  photos?: Photo[];

}
