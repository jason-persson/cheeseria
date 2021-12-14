import React, { useEffect, useState } from 'react';
import { Cheese } from './Cheese';
import { fetchCheesePrice, IMAGES_BASE } from './api';
import './bulma.css';

type Props = {
    cheese: Cheese
}

function CheeseCard({ cheese }: Props) {

    const [cheeseKg, setCheeseKg] = useState(0);
    const [totalCost, setTotalCost] = useState(0);

    useEffect(() => {
        fetchCheesePrice(cheese.id, cheeseKg)
            .then(cost => setTotalCost(cost.totalPrice));
    }, [cheese.id, cheeseKg]);

    const onAmountChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const kgs = Number.parseFloat(e.target.value);
        if (!isNaN(kgs)) {
            setCheeseKg(kgs)
        }
    }

    return (
        <div className='card my-4'>
            <header className='card-header has-background-dark'>
                <p className='card-header-title has-text-light'>{cheese.name}</p>
            </header>
            <div className='card-content'>
                <p>Color: {cheese.color}</p>
                <p>Price ${cheese.pricePerKg.toFixed(2)}</p>
                <div className='level'>
                    <div className='level-left'>
                        <p>Amount to buy (kg)</p>
                        <input type="number" min="0" max="100" step="0.25" onChange={onAmountChange} value={cheeseKg}></input>
                    </div>
                    <div className='level-right'>
                        <p className='has-background-info-light'>Total cost: ${`${totalCost.toFixed(2)}`}</p>
                    </div>
                </div>
            </div>
            <div className='card-image'>
                <figure className='image'>
                    <img
                        src={`${IMAGES_BASE}${cheese.picture}`}
                        alt={`${cheese.name}`}></img>
                </figure>
            </div>
        </div>
    )
}

export default CheeseCard;