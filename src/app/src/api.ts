import { Cheese } from "./Cheese";
import { CheeseCost } from "./CheeseCost";

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

export async function fetchCheesePrice(id: number, kgToBuy: number): Promise<CheeseCost> {
    try {
        const url = `${API_BASE}cheeses/${id}/price?` + new URLSearchParams({ 'kgToBuy': kgToBuy.toString() });
        var response = await fetch(url);
        var data = await response.json() as Promise<CheeseCost>;

        return data;
    }
    catch (error)
    {
        console.log('Error fetching cheeses', error)
        // If there's an error return a "null" object
        return {
            id: 0,
            kgToBuy: 0,
            totalPrice: 0
        };
    }
}