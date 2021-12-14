import { Cheese } from "./Cheese";

export const URL_BASE = process.env.NODE_ENV === 'development'
    ? 'http://localhost:5002/'
    : 'http://localhost/';

export const API_BASE = URL_BASE;
export const IMAGES_BASE = URL_BASE + '/images/';

export async function fetchCheeses(): Promise<Cheese[]> {
    try {
        var response = await fetch(API_BASE + 'cheeses');
        var data = await response.json() as Promise<Cheese[]>;

        return data;
    }
    catch (error)
    {
        console.log('Error fetching cheeses', error)
        return [];
    }
}