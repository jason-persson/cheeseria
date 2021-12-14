import React from 'react';
import { Cheese } from './Cheese';
import { IMAGES_BASE } from './api';
import './bulma.css';

type Props = {
    cheese: Cheese
}

function CheeseCard({ cheese }: Props) {
    return (
        <div className='card my-4'>
            <header className='card-header has-background-dark'>
                <p className='card-header-title has-text-light'>{cheese.name}</p>
            </header>
            <div className='card-content'>
                <p>Color: {cheese.color}</p>
                <p>Price ${cheese.pricePerKg.toFixed(2)}</p>
            </div>
            <div className='card-image'>
                <figure className='image'>
                    <img src={`${IMAGES_BASE}${cheese.picture}`}></img>
                </figure>
            </div>
        </div>
    )
}

export default CheeseCard;