import { Photo } from './Photo';

export interface User {
    id: number;
    username: string;
    knownAs: string;
    age: number;
    gender: string;
    created: string;
    lastActive: string;
    city: string;
    country: string;
    interest?: string;
    introduction?: string;
    lookingFor?: string;
    photoUrl: string;
    photos?: Photo[];
}
